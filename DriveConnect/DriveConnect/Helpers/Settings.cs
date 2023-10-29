using DriveConnect.Services;
using Newtonsoft.Json;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveConnect.Helpers
{
    public static class Settings
    {
        public static string OneDriveAppId { get; } = "d9ff4603-ebf0-47e1-bc24-a3d1b78c368d";
        public static string OneDriveObjectId { get; } = "551e097a-097b-4c84-8596-d43ccfcd98da";
        public static string OneDriveTenantId { get; } = "b05e5dbc-60da-4e59-b1ed-16beda9e5683";
        public static string OneDriveRedirectURI { get; } = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public static string[] Scopes { get; } =
        {
            "Files.Read",
            "Files.Read.All",
            "Files.Read.Selected",
            "Files.ReadWrite",
            "Files.ReadWrite.All",
            "Sites.Read.All",
            "Sites.ReadWrite.All",
            "User.Read",
            "Group.Read.All",
            "GroupMember.Read.All",
            "GroupMember.ReadWrite.All",
            "Directory.Read.All",
            "Directory.ReadWrite.All",
        };
        public static object ParentWindow { get; set; }

        public static void AppInit()
        {
            FileExtensions.Init();
            OneDriveConnected = false;
            FileExtensionHelper.ClearAllTempFiles();
            FileExtensionHelper.PeriodicFileClear();
            //OneDriveUserInfo = string.Empty;
        }

        // 0 = default, 1 = light, 2 = dark
        const int theme = 0;
        public static int AppTheme
        {
            get => Preferences.Get(nameof(AppTheme), theme);
            set => Preferences.Set(nameof(AppTheme), value);
        }

        public static bool OneDriveConnected
        {
            get => Preferences.Get(nameof(OneDriveConnected), false);
            set => Preferences.Set(nameof(OneDriveConnected), value);
        }

        public static async Task SetOneDriveUserInfo(OneDriveUserInfo info)
        {
            string oneDriveUserInfo = JsonConvert.SerializeObject(info);
            await AppSecrets.CreateOneDriveUserInfo(oneDriveUserInfo);
        }

        public static async Task<OneDriveUserInfo> GetOneDriveUserInfo()
        {
            bool infoExist = await AppSecrets.CheckOneDriveUserInfo();
            if (infoExist)
            {
                string oneDriveUserInfo = await AppSecrets.GetOneDriveUserInfo();
                return JsonConvert.DeserializeObject<OneDriveUserInfo>(oneDriveUserInfo);
            }
            else return null;
        }

        public static bool OneDriveAlertDownload
        {
            get => Preferences.Get(nameof(OneDriveAlertDownload), true);
            set => Preferences.Set(nameof(OneDriveAlertDownload), value);
        }
    }
}
