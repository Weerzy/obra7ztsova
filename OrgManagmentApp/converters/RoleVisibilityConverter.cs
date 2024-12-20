using System.Globalization;
using System.Windows;
using System.Windows.Data;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Services;

namespace OrgManagmentApp.converters;

public class RoleVisibilityConverter : IValueConverter
{
    public RoleVisibilityConverter()
    {
    }

    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        var userContext = App.ServiceProvider.GetService<IUserContext>();
        if (userContext == null || userContext.CurrentUser?.Role == null)
            return Visibility.Collapsed;

        if (parameter is string roles)
        {
            var allowedRoles = roles.Split(',').Select(int.Parse).ToList();
            return allowedRoles.Contains(userContext.CurrentUser.Role.ID) 
                ? Visibility.Visible 
                : Visibility.Collapsed;
        }
        return Visibility.Collapsed;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}