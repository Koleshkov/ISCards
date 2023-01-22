using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.PassengerCardServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.ViewModels.PageModels.Base;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class ActionsPageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        //Services
        private readonly IPassengerCardService passengerCardServices;

        public ActionsPageModel(IPassengerCardService passengerCardServices,
            ICardRepository<PassengerCard, PassengerCardDTO> repository,
            IFileIOService fileIOService) : base(repository, fileIOService)
        {
            this.passengerCardServices=passengerCardServices;
        }

        [RelayCommand]
        public async Task SaveAndSend()
        {
            await base.Save();
            await passengerCardServices.SendPassagnerCardAsync(Card);
        }
    }
}
