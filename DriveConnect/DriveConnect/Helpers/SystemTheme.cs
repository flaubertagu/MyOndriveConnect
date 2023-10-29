using Xamarin.Essentials;
using Xamarin.Forms;

namespace DriveConnect.Helpers
{
    public class SystemTheme
    {
        public void SetUserTheme()
        {
            switch (Settings.AppTheme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    break;
                //light
                case 1:
                    App.Current.UserAppTheme = OSAppTheme.Light;
                    break;
                //dark
                case 2:
                    App.Current.UserAppTheme = OSAppTheme.Dark;
                    break;
            }
        }

        public int GetThemeId()
        {
            int themeId = 0;
            switch (Settings.AppTheme)
            {
                //default
                case 0:
                    App.Current.UserAppTheme = OSAppTheme.Unspecified;
                    if (IsDarkTheme() == false)
                        themeId = 1;
                    else
                        themeId = 2;
                    break;
                //light
                case 1:
                    themeId = 1;
                    break;
                //dark
                case 2:
                    themeId = 2;
                    break;
            }
            return themeId;
        }

        public void SetDashboardColors()
        {
            int appTheme = GetThemeId();
            if (appTheme == 1)
            {

            }
            else
            {

            }
        }

        public bool IsDarkTheme()
        {
            if (AppInfo.RequestedTheme == Xamarin.Essentials.AppTheme.Light)
                return false;
            else
                return true;
        }
    }
}
