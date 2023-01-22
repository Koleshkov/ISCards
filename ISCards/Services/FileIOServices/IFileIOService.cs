using Syncfusion.XlsIO;

namespace ISCards.Services.FileIOServices
{
    public interface IFileIOService
    {
        Stream GetFileStream(string fileName);
        string GetFilePath(string fileName);
        bool SaveFile(IWorkbook package, string fileName);
        bool DeleteFile(string path);
    }
}
