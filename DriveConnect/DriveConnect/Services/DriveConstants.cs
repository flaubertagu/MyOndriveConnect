namespace DriveConnect.Services
{
    public class DriveConstants
    {
        public static string DriveUrl { get; } = "https://graph.microsoft.com/v1.0/";
        public static string MyDrive { get; } = "me/";
        public static string SitesDrive { get; } = "sites/";
        public static string SearchSites { get; } = "?search=*";
        public static string Root { get; } = "Root";
        public static string OneDriveRoot { get; } = "/drive/root/children";
        
        public static string DriveId { get; } = "drive-id";
        public static string ItemId { get; } = "item-id";
        public static string SiteId { get; } = "site-id";
        public static string ParentItemId { get; } = "parent-item-id";
        public static string Hook_Left { get; } = "{";
        public static string Hook_Rigth { get; } = "}";
        public static string DriveChildren { get; } = $"drives/{DriveId}/items/{ItemId}/children";
        public static string DriveUpload { get; } = $"drive/items/{ItemId}/content";
        public static string DriveCreateFolder_Me { get; } = 
            $"drive/items/{Hook_Left}{ParentItemId}{Hook_Rigth}/children";
        public static string DriveCreateFolder_Site { get; } = 
            $"sites/{Hook_Left}{SiteId}{Hook_Rigth}/drive/items/{Hook_Left}{ParentItemId}{Hook_Rigth}/children";
    }
}
