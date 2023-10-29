using System.Collections.Generic;

namespace DriveConnect
{
    public static class FileExtensions
    {
        public static string _folder { get; } = ".folder";
        public static string _doc { get; } = ".doc";
        public static string _docx { get; } = ".docx";
        public static string _xls { get; } = ".xls";
        public static string _xlsx { get; } = ".xlsx";
        public static string _ppt { get; } = ".ppt";
        public static string _pptx { get; } = ".pptx";
        public static string _pdf { get; } = ".pdf";
        public static string _txt { get; } = ".txt";
        public static List<string> Images { get; private set; } = new List<string>();
        public static List<string> Videos { get; private set; } = new List<string>();
        public static List<string> Audios { get; private set; } = new List<string>();

        public static void Init()
        {
            Images = new List<string>();
            Videos = new List<string>();
            Audios = new List<string>();

            #region Add images extensions
            Images.Add(GlobalVariables.png);
            Images.Add(GlobalVariables.gif);
            Images.Add(GlobalVariables.bmp);
            Images.Add(GlobalVariables.tif);
            Images.Add(GlobalVariables.tiff);
            Images.Add(GlobalVariables.jpg);
            Images.Add(GlobalVariables.jpeg);
            Images.Add(GlobalVariables.jpe);
            Images.Add(GlobalVariables.jfif);
            #endregion

            #region Add video extensions
            Videos.Add(GlobalVariables.webm);
            Videos.Add(GlobalVariables.mpg);
            Videos.Add(GlobalVariables.mp2);
            Videos.Add(GlobalVariables.mpeg);
            Videos.Add(GlobalVariables.mpe);
            Videos.Add(GlobalVariables.mpv);
            Videos.Add(GlobalVariables.ogg);
            Videos.Add(GlobalVariables.mp4);
            Videos.Add(GlobalVariables.m4p);
            Videos.Add(GlobalVariables.m4v);
            Videos.Add(GlobalVariables.avi);
            Videos.Add(GlobalVariables.mov);
            Videos.Add(GlobalVariables.qt);
            Videos.Add(GlobalVariables.flv);
            Videos.Add(GlobalVariables.swf);
            Videos.Add(GlobalVariables.avchd);
            #endregion

            #region Add audio extensions
            Audios.Add(GlobalVariables.mp3);
            Audios.Add(GlobalVariables.aac);
            Audios.Add(GlobalVariables.flac);
            Audios.Add(GlobalVariables.wav);
            Audios.Add(GlobalVariables.aiff);
            Audios.Add(GlobalVariables.dsd);
            Audios.Add(GlobalVariables.pcm);
            #endregion
        }
    }
}
