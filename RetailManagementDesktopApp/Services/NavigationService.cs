using RetailManagementDesktopApp.Stores;
using RetailManagementDesktopApp.ViewModels;

namespace RetailManagementDesktopApp.Services;

public class NavigationService<TViewModel>(NavigationStore navigationStore, 
    Func<TViewModel> createViewModel)
     where TViewModel : ViewModelBase
{
    public NavigationService(): this(new NavigationStore(), () => default(TViewModel)!)
    {
        
    }

    public void Navigate()
    {
        navigationStore.CurrentViewModel = createViewModel();
    }
}
