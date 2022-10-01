using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;

namespace ISCards.Models
{
    public partial class PassengerCardDTO: BaseCardDTO, IMapWith<PassengerCard>
    {
        public PassengerCardDTO() : base(cardType: "Карта пассажира") { }

        [ObservableProperty]
        private bool isSent;

        [ObservableProperty]
        private bool workStopped;

        [ObservableProperty]
        private string nameOfOrganization="";

        [ObservableProperty]
        private string numberOfAuto="";

        [ObservableProperty]
        private string typeOfAuto="";

        [ObservableProperty]
        private bool emergencyKit;

        [ObservableProperty]
        private bool monitoringSystem;

        [ObservableProperty]
        private bool foreignObjects;

        [ObservableProperty]
        private bool routePassport;

        [ObservableProperty]
        private bool busPassport;

        [ObservableProperty]
        private bool seatBeltsFastened;

        [ObservableProperty]
        private bool cargoFixed;

        [ObservableProperty]
        private bool safeLaneChange;

        [ObservableProperty]
        private bool keepingDistance;

        [ObservableProperty]
        private bool speedLimit;

        [ObservableProperty]
        private bool safeBehavior;

        [ObservableProperty]
        private bool noCell;

        [ObservableProperty]
        private bool controlOfAuto;

        [ObservableProperty]
        private bool notEat;

        [ObservableProperty]
        private bool understandsRoadConditions;

        [ObservableProperty]
        private bool roadSignRequirements;

        [ObservableProperty]
        private bool timelyTurnOffTheLights;

        [ObservableProperty]
        private bool attentionToPedestrians;

        [ObservableProperty]
        private bool giveWay;

        [ObservableProperty]
        private bool autoSafelyInReverse;

        [ObservableProperty]
        private bool handbrakeUsing;

        [ObservableProperty]
        private bool restRegime;

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
        private string actions="";


        public void Mapping(Profile profile)
        {
            profile.CreateMap<PassengerCard, PassengerCardDTO>();
            profile.CreateMap<PassengerCardDTO, PassengerCard>();
        }
    }
}
