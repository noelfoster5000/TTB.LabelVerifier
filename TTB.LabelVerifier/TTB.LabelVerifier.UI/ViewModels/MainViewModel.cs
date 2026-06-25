using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using TTB.LabelVerifier.UI.Commands;
using TTB.LabelVerifier.UI.Views;

public class MainViewModel : INotifyPropertyChanged
{
    private object _currentView;

    public object CurrentView
    {
        get => _currentView;
        set { _currentView = value; OnPropertyChanged(); }
    }

    public ICommand NavigateSingleCheckCommand { get; }
    public ICommand NavigateBatchCheckCommand { get; }

    public MainViewModel()
    {
        NavigateSingleCheckCommand = new RelayCommand(_ => CurrentView = new SingleCheckView());
        NavigateBatchCheckCommand = new RelayCommand(_ => CurrentView = new BatchCheckView());

        CurrentView = new SingleCheckView();
    }

    public event PropertyChangedEventHandler PropertyChanged;


    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
