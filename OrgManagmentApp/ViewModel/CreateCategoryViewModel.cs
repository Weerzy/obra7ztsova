using System.ComponentModel.DataAnnotations;
using System.Windows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OrgManagmentApp.Models;
using OrgManagmentApp.Services;
using OrgManagmentApp.View;

namespace OrgManagmentApp.ViewModel;

public partial class CreateCategoryViewModel : ObservableValidator
{
    private readonly IEventCategoryService _categoryService;
    
    public CreateCategoryViewModel(IEventCategoryService categoryService)
    {
        _categoryService = categoryService;
    }
    
    private EventCategory? _editingCategory;
    
    [ObservableProperty]
    private string title;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [Required(ErrorMessage = "Название категории обязательно")]
    [MinLength(2, ErrorMessage = "Название должно содержать минимум 2 символа")]
    [MaxLength(50, ErrorMessage = "Название не должно превышать 50 символов")]
    private string? name;

    [ObservableProperty]
    [NotifyDataErrorInfo]
    [MaxLength(200, ErrorMessage = "Описание не должно превышать 200 символов")]
    private string? description;
    
    public void SetCategory(EventCategory? category)
    {
        _editingCategory = category;
        
        if (category != null)
        {
            Name = category.Name;
            Description = category.Description;
            Title = "Редактирование категории";
        }
        else
        {
            Name = null;
            Description = null;
            Title = "Добавление категории";
        }
    }

    [RelayCommand]
    private async Task Save()
    {
        ValidateAllProperties();
        
        if (HasErrors)
        {
            return;
        }

        if (_editingCategory != null)
        {
            // Обновляем существующую категорию
            _editingCategory.Name = Name!;
            _editingCategory.Description = Description;
            await _categoryService.UpdateCategoryAsync(_editingCategory);
            MessageBox.Show("Категория успешно отредактирована!", "Инфо", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Application.Current.Windows.OfType<CreateEventCategory>().First().Close();
        }
        else
        {
            // Создаем новую категорию
            var category = new EventCategory
            {
                Name = Name!,
                Description = Description
            };
            await _categoryService.AddCategoryAsync(category);
            MessageBox.Show("Новая категория успешно добавлена!", "Инфо", MessageBoxButton.OK,
                MessageBoxImage.Information);
            Application.Current.Windows.OfType<CreateEventCategory>().First().Close();
        }
    }

    [RelayCommand]
    private void Cancel()
    {
        Application.Current.Windows.OfType<CreateEventCategory>().First().Close();
    }
}