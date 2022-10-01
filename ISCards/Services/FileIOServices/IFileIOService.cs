

using Syncfusion.XlsIO;

namespace ISCards.Services.FileIOServices
{
    public interface IFileIOService
    {
        Stream GetFileStream(string fileName);
        string GetFilePath(string fileName);
        bool SaveExcelFile(IWorkbook workbook, string fileName);
    }
}
