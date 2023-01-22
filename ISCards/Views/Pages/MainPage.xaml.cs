using ISCards.Views.Pages.PassengerCardPages;
using ISCards.Views.Pages.SafetyCardPages;

namespace ISCards.Views.Pages;

public partial class MainPage : Shell
{
	public MainPage()
	{
		InitializeComponent();

        Routing.RegisterRoute(nameof(CardCreatorInfoPage), typeof(CardCreatorInfoPage));
        Routing.RegisterRoute(nameof(AutoDataPage), typeof(AutoDataPage));
        Routing.RegisterRoute(nameof(ReviewAutoPage), typeof(ReviewAutoPage));
        Routing.RegisterRoute(nameof(EvaluationOfDriverActionsPage), typeof(EvaluationOfDriverActionsPage));
        Routing.RegisterRoute(nameof(RoadConditionsPage), typeof(RoadConditionsPage));
        Routing.RegisterRoute(nameof(RoadSurfacePage), typeof(RoadSurfacePage));
        Routing.RegisterRoute(nameof(PassangersCommentPage), typeof(PassangersCommentPage));
        Routing.RegisterRoute(nameof(ActionsPage), typeof(ActionsPage));

        Routing.RegisterRoute(nameof(PersonalDataPage), typeof(PersonalDataPage));
        Routing.RegisterRoute(nameof(DescriptionOfTheSituationPage), typeof(DescriptionOfTheSituationPage));
        Routing.RegisterRoute(nameof(ReasonsAndActionPage), typeof(ReasonsAndActionPage));
    }
}