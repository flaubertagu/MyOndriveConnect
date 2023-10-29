using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveConnect.Services
{
    public static class AppSecrets
    {
        #region OneDrive
        public static string OneDriveUserInfo { get; } = "OneDriveUserInfo";

        #region Check keys
        public static async Task<bool> CheckOneDriveUserInfo()
        {
            string info = await SecureStorage.GetAsync(OneDriveUserInfo);
            if (!string.IsNullOrEmpty(info))
                return true;
            else
                return false;
        }
        #endregion

        #region Create keys
        public static async Task CreateOneDriveUserInfo(string info)
        {
            try
            {
                await SecureStorage.SetAsync(OneDriveUserInfo, info);
            }
            catch (Exception err)
            {
                //await CrashHandler.TrackError(err);
            }
        }
        #endregion

        #region Delete keys
        public static async Task DeleteOneDriveUserInfo()
        {
            bool infoExist = await CheckOneDriveUserInfo();
            if (!infoExist) return;
            string key = await SecureStorage.GetAsync(OneDriveUserInfo);
            if (!string.IsNullOrEmpty(key))
                SecureStorage.Remove(OneDriveUserInfo);
        }
        #endregion

        #region Get key
        public static async Task<string> GetOneDriveUserInfo()
        {
            return await SecureStorage.GetAsync(OneDriveUserInfo);
        }
        #endregion

        #endregion
    }
}
