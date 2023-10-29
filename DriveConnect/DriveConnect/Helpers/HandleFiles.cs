using System.IO;

namespace DriveConnect.Helpers
{
    public static class HandleFiles
    {
        public static bool FileIsLocked(string filePath)
        {
            bool blnReturn = false;
            FileStream fs;
            try
            {
                fs = File.Open(filePath, FileMode.OpenOrCreate, FileAccess.Read, FileShare.None);
                fs.Close();
            }
            catch (IOException)
            {
                blnReturn = true;
            }
            return blnReturn;
        }
    }
}
