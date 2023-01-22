using ISCards.Models;
using ISCards.Services.FileIOServices;
using Syncfusion.XlsIO;

namespace ISCards.Services.SafetyCardServices
{
    public class SafetyCardService : ISafetyCardService
    {
        private readonly IFileIOService fileIOService;

        public SafetyCardService(IFileIOService fileIOService)
        {
            this.fileIOService=fileIOService;
        }

        public async Task<bool> SendSafetyCardAsync(SafetyCardDTO safetyCard)
        {
            try
            {
                using var stream = fileIOService.GetFileStream("SafetyCard.xlsx");

                if (stream==null) return false;

                using ExcelEngine excelEngine = new();

                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(stream);

                IWorksheet worksheet = workbook.Worksheets[0];


                worksheet.Range["B9"].Text = safetyCard.CreationDate.ToShortDateString();
                worksheet.Range["C9"].Text = $"{safetyCard.LastName} {safetyCard.FirstName} {safetyCard.MiddleName}";
                worksheet.Range["D9"].Text = safetyCard.Position;
                worksheet.Range["E9"].Text = safetyCard.Phone;
                worksheet.Range["F9"].Text = safetyCard.Email;
                worksheet.Range["G9"].Text = safetyCard.Organization;
                worksheet.Range["H9"].Text = safetyCard.Department;
                worksheet.Range["I9"].Text = safetyCard.JobObject;
                worksheet.Range["J9"].Text = safetyCard.TypeOfAction;
                worksheet.Range["K9"].Text = safetyCard.Description;
                worksheet.Range["L9"].Text = safetyCard.Actions;
                worksheet.Range["M9"].Text = safetyCard.Reasons;
                worksheet.Range["N9"].Text = safetyCard.PlannedEvents;
                worksheet.Range["O9"].Text = safetyCard.Deadline.ToShortDateString();
                worksheet.Range["P9"].Text = safetyCard.RespName;
                worksheet.Range["Q9"].Text = safetyCard.Status;


                var fileName = $"{safetyCard.CardName}.xlsx";
                var filePath = fileIOService.GetFilePath(fileName);

                if (!fileIOService.SaveFile(workbook, safetyCard.FilePath)) return await Task.FromResult(false);

                var message = new EmailMessage
                {
                    Subject = safetyCard.FileName,
                    Body = $"Во вложении файл {safetyCard.FileName}",
                    BodyFormat = EmailBodyFormat.PlainText
                };

                message.Attachments.Add(new EmailAttachment(safetyCard.FilePath));

                await Email.Default.ComposeAsync(message);

                return await Task.FromResult(true);

            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
