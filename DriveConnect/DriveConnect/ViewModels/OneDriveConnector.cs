using DriveConnect.Helpers;
using DriveConnect.OneDriveClass;
using DriveConnect.Services;
using DriveConnect.Views;
using Microsoft.Identity.Client;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace DriveConnect.ViewModels
{
    public class OneDriveConnector : INotifyPropertyChanged
    {
        public static string SignIn { get; } = "Sign in";
        public static string SignOut { get; } = "Sign out";
        public OneDriveConnector()
        {
            SignInSignOut = new Command(async () => await OnSignInSignOut());
            GetMyFolders = new Command(async () => await GetMyDriveRoot());
            GetSitesList = new Command(async () => await GetGroupSitesLists());
            PreviousNav = new Command(async () => await GoToPreviousNav());
            ConfirmSelection = new Command(async () => await FinalizeFileSelection());

            SetIEnumerableAccounts();
            SetOnedriveConnector();
        }

        #region Common functions
        private async void SetIEnumerableAccounts()
        {
            Accounts = await App.PCA.GetAccountsAsync().ConfigureAwait(false);
        }

        public async void SetOnedriveConnector()
        {
            var userInfo = await Settings.GetOneDriveUserInfo();
            if (userInfo != null)
            {
                DateTimeOffset now = DateTimeOffset.UtcNow;
                DateTimeOffset tokenExipration = userInfo.TokenExpiration;
                double delayExpiration = (tokenExipration - now).TotalMinutes;

                if (!string.IsNullOrEmpty(userInfo.AccessToken) && delayExpiration > 10)
                {
                    UserHasToken = true;
                    SignInText = SignOut;
                }
                else
                    SetSignInIsVisible();
            }
            else
                SetSignInIsVisible();
        }

        private void SetSignInIsVisible()
        {
            UserHasToken = false;
            SignInText = SignIn;
            DriveItemsList = new List<DriveItem>();
            DriveItems = new ObservableCollection<DriveItem>();
            MyOneDriveNav.Clear();
            SetGetRoot();
        }

        private async void DeleteOneDriveInfo()
        {
            await AppSecrets.DeleteOneDriveUserInfo();
        }

        public async Task<Response> GetOneDriveAccessToken()
        {
            Response response = new Response() { Success = false };
            var userInfo = await Settings.GetOneDriveUserInfo();
            string accessToken = userInfo.AccessToken;
            if (string.IsNullOrEmpty(accessToken))
                return response;

            response.Success = true;
            response.Message = accessToken;
            return response;
        }

        private void CheckAccessToken(Response oneDriveTokenResult)
        {
            if (!oneDriveTokenResult.Success)
                UnAuthorized = true;
        }
        #endregion

        #region Common MVVM
        private string _SignInText = SignIn;
        public string SignInText
        {
            get { return _SignInText; }
            set { _SignInText = value; OnPropertyChanged(nameof(SignInText)); }
        }

        private bool _UserHasToken = false;
        public bool UserHasToken
        {
            get { return _UserHasToken; }
            set { _UserHasToken = value; OnPropertyChanged(nameof(UserHasToken)); }
        }

        private bool _UnAuthorized = false;
        public bool UnAuthorized
        {
            get { return _UnAuthorized; }
            set 
            { 
                _UnAuthorized = value; 
                OnPropertyChanged(nameof(UnAuthorized));
                if (value == true)
                    OnSignOut();
            }
        }

        public void ResetFramesVisibility()
        {
            DriveItemListIsVisible = false;
            SiteListIsVisible = false;
            TryHideCreateFrame();
        }

        private bool _DriveItemListIsVisible = false;
        public bool DriveItemListIsVisible
        {
            get { return _DriveItemListIsVisible; }
            set 
            { 
                _DriveItemListIsVisible = value;
                OnPropertyChanged(nameof(DriveItemListIsVisible)); 
            }
        }

        private string _FailedMessage = string.Empty;
        public string FailedMessage
        {
            get => _FailedMessage;
            set
            {
                _FailedMessage = value;
                OnPropertyChanged(nameof(FailedMessage));
            }
        }

        private bool _SiteListIsVisible = false;
        public bool SiteListIsVisible
        {
            get { return _SiteListIsVisible; }
            set 
            { 
                _SiteListIsVisible = value;
                OnPropertyChanged(nameof(SiteListIsVisible)); 
            }
        }
        #endregion

        #region OneDrive SignIn and SignOut
        public IEnumerable<IAccount> Accounts;
        public ICommand SignInSignOut { get; private set; }
        public async Task OnSignInSignOut()
        {
            try
            {
                if (SignInText == SignIn)
                    await OnSignIn();
                else
                    OnSignOut();
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await ShowDisplayAlert.Error("Authentication failed. See exception message for details: ", ex.Message, "Dismiss");
                });
            }
        }

        private async Task OnSignIn()
        {
            AuthenticationResult authResult = null;
            try
            {
                IAccount firstAccount = Accounts.FirstOrDefault();
                authResult = await App.PCA.AcquireTokenSilent(Settings.Scopes, firstAccount)
                                          .ExecuteAsync()
                                          .ConfigureAwait(false);
            }
            catch (MsalUiRequiredException)
            {
                try
                {
                    var builder = App.PCA.AcquireTokenInteractive(Settings.Scopes)
                                         .WithParentActivityOrWindow(Settings.ParentWindow);

                    if (Device.RuntimePlatform != "UWP")
                    {
                        // on Android and iOS, prefer to use the system browser, which does not exist on UWP
                        SystemWebViewOptions systemWebViewOptions = new SystemWebViewOptions()
                        {
                            iOSHidePrivacyPrompt = true,
                        };

                        builder.WithSystemWebViewOptions(systemWebViewOptions);
                        builder.WithUseEmbeddedWebView(false);
                    }

                    authResult = await builder.ExecuteAsync().ConfigureAwait(false);
                }
                catch (Exception ex2)
                {
                    Device.BeginInvokeOnMainThread(async () =>
                    {
                        await ShowDisplayAlert.Error("Acquire token interactive failed. See exception message for details: ", ex2.Message, "Dismiss");
                    });
                }
            }

            if (authResult != null)
            {
                var content = await GetHttpContentWithTokenAsync(authResult.AccessToken);
                string idToken = authResult.IdToken;
                string accessToken = authResult.AccessToken;
                DateTimeOffset tokenExpiration = authResult.ExpiresOn.UtcDateTime;
                await UpdateUserContent(content, idToken, accessToken, tokenExpiration);
                UserHasToken = true;
            }
            else
                UserHasToken = false;
        }

        private async void OnSignOut()
        {
            while (Accounts.Any())
            {
                await App.PCA.RemoveAsync(Accounts.FirstOrDefault()).ConfigureAwait(false);
                Accounts = await App.PCA.GetAccountsAsync().ConfigureAwait(false);
            }
            DeleteOneDriveInfo();
            SetSignInIsVisible();
            SignInText = SignIn;
            ResetFramesVisibility();
            DriveItems.Clear();
        }

        private async Task UpdateUserContent(string content, string idToken, string accessToken, DateTimeOffset tokenExpiration)
        {
            if (!string.IsNullOrEmpty(content))
            {
                JObject user = JObject.Parse(content);

                string displayName = user["displayName"].ToString();
                string givenName = user["givenName"].ToString();
                string id = user["id"].ToString();
                string surname = user["surname"].ToString();
                string userPrincipalName = user["userPrincipalName"].ToString();

                OneDriveUserInfo info = new OneDriveUserInfo()
                {
                    DisplayName = displayName,
                    GivenName = givenName,
                    Id = id,
                    Surname = surname,
                    UserPrincipalName = userPrincipalName,
                    IdToken = idToken,
                    AccessToken = accessToken,
                    TokenExpiration = tokenExpiration
                };
                await Settings.SetOneDriveUserInfo(info);

                SignInText = SignOut;
            }
        }

        public async Task<string> GetHttpContentWithTokenAsync(string token)
        {
            try
            {
                HttpClient client = new HttpClient();
                HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Get, "https://graph.microsoft.com/v1.0/me");
                message.Headers.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
                HttpResponseMessage response = await client.SendAsync(message).ConfigureAwait(false);
                string responseString = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                return responseString;
            }
            catch (Exception ex)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await ShowDisplayAlert.Error("API call to graph failed: ", ex.Message, "Dismiss").ConfigureAwait(false);
                });
                return ex.ToString();
            }
        }
        #endregion

        #region Drive Root functions
        private string _DriveType = string.Empty;
        public string DriveType
        {
            get { return _DriveType; }
            set { _DriveType = value; OnPropertyChanged(nameof(DriveType)); }
        }

        private bool _CreateFrameIsVisible = false;
        public bool CreateFrameIsVisible
        {
            get => _CreateFrameIsVisible;
            set { _CreateFrameIsVisible = value; OnPropertyChanged(nameof(CreateFrameIsVisible)); }
        }

        private bool TryHideCreateFrame()
        {
            if (CreateFrameIsVisible)
            {
                CreateFrameIsVisible = false;
                return true;
            }
            return false;
        }

        public ICommand GetMyFolders { get; private set; }
        public async Task GetMyDriveRoot()
        {
            MyOneDriveNav.Clear();
            ResetFramesVisibility();
            DriveType = DriveConstants.MyDrive;
            bool addNav = true;
            bool success = await ExecuteDrive(DriveConstants.OneDriveRoot, addNav);
            if (success)
                DriveItemListIsVisible = true;
        }

        public async Task GetSiteDriveRoot()
        {
            MyOneDriveNav.Clear();
            ResetFramesVisibility();
            DriveType = DriveConstants.SitesDrive;
            bool addNav = true;
            string siteId = GetSiteId();
            string specific = $"{siteId}{DriveConstants.OneDriveRoot}";
            bool success = await ExecuteDrive(specific, addNav);
            if (success)
                DriveItemListIsVisible = true;
        }

        public string GetSpecific(string endUrl)
        {
            string url = string.Empty;
            string driveType = DriveType;
            if (driveType == DriveConstants.MyDrive)
            {
                url = endUrl;
            }
            else if (driveType == DriveConstants.SitesDrive)
            {
                string siteId = GetSiteId();
                url = $"{siteId}/{endUrl}";
            }
            return url;
        }

        public string GetSiteId()
        {
            string id = SiteSelected.Id;
            string siteId = "{" + id + "}";
            return siteId;
        }

        private async Task<bool> ExecuteDrive(string specific, bool addNav)
        {
            var oneDriveTokenResult = await GetOneDriveAccessToken();
            string url = GetDriveUrl(specific);
            return await GetAllDriveItems(url, oneDriveTokenResult, addNav);
        }

        public string GetDriveUrl(string specific)
        {
            string url = $"{DriveConstants.DriveUrl}{DriveType}";
            if (!string.IsNullOrEmpty(specific))
                return $"{url}{specific}";
            return url;
        }
        #endregion

        #region Drive sites functions
        public ICommand GetSitesList { get; private set; }
        public async Task GetGroupSitesLists()
        {
            try
            {
                ResetFramesVisibility();
                DriveType = DriveConstants.SitesDrive;
                var oneDriveTokenResult = await GetOneDriveAccessToken();

                CheckAccessToken(oneDriveTokenResult);
                if (UnAuthorized) return;

                string url = GetDriveUrl(DriveConstants.SearchSites);
                string accessToken = oneDriveTokenResult.Message;

                var sites = await GetDriveSitesList(url, accessToken);
                if (sites.Any())
                {
                    DriveSiteList = new ObservableCollection<DriveSite>(sites.ToList());
                    SiteListIsVisible = true;
                }
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.Error("Error", err.Message, "Close");
                //await CrashHandler.TrackError(err);
            }
        }

        #endregion

        #region MyOneDrive nav functions
        public string FolderPath { get; set; }
        private bool _CanPrevious = false;
        public bool CanPrevious
        {
            get { return _CanPrevious; }
            set { _CanPrevious = value; OnPropertyChanged(nameof(CanPrevious)); }
        }

        public List<DriveNav> MyOneDriveNav { get; set; } = new List<DriveNav>();
        public ICommand PreviousNav { get; private set; }
        public async Task GoToPreviousNav()
        {
            RemoveLastNav_Me();
            DriveNav lastNav = GetLastNav();
            string url = lastNav.Url;
            var oneDriveTokenResult = await GetOneDriveAccessToken();
            bool addNav = false;
            await GetAllDriveItems(url, oneDriveTokenResult, addNav);
        }

        public void AddNav_Me(DriveNav nav)
        {
            MyOneDriveNav.Add(nav);
            SetGetRoot();
        }

        private void RemoveLastNav_Me()
        {
            int rowsCount = MyOneDriveNav.Count;
            if (rowsCount > 1)
                MyOneDriveNav.RemoveAt(rowsCount - 1);
            SetGetRoot();
        }

        public DriveNav GetLastNav()
        {
            return MyOneDriveNav.LastOrDefault();
        }

        private void SetGetRoot()
        {
            if (MyOneDriveNav.Count > 1)
                CanPrevious = true;
            else
                CanPrevious = false;
        }
        #endregion

        #region Site Groups
        private DriveSite _SiteSelected = null;
        public DriveSite SiteSelected
        {
            get { return _SiteSelected; }
            set { _SiteSelected = value; OnPropertyChanged(nameof(SiteSelected)); }
        }

        private ObservableCollection<DriveSite> _DriveSiteList = new ObservableCollection<DriveSite>();
        public ObservableCollection<DriveSite> DriveSiteList
        {
            get => _DriveSiteList;
            set { _DriveSiteList = value; OnPropertyChanged(nameof(DriveSiteList)); }
        }

        public async Task<List<DriveSite>> GetDriveSitesList(string url, string accessToken)
        {
            List<DriveSite> responses = new List<DriveSite>();
            try
            {
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                };

                HttpClient httpClient = new HttpClient(httpClientHandler);
                AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", accessToken);
                httpClient.DefaultRequestHeaders.Authorization = token;
                var result = await httpClient.GetAsync(url);
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await ShowDisplayAlert.SimpleTranslated("Warning", result.ReasonPhrase, "Close");
                    return responses;
                }

                if (result.IsSuccessStatusCode)
                {
                    UnAuthorized = false;
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        JObject itemsResponse = JObject.Parse(content);
                        if (content.Contains("value"))
                        {
                            var value = itemsResponse["value"].ToString();

                            List<object> items = JsonConvert.DeserializeObject<List<object>>(value.Replace("\r\n", null));
                            foreach (var item in items)
                            {
                                try
                                {
                                    JObject itemJson = JObject.Parse(item.ToString());
                                    DriveSite driveItem = HandleDriveItems.ReturnDriveSite(itemJson);
                                    responses.Add(driveItem);
                                }
                                catch (Exception err)
                                {
                                    string error = err.Message;
                                }
                            }
                        }
                    }
                }
                else if (!result.IsSuccessStatusCode)
                {
#if DEBUG
                    string error = await result.Content.ReadAsStringAsync();
                    await ShowDisplayAlert.SimpleTranslated("Error", error, "Close");
#else
                    await ShowDisplayAlert.SimpleTranslated(result.ReasonPhrase, "", "Close");
#endif
                }
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.Error("Error", err.Message, "Close");
            }
            return responses;
        }
        #endregion

        #region Drive Items
        private bool _HasDriveItems = false;
        public bool HasDriveItems
        {
            get { return _HasDriveItems; }
            set { _HasDriveItems = value; OnPropertyChanged(nameof(HasDriveItems)); }
        }

        public List<DriveItem> DriveItemsList { get; set; } = new List<DriveItem>();
        private ObservableCollection<DriveItem> _DriveItems = new ObservableCollection<DriveItem>();
        public ObservableCollection<DriveItem> DriveItems
        {
            get { return _DriveItems; }
            set { _DriveItems = value; OnPropertyChanged(nameof(DriveItems)); SetHasDriveItems(); }
        }

        public async Task<bool> GetAllDriveItems(string url, Response oneDriveTokenResult, bool addNav)
        {
            CheckAccessToken(oneDriveTokenResult);
            if (UnAuthorized) return false;

            string accessToken = oneDriveTokenResult.Message;
            var response = await GetDriveItems(url, accessToken);
            if (UnAuthorized)
                return false;

            if (response.Count() == 0)
            {
                FailedMessage = "No items found";
                return false;
            }

            FailedMessage = string.Empty;
            DriveItemsList = response.ToList();
            SetDriveItemsList();
            if (addNav)
            {
                string path;
                if (MyOneDriveNav.Count == 0)
                    path =  DriveConstants.Root;
                else
                {
                    var lastnav = GetLastNav();
                    string folderpath = lastnav.FolderPath;
                    path = $"{folderpath}/{FolderPath}";
                }

                var nav = new DriveNav()
                {
                    Url = url,
                    FolderPath = path,
                };
                AddNav_Me(nav);
            }
            else
            {
                var nav = GetLastNav();
                string folderPath = nav.FolderPath;
                int count = folderPath.Count(x => x == '/');
                string[] path = folderPath.Split('/');
                string newPath = path[count];
            }

            return true;
        }

        public async Task<bool> RefreshDrivesItems(string url, Response oneDriveTokenResult)
        {
            CheckAccessToken(oneDriveTokenResult);
            if (UnAuthorized) return false;

            string accessToken = oneDriveTokenResult.Message;
            var response = await GetDriveItems(url, accessToken);
            if (UnAuthorized)
                return false;

            DriveItemsList = response.ToList();
            SetDriveItemsList();
            return true;
        }

        public async Task<List<DriveItem>> GetDriveItems(string url, string accessToken)
        {
            List<DriveItem> responses = new List<DriveItem>();
            try
            {
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                };

                HttpClient httpClient = new HttpClient(httpClientHandler);
                AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", accessToken);
                httpClient.DefaultRequestHeaders.Authorization = token;
                var result = await httpClient.GetAsync(url);
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await ShowDisplayAlert.SimpleTranslated("Warning", result.ReasonPhrase, "Close");
                    return responses;
                }

                if (result.IsSuccessStatusCode)
                {
                    UnAuthorized = false;
                    string content = await result.Content.ReadAsStringAsync();
                    if (content != null)
                    {
                        JObject itemsResponse = JObject.Parse(content);
                        var value = itemsResponse["value"].ToString();

                        List<object> items = JsonConvert.DeserializeObject<List<object>>(value.Replace("\r\n", null));
                        foreach (var item in items)
                        {
                            try
                            {

                                JObject itemJson = JObject.Parse(item.ToString());
                                DriveItem driveItem = HandleDriveItems.ReturnDriveItem(itemJson);
                                responses.Add(driveItem);
                            }
                            catch (Exception err)
                            {
                                string error = err.Message;
                            }
                        }
                    }
                }
                else if (!result.IsSuccessStatusCode)
                {
#if DEBUG
                    string error = await result.Content.ReadAsStringAsync();
                    await ShowDisplayAlert.SimpleTranslated("Error", error, "Close");
#else
                    await ShowDisplayAlert.SimpleTranslated(result.ReasonPhrase, "", "Close");
#endif
                }
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.Error("Error", err.Message, "Close");
            }
            return responses;
        }

        public void SetDriveItemsList()
        {
            DriveItems = new ObservableCollection<DriveItem>(DriveItemsList);
        }

        public void SetHasDriveItems()
        {
            if (DriveItems.Count > 0)
                HasDriveItems = true;
            else
                HasDriveItems = false;
        }
        #endregion

        #region File selection functions
        public const string SingleSelection = "Single selection";
        public const string MultipleSelection = "Multiple selection";
        public ICommand ConfirmSelection { get; private set; }
        private async Task FinalizeFileSelection()
        {
            DoNotIntegrate.CreateItemsTxt(SelectedDriveItem.ToList());
            SelectedDriveItem.Clear();
            SetSelectionFrame(false, 0);
            await Shell.Current.GoToAsync($"//{nameof(DriveItemsSelected)}");
        }

        private ObservableCollection<DriveItem> _SelectedDriveItem = new ObservableCollection<DriveItem>();
        public ObservableCollection<DriveItem> SelectedDriveItem
        {
            get { return _SelectedDriveItem; }
            set 
            {
                _SelectedDriveItem = value;
                OnPropertyChanged(nameof(SelectedDriveItem)); SetHasDriveItems(); 
            }
        }

        private bool _ConfirmSelectionIsEnable = false;
        public bool ConfirmSelectionIsEnable
        {
            get { return _ConfirmSelectionIsEnable; }
            set { _ConfirmSelectionIsEnable = value; OnPropertyChanged(nameof(ConfirmSelectionIsEnable)); }
        }

        public void AddRemoveFileSelection(DriveItem item)
        {
            if (!SelectedDriveItem.Contains(item))
            {
                var nav = GetLastNav();
                item.FolderPath = nav.FolderPath;
                SelectedDriveItem.Add(item);
            }
            else
                SelectedDriveItem.Remove(item);

            var selectedItems = SelectedDriveItem.ToList();
            if (selectedItems.Count > 0)
                ConfirmSelectionIsEnable = true;
            else
                ConfirmSelectionIsEnable = false;
        }

        public void SetSelectionFrame(bool isVisible, double heigth)
        {
            SelectionFrameIsVisible = isVisible;
            if (isVisible)
                SelectionTypeText = MultipleSelection;
            else
                SelectionTypeText = SingleSelection;

            if (heigth == 0)
                SelectionFrameHeigth = 10;
            else
                SelectionFrameHeigth = heigth * Decimal.ToDouble(Decimal.Divide(3, 7));
        }

        private bool _SelectionFrameIsVisible = false;
        public bool SelectionFrameIsVisible
        {
            get { return _SelectionFrameIsVisible; }
            set { _SelectionFrameIsVisible = value; OnPropertyChanged(nameof(SelectionFrameIsVisible)); }
        }

        private string _SelectionTypeText = SingleSelection;
        public string SelectionTypeText
        {
            get => _SelectionTypeText;
            set { _SelectionTypeText = value; OnPropertyChanged(nameof(SelectionTypeText)); }
        }

        private double _SelectionFrameHeigth = 10;
        public double SelectionFrameHeigth
        {
            get { return _SelectionFrameHeigth; }
            set { _SelectionFrameHeigth = value; OnPropertyChanged(nameof(SelectionFrameHeigth)); }
        }
        #endregion

        #region Files selected list
        //-------------- DO NOT INTEGRATE LIKE THIS --------------
        public void UpdateFileSelected(List<DriveItemInfo> list)
        {
            FilesSelected = new ObservableCollection<DriveItemInfo>(list.ToList());
        }
        //-------------- DO NOT INTEGRATE LIKE THIS --------------

        private ObservableCollection<DriveItemInfo> _FilesSelected = new ObservableCollection<DriveItemInfo>();
        public ObservableCollection<DriveItemInfo> FilesSelected
        {
            get { return _FilesSelected; }
            set { _FilesSelected = value; OnPropertyChanged(nameof(FilesSelected)); }
        }
        #endregion

        #region Search items
        private string _SearchDriveItem = string.Empty;
        public string SearchDriveItem
        {
            get => _SearchDriveItem;
            set
            {
                _SearchDriveItem = value;
                OnPropertyChanged(nameof(SearchDriveItem));
                ExecuteSearchDriveItem();
            }
        }

        private void ExecuteSearchDriveItem()
        {
            if (string.IsNullOrEmpty(SearchDriveItem))
            {
                SetDriveItemsList();
                return;
            }

            if (DriveItemsList != null && DriveItemsList.Count > 0)
            {
                var tempRecords = DriveItemsList.Where(x => x.Name.ToLower().Contains(_SearchDriveItem.ToLower()));
                var searchList = new ObservableCollection<DriveItem>();
                foreach (var item in tempRecords)
                {
                    searchList.Add(item);
                }
                DriveItems = searchList;
            }
        }
        #endregion

        #region Create - Upload functions
        public async Task UploadFile(string url, Response oneDriveTokenResult, Stream stream)
        {
            CheckAccessToken(oneDriveTokenResult);
            if (UnAuthorized) return;
            string accessToken = oneDriveTokenResult.Message;

            try
            {
                var httpClientHandler = new HttpClientHandler
                {
                    ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => { return true; }
                };

                HttpClient httpPut = new HttpClient(httpClientHandler);
                AuthenticationHeaderValue token = new AuthenticationHeaderValue("bearer", accessToken);
                httpPut.DefaultRequestHeaders.Authorization = token;

                httpPut.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                StreamContent streamContent = new StreamContent(stream);
                var result = await httpPut.PutAsync(url, streamContent);
                if (result.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                {
                    await ShowDisplayAlert.SimpleTranslated("Warning", result.ReasonPhrase, "Close");
                    return;
                }

                if (result.IsSuccessStatusCode)
                {
                    await ShowDisplayAlert.SimpleTranslated("", "Update sucessfull", "Close");
                    var nav = GetLastNav();
                    string lastnav = nav.Url;
                    await RefreshDrivesItems(lastnav, oneDriveTokenResult);
                }
                else if (!result.IsSuccessStatusCode)
                {
#if DEBUG
                    string error = await result.Content.ReadAsStringAsync();
                    await ShowDisplayAlert.SimpleTranslated("Error", error, "Close");
#else
                    await ShowDisplayAlert.SimpleTranslated(result.ReasonPhrase, "", "Close");
#endif
                }
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.Error("Error", err.Message, "Close");
            }
        }
        #endregion

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
