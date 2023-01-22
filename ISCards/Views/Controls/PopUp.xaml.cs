using CommunityToolkit.Maui.Views;
namespace ISCards.Views.Controls;

public partial class PopUp : Popup
{
    public PopUp(string message)
    {
        InitializeComponent();

        MsgPopUp.Text=message;
    }
}