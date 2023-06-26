using System.ComponentModel;
using System.Windows.Input;

public class RelayCommand : ICommand //MvvmCommand, WpfCommand
{
    private Action<object> execute;
    private Func<object, bool> canExecute;
    private INotifyPropertyChanged npc;

    public RelayCommand(INotifyPropertyChanged npc, Action<object> execute, Func<object, bool> canExecute = null)
    {
        this.npc = npc;
        this.npc.PropertyChanged += npc_PropertyChanged;
        if (execute == null) throw new ArgumentNullException(nameof(execute));
        this.execute = execute;
        this.canExecute = canExecute;
    }

    private void npc_PropertyChanged(object sender, PropertyChangedEventArgs e)
    {
        if (CanExecuteChanged != null) CanExecuteChanged(this, EventArgs.Empty);
    }

    public event EventHandler CanExecuteChanged; //nie zagospodarowane

    public bool CanExecute(object parameter)
    {
        if (canExecute == null) return true;
        else return canExecute(parameter);
    }

    public void Execute(object parameter)
    {
        execute(parameter);
    }
}