using System.ComponentModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Services;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class LoginViewModel : ObservableValidator
{
    private readonly IUserService _userService;

    [ObservableProperty]
    [Required(ErrorMessage = "Логин обязателен")]
    private string login;

    private IUserContext _userContext;

    public LoginViewModel(IUserService userService, IUserContext userContext)
    {
        _userService = userService;
        _userContext = userContext;
    }
    
    [RelayCommand]
    private void OpenRegister()
    {
        var registerView = App.ServiceProvider.GetRequiredService<RegisterView>();
        registerView.Show();
    }

    [RelayCommand]
    private async Task Auth()
    {
        if (HasErrors)
        {
            var errors = GetErrors();
            var enumerator = errors.GetEnumerator();
            MessageBox.Show(enumerator.Current.ErrorMessage);
        }

        var loginView = Application.Current.Windows.OfType<LoginView>().First();
        var user = await _userService.AuthenticateAsync(Login, loginView.PasswordBox.Password);
        if (user is not null)
        {
            _userContext.CurrentUser = user;

            var mainView = App.ServiceProvider.GetRequiredService<MainView>();
            mainView.Show();

            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is LoginView)?.Close();
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is MainWindow)?.Close();
        }
        else
        {
            MessageBox.Show("Неправильный логин или пароль");
        }
    }
    
    protected override void OnPropertyChanged(PropertyChangedEventArgs e)
    {
        base.OnPropertyChanged(e);
        ValidateProperty(e.PropertyName);
    }

    private void ValidateProperty(string propertyName)
    {
        // Добавьте логику валидации для каждого свойства
    }
}