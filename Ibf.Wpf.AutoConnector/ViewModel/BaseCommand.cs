using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Ibf.Wpf.AutoConnector.ViewModel;

public class BaseCommand : BindableBase, ICommand
{
    private readonly Func<Task> action;
    private bool busy;

    public BaseCommand(Func<Task> action)
    {
        this.action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public async void Execute(object? parameter)
    {
        if (Busy)
        {
            return;
        }

        try
        {
            Busy = true;
            await action();
        }
        catch (Exception e)
        {
            MessageBox.Show(e.Message);
        }
        finally
        {
            Busy = false;
        }
    }

    public bool Busy
    {
        get => busy;
        set => SetField(ref busy, value);
    }

    public event EventHandler? CanExecuteChanged;
}