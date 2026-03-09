using System.Windows;
using RetailManagementDesktopApp.ViewModels;
using RetailManagementDesktopApp.Views;

namespace RetailManagementDesktopApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App
{
    private readonly MainWindowViewModel _viewModel = new();
    private readonly MainWindowView _view;

    public App()
    {
        _view = new() { DataContext = _viewModel };
    }
    
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _view.Show();
    }
}