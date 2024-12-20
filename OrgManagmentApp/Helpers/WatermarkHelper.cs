using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace OrgManagmentApp.Helpers;

public static class WatermarkHelper
{
    public static readonly DependencyProperty WatermarkProperty =
        DependencyProperty.RegisterAttached(
            "Watermark", typeof(string), typeof(WatermarkHelper),
            new PropertyMetadata(string.Empty, OnWatermarkChanged));

    public static string GetWatermark(DependencyObject obj)
    {
        return (string)obj.GetValue(WatermarkProperty);
    }

    public static void SetWatermark(DependencyObject obj, string value)
    {
        obj.SetValue(WatermarkProperty, value);
    }

    private static void OnWatermarkChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (d is TextBox textBox)
        {
            textBox.Loaded += TextBox_Loaded;
            textBox.GotFocus += RemoveWatermark;
            textBox.LostFocus += ShowWatermark;
        }
    }

    private static void TextBox_Loaded(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
        {
            ShowWatermark(textBox, null);
        }
    }

    private static void ShowWatermark(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && string.IsNullOrEmpty(textBox.Text))
        {
            textBox.Foreground = new SolidColorBrush(Colors.Gray);
            textBox.Text = GetWatermark(textBox);
        }
    }

    private static void RemoveWatermark(object sender, RoutedEventArgs e)
    {
        if (sender is TextBox textBox && textBox.Text == GetWatermark(textBox))
        {
            textBox.Text = string.Empty;
            textBox.Foreground = new SolidColorBrush(Colors.Black);
        }
    }
}