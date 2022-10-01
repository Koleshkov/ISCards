using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.CardRepositories;
using ISCards.Services.UserRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.SafetyCardPages;


namespace ISCards.ViewModels.PageModels.SafetyCardPageModels
{
    public partial class PersonalDataPageModel : CardPageModelBase<SafetyCard, SafetyCardDTO>
    {
        //Services
        private readonly IUserRepository userRepository;

        public PersonalDataPageModel(IUserRepository userRepository,
            ICardRepository<SafetyCard, SafetyCardDTO> repository) : base(repository)
        {
            this.userRepository=userRepository;

            Task.Run(() => InitializeAsync());
        }

        public override async Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(DescriptionOfTheSituationPage), NavigationParameters);
        }

        public async Task InitializeAsync()
        {
            if (await userRepository.Any())
            {
                var user = await userRepository.GetUserAsync();

                base.Card.CreatorName = user.UserName;
                base.Card.Organization = user.Organization;
                base.Card.Department = user.Department;
                base.Card.Position = user.Position;
                base.Card.Phone = user.Phone;
                base.Card.Email = user.Email;
            }
        }
    }
}
