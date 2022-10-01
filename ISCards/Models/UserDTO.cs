using AutoMapper;
using CommunityToolkit.Mvvm.ComponentModel;
using ISCards.Common.Mappings;
using ISCards.Data.Entities;

namespace ISCards.Models
{
    public partial class UserDTO : BaseDTO, IMapWith<User>
    {
        [ObservableProperty]
        public string userName;

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
