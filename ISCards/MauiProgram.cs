using ISCards.Common.Mappings;
using ISCards.Data;
using ISCards.ViewModels.PageModels;
using Microsoft.EntityFrameworkCore;
using System.Reflection;
using ISCards.Views.Pages;
using ISCards.Services.PassengerCardServices;
using ISCards.Services.FileIOServices;
using ISCards.Services.CardRepositories;
using ISCards.Data.Entities;
using ISCards.Models;
using ISCards.ViewModels.PageModels.PassengerCardPageModels;
using ISCards.Views.Pages.PassengerCardPages;
using ISCards.Services.UserRepositories;
using CommunityToolkit.Maui;
using ISCards.Services.SafetyCardServices;
using ISCards.Views.Pages.SafetyCardPages;
using ISCards.ViewModels.PageModels.SafetyCardPageModels;

namespace ISCards;

public static class MauiProgram
{
    private static IServiceProvider serviceProvider;
    public static IServiceProvider ServiceProvider =>
        serviceProvider ?? throw new Exception("Service provider has not been initialized");

    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        var services = builder.Services;
        var configuration = builder.Configuration;

        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        builder.UseMauiApp<App>().UseMauiCommunityToolkit();

        //Register Services
        //services.AddDbContext<ApplicationContext>(opt =>
        //    opt.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "appdata.db")}"));

        services.AddDbContextFactory<ApplicationContext>(opt=>
            opt.UseSqlite($"Data Source={Path.Combine(FileSystem.AppDataDirectory, "appdata.db")}"));

        services.AddAutoMapper(config =>
        {
            config.AddProfile(new AssemblyMappingProfile(Assembly.GetExecutingAssembly()));
            config.AddProfile(new AssemblyMappingProfile(typeof(ApplicationContext).Assembly));
        });

        services.AddTransient<IPassengerCardService, PassengerCardService>();
        services.AddTransient<ISafetyCardService, SafetyCardService>();
        services.AddTransient<IFileIOService, FileIOService>();

        services.AddTransient<ICardRepository<PassengerCard, PassengerCardDTO>, CardRepository<PassengerCard, PassengerCardDTO>>();
        services.AddTransient<ICardRepository<SafetyCard, SafetyCardDTO>, CardRepository<SafetyCard, SafetyCardDTO>>();
        services.AddTransient<IUserRepository, UserRepository>();

        //Register Pages
        services.AddTransient<MainPageModel>();
        services.AddTransient(s => new MainPage
        {
            BindingContext = s.GetRequiredService<MainPageModel>()
        });

        services.AddTransient<PassengerCardListPageModel>();
        services.AddTransient(s => new PassengerCardListPage
        {
            BindingContext = s.GetRequiredService<PassengerCardListPageModel>()
        });

        services.AddTransient<SafetyCardListPageModel>();
        services.AddTransient(s => new SafetyCardListPage
        {
            BindingContext = s.GetRequiredService<SafetyCardListPageModel>()
        });

        services.AddTransient<PersonalDataPageModel>();
        services.AddTransient(s => new PersonalDataPage
        {
            BindingContext = s.GetRequiredService<PersonalDataPageModel>()
        });

        services.AddTransient<DescriptionOfTheSituationPageModel>();
        services.AddTransient(s => new DescriptionOfTheSituationPage
        {
            BindingContext = s.GetRequiredService<DescriptionOfTheSituationPageModel>()
        });

        services.AddTransient<ReasonsAndActionPageModel>();
        services.AddTransient(s => new ReasonsAndActionPage
        {
            BindingContext = s.GetRequiredService<ReasonsAndActionPageModel>()
        });



        services.AddTransient<SettingsPageModel>();
        services.AddTransient(s => new SettingsPage
        {
            BindingContext = s.GetRequiredService<SettingsPageModel>()
        });

        services.AddTransient<AboutPageModel>();
        services.AddTransient(s => new AboutPage
        {
            BindingContext = s.GetRequiredService<AboutPageModel>()
        }) ;

        #region Inject Passenger Card Pages
        services.AddTransient<CardCreatorInfoPageModel>();
        services.AddTransient(s => new CardCreatorInfoPage
        {
            BindingContext = s.GetRequiredService<CardCreatorInfoPageModel>()
        });

        services.AddTransient<AutoDataPageModel>();
        services.AddTransient(s => new AutoDataPage
        {
            BindingContext = s.GetRequiredService<AutoDataPageModel>()
        });

        services.AddTransient<ViewAutoPageModel>();
        services.AddTransient(s => new ReviewAutoPage
        {
            BindingContext = s.GetRequiredService<ViewAutoPageModel>()
        });

        services.AddTransient<EvaluationOfDriverActionsPageModel>();
        services.AddTransient(s => new EvaluationOfDriverActionsPage
        {
            BindingContext = s.GetRequiredService<EvaluationOfDriverActionsPageModel>()
        });

        services.AddTransient<RoadConditionsPageModel>();
        services.AddTransient(s => new RoadConditionsPage
        {
            BindingContext = s.GetRequiredService<RoadConditionsPageModel>()
        });

        services.AddTransient<RoadSurfacePageModel>();
        services.AddTransient(s => new RoadSurfacePage
        {
            BindingContext = s.GetRequiredService<RoadSurfacePageModel>()
        });

        services.AddTransient<PassangersCommentPageModel>();
        services.AddTransient(s => new PassangersCommentPage
        {
            BindingContext = s.GetRequiredService<PassangersCommentPageModel>()
        });

        services.AddTransient<ActionsPageModel>();
        services.AddTransient(s => new ActionsPage
        {
            BindingContext = s.GetRequiredService<ActionsPageModel>()
        });

        #endregion



        //Build Adpp
        var app = builder.Build();
        serviceProvider=app.Services;

        return app;
    }
}
