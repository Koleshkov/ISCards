using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace ISCards.ViewModels.PageModels.Base
{
    [ObservableObject]
    public partial class PageModelBase
    {
        [ObservableProperty]
        private string title;
        [RelayCommand]
        public virtual Task GoBack()
        {
            return Shell.Current.GoToAsync("..");
        }
    }
}
