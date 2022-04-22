using System.Windows.Input;
using QuantTrader.Factories.Interfaces;
using QuantTrader.ViewModels.Documents;
using QuantTrader.ViewModels.Interfaces.Sidebar;
using ReactiveUI;

namespace QuantTrader.ViewModels.Sidebar;

public class SidebarNavViewModel : ViewModelBase, ISidebarNavViewModel
{
    #region properties
    private readonly IMainDockFactory? _mainDockFactory; 
    public ISidebarLogoViewModel? SidebarLogoViewModel { get; }
    #endregion

    #region constructors
    public SidebarNavViewModel(IMainDockFactory? mainDockFactory, ISidebarLogoViewModel? sidebarLogoViewModel)
    {
        _mainDockFactory = mainDockFactory;
        SidebarLogoViewModel = sidebarLogoViewModel;
        DashboardCommand = ReactiveCommand.Create(NavigateToDashboard);
        AnalyticsCommand = ReactiveCommand.Create(NavigateToAnalytics);
        MomentumScannerCommand = ReactiveCommand.Create(NavigateToMomentumScanner);
        ValueScannerCommand = ReactiveCommand.Create(NavigateToValueScanner);
        IndexFundsCommand = ReactiveCommand.Create(NavigateToIndexFunds);
        SettingsCommand = ReactiveCommand.Create(NavigateToSettings);
    }
    public SidebarNavViewModel() { }
    #endregion

    #region commands
    public ICommand? DashboardCommand { get; }
    public ICommand? AnalyticsCommand { get; }
    public ICommand? MomentumScannerCommand { get; }
    public ICommand? ValueScannerCommand { get; }
    public ICommand? IndexFundsCommand { get; }
    public ICommand? SettingsCommand { get; }
    
    private void NavigateToDashboard()
    {
        _mainDockFactory?.GetOrAddDocument(new DashboardViewModel
        {
            Id = "Dashboard",
            Title = "Dashboard"
        });
    }
    private void NavigateToAnalytics()
    {
        _mainDockFactory?.CreateDocument(new AnalyticsViewModel
        {
            Id = "Analytics",
            Title = "Analytics"
        });
    }
    private void NavigateToMomentumScanner()
    {
        _mainDockFactory?.GetOrAddDocument(new MomentumScannerViewModel
        {
            Id = "Momentum",
            Title = "Momentum Scanner"
        });
    }
    private void NavigateToValueScanner()
    {
        _mainDockFactory?.GetOrAddDocument(new ValueScannerViewModel
        {
            Id = "ValueScanner",
            Title = "Value Scanner"
        });
    }
    private void NavigateToIndexFunds()
    {
        _mainDockFactory?.GetOrAddDocument(new IndexFundsViewModel
        {
            Id = "IndexFunds",
            Title = "Index Funds"
        });
    }
    private void NavigateToSettings()
    {        
        _mainDockFactory?.GetOrAddDocument(new SettingsViewModel
        {
            Id = "Settings",
            Title = "Settings"
        });

    }
    #endregion

    

    

    
}