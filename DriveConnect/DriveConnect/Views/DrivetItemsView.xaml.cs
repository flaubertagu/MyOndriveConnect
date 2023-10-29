using DriveConnect.Helpers;
using DriveConnect.OneDriveClass;
using DriveConnect.Services;
using Newtonsoft.Json.Linq;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DrivetItemsView : ContentView
    {
        public DrivetItemsView()
        {
            InitializeComponent();
            AlertOnDownload.IsToggled = Settings.OneDriveAlertDownload;
            BindingContext = App.OneDriveConnector;
        }

        void MultipleSelection_Toggled(object sender, ToggledEventArgs e)
        {
            bool selectionFrameIsVisible = App.OneDriveConnector.SelectionFrameIsVisible;
            if (!selectionFrameIsVisible)
            {
                double heigth = DriveItemContent.Height;
                App.OneDriveConnector.SetSelectionFrame(true, heigth);
                App.OneDriveConnector.ConfirmSelectionIsEnable = false;
            }
            else
            {
                App.OneDriveConnector.SetSelectionFrame(false, 0);
                App.OneDriveConnector.SelectedDriveItem.Clear();
            }
        }

        void AlertOnDownload_Toggled(object sender, ToggledEventArgs e)
        {
            Settings.OneDriveAlertDownload = e.Value;
        }

        private void OnDriveItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (((CollectionView)sender).SelectedItem == null)
                    return;

                try
                {
                    var item = (DriveItem)((CollectionView)sender).SelectedItem;
                    string itemName = item.Name;
                    if (item.IsAFile)
                    {
                        if (App.OneDriveConnector.SelectionFrameIsVisible)
                        {
                            if (App.OneDriveConnector.SelectedDriveItem.Contains(item))
                            {
                                await ShowDisplayAlert.SimpleTranslated("", "Already in the list", "Close");
                                return;
                            }
                            App.OneDriveConnector.AddRemoveFileSelection(item);
                        }
                        else
                        {
                            bool alert = Settings.OneDriveAlertDownload;
                            bool proceed;
                            if (alert)
                                proceed = await ShowDisplayAlert.BoolTranslated("Do you", "Want to download the file", "Yes", "No");
                            else
                                proceed = true;

                            if (proceed)
                            {
                                string url = item.DownloadURL;
                                await HandleDriveItems.DownloadFile(url, itemName);
                            }
                        }
                    }
                    else
                    {
                        #region Check if folder have children
                        string folder = item.Folder;
                        JObject folderReference = JObject.Parse(folder);
                        int childcount = int.Parse(folderReference["childCount"].ToString());
                        if (childcount == 0)
                        {
                            await ShowDisplayAlert.SimpleTranslated("No children", "", "Close");
                            return;
                        }
                        #endregion

                        #region Navigate to child
                        string id = item.Id;
                        string parentReference = item.ParentReference;
                        JObject reference = JObject.Parse(parentReference);
                        string driveId = reference["driveId"].ToString();
                        string specific = App.OneDriveConnector.GetSpecific(DriveConstants.DriveChildren);
                        string urlBase = App.OneDriveConnector.GetDriveUrl(specific);
                        if (string.IsNullOrEmpty(urlBase))
                        {
                            await ShowDisplayAlert.SimpleTranslated("Error", "Base url cannot be retrieved", "Close");
                            return;
                        }

                        string url = urlBase.Replace(DriveConstants.DriveId, driveId)
                        .Replace(DriveConstants.ItemId, id);

                        App.OneDriveConnector.FolderPath = itemName;
                        var oneDriveTokenResult = await App.OneDriveConnector.GetOneDriveAccessToken();
                        bool addNav = true;
                        await App.OneDriveConnector.GetAllDriveItems(url, oneDriveTokenResult, addNav);
                        #endregion
                    }
                }
                catch (Exception err)
                {
                    await ShowDisplayAlert.Error("Error", err.Message, "Close");
                    //await CrashHandler.TrackError(err);
                }

                ((CollectionView)sender).SelectedItem = null;
            });
        }

        private void RemoveDriveItemSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if (((CollectionView)sender).SelectedItem == null)
                    return;

                var item = (DriveItem)((CollectionView)sender).SelectedItem;
                App.OneDriveConnector.AddRemoveFileSelection(item);

                ((CollectionView)sender).SelectedItem = null;
            });
        }
    }
}