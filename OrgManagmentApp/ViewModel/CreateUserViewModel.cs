using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Extensions;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class CreateUserViewModel : ObservableValidator
    {
        private readonly IUserService _userService;
        private readonly IRoleService _roleService;

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

        [ObservableProperty]
        [NotifyDataErrorInfo]
        [Required(ErrorMessage = "Роль обязательна")]
        private Role selectedRole;

        public ObservableCollection<Role> Roles { get; } = new();

        public CreateUserViewModel(IUserService userService, IRoleService roleService)
        {
            _userService = userService;
            _roleService = roleService;

            LoadRolesAsync();
        }

        private async Task LoadRolesAsync()
        {
            var roles = await _roleService.GetAllRolesAsync();
            Roles.AddRange(roles);
        }

        [RelayCommand]
        private async Task CreateUserAsync(object Parameter)
        {
            ValidateAllProperties();
            if (HasErrors)
            {
                return;
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
                RoleID = SelectedRole.ID
            };

            await _userService.CreateUserAsync(newUser);

            MessageBox.Show("Пользователь успешно создан!", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

            // Закрытие окна
            Application.Current.Windows.OfType<Window>().FirstOrDefault(w => w is CreateUserView)?.Close();
        }
    }