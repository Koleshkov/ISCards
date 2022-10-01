using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.Services.SafetyCardServices;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages;

namespace ISCards.ViewModels.PageModels.SafetyCardPageModels
{
    public partial class ReasonsAndActionPageModel : CardPageModelBase<SafetyCard, SafetyCardDTO>
    {
        //Services
        private readonly ISafetyCardService safetyCardService;
        public ReasonsAndActionPageModel(ICardRepository<SafetyCard, SafetyCardDTO> repository, 
            ISafetyCardService safetyCardService) : base(repository)
        {
            this.safetyCardService=safetyCardService;
        }

        [RelayCommand]
        public async Task SaveAndSend()
        {
            await Save();
            await safetyCardService.SendSafetyCardAsync(Card);
        }
    }
}
