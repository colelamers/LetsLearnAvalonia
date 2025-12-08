using Avalonia.Controls;
using Avalonia.Input;
using LetsLearnAvalonia.ViewModels;
namespace LetsLearnAvalonia.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void SvgImage_PointerPressed(object? sender, PointerPressedEventArgs e)
     {
        if (e.ClickCount != 2)
        {
            return;
        }

        ((MainWindowViewModel)DataContext!).SideMenuResizeCommand.Execute(null);
     }
}
