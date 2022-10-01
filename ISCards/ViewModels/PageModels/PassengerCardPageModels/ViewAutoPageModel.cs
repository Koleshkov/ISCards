using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.PassengerCardPages;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class ViewAutoPageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        public ViewAutoPageModel(ICardRepository<PassengerCard, PassengerCardDTO> repository) : base(repository)
        {
        }

        public override async Task GoNext()
        {
            await base.GoNext();

            await Shell.Current.GoToAsync(nameof(EvaluationOfDriverActionsPage), NavigationParameters);
        }
    }
}
