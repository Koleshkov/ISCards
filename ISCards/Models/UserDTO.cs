using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;


namespace ISCards.Models
{
    public partial class UserDTO : BaseEntityDTO, IMapWith<User>
    {
        [ObservableProperty]
        public string firstName;

        [ObservableProperty]
        public string lastName;

        [ObservableProperty]
        public string middleName;

        public string ShortName => $"{LastName} {FirstName[0]}.{MiddleName[0]}.";

        public string LongName => $"{LastName} {FirstName} {MiddleName}";


        [ObservableProperty]
        public string position;

        [ObservableProperty]
        public string organization;

        [ObservableProperty]
        public string department;

        [ObservableProperty]
        public string phone;

        [ObservableProperty]
        public string email;

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDTO>();
            profile.CreateMap<UserDTO, User>();
        }
    }
}
