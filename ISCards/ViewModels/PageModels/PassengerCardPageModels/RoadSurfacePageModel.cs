﻿using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.Services.FileIOServices;
using ISCards.Services.Repositories.CardRepositories;
using ISCards.ViewModels.PageModels.Base;
using ISCards.Views.Pages.PassengerCardPages;

namespace ISCards.ViewModels.PageModels.PassengerCardPageModels
{
    public partial class RoadSurfacePageModel : CardPageModelBase<PassengerCard, PassengerCardDTO>
    {
        public RoadSurfacePageModel(
            ICardRepository<PassengerCard, PassengerCardDTO> repository,
            IFileIOService fileIOService) : base(repository, fileIOService)
        {
        }

        public async override Task GoNext()
        {
            await base.GoNext();
            await Shell.Current.GoToAsync(nameof(PassangersCommentPage), NavigationParameters);
        }
    }
}
