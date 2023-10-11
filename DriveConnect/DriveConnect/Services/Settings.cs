using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace DriveConnect.Services
{
    public static class Settings
    {

        public static string OneDriveAppId { get; } = "d9ff4603-ebf0-47e1-bc24-a3d1b78c368d";
        public static string OneDriveObjectId { get; } = "551e097a-097b-4c84-8596-d43ccfcd98da";
        public static string OneDriveTenantId { get; } = "b05e5dbc-60da-4e59-b1ed-16beda9e5683";
        public static string OneDriveRedirectURI { get; } = "https://login.microsoftonline.com/common/oauth2/nativeclient";
        public static string[] Scopes { get; } = { "User.Read", "files.readwrite" };
        public static object ParentWindow { get; set; }

        public static string OneDriveUserId
        {
            get => Preferences.Get(nameof(OneDriveUserId), string.Empty);
            set => Preferences.Set(nameof(OneDriveUserId), value);
        }

        public static string OneDriveUsername
        {
            get => Preferences.Get(nameof(OneDriveUsername), string.Empty);
            set => Preferences.Set(nameof(OneDriveUsername), value);
        }

        public static string OneDrivePassword
        {
            get => Preferences.Get(nameof(OneDrivePassword), string.Empty);
            set => Preferences.Set(nameof(OneDrivePassword), value);
        }
    }
}
