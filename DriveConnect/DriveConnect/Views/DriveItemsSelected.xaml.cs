using DriveConnect.Helpers;
using DriveConnect.OneDriveClass;
using DriveConnect.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DriveItemsSelected : ContentPage
    {
        public DriveItemsSelected()
        {
            InitializeComponent();
            BindingContext = App.OneDriveConnector;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var list = DoNotIntegrate.ExtractSelectedFiles();
            App.OneDriveConnector.UpdateFileSelected(list);
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            //DoNotIntegrate.DeleteItemsTxt();
            List<DriveItemInfo> list = new List<DriveItemInfo>();
            App.OneDriveConnector.UpdateFileSelected(list);
        }

        private async void DownloadFile_Clicked(object sender, EventArgs e)
        {
            try
            {
                Button button = sender as Button;
                Grid layout = (Grid)button.Parent;
                Label name = (Label)layout.Children[2];
                Label downloadUrl = (Label)layout.Children[3];
                string filename = name.Text;
                string url = downloadUrl.Text;
                await HandleDriveItems.DownloadFile(url, filename);
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.Error("Error", err.Message, "Close");
            }
        }

        private async void UpdateFile_Clicked(object sender, EventArgs e)
        {
            Button button = sender as Button;
            Grid layout = (Grid)button.Parent;
            Label name = (Label)layout.Children[2];
            Label idText = (Label)layout.Children[4];
            Label parent = (Label)layout.Children[5];
            string filename = name.Text;
            string id = idText.Text;
            string parentReference = parent.Text;

            //JObject reference = JObject.Parse(parentReference);
            //string urlBase = App.OneDriveConnector.GetDriveUrl(DriveConstants.DriveUpload);
            //string urlBase = DriveConstants.DriveUpload_Me;
            string specific = App.OneDriveConnector.GetSpecific(DriveConstants.DriveUpload);
            string urlBase = App.OneDriveConnector.GetDriveUrl(specific);
            string url = urlBase.Replace(DriveConstants.ItemId, id);
            await ExecuteUpdateFile(filename, url);
        }

        private async Task ExecuteUpdateFile(string name, string url)
        {
            var fileResult = await FileExtensionHelper.PickAFile();
            if (fileResult != null)
            {
                string filename = fileResult.FileName;
                if (filename != name)
                {
                    await ShowDisplayAlert.SimpleTranslated("Warning", $"Please select the file '{name}' to update", "Close");
                    return;
                }

                Stream stream = await fileResult.OpenReadAsync();
                long size = stream.Length;
                long smallSize = GlobalVariables.BaseFileSize * 4;

                var oneDriveTokenResult = await App.OneDriveConnector.GetOneDriveAccessToken();
                if (size <= smallSize)
                    await UploadSmallFile(url, oneDriveTokenResult, stream);
                else
                    await UploadLargeFile(url, oneDriveTokenResult, stream);
            }
            else
            {
                #region Verify if the user choose a file
                bool action = await ShowDisplayAlert.BoolTranslated(
                    Translate.Warning,
                    Translate.No_file_selected,
                    Translate.Retry, Translate.Cancel);
                if (action)
                    await ExecuteUpdateFile(name, url);
                else
                    return;
                #endregion
            }
        }

        private async Task UploadSmallFile(string url, Response oneDriveTokenResult, Stream stream)
        {
            await App.OneDriveConnector.UploadFile(url, oneDriveTokenResult, stream);
        }

        private async Task UploadLargeFile(string url, Response oneDriveTokenResult, Stream stream)
        {
            await App.OneDriveConnector.UploadFile(url, oneDriveTokenResult, stream);
        }
    }
}