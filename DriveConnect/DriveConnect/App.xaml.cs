using DriveConnect.Helpers;
using DriveConnect.ViewModels;
using Microsoft.Identity.Client;
using System;
using Xamarin.Essentials;
using Xamarin.Forms;

[assembly: ExportFont("orkney-bold.ttf", Alias = "Orkney_bold")]
[assembly: ExportFont("orkney-medium.ttf", Alias = "Orkney_medium")]
[assembly: ExportFont("orkney-regular.ttf", Alias = "Orkney_regular")]
[assembly: ExportFont("orkney-light.ttf", Alias = "Orkney_light")]
namespace DriveConnect
{
    public partial class App : Application
    {
        public static SystemTheme SystemTheme { get; set; }
        public static IPublicClientApplication PCA = null;
        public static OneDriveConnector OneDriveConnector { get; set; }
        public App()
        {
            InitializeComponent();
            SystemTheme = new SystemTheme();

            PCA = PublicClientApplicationBuilder.Create(Settings.OneDriveAppId)
                .WithRedirectUri(Settings.OneDriveRedirectURI?? $"msal{Settings.OneDriveAppId}://auth")
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .Build();

            OneDriveConnector = new OneDriveConnector();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
            OnResume();
        }

        protected override void OnSleep()
        {
            try
            {
                SystemTheme.SetUserTheme();
                RequestedThemeChanged += App_RequestedThemeChanged;
            }
            catch (Exception)
            {
            }
        }

        protected override void OnResume()
        {
            try
            {
                SystemTheme.SetUserTheme();
                RequestedThemeChanged += App_RequestedThemeChanged;
            }
            catch (Exception)
            {
            }
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                SystemTheme.SetUserTheme();
            });
        }
    }
}
