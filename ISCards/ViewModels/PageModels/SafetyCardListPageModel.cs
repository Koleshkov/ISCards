using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.ViewModels.PageModels.SafetyCardPageModels;
using ISCards.Views.Pages;
using ISCards.Views.Pages.PassengerCardPages;
using ISCards.Views.Pages.SafetyCardPages;
using System.Collections.ObjectModel;

namespace ISCards.ViewModels.PageModels
{
    public partial class SafetyCardListPageModel : PageModelBase
    {
        //Services
        private readonly ICardRepository<SafetyCard, SafetyCardDTO> repository;

        //Props
        [ObservableProperty]
        private ObservableCollection<SafetyCardDTO> safetyCards = new();

        [ObservableProperty]
        private SafetyCardDTO selectedCard;

        public Dictionary<string, object> NavigationParameters { get; set; }

        public SafetyCardListPageModel(ICardRepository<SafetyCard, SafetyCardDTO> repository)
        {
            this.repository=repository;

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
            SafetyCards = new ObservableCollection<SafetyCardDTO>(tempCards);
        }

        [RelayCommand]
        private async Task CreateCard()
        {
            NavigationParameters["IsEditCard"]=false;
            NavigationParameters["SelectedCard"]= new SafetyCardDTO();
            await Shell.Current.GoToAsync(nameof(PersonalDataPage), NavigationParameters);
        }

        [RelayCommand]
        private async Task EditCard()
        {
            NavigationParameters["IsEditCard"]=true;
            NavigationParameters["SelectedCard"] = SelectedCard;
            await Shell.Current.GoToAsync(nameof(PersonalDataPage), NavigationParameters);
        }

        [RelayCommand]
        private async Task DeleteCard()
        {
            await repository.DeleteCardAsync(SelectedCard.Id);
            UpdatePassengerCards();
        }
    }
}
