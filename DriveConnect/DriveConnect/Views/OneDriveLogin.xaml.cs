using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DriveConnect.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class OneDriveLogin : ContentPage
    {
        public OneDriveLogin()
        {
            InitializeComponent();
            BindingContext = App.OneDriveConnector;
        }
    }
}