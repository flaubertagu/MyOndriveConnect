using System;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveConnect.Services
{
    public static class AppSecrets
    {
        #region OneDrive
        public static string OneDriveUserId { get; } = "OneDriveUserId";
        public static string OneDriveUsername { get; } = "OneDriveUsername";
        public static string OneDrivePassword { get; } = "OneDrivePassword";

        #region Check keys
        public static async Task<bool> CheckOneDriveUserId()
        {
            string UserId = await SecureStorage.GetAsync(OneDriveUserId);
            if (!string.IsNullOrEmpty(UserId))
                return true;
            else
                return false;
        }
        public static async Task<bool> CheckOneDriveUsername()
        {
            string Username = await SecureStorage.GetAsync(OneDriveUsername);
            if (!string.IsNullOrEmpty(Username))
                return true;
            else
                return false;
        }
        public static async Task<bool> CheckOneDrivePassword()
        {
            string Password = await SecureStorage.GetAsync(OneDrivePassword);
            if (!string.IsNullOrEmpty(Password))
                return true;
            else
                return false;
        }
        #endregion

        #region Create keys
        public static async Task CreateOneDriveUserId(string userId)
        {
            try
            {
                await SecureStorage.SetAsync(OneDriveUserId, userId);
            }
            catch (Exception err)
            {
                //await CrashHandler.TrackError(err);
            }
        }
        public static async Task CreateOneDriveUsername(string username)
        {
            try
            {
                await SecureStorage.SetAsync(OneDriveUsername, username);
            }
            catch (Exception err)
            {
                //await CrashHandler.TrackError(err);
            }
        }
        public static async Task CreateOneDrivePassword(string password)
        {
            try
            {
                await SecureStorage.SetAsync(OneDrivePassword, password);
            }
            catch (Exception err)
            {
                //await CrashHandler.TrackError(err);
            }
        }
        #endregion

        #region Delete keys
        public static async Task DeleteOneDriveUserId()
        {
            string key = await SecureStorage.GetAsync(OneDriveUserId);
            if (!string.IsNullOrEmpty(key))
                SecureStorage.Remove(OneDriveUserId);
        }
        public static async Task DeleteOneDriveUsername()
        {
            string key = await SecureStorage.GetAsync(OneDriveUsername);
            if (!string.IsNullOrEmpty(key))
                SecureStorage.Remove(OneDriveUsername);
        }
        public static async Task DeleteOneDrivePassword()
        {
            string key = await SecureStorage.GetAsync(OneDrivePassword);
            if (!string.IsNullOrEmpty(key))
                SecureStorage.Remove(OneDrivePassword);
        }
        #endregion

        #region Get key
        public static async Task<string> GetOneDriveUserId()
        {
            return await SecureStorage.GetAsync(OneDriveUserId);
        }
        public static async Task<string> GetOneDriveUsername()
        {
            return await SecureStorage.GetAsync(OneDriveUsername);
        }
        public static async Task<string> GetOneDrivePassword()
        {
            return await SecureStorage.GetAsync(OneDrivePassword);
        }
        #endregion

        #endregion
    }
}
