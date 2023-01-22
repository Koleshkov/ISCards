using ISCards.Models;
using ISCards.Services.FileIOServices;
using Syncfusion.XlsIO;

namespace ISCards.Services.PassengerCardServices
{
    public class PassengerCardService : IPassengerCardService
    {
        private readonly IFileIOService fileIOService;

        public PassengerCardService(IFileIOService fileIOService)
        {
            this.fileIOService=fileIOService;
        }

        public async Task<bool> SendPassagnerCardAsync(PassengerCardDTO passengerCard)
        {
            try
            {
                using var stream = fileIOService.GetFileStream("PassengerCard.xlsx");

                if (stream==null) return false;

                using ExcelEngine excelEngine = new();

                IWorkbook workbook = excelEngine.Excel.Workbooks.Open(stream);

                IWorksheet worksheet = workbook.Worksheets[0];


                worksheet.Range["P14"].Text = passengerCard.NameOfOrganization;
                worksheet.Range["P17"].Text = passengerCard.NumberOfAuto;

                worksheet.Range["F20"].Text=passengerCard.TypeOfAuto=="Легковой автомобиль" ? "V" : "";
                worksheet.Range["F22"].Text=passengerCard.TypeOfAuto=="Автобус" ? "V" : "";
                worksheet.Range["S20"].Text=passengerCard.TypeOfAuto=="Грузовой автомобиль" ? "V" : "";
                worksheet.Range["s22"].Text=passengerCard.TypeOfAuto=="Прочие т/c" ? "V" : "";


                if (passengerCard.EmergencyKit) worksheet.Range["AB30"].Text="V";
                else worksheet.Range["AE30"].Text="V";

                if (passengerCard.MonitoringSystem) worksheet.Range["AB32"].Text="V";
                else worksheet.Range["AE32"].Text="V";

                if (passengerCard.ForeignObjects) worksheet.Range["AB34"].Text="V";
                else worksheet.Range["AE34"].Text="V";

                if (passengerCard.RoutePassport) worksheet.Range["AB36"].Text="V";
                else worksheet.Range["AE36"].Text="V";

                if (passengerCard.BusPassport) worksheet.Range["AB38"].Text="V";
                else worksheet.Range["AE38"].Text="V";

                if (passengerCard.SeatBeltsFastened) worksheet.Range["AB40"].Text="V";
                else worksheet.Range["AE40"].Text="V";

                if (passengerCard.CargoFixed) worksheet.Range["AB42"].Text="V";
                else worksheet.Range["AE42"].Text="V";

                if (passengerCard.SafeLaneChange) worksheet.Range["AB47"].Text="V";
                else worksheet.Range["AE47"].Text="V";

                if (passengerCard.KeepingDistance) worksheet.Range["AB49"].Text="V";
                else worksheet.Range["AE49"].Text="V";

                if (passengerCard.SpeedLimit) worksheet.Range["AB51"].Text="V";
                else worksheet.Range["AE51"].Text="V";

                if (passengerCard.SafeBehavior) worksheet.Range["AB53"].Text="V";
                else worksheet.Range["AE53"].Text="V";

                if (passengerCard.NoCell) worksheet.Range["AB55"].Text="V";
                else worksheet.Range["AE55"].Text="V";

                if (passengerCard.ControlOfAuto) worksheet.Range["AB57"].Text="V";
                else worksheet.Range["AE57"].Text="V";

                if (passengerCard.NotEat) worksheet.Range["AB59"].Text="V";
                else worksheet.Range["AE59"].Text="V";

                if (passengerCard.UnderstandsRoadConditions) worksheet.Range["AB61"].Text="V";
                else worksheet.Range["AE61"].Text="V";

                if (passengerCard.RoadSignRequirements) worksheet.Range["AB63"].Text="V";
                else worksheet.Range["AE63"].Text="V";

                if (passengerCard.TimelyTurnOffTheLights) worksheet.Range["AB65"].Text="V";
                else worksheet.Range["AE65"].Text="V";

                if (passengerCard.AttentionToPedestrians) worksheet.Range["AB67"].Text="V";
                else worksheet.Range["AE67"].Text="V";

                if (passengerCard.GiveWay) worksheet.Range["AB70"].Text="V";
                else worksheet.Range["AE70"].Text="V";

                if (passengerCard.AutoSafelyInReverse) worksheet.Range["AB72"].Text="V";
                else worksheet.Range["AE72"].Text="V";

                if (passengerCard.HandbrakeUsing) worksheet.Range["AB74"].Text="V";
                else worksheet.Range["AE74"].Text="V";

                if (passengerCard.RestRegime) worksheet.Range["AB76"].Text="V";
                else worksheet.Range["AE76"].Text="V";

                if (passengerCard.WorkStopped) worksheet.Range["BG6"].Text="V";
                else worksheet.Range["BG6"].Text="";

                worksheet.Range["E81"].Text = passengerCard.Clear ? "V" : "";
                worksheet.Range["E83"].Text = passengerCard.Snow ? "V" : "";
                worksheet.Range["E85"].Text = passengerCard.Cloud ? "V" : "";
                worksheet.Range["E87"].Text = passengerCard.RainHail ? "V" : "";
                worksheet.Range["E89"].Text = passengerCard.Sun ? "V" : "";
                worksheet.Range["L81"].Text = passengerCard.Night ? "V" : "";
                worksheet.Range["L85"].Text = passengerCard.Rain ? "V" : "";
                worksheet.Range["L87"].Text = passengerCard.Dirt ? "V" : "";

                worksheet.Range["S81"].Text = passengerCard.Asphalt ? "V" : "";
                worksheet.Range["S83"].Text = passengerCard.Ice ? "V" : "";
                worksheet.Range["S85"].Text = passengerCard.Gravel ? "V" : "";
                worksheet.Range["Z81"].Text = passengerCard.OffRoad ? "V" : "";
                worksheet.Range["Z83"].Text = passengerCard.Ground ? "V" : "";

                worksheet.Range["AL16"].Text = passengerCard.PassengerComment;
                worksheet.Range["AL36"].Text = passengerCard.Actions;
                worksheet.Range["AT69"].Text = passengerCard.RespName;
                worksheet.Range["AV71"].Text = passengerCard.Deadline.ToShortDateString();

                worksheet.Range["AO77"].Text = $"{passengerCard.LastName} {passengerCard.FirstName} {passengerCard.MiddleName}";
                worksheet.Range["AV81"].Text = passengerCard.CreationDate.ToShortDateString();


                //var fileName = $"{passengerCard.CardName}.xlsx";
                //var filePath = fileIOService.GetFilePath(fileName);

                if (!fileIOService.SaveFile(workbook, passengerCard.FilePath)) return await Task.FromResult(false);

                var message = new EmailMessage
                {
                    Subject = passengerCard.FileName,
                    Body = $"Во вложении файл {passengerCard.FileName}",
                    BodyFormat = EmailBodyFormat.PlainText
                };

                message.Attachments.Add(new EmailAttachment(passengerCard.FilePath));

                await Email.Default.ComposeAsync(message);

                return await Task.FromResult(true);
            }
            catch
            {
                return await Task.FromResult(false);
            }
        }
    }
}
