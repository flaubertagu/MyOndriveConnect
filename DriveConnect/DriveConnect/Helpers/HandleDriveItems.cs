using DriveConnect.OneDriveClass;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Xamarin.Essentials;
using ShareClass.Resources;
using System.Linq;

namespace DriveConnect.Helpers
{
    public static class HandleDriveItems
    {
        public static DriveItem ReturnDriveItem(JObject itemJson)
        {
            string name = itemJson["name"].ToString();
            DriveItem driveItem = new DriveItem()
            {
                CreatedDateTime = DateTimeOffset.Parse(itemJson["createdDateTime"].ToString()),
                ETag = itemJson["eTag"].ToString(),
                Id = itemJson["id"].ToString(),
                LastModifiedDateTime = DateTimeOffset.Parse(itemJson["lastModifiedDateTime"].ToString()),
                Name = name,
                WebUrl = itemJson["webUrl"].ToString(),
                CTag = itemJson["cTag"].ToString(),
            };
            if (itemJson.ContainsKey("folder"))
                driveItem.Folder = itemJson["folder"].ToString();

            if (itemJson.ContainsKey("file"))
                driveItem.File = itemJson["file"].ToString();
            if (itemJson.ContainsKey("sharepointIds"))
                driveItem.SharepointIds = itemJson["sharepointIds"].ToString();
            if (itemJson.ContainsKey("specialFolder"))
                driveItem.SpecialFolder = itemJson["specialFolder"].ToString();
            if (itemJson.ContainsKey("parentReference"))
                driveItem.ParentReference = itemJson["parentReference"].ToString();

            if (itemJson.ContainsKey("folder"))
                driveItem.ItemType = FileExtensions._folder;
            else
                driveItem.ItemType = Path.GetExtension(name);

            if (driveItem.ItemType != FileExtensions._folder)
                driveItem.IsAFile = true;
            else
                driveItem.IsAFile = false;

            if (itemJson.ContainsKey("@microsoft.graph.downloadUrl"))
                driveItem.DownloadURL = itemJson["@microsoft.graph.downloadUrl"].ToString();

            driveItem.SelectionAction = GlobalVariables.Select;

            return driveItem;
        }

        public static DriveSite ReturnDriveSite(JObject itemJson)
        {
            string id;
            string idGet = itemJson["id"].ToString();
            if (idGet.Count(x => x == ',') == 0)
                id = itemJson["id"].ToString();
            else
            {
                string[] idSplit = idGet.Split(',');
                id = idSplit[1];
            }

            DriveSite driveGroup = new DriveSite()
            {
                Id = id,
                DisplayName = itemJson["displayName"].ToString(),
                Name = itemJson["name"].ToString(),
            };
            return driveGroup;
        }

        public static async Task DownloadFile(string url, string filename)
        {
            string downloadPath = GlobalVariables.DriveDownload;
            if (!Directory.Exists(downloadPath))
                Directory.CreateDirectory(downloadPath);
            try
            {
                string filepath = Path.Combine(downloadPath, filename);
                bool proceed;
                if (!File.Exists(filepath))
                    proceed = true;
                else
                    proceed = await ShowDisplayAlert.BoolTranslated("Notification", "File already exist. Replace", "Yes", "No");

                if (proceed)
                {
                    byte[] filebytes = new WebClient().DownloadData(url);
                    if (filebytes != null)
                    {
                        StaticFunctions.CreateFileByte(filepath, filebytes);
                        if (File.Exists(filepath))
                        {
                            await OpenUnencryptedFiles(filepath);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                await ShowDisplayAlert.SimpleTranslated("Error", err.Message, "Close");
            }
        }

        static async Task OpenUnencryptedFiles(string filePath)
        {
            await Launcher.OpenAsync(new OpenFileRequest() { File = new ReadOnlyFile(filePath) });
        }
    }
}
