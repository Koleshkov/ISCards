using CommunityToolkit.Mvvm.ComponentModel;

namespace ISCards.Models
{
    public partial class BaseEntityDTO : ObservableObject
    {
        [ObservableProperty]
        private int id;
    }
}
