using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.SafetyCardPages;

namespace ISCards.ViewModels.PageModels.SafetyCardPageModels
{
    public partial class DescriptionOfTheSituationPageModel : CardPageModelBase<SafetyCard, SafetyCardDTO>
    {
        public DescriptionOfTheSituationPageModel(
            ICardRepository<SafetyCard, SafetyCardDTO> repository, 
            IFileIOService fileIOService) : base(repository, fileIOService)
        {

        }

        public async override Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(ReasonsAndActionPage), NavigationParameters);
        }
    }
}
