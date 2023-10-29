using DriveConnect.OneDriveClass;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using Xamarin.Essentials;

namespace DriveConnect
{
    public static class DoNotIntegrate
    {
        public static string DriveIntemsInfo { get; } = Path.Combine(FileSystem.AppDataDirectory, "DriveIntemsInfo.txt");
        public static void DeleteItemsTxt()
        {
            if (File.Exists(DriveIntemsInfo))
                File.Delete(DriveIntemsInfo);
        }

        public static void CreateItemsTxt(List<DriveItem> items)
        {
            List<DriveItemInfo> list = new List<DriveItemInfo>();
            foreach (DriveItem item in items)
            {
                DriveItemInfo intemInfo = new DriveItemInfo()
                {
                    SharepointIds = item.SharepointIds,
                    SpecialFolder = item.SpecialFolder,
                    Id = item.Id,
                    Name = item.Name,
                    ParentReference = item.ParentReference,
                    WebUrl = item.WebUrl,
                    ItemType = item.ItemType,
                    DownloadURL = item.DownloadURL,
                    FolderPath = item.FolderPath,
                };
                list.Add(intemInfo);
            }

            string itemList = JsonConvert.SerializeObject(list);
            DeleteItemsTxt();
            using (StreamWriter sw = File.CreateText(DriveIntemsInfo))
            {
                sw.WriteLine(itemList);
                sw.Dispose();
                sw.Close();
            }
        }

        public static List<DriveItemInfo> ExtractSelectedFiles()
        {
            List<DriveItemInfo> list = new List<DriveItemInfo>();
            if (File.Exists(DriveIntemsInfo))
            {
                string itemList = string.Empty;
                using (StreamReader sr = File.OpenText(DriveIntemsInfo)) 
                { 
                    itemList = sr.ReadToEnd();
                    sr.Dispose();
                    sr.Close();
                }

                if (!string.IsNullOrEmpty(itemList))
                    list = JsonConvert.DeserializeObject<List<DriveItemInfo>>(itemList);
            }
            return list;
        }
    }
}
