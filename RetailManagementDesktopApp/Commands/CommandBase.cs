using System.Windows.Input;

namespace RetailManagementDesktopApp.Commands;

public abstract class CommandBase: ICommand
{
    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public abstract void Execute(object? parameter);

    public event EventHandler? CanExecuteChanged;
}