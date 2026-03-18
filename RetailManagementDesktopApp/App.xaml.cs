using RetailManagementDesktopApp.ViewModels;
using System.Windows;


namespace RetailManagementDesktopApp;
public partial class App : Application
{
    readonly MainViewModel _mainViewModel;

    public App()
    {
        _mainViewModel = new MainViewModel();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);

        MainWindow window = new(_mainViewModel);
        window.Show();
    }
}