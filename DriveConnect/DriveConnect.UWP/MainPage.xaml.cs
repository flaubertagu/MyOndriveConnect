using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace DriveConnect.UWP
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Xamarin.Forms.Platform.UWP.WindowsPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            // To get SSO with a UWP app, you'll need to register the following
            // redirect URI for your application
            Uri redirectURIForSsoWithoutBroker = Windows.Security.Authentication.Web.WebAuthenticationBroker.GetCurrentApplicationCallbackUri();

            // To have WAM working you need to register the following redirect URI for your application
            string sid = redirectURIForSsoWithoutBroker.Host.ToUpper();

            // only used in the .WithBroker scenario.
            string redirectUriWithWAM = $"ms-appx-web://microsoft.aad.brokerplugin/{sid}";

            LoadApplication(new DriveConnect.App());
        }
    }
}
