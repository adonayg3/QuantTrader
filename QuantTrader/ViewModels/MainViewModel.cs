using QuantTrader.ViewModels.Interfaces;

namespace QuantTrader.ViewModels;

public class MainViewModel : ViewModelBase, IMainViewModel
{
    public string Greeting => "Welcome to Avalonia!";
}