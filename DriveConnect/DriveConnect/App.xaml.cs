using DriveConnect.Services;
using Microsoft.Identity.Client;
using Xamarin.Forms;

namespace DriveConnect
{
    public partial class App : Application
    {
        public static IPublicClientApplication PCA = null;
        //public static string ClientID = "d9ff4603-ebf0-47e1-bc24-a3d1b78c368d"; //msidentity-samples-testing tenant
        //public static string[] Scopes { get; } = { "User.Read", "files.readwrite" };
        //public static object ParentWindow { get; set; }
        //public static string RedirectURI { get; } = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public App()
        {
            InitializeComponent();
            PCA = PublicClientApplicationBuilder.Create(Settings.OneDriveAppId)
                .WithRedirectUri(Settings.OneDriveRedirectURI?? $"msal{Settings.OneDriveAppId}://auth")
                .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
                .Build();
            //PCA = PublicClientApplicationBuilder.Create(ClientID)
            //    .WithRedirectUri(RedirectURI?? $"msal{ClientID}://auth")
            //    .WithIosKeychainSecurityGroup("com.microsoft.adalcache")
            //    .Build();

            MainPage = new AppShell();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
