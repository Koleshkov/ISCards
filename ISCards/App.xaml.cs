using ISCards.Views.Pages;

namespace ISCards;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

        MainPage = MauiProgram.ServiceProvider.GetRequiredService<MainPage>();
    }
}
