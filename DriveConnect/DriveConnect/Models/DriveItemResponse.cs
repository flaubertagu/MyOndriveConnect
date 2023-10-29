using DriveConnect.OneDriveClass;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace DriveConnect.Models
{
    public class DriveItemResponse : BaseModel
    {
        [JsonProperty]
        public List<DriveItem> DriveItem { get; set; }
    }
}
