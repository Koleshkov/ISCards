using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.PassengerCardPages;
using System.Collections.ObjectModel;

namespace ISCards.ViewModels.PageModels
{
   
    public partial class PassengerCardListPageModel : PageModelBase
    {
        //Services
        private readonly ICardRepository<PassengerCard, PassengerCardDTO> repository;
        private readonly IFileIOService fileIOService;

        //Props
        [ObservableProperty]
        private ObservableCollection<PassengerCardDTO> passengerCards = new();

        [ObservableProperty]
        private PassengerCardDTO selectedCard;

        public Dictionary<string, object> NavigationParameters { get; set; }

        public PassengerCardListPageModel(
            ICardRepository<PassengerCard, PassengerCardDTO> repository, 
            IFileIOService fileIOService)
        {
            this.repository=repository;
            this.fileIOService=fileIOService;

            NavigationParameters = new()
            {
                { "UpdateCardsHandler", new Action(UpdatePassengerCards) },
                { "SelectedCard", SelectedCard},
                { "IsEditCard", false}
            };

            UpdatePassengerCards();
        }

        private async void UpdatePassengerCards()
        {
            var tempCards = await repository.GetAllCardsAsync();
            PassengerCards = new ObservableCollection<PassengerCardDTO>(tempCards);
        }

        [RelayCommand]
        private async Task CreateCard()
        {
            NavigationParameters["IsEditCard"]=false;
            NavigationParameters["SelectedCard"]= new PassengerCardDTO();
            await Shell.Current.GoToAsync(nameof(CardCreatorInfoPage), NavigationParameters);
        }

        [RelayCommand]
        private async Task EditCard()
        {
            NavigationParameters["IsEditCard"]=true;
            NavigationParameters["SelectedCard"] = SelectedCard;
            await Shell.Current.GoToAsync(nameof(CardCreatorInfoPage), NavigationParameters);
        }

        [RelayCommand]
        private async Task DeleteCard()
        {
            await repository.DeleteCardAsync(SelectedCard.Id);
            fileIOService.DeleteFile(SelectedCard.FilePath);
            UpdatePassengerCards();
        }
    }
}
