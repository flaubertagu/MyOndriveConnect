using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace ShareClass.Resources
{
    public static class StaticFunctions
    {
        public static bool IsByte_string(string bytestring)
        {
            bool isByte;
            try
            {
                byte bytevalue = Convert.ToByte(bytestring);
                isByte = true;
            }
            catch (Exception)
            {
                isByte = false;
            }
            return isByte;
        }

        public static bool PlusOrLess(int currentStringLenght, int previousStringLenght)
        {
            bool plusOrLess = true;
            if (previousStringLenght > 0)
            {
                if (currentStringLenght > previousStringLenght)
                    plusOrLess = true;
                else
                    plusOrLess = false;
            }
            return plusOrLess;
        }

        public static bool NumberIsEven(int value)
        {
            if (value % 2 == 0)
                return true;
            return false;
        }

        #region Email functions
        public static bool IsValidEmail(string email)
        {
            var trimmedEmail = email.Trim();

            if (trimmedEmail.EndsWith("."))
            {
                return false;
            }
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == trimmedEmail;
            }
            catch
            {
                return false;
            }
        }

        public static string GetUsernameFromEmail(string email)
        {
            string username = string.Empty;
            string[] emailSplit = email.Split('@');
            username = emailSplit[0];
            return username;
        }
        #endregion

        #region Random strings and shuffle
        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomString(int nb_uppercase, int nb_lowercase, int nb_number)
        {
            string alphaUppercase = RandomString_AlphaUppercase(nb_uppercase);
            string alphaLowercase = RandomString_AlphaLowercase(nb_lowercase);
            string numeric = RandomString_Numeric(nb_number);
            string textToShuffle = $"{alphaUppercase}{alphaLowercase}{numeric}";
            return Shuffle(textToShuffle);
        }

        public static string GeneratePassword(int nb_uppercase, int nb_lowercase, int nb_number, int nb_specialchar)
        {
            string alphaUppercase = RandomString_AlphaUppercase(nb_uppercase);
            string alphaLowercase = RandomString_AlphaLowercase(nb_lowercase);
            string numeric = RandomString_Numeric(nb_number);
            string specialChar = RandomString_SpecialChar(nb_specialchar);
            string textToShuffle = $"{alphaUppercase}{alphaLowercase}{numeric}{specialChar}";
            return Shuffle(textToShuffle);
        }

        public static string RandomString_AlphaUppercase(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomString_AlphaLowercase(int length)
        {
            const string chars = "abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomString_Numeric(int length)
        {
            const string chars = "0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string RandomString_SpecialChar(int length)
        {
            const string chars = "!@#$%^&*~";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string Shuffle(string list)
        {
            int index;
            List<char> chars = new List<char>(list);
            StringBuilder sb = new StringBuilder();
            while (chars.Count > 0)
            {
                index = random.Next(chars.Count);
                sb.Append(chars[index]);
                chars.RemoveAt(index);
            }
            return sb.ToString();
        }
        #endregion

        public static void DeleteSubFolder(string directory)
        {
            if (Directory.Exists(directory))
            {
                Directory.Delete(directory, true);
            }
        }

        public static byte[] ReadFileByte(string filePath)
        {
            byte[] byteToReturn = null;
            try
            {
                using (var stream = new FileStream(filePath, FileMode.Open))
                {
                    using (BinaryReader br = new BinaryReader(stream))
                    {
                        byteToReturn = br.ReadBytes((int)stream.Length);
                        br.Dispose();
                        br.Close();
                    }
                    stream.Dispose();
                    stream.Close();
                }
            }
            catch (IOException)
            {
            }
            return byteToReturn;
        }

        public static void CreateFileByte(string filePath, byte[] byteToWrite)
        {
            try
            {
                using (var stream = new FileStream(filePath, FileMode.OpenOrCreate))
                {
                    try
                    {
                        using (BinaryWriter bw = new BinaryWriter(stream))
                        {
                            bw.Write(byteToWrite);
                            bw.Dispose();
                            bw.Close();
                        }
                        stream.Dispose();
                        stream.Close();
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            catch (IOException)
            {
            }
        }

        public static string ReadFileString(string filePath)
        {
            string stringToReturn = null;
            using (TextReader textReader = new StreamReader(filePath))
            {
                stringToReturn = textReader.ReadToEnd();
                textReader.Dispose();
                textReader.Close();
            }
            return stringToReturn;
        }

        public static void CreateFileString(string filePath, string textToWrite)
        {
            using (TextWriter textWriter = new StreamWriter(filePath))
            {
                textWriter.WriteLine(textToWrite);
                textWriter.Dispose();
                textWriter.Close();
            }
        }

        public static byte[] ConvertStringInByte(string key)
        {
            byte[] theKey = Encoding.ASCII.GetBytes(key);
            return theKey;
        }

        public static void DeleteFile(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return;
                if (File.Exists(path))
                    File.Delete(path);
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteFolderExistIfFile(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return;
                if (Directory.Exists(path))
                    Directory.Delete(path, false);
            }
            catch (Exception)
            {
            }
        }

        public static void DeleteFolder_IncludingFiles(string path)
        {
            try
            {
                if (string.IsNullOrEmpty(path)) return;
                if (Directory.Exists(path))
                    Directory.Delete(path, true);
            }
            catch (Exception)
            {
            }
        }

        #region Datetime functions
        public static string CreateFileFolderDateBase(DateTime date)
        {
            string year = date.Year.ToString();
            string month = date.Month.ToString("00");
            string day = date.Day.ToString("00");
            string hour = date.Hour.ToString("00");
            string minute = date.Minute.ToString("00");
            string second = date.Second.ToString("00");
            string dateFile = year + month + day + hour + minute + second;
            return dateFile;
        }

        public static DateTime ConvertFileFolderToDatetime(string fileFolder)
        {
            int year = int.Parse(fileFolder.Substring(0, 4));
            int month = int.Parse(fileFolder.Substring(4, 2));
            int day = int.Parse(fileFolder.Substring(6, 2));
            int hour = int.Parse(fileFolder.Substring(8, 2));
            int minute = int.Parse(fileFolder.Substring(10, 2));
            int second = int.Parse(fileFolder.Substring(12, 2));
            return new DateTime(year, month, day, hour, minute, second);
        }

        public static DateTime StartOfWeek(this DateTime dt, DayOfWeek startOfWeek)
        {
            int diff = (7 + (dt.DayOfWeek - startOfWeek)) % 7;
            return dt.AddDays(-1 * diff).Date;
        }

        public static int DaysBetweenTwoDates(DateTime dt1, DateTime dt2)
        {
            return (dt1 - dt2).Days;
        }

        public static string GetMonthString(int month)
        {
            DateTime dateTime = new DateTime(1, month, 1);
            return dateTime.ToString("MMMM", CultureInfo.InvariantCulture);
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static int GetHoursDifference(DateTime d1, DateTime d2)
        {
            return (d1 - d2).Hours;
        }
        #endregion

        #region Value convertion
        public static String HexConverter(System.Drawing.Color c)
        {
            return "#" + c.R.ToString("X2") + c.G.ToString("X2") + c.B.ToString("X2");
        }

        public static String RGBConverter(System.Drawing.Color c)
        {
            return "RGB(" + c.R.ToString() + "," + c.G.ToString() + "," + c.B.ToString() + ")";
        }

        public static bool IntParseResult(string value)
        {
            return int.TryParse(value, out int intStr);
        }

        public static decimal IntToDecimal(int value)
        {
            return Convert.ToDecimal(value);
        }

        public static double StringToDouble(string str)
        {
            return Convert.ToDouble(str);
        }

        public static double DecimalToDouble(decimal d)
        {
            return Convert.ToDouble(d);
        }

        public static string ConvertByteArrayToString(byte[] bytes)
        {
            return Encoding.UTF8.GetString(bytes);
        }

        public static byte[] ConvertStringToByteArray(string str)
        {
            return Encoding.UTF8.GetBytes(str);
        }

        public static string DecimalToStringPercent(decimal d)
        {
            return (d * 100).ToString("00.00");
        }
        #endregion

        #region Calcul
        public static decimal DecimalDivide(int i1, int i2)
        {
            decimal d = 0;
            try
            {
                d = Decimal.Divide(i1, i2);
            }
            catch (Exception)
            {
            }
            return d;
        }

        public static decimal DecimalDivide(decimal d1, decimal d2)
        {
            decimal d = 0;
            try
            {
                d = Decimal.Divide(d1, d2);
            }
            catch (Exception)
            {
            }
            return d;
        }
        #endregion

        #region Lorem text generator
        public static void CreateEmptyTxtFile(string path)
        {
            //File.Create(path).Dispose();
            using (StreamWriter sw = File.CreateText(path))
            {
                sw.Dispose();
                sw.Close();
            }
        }

        public static void CreateRandomTxtFile(string path, int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {
            string text = LoremIpsum(minWords, maxWords, minSentences, maxSentences, numParagraphs);
            using (StreamWriter sw = File.CreateText(path))
            {
                string textNewLine = text.Replace("<p>", Environment.NewLine).Replace("</p>", Environment.NewLine);
                sw.WriteLine(textNewLine);
                //sw.WriteLine(text);
                sw.Flush();
                sw.Dispose();
                sw.Close();
            }
        }

        public static string LoremIpsum(int minWords, int maxWords, int minSentences, int maxSentences, int numParagraphs)
        {
            var words = new[]{"lorem", "ipsum", "dolor", "sit", "amet", "consectetuer",
                "adipiscing", "elit", "sed", "diam", "nonummy", "nibh", "euismod",
                "tincidunt", "ut", "laoreet", "dolore", "magna", "aliquam", "erat"};

            var rand = new Random();
            int numSentences = rand.Next(maxSentences - minSentences)
                + minSentences + 1;
            int numWords = rand.Next(maxWords - minWords) + minWords + 1;

            StringBuilder result = new StringBuilder();

            for (int p = 0; p < numParagraphs; p++)
            {
                result.Append("<p>");
                for (int s = 0; s < numSentences; s++)
                {
                    for (int w = 0; w < numWords; w++)
                    {
                        if (w > 0) { result.Append(" "); }
                        result.Append(words[rand.Next(words.Length)]);
                    }
                    result.Append(". ");
                }
                result.Append("</p>");
            }

            return result.ToString();
        }
        #endregion
    }
}
