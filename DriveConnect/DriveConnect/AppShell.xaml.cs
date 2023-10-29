using DriveConnect.Views;
using System;
using Xamarin.Forms;

namespace DriveConnect
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(OneDriveLogin), typeof(OneDriveLogin));
            Routing.RegisterRoute(nameof(DriveItemsSelected), typeof(DriveItemsSelected));
        }
    }
}
