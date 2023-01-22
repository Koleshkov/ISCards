using Syncfusion.XlsIO;
using System.Reflection;



namespace ISCards.Services.FileIOServices
{
    public class FileIOService : IFileIOService
    {
        public string GetFilePath(string fileName)
        {
            try
            {
                string root = Android.App.Application.Context!.GetExternalFilesDir(Android.OS.Environment.DirectoryDocuments)!.AbsolutePath;
                string filepath = Path.Combine(root, fileName);
                return filepath;
            }
            catch
            {
                return null;
            }
        }

        public Stream GetFileStream(string fileName)
        {
            try
            {
                var assembly = typeof(App).GetTypeInfo().Assembly;

                var assemblyName = assembly.GetName().Name;

                return assembly.GetManifestResourceStream($"{assemblyName}.Resources.Templates.{fileName}");
            }
            catch
            {
                return null;
            }
        }

        public bool SaveFile(IWorkbook file, string filePath)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(filePath)&&file!=null)
                {
                    using MemoryStream ms = new();

                    file.SaveAs(ms);
                    ms.Position = 0;

                    File.WriteAllBytes(filePath, ms.ToArray());

                    return true;
                }
                else return false;
                
            }
            catch
            {
                return false;
            }
        }

        public bool DeleteFile(string path)
        {
            try
            {
                if (!string.IsNullOrWhiteSpace(path))
                {
                    File.Delete(path);
                    return true;
                }
                else return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
