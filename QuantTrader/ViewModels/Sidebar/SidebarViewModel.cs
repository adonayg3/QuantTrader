using QuantTrader.ViewModels.Interfaces.Sidebar;

namespace QuantTrader.ViewModels.Sidebar;

public class SidebarViewModel : ViewModelBase, ISidebarViewModel
{ 
    public ISidebarNavViewModel? SidebarNavViewModel { get; }

    public SidebarViewModel(ISidebarNavViewModel sidebarNavViewModel)
    {
        SidebarNavViewModel = sidebarNavViewModel;
    }

    public SidebarViewModel() { }
}