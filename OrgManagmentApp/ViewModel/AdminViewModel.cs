using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class AdminViewModel : ObservableObject
{
    private readonly IUserService _userService;
    private readonly IRoleService _roleService;

    [ObservableProperty]
    private ObservableCollection<User> users;

    [ObservableProperty]
    private User selectedUser;

    public AdminViewModel(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;

        LoadUsersAsync();
    }

    private async Task LoadUsersAsync()
    {
        var userList = await _userService.GetAllUsersAsync();
        Users = new ObservableCollection<User>(userList);
    }

    [RelayCommand]
    private void CreateUser()
    {
        var createUserView = App.ServiceProvider.GetRequiredService<CreateUserView>();
        createUserView.ShowDialog();
        LoadUsersAsync();
    }

    [RelayCommand]
    private async Task DeleteUserAsync()
    {
        if (SelectedUser != null)
        {
            await _userService.DeleteUserAsync(SelectedUser.ID);
            LoadUsersAsync();
        }
        else
        {
            MessageBox.Show("Пожалуйста, выберите пользователя для удаления.", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}