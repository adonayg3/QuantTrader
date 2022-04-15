using QuantTrader.ViewModels.Interfaces.Sidebar;

namespace QuantTrader.ViewModels.Sidebar;

public class SidebarViewModel : ViewModelBase, ISidebarViewModel
{
    public ISidebarLogoViewModel? SidebarLogoViewModel { get; }

    public ISidebarNavViewModel? SidebarNavViewModel { get; }

    public SidebarViewModel(ISidebarLogoViewModel? sidebarLogoViewModel, ISidebarNavViewModel sidebarNavViewModel)
    {
        SidebarLogoViewModel = sidebarLogoViewModel;
        SidebarNavViewModel = sidebarNavViewModel;
    }

    public SidebarViewModel() { }
}