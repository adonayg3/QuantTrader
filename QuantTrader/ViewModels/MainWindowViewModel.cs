using QuantTrader.ViewModels.Interfaces;
using QuantTrader.ViewModels.Interfaces.Sidebar;

namespace QuantTrader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public string Greeting => "Welcome to Avalonia!";
        public ISidebarViewModel? SidebarViewModel { get; }
        public MainWindowViewModel(ISidebarViewModel? sidebarViewModel)
        {
            SidebarViewModel = sidebarViewModel;
        }
        
        // Parameterless constructor required for data context binding 
        public MainWindowViewModel() { }
    }
}