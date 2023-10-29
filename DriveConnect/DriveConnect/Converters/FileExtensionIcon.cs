using System;
using System.Globalization;
using System.IO;
using Xamarin.Forms;

namespace DriveConnect.Converters
{
    public class FileExtensionIcon : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                string extension = Path.GetExtension(value.ToString());
                bool extensionChecked;
                extensionChecked = ItsFolder(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.Folder);
                extensionChecked = ItsOfficeFile(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.OfficeDocFile);
                extensionChecked = ItsExcelFile(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.ExcelDocFile);
                extensionChecked = ItsPowerPointFile(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.PowerPointDocFile);
                extensionChecked = ItsPdfFile(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.PdfFile);
                extensionChecked = ItsImageFile(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.ImageFile);
                extensionChecked = ItsVideo(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.Video);
                extensionChecked = ItsAudio(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.Audio);
                extensionChecked = ItsText(extension);
                if (extensionChecked)
                    return ImageSource.FromFile(FileIcons.Text);
                else
                    return ImageSource.FromFile(FileIcons.Other);
            }
            else
                return ImageSource.FromFile(FileIcons.Other);
        }

        public bool ItsFolder(string value)
        {
            if (value == FileExtensions._folder)
                return true;
            return false;
        }
        public bool ItsOfficeFile(string extension)
        {
            return extension == FileExtensions._doc || extension == FileExtensions._docx;
        }
        public bool ItsExcelFile(string extension)
        {
            return extension == FileExtensions._xls || extension == FileExtensions._xlsx;
        }
        public bool ItsPowerPointFile(string extension)
        {
            return extension == FileExtensions._ppt || extension == FileExtensions._pptx;
        }
        public bool ItsPdfFile(string extension)
        {
            return extension == FileExtensions._pdf;
        }
        public bool ItsImageFile(string extension)
        {
            if (FileExtensions.Images.Contains(extension))
                return true;
            return false;
        }
        public bool ItsVideo(string extension)
        {
            if (FileExtensions.Videos.Contains(extension))
                return true;
            return false;
        }
        public bool ItsAudio(string extension)
        {
            if (FileExtensions.Audios.Contains(extension))
                return true;
            return false;
        }
        public bool ItsText(string extension)
        {
            return extension == FileExtensions._txt;
        }
        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return null;
        }
    }
}
