using RetailManagementDesktopApp.ViewModels;

namespace RetailManagementDesktopApp.Stores;
public class NavigationStore
{
    public event Action? CurrentViewModelChanged;
    public ViewModelBase? CurrentViewModel
    {
        get;
        set
        {
            field = value;
            CurrentViewModelChanged?.Invoke();
        }
    }
}
