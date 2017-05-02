using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Ionic.Zip;
using Ionic.Zlib;


namespace OutlookExtentionPack
{
    public static class AppEnvironment
    {
        public static string AppDataPath
        {
            get
            {
                return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"OutlookExtentionPack");
            }
        }
    }
    public static class UserConfig
    {

    }

    public interface IResult
    {
        bool IsSuccess { get; set; }
        Exception Exception { get; set; }
    }
    public class IOResult : IResult
    {
        public IOResult()
        {
            IsSuccess = true;
        }
        public bool IsSuccess { get; set; }
        public Exception Exception { get; set; }

        public string Path { get; set; }
    }

    public static class FileManager
    {
        public static IOResult CreateTempDirectory(string prefix = "")
        {
            prefix = 禁止文字削除(prefix);
            var result = new IOResult();
            try
            {
                var path1 = Path.Combine(AppEnvironment.AppDataPath, "temp");

                if (string.IsNullOrEmpty(prefix) == true)
                {
                    result.Path = Path.Combine(path1, string.Format("{0:yyyyMMddHHmmss}", DateTime.Now));
                }
                else
                {
                    result.Path = Path.Combine(path1, string.Format("{0}_{1:yyyyMMddHHmmss}", prefix, DateTime.Now));
                }

                Directory.CreateDirectory(result.Path);

            }
            catch(Exception e)
            {
                result.IsSuccess = false;
                result.Exception = e;
            }
            return result;
        }
        public static IOResult FileCopyToTempDirectory(string[] srcFileFullPaths, string prefix = "")
        {
            var temp = CreateTempDirectory(prefix);
            FileCopy(srcFileFullPaths, temp.Path);

            return temp;

        }
        public static IOResult FileCopy(string[] srcFileFullPaths, string distDirectory)
        {
            var result = new IOResult();
            foreach (var file in srcFileFullPaths)
            {
                var tempResult = FileCopy(file, distDirectory);
            }
            return result;
        }
        public static IOResult FileCopy(string srcFileFullPath, string distDirectory)
        {
            var result = new IOResult();
            try
            {
                var fileName = Path.GetFileName(srcFileFullPath);
                var distFileFullPath = Path.Combine(distDirectory, fileName);

                if (Directory.Exists(distDirectory) == false)
                {
                    result.IsSuccess = false;
                    result.Exception = new Exception("コピー先ディレクトリが存在しません。");
                    return result;
                }
                else if (File.Exists(distFileFullPath) == true)
                {
                    result.IsSuccess = false;
                    result.Exception = new Exception("コピー先に既にファイルが存在します。");
                    return result;
                }


                File.Copy(srcFileFullPath, distFileFullPath);
            }
            catch (Exception e)
            {
                result.IsSuccess = false;
                result.Exception = e;
            }

            return result;
        }


        private static string[] 禁止文字 = new string[] { @"\", "/", ":", "*", "?", "<", ">", "\"", "|" };
        private static string 禁止文字削除(string path)
        {
            foreach (var word in 禁止文字)
            {
                path = path.Replace(word, "");
            }
            return path;
        }
    }

    public class FileIo
    {
        public FileIo()
        {
            if (Directory.Exists(TempFilePath) == false)
            {
                Directory.CreateDirectory(TempFilePath);
            }
        }

        private string appDataPath;
        private string tempPath;
        public string AppDataPath
        {
            get
            {
                if (string.IsNullOrEmpty(appDataPath) == true)
                {
                    appDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), @"OutlookExtentionPack");
                }
                if (Directory.Exists(appDataPath) == false)
                {
                    Directory.CreateDirectory(appDataPath);
                }
                return appDataPath;
            }
        }
        public string TempFilePath
        {
            get
            {
                if (string.IsNullOrEmpty(tempPath) == true)
                {
                    tempPath = Path.Combine(AppDataPath, string.Format("temp\\{0:yyyyMMddHHmmss}", DateTime.Now));
                    Directory.CreateDirectory(tempPath);
                    if (Directory.Exists(tempPath) == false)
                    {

                    }
                }
                return tempPath;
            }
        }

        public List<string> SaveObject(object content, string fileName = null)
        {
            List<string> ret = new List<string>();
            if (string.IsNullOrEmpty(fileName) == true)
            {
                fileName = GetFileName(content);
            }
            string path = Path.Combine(this.TempFilePath, fileName);
            if (content is string)
            {
                File.AppendAllText(path, (content as string), Encoding.GetEncoding("shift_jis"));
                ret.Add(path);
            }
            else if (content is Image)
            {
                (content as Image).Save(path, ImageFormat.Png);
                ret.Add(path);
            }
            //else if (content is string[])
            //{
            //	ret.AddRange((string[])content);
            //}
            else
            {
                MessageBox.Show(string.Format("未対応のデータフォーマットです。{0}", content.GetType().ToString()));
            }

            return ret;
        }
        public string CreateTempFolder(string folderName)
        {
            if (string.IsNullOrEmpty(folderName) == true)
            {
                folderName = string.Format("ZIP{0:HHmmss}", DateTime.Now);
            }
            var path = Path.Combine(this.TempFilePath, folderName);
            Directory.CreateDirectory(path);
            return path;
        }

        private string GetFileName(object content)
        {
            string prefix = "orz";
            string extension = "orz";
            if (content is string)
            {
                prefix = "TEXT";
                extension = GetDataTypeExtension(DataFormats.Text);
            }
            else if (content is Image)
            {
                prefix = "IMAGE";
                extension = GetDataTypeExtension(DataFormats.Bitmap);
            }
            else if (content is string[])
            {
                prefix = "FILES";
                extension = "zip";
            }
            else if (content is ZipFile)
            {
                prefix = "ZIP";
                extension = "zip";
            }
            return string.Format("{0}{1:HHmmss}.{2}", prefix, DateTime.Now, extension);
        }
        public static string GetDataTypeExtension(string dateType)
        {
            if (dateType == DataFormats.Text)
            {
                return "txt";
            }
            else if (dateType == DataFormats.Bitmap)
            {
                return "png";
            }
            else if (dateType == DataFormats.FileDrop)
            {
                return "zip";
            }
            return "orz";
        }
        public static Image GetDataTypeImage(string dateType)
        {
            if (dateType == DataFormats.Text)
            {
                return OutlookExtentionPack.Properties.Resources.DataType_Text;
            }
            else if (dateType == DataFormats.Bitmap)
            {
                return OutlookExtentionPack.Properties.Resources.DataType_Bitmap;
            }
            else if (dateType == DataFormats.FileDrop)
            {
                return OutlookExtentionPack.Properties.Resources.MultiFile;
            }
            return OutlookExtentionPack.Properties.Resources.DataType_None;
        }
        /// <summary>
        /// 指定されたファイルを一つのフォルダにまとめて圧縮を行います。
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="paths"></param>
        /// <returns></returns>
        public string FilesCompress(string fileName, params string[] paths)
        {
            string path = string.Empty;
            //圧縮対象フォルダ
            string compFolder = string.Empty;
            //圧縮ファイル名
            string compFile = string.Empty;
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("Shift_JIS")))
            {
                if (string.IsNullOrEmpty(fileName) == true)
                {
                    fileName = GetFileName(zip);
                }
                path = Path.Combine(this.TempFilePath, fileName);
                compFolder = Path.Combine(this.TempFilePath, fileName);
                compFolder = compFolder.Replace(Path.GetExtension(compFolder), string.Empty);
                compFile = Path.Combine(compFolder, fileName);
                if (Path.GetExtension(compFile) != ".zip")
                {
                    compFile = compFile + ".zip";
                }

                //フォルダ作成
                Directory.CreateDirectory(compFolder);
                foreach (var file in paths)
                {
                    File.Copy(file, Path.Combine(compFolder, Path.GetFileName(file)));
                }

                zip.CompressionLevel = CompressionLevel.BestCompression;
                zip.AddDirectory(compFolder);
                zip.Save(compFile);
            }
            return compFile;
        }
        public string FolderCompress(SubWindow.MailComposeAddin.CompressSetting setting)
        {
            string compFile = string.Empty;
            using (ZipFile zip = new ZipFile(Encoding.GetEncoding("Shift_JIS")))
            {
                var fileName = setting.CompressTargetPath.Split('\\').Where(i => i != "\\").Last() + ".zip";
                compFile = Path.Combine(setting.CompressTargetPath, fileName);
                if (setting.HasPassword == true)
                {
                    zip.Password = setting.PasswordText;
                    //zip.Encryption = Ionic.Zip.EncryptionAlgorithm.None;
                }

                zip.CompressionLevel = CompressionLevel.BestCompression;
                zip.AddDirectory(setting.CompressTargetPath);

                zip.Save(compFile);
            }
            setting.CompressFilePath = compFile;
            return compFile;
        }
    }
}
