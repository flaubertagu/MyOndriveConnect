using DriveConnect.Helpers;
using DriveConnect.OneDriveClass;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SiteListView : ContentView
    {
        public SiteListView()
        {
            InitializeComponent();
            BindingContext = App.OneDriveConnector;
        }

        private void DriveSite_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (((CollectionView)sender).SelectedItem == null)
                    return;

                try
                {
                    var group = (DriveSite)((CollectionView)sender).SelectedItem;
                    App.OneDriveConnector.SiteSelected = group;
                    await App.OneDriveConnector.GetSiteDriveRoot();
                }
                catch (Exception err)
                {
                    await ShowDisplayAlert.Error("Error", err.Message, "Close");
                    //await CrashHandler.TrackError(err);
                }

                ((CollectionView)sender).SelectedItem = null;
            });
        }
    }
}