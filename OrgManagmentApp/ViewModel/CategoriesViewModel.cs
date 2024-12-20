using System.Collections.ObjectModel;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class CategoriesViewModel : ObservableValidator
{
    private readonly IEventCategoryService _categoryService;

    [ObservableProperty]
    private ObservableCollection<EventCategory> categories;

    [ObservableProperty]
    private EventCategory selectedCategory;
    
    public CategoriesViewModel(IEventCategoryService categoryService)
    {
        _categoryService = categoryService;
        LoadData();
    }

    private void LoadData()
    {
        var categories = _categoryService.GetAllCategoriesAsync();
        Categories = new ObservableCollection<EventCategory>(categories);
    }

    [RelayCommand]
    public void AddEventCategory()
    {
        var window = App.ServiceProvider.GetService<CreateEventCategory>();
        window.ShowDialog();
        LoadData();
    }
    
    [RelayCommand]
    public void EditEventCategory()
    {
        if (SelectedCategory != null)
        {
            var window = App.ServiceProvider.GetService<CreateEventCategory>();
            var context = window.DataContext as CreateCategoryViewModel;
            context.SetCategory(SelectedCategory);
            window.ShowDialog();  
            LoadData();
            return;
        }

        MessageBox.Show("Для редактирования выберите объект, который вы хотите отредактировать", "Внимание", MessageBoxButton.OK, MessageBoxImage.Information);

    }

    [RelayCommand]
    public async Task RemoveEventCategory()
    {
        if (SelectedCategory is null)
        {
            MessageBox.Show("Выберите категорию, которую необходимо удалить!", "Инфо", MessageBoxButton.OK,
                MessageBoxImage.Information);
            return;
        }

        await _categoryService.DeleteCategoryAsync(SelectedCategory);
        LoadData();
    }
    
}