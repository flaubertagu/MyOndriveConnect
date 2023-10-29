using System.IO;
using Xamarin.Essentials;

namespace DriveConnect
{
    public static class GlobalVariables
    {
        #region Images extensions
        public static string png { get; } = ".png";
        public static string gif { get; } = ".gif";
        public static string bmp { get; } = ".bmp";
        public static string tif { get; } = ".tif";
        public static string tiff { get; } = ".tiff";
        public static string jpg { get; } = ".jpg";
        public static string jpeg { get; } = ".jpeg";
        public static string jpe { get; } = ".jpe";
        public static string jfif { get; } = ".jfif";
        #endregion

        #region Video extensions
        public static string webm { get; } = ".webm";
        public static string mpg { get; } = ".mpg";
        public static string mp2 { get; } = ".mp2";
        public static string mpeg { get; } = ".mpeg";
        public static string mpe { get; } = ".mpe";
        public static string mpv { get; } = ".mpv";
        public static string ogg { get; } = ".ogg";
        public static string mp4 { get; } = ".mp4";
        public static string m4p { get; } = ".m4p";
        public static string m4v { get; } = ".m4v";
        public static string avi { get; } = ".avi";
        public static string mov { get; } = ".mov";
        public static string MOV { get; } = ".MOV";
        public static string qt { get; } = ".qt";
        public static string flv { get; } = ".flv";
        public static string swf { get; } = ".swf";
        public static string avchd { get; } = ".avchd";
        #endregion

        #region Audio extension
        public static string mp3 { get; } = ".mp3";
        public static string aac { get; } = ".aac";
        public static string flac { get; } = ".flac";
        public static string wav { get; } = ".wav";
        public static string aiff { get; } = ".aiff";
        public static string dsd { get; } = ".dsd";
        public static string pcm { get; } = ".pcm";
        #endregion

        #region Document extension
        public static string MS_word { get; } = ".docx";
        public static string MS_excel { get; } = ".xlsx";
        public static string MS_powerpoint { get; } = ".pptx";

        #endregion

        public static string DriveDownload { get; } = Path.Combine(FileSystem.AppDataDirectory, "DriveDownload");
        public static string Select { get; } = "Select";
        public static string Deselect { get; } = "Deselect";
        public static long BaseFileSize { get; set; } = 1024 * 1024;
    }
}
