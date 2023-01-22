using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;

namespace ISCards.Models
{
    public partial class PassengerCardDTO : BaseCardDTO, IMapWith<PassengerCard>
    {
        public PassengerCardDTO() : base(cardType: "КНП") { }

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

                CardName = $"{CreationDate.ToShortDateString()}_" +
                    $"{CardType}_{LastName}_" +
                    $"{(String.IsNullOrWhiteSpace(value) ? "" : value[0])}." +
                    $"{(String.IsNullOrWhiteSpace(MiddleName) ? "" : MiddleName[0])}";

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

                CardName = $"{CreationDate.ToShortDateString()}_" +
                    $"{CardType}_{value}_" +
                    $"{(String.IsNullOrWhiteSpace(FirstName) ? "" : FirstName[0])}." +
                    $"{(String.IsNullOrWhiteSpace(MiddleName) ? "" : MiddleName[0])}";

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

                CardName = $"{CreationDate.ToShortDateString()}_" +
                    $"{CardType}_{LastName}_" +
                    $"{(String.IsNullOrWhiteSpace(FirstName) ? "" : FirstName[0])}." +
                    $"{(String.IsNullOrWhiteSpace(value) ? "" : value[0])}";

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

                CardName=$"{value.ToShortDateString()}_" +
                    $"{CardType}_{LastName}_" +
                    $"{(String.IsNullOrWhiteSpace(FirstName) ? "" : FirstName[0])}." +
                    $"{(String.IsNullOrWhiteSpace(MiddleName) ? "" : MiddleName[0])}";

                CardTitle = $"{CardType} {value}";

                OnPropertyChanged(nameof(CreationDate));
            }
        }



        [ObservableProperty]
        private bool workStopped;

        [ObservableProperty]
        private string nameOfOrganization = "";

        [ObservableProperty]
        private string numberOfAuto = "";

        [ObservableProperty]
        private string typeOfAuto = "";

        [ObservableProperty]
        private bool emergencyKit = true;

        [ObservableProperty]
        private bool monitoringSystem = true;

        [ObservableProperty]
        private bool foreignObjects = true;

        [ObservableProperty]
        private bool routePassport = true;

        [ObservableProperty]
        private bool busPassport = true;

        [ObservableProperty]
        private bool seatBeltsFastened = true;

        [ObservableProperty]
        private bool cargoFixed = true;

        [ObservableProperty]
        private bool safeLaneChange = true;

        [ObservableProperty]
        private bool keepingDistance = true;

        [ObservableProperty]
        private bool speedLimit = true;

        [ObservableProperty]
        private bool safeBehavior = true;

        [ObservableProperty]
        private bool noCell = true;

        [ObservableProperty]
        private bool controlOfAuto = true;

        [ObservableProperty]
        private bool notEat = true;

        [ObservableProperty]
        private bool understandsRoadConditions = true;

        [ObservableProperty]
        private bool roadSignRequirements = true;

        [ObservableProperty]
        private bool timelyTurnOffTheLights = true;

        [ObservableProperty]
        private bool attentionToPedestrians = true;

        [ObservableProperty]
        private bool giveWay = true;

        [ObservableProperty]
        private bool autoSafelyInReverse = true;

        [ObservableProperty]
        private bool handbrakeUsing = true;

        [ObservableProperty]
        private bool restRegime = true;

        [ObservableProperty]
        private bool clear;

        [ObservableProperty]
        private bool snow;

        [ObservableProperty]
        private bool cloud;

        [ObservableProperty]
        private bool rainHail;

        [ObservableProperty]
        private bool sun;

        [ObservableProperty]
        private bool night;

        [ObservableProperty]
        private bool rain;

        [ObservableProperty]
        private bool dirt;

        [ObservableProperty]
        private bool asphalt;

        [ObservableProperty]
        private bool ice;

        [ObservableProperty]
        private bool gravel;

        [ObservableProperty]
        private bool offRoad;

        [ObservableProperty]
        private bool ground;

        [ObservableProperty]
        private string passengerComment = "";

        [ObservableProperty]
        private string actions = "";


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PassengerCard, PassengerCardDTO>();
            profile.CreateMap<PassengerCardDTO, PassengerCard>();
        }
    }
}
