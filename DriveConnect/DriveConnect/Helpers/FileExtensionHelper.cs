using Xamarin.Forms;
using System.IO;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace DriveConnect.Helpers
{
    public static class FileExtensionHelper
    {
        public static void ClearAllTempFiles()
        {
            ClearOneDriveCache();
        }
        public async static void ClearOneDriveCache()
        {
            var fileCache = new DirectoryInfo(GlobalVariables.DriveDownload);
            foreach (var fileInfo in fileCache.GetFiles())
            {
                try
                {
                    string filepath = fileInfo.FullName;
                    bool isLocked = HandleFiles.FileIsLocked(filepath);
                    if (!isLocked)
                        fileInfo.Delete();
                }
                catch (IOException err)
                {
                    //await CrashHandler.TrackIOError(err);
                }
            }
        }

        // ------ ADD FUNCTION REFERENCE IN AUTHENTICATEVM LIGNE 206 -----
        public static void PeriodicFileClear()
        {
            Device.StartTimer(new TimeSpan(0, 1, 0), () =>
            {
                Device.BeginInvokeOnMainThread(() =>
                {
                    ClearOneDriveCache();
                });
                return true;
            });
        }

        public async static Task<IEnumerable<FileResult>> PickFiles()
        {
            var pickResult = await FilePicker.PickMultipleAsync(new PickOptions
            {
                FileTypes = default,
                PickerTitle = "Pick file(s)",
            });

            return pickResult;
        }

        public async static Task<FileResult> PickAFile()
        {
            var pickResult = await FilePicker.PickAsync(new PickOptions
            {
                FileTypes = default,
            });

            return pickResult;
        }
    }
}
