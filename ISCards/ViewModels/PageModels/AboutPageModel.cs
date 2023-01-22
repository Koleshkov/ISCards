using CommunityToolkit.Mvvm.Input;
using ISCards.ViewModels.PageModels.Base;


namespace ISCards.ViewModels.PageModels
{
    public partial class AboutPageModel : PageModelBase
    {
        [RelayCommand]
        public static async Task TapTelegram()
        {
            await Launcher.OpenAsync("https://t.me/koleshkov");
        }

        [RelayCommand]
        public static async Task TapEmail()
        {
            await Launcher.OpenAsync("mailto:e.koleshkov@isnnb.ru");
        }

        [RelayCommand]
        public static async Task TapGithub()
        {
            await Launcher.OpenAsync("https://github.com/Koleshkov");
        }
    }
}
