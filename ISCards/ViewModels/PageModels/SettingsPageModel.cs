using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISCards.Models;
using ISCards.Services.Repositories.UserRepositories;
using ISCards.ViewModels.PageModels.Base;

namespace ISCards.ViewModels.PageModels
{
    public partial class SettingsPageModel : PageModelBase
    {
        //Services
        private readonly IUserRepository repository;
        //private readonly SettingsPage settingsPage;

        //Props
        [ObservableProperty]
        private UserDTO user = new();

        public SettingsPageModel(IUserRepository repository)
        {
            this.repository=repository;

            InitializeAsync();
        }


        protected override async void InitializeAsync()
        {
            if (await repository.Any())
            {
                user = await repository.GetUserAsync();
            }
        }

        [RelayCommand]
        public async Task Save()
        {
            if (await repository.Any()) await repository.UpdateUserAsync(User);

            else await repository.CreateUserAsync(User);

            await App.Current.MainPage.DisplayAlert("Готово", "Данные сохранены.", "Ok");
        }
    }
}
