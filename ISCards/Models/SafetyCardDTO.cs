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

        private string firstName = "";
        public override string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
                CardName = $"{CardType}_{LastName}_{value}_{MiddleName}_{CreationDate.ToShortDateString()}";
                OnPropertyChanged(nameof(FirstName));
            }
        }

        private string lastName = "";
        public override string LastName
        {
            get
            {
                return lastName;
            }
            set
            {
                lastName = value;
                CardName = $"{CardType}_{value}_{FirstName}_{MiddleName}_{CreationDate.ToShortDateString()}";
                OnPropertyChanged(nameof(LastName));
            }
        }

        private string middleName = "";
        public override string MiddleName
        {
            get
            {
                return middleName;
            }
            set
            {
                middleName = value;
                CardName = $"{CardType}_{LastName}_{FirstName}_{value}_{CreationDate.ToShortDateString()}";
                OnPropertyChanged(nameof(MiddleName));
            }
        }

        private DateTime creationDate = DateTime.Now;
        public override DateTime CreationDate
        {
            get
            {
                return creationDate;
            }
            set
            {
                creationDate = value;
                CardName=$"{CardType}_{LastName}_{FirstName}_{MiddleName}_{value.ToShortDateString()}";
                CardTitle = $"{CardType} {value}";
                OnPropertyChanged(nameof(CreationDate));
            }
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
