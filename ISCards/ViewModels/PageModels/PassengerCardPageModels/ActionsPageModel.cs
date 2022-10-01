using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.Services.PassengerCardServices;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class ActionsPageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        //Services
        private readonly IPassengerCardService passengerCardServices;

        public ActionsPageModel(IPassengerCardService passengerCardServices,
            ICardRepository<PassengerCard, PassengerCardDTO> repository) : base(repository)
        {
            this.passengerCardServices=passengerCardServices;
        }

        [RelayCommand]
        public async Task SaveAndSend()
        {
            await Save();
            await passengerCardServices.SendPassagnerCardAsync(Card);
        }
    }
}
