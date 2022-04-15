using System.Reflection;
using QuantTrader.ViewModels.Interfaces.Sidebar;

namespace QuantTrader.ViewModels.Sidebar;

public class SidebarLogoViewModel : ViewModelBase, ISidebarLogoViewModel
{
    public string Version => $"Version {Assembly.GetExecutingAssembly().GetName().Version}";

    public string AppName => "Quant Trader";
    
}