using Avalonia.Controls;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;

namespace AvaloniaApplication1;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        AvaloniaXamlLoader.Load(this);
    }

    private void BasicBtn_OnClick(object? sender, RoutedEventArgs e)
    {
        BasicBtn.Content = "Basic Button";
         
    }
}