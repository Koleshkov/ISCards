using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.Services.UserRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.PassengerCardPages;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class CardCreatorInfoPageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        //Services
        private readonly IUserRepository userRepository;

        public CardCreatorInfoPageModel(IUserRepository userRepository,
            ICardRepository<PassengerCard, PassengerCardDTO> repository) : base(repository)
        {
            this.userRepository=userRepository;

            Task.Run(() => InitializeAsync());
        }

        public override async Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(AutoDataPage), NavigationParameters);
        }

        public async Task InitializeAsync()
        {
            if (await userRepository.Any())
            {
                var user = await userRepository.GetUserAsync();

                base.Card.CreatorName = user.UserName;
            }
        }
    }
}
