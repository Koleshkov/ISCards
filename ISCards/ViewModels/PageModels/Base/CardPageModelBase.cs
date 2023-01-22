using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.Views.Pages;

namespace ISCards.ViewModels.PageModels.Base
{
    [QueryProperty(nameof(UpdateCardsAction), "UpdateCardsHandler")]
    [QueryProperty(nameof(Card), "SelectedCard")]
    [QueryProperty(nameof(IsEditCard), "IsEditCard")]
    public partial class CardPageModelBase<TCard, TCardDTO> : PageModelBase
        where TCard : BaseCard where TCardDTO : BaseCardDTO
    {
        //Services
        private readonly ICardRepository<TCard, TCardDTO> repository;
        private readonly IFileIOService fileIOService;


        //Props
        [ObservableProperty]
        private TCardDTO card;

        public Action UpdateCardsAction { get; set; }

        public bool IsEditCard { get; set; }

        public Dictionary<string, object> NavigationParameters { get; set; } = new();


        public CardPageModelBase(ICardRepository<TCard, TCardDTO> repository, IFileIOService fileIOService)
        {
            this.repository=repository;
            this.fileIOService=fileIOService;
        }

        [RelayCommand]
        public virtual Task GoNext()
        {
            SetNavigationParameters();

            return Task.CompletedTask;
        }

        [RelayCommand]
        public async virtual Task Save()
        {
            Card.FileName = $"{Card.CardName}.xlsx";
            Card.FilePath = fileIOService.GetFilePath(Card.FileName);

            if (IsEditCard)
            {
                Card.CreationDate=DateTime.UtcNow;
                await repository.UpdateCardAsync(Card);
            }
            else
            {
                await repository.CreateCardAsync(Card);
            }

            SetNavigationParameters();

            ((Action)NavigationParameters["UpdateCardsHandler"])?.Invoke();

            if (Card is PassengerCardDTO) await Shell.Current.GoToAsync($"//../{nameof(PassengerCardListPage)}");
            else await Shell.Current.GoToAsync($"//../{nameof(SafetyCardListPage)}");
        }

        private void SetNavigationParameters()
        {
            NavigationParameters = new()
            {
                { "UpdateCardsHandler", UpdateCardsAction},
                { "SelectedCard", Card},
                { "IsEditCard", IsEditCard}
            };
        }
    }
}
