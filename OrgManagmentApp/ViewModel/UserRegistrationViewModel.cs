using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;

namespace OrgManagmentApp.ViewModel;

public partial class UserRegistrationViewModel : ObservableValidator
{
    private readonly IUserService _userService;

    [ObservableProperty]
    [Required(ErrorMessage = "Имя обязательно")]
    private string firstName;

    [ObservableProperty]
    [Required(ErrorMessage = "Фамилия обязательна")]
    private string lastName;

    [ObservableProperty]
    [Required(ErrorMessage = "Email обязателен")]
    [EmailAddress(ErrorMessage = "Неверный формат email")]
    private string email;

    [ObservableProperty]
    [Required(ErrorMessage = "Логин обязателен")]
    private string login;

    [ObservableProperty]
    [Required(ErrorMessage = "Пароль обязателен")]
    private string password;

    public UserRegistrationViewModel(IUserService userService)
    {
        _userService = userService;
    }

    [RelayCommand]
    private async void Register()
    {
        if (HasErrors)
        {
            // Обработка ошибок валидации
            return;
        }

        var passwordHash = ComputeHash(Password);

        var newUser = new User
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Login = Login,
            PasswordHash = passwordHash,
            RoleID = 1 // Присваиваем роль по умолчанию
        };

        await _userService.CreateUserAsync(newUser);
        // Уведомить пользователя об успешной регистрации
    }

    private string ComputeHash(string input)
    {
        using var sha256 = SHA256.Create();
        var bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
        var builder = new StringBuilder();
        foreach (var b in bytes)
            builder.Append(b.ToString("x2"));
        return builder.ToString();
    }
}