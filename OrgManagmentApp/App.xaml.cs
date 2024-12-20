using System.Configuration;
using System.Data;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Db;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;
using OrgManagmentApp.ViewModel;

namespace OrgManagmentApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ServiceProvider ServiceProvider { get; private set; }

    protected override async void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var initializer = ServiceProvider.GetRequiredService<DatabaseInitializer>();
        await initializer.InitializeAsync();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>();

        services.AddSingleton<IUserContext, UserContext>();
        services.AddTransient<IUserService, UserService>();
        services.AddTransient<IEventService, EventService>();
        services.AddTransient<IEventCategoryService, EventCategoryService>();
        services.AddTransient<IOrganizerService, OrganizerService>();
        services.AddTransient<ITicketService, TicketService>();
        services.AddTransient<ILevelService, LevelService>();
        services.AddTransient<IRoleService, RoleService>();
        services.AddTransient<IEventAddressService, EventAddressService>();
        services.AddTransient<Categories>();
        services.AddTransient<CreateCategoryViewModel>();
        services.AddTransient<CreateEventCategory>();
        services.AddTransient<CategoriesViewModel>();
        services.AddTransient<IEventTicketLevelService, EventTicketLevelService>();

        services.AddTransient<LoginViewModel>();
        services.AddTransient<MainViewModel>();
        services.AddTransient<EventViewModel>();
        services.AddTransient<AdminTicketsViewModel>();
        services.AddTransient<RegisterViewModel>();
        services.AddTransient<AdminViewModel>();
        services.AddTransient<CreateUserViewModel>();
        services.AddTransient<TicketViewModel>();
        services.AddTransient<UserTicketsViewModel>();

        services.AddTransient<LoginView>();
        services.AddTransient<RegisterView>();
        services.AddTransient<TicketView>();
        services.AddTransient<AdminView>();
        services.AddTransient<CreateUserView>();
        services.AddTransient<UserTicketsView>();
        services.AddTransient<MainView>();
        services.AddTransient<EventView>();
        services.AddTransient<AdminTicketsView>();
        services.AddScoped<DatabaseInitializer>();
    }
}