using System.Threading.Tasks;

namespace DriveConnect.Helpers
{
    public static class ShowDisplayAlert
    {
        public static async Task SimpleTranslated(string title, string message, string action)
        {
            await App.Current.MainPage.DisplayAlert(title, message, action);
        }

        public static async Task<bool> BoolTranslated(string title, string message, string action1, string action2)
        {
            bool action = await App.Current.MainPage.DisplayAlert(title, message, action1, action2);
            return action;
        }

        public static async Task Error(string title, string message, string action)
        {
            await App.Current.MainPage.DisplayAlert(title, message, action);
        }
    }
}
