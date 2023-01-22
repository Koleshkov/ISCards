using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.Services.Repositories.UserRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.PassengerCardPages;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class CardCreatorInfoPageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        //Services
        private readonly IUserRepository userRepository;

        public CardCreatorInfoPageModel(IUserRepository userRepository,
            ICardRepository<PassengerCard, PassengerCardDTO> repository,
            IFileIOService fileIOService) : base(repository, fileIOService)
        {
            this.userRepository=userRepository;

            Task.Run(() => InitializeAsync());
        }


        public override async Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(AutoDataPage), NavigationParameters);
        }

        protected override async void InitializeAsync()
        {
            if (await userRepository.Any())
            {
                var user = await userRepository.GetUserAsync();

                base.Card.FirstName = user.FirstName;
                base.Card.LastName = user.LastName;
                base.Card.MiddleName = user.MiddleName;
            }
        }
    }
}
