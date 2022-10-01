using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;

namespace ISCards.Models
{
    public partial class SafetyCardDTO : BaseCardDTO, IMapWith<SafetyCard>
    {
        public SafetyCardDTO() : base(cardType: "ЭКФ")
        {
        }

        [ObservableProperty]
        private string position;

        [ObservableProperty]
        private string phone;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string organization;

        [ObservableProperty]
        private string department;

        [ObservableProperty]
        private string jobObject;

        [ObservableProperty]
        private string typeOfAction;

        [ObservableProperty]
        private string description;

        [ObservableProperty]
        private string actions;

        [ObservableProperty]
        private string reasons;

        [ObservableProperty]
        private string plannedEvents;

        [ObservableProperty]
        private string status;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<SafetyCard, SafetyCardDTO>();
            profile.CreateMap<SafetyCardDTO, SafetyCard>();
        }
    }
}
