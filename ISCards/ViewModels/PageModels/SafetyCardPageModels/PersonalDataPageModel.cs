using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.Services.Repositories.UserRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.SafetyCardPages;

namespace ISCards.ViewModels.PageModels.SafetyCardPageModels
{
    public partial class PersonalDataPageModel : CardPageModelBase<SafetyCard, SafetyCardDTO>
    {
        //Services
        private readonly IUserRepository userRepository;

        public PersonalDataPageModel(IUserRepository userRepository,
            ICardRepository<SafetyCard, SafetyCardDTO> repository,
            IFileIOService fileIOService) : base(repository, fileIOService)
        {
            this.userRepository=userRepository;

            Task.Run(()=>InitializeAsync());
        }

        public override async Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(DescriptionOfTheSituationPage), NavigationParameters);
        }

        protected override async void InitializeAsync()
        {
            if (await userRepository.Any())
            {
                var user = await userRepository.GetUserAsync();

                base.Card.FirstName = user.FirstName;
                base.Card.LastName = user.LastName;
                base.Card.MiddleName = user.MiddleName;
                base.Card.Organization = user.Organization;
                base.Card.Department = user.Department;
                base.Card.Position = user.Position;
                base.Card.Phone = user.Phone;
                base.Card.Email = user.Email;
            }
        }
    }
}
