using DriveConnect.Helpers;
using DriveConnect.OneDriveClass;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GroupListView : ContentView
    {
        public GroupListView()
        {
            InitializeComponent();
            BindingContext = App.OneDriveConnector;
        }

        private void DriveGroup_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Device.BeginInvokeOnMainThread(async () =>
            {
                if (((CollectionView)sender).SelectedItem == null)
                    return;

                try
                {
                    var group = (DriveGroup)((CollectionView)sender).SelectedItem;
                    App.OneDriveConnector.GroupSelected = group;
                    await App.OneDriveConnector.GetGroupDriveRoot();
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