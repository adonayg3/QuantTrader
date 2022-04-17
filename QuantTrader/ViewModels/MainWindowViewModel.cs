using QuantTrader.ViewModels.Interfaces;
using QuantTrader.ViewModels.Interfaces.Sidebar;

namespace QuantTrader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        public ISidebarViewModel? SidebarViewModel { get; }
        public IMainViewModel? MainViewModel { get; }
        public MainWindowViewModel(ISidebarViewModel? sidebarViewModel, IMainViewModel? mainViewModel)
        {
            SidebarViewModel = sidebarViewModel;
            MainViewModel = mainViewModel;
        }
        
        // Parameterless constructor required for data context binding 
        public MainWindowViewModel() { }
    }
}