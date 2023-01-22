using CommunityToolkit.Mvvm.Input;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.Services.SafetyCardServices;
using ISCards.ViewModels.PageModels.Base;

namespace ISCards.ViewModels.PageModels.SafetyCardPageModels
{
    public partial class ReasonsAndActionPageModel : CardPageModelBase<SafetyCard, SafetyCardDTO>
    {
        //Services
        private readonly ISafetyCardService safetyCardService;
        public ReasonsAndActionPageModel(ICardRepository<SafetyCard, SafetyCardDTO> repository,
            ISafetyCardService safetyCardService, IFileIOService fileIOService) : base(repository, fileIOService)
        {
            this.safetyCardService=safetyCardService;
        }

        [RelayCommand]
        public async Task SaveAndSend()
        {
            await base.Save();
            await safetyCardService.SendSafetyCardAsync(Card);
        }
    }
}
