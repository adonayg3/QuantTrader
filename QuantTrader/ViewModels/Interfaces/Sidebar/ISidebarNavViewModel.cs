using System.Windows.Input;

namespace QuantTrader.ViewModels.Interfaces.Sidebar;

public interface ISidebarNavViewModel
{
    ICommand? DashboardCommand { get; }
    ICommand? AnalyticsCommand { get; }
    ICommand? MomentumScannerCommand { get; }
    ICommand? ValueScannerCommand { get; }
    ICommand? IndexFundsCommand { get; }
    ICommand? SettingsCommand { get; }
}