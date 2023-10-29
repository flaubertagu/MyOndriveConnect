using System;

namespace DriveConnect.OneDriveClass
{
    public class DriveItem
    {
        public string Content { get; set; }
        public string CTag { get; set; }
        public string File { get; set; }
        public string Folder { get; set; }
        public string SharepointIds { get; set; }
        public string SpecialFolder { get; set; }
        public string Id { get; set; } //Identifier
        public DateTimeOffset CreatedDateTime { get; set; }
        public string ETag { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Name { get; set; }
        public string ParentReference { get; set; }
        public string WebUrl { get; set; }

        public string ItemType { get; set; }
        public string DownloadURL { get; set; }
        public bool IsAFile { get; set; }
        public string SelectionAction { get; set; }
        public string FolderPath { get; set; }
    }
}
