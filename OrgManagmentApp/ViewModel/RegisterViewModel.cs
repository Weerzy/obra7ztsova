using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class RegisterViewModel : ObservableValidator
{
    private readonly IUserService _userService;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Имя обязательно")]
    private string firstName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Фамилия обязательна")]
    private string lastName;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Неверный формат email")]
    private string email;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Логин обязателен")]
    private string login;

    public RegisterViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async Task RegisterAsync(object Parameter)
    {
        ValidateAllProperties();
        if (HasErrors)
        {
            MessageBox.Show("А ты знал. что у тебя есть ошибкки в коде?");
        }

        var passwordBox = Parameter as PasswordBox;
        var passwordHash = _userService.ComputeHash(passwordBox.Password);

        var newUser = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Login = Login,
            PasswordHash = passwordHash,
            RoleID = 2 // Роль обычного пользователя
        };

        await _userService.CreateUserAsync(newUser);

        MessageBox.Show("Регистрация успешна!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

        // Закрытие окна регистрации
        Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is RegisterView)?.Close();
    }
}