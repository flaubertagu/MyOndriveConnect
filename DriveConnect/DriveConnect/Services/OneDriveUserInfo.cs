using System;

namespace DriveConnect.Services
{
    public class OneDriveUserInfo
    {
        public string DisplayName { get; set; }
        public string GivenName { get; set; }
        public string Id { get; set; }
        public string Surname { get; set; }
        public string UserPrincipalName { get; set; }
        public string IdToken { get; set; }
        public string AccessToken { get; set; }
        public DateTimeOffset TokenExpiration { get; set; }
    }
}
