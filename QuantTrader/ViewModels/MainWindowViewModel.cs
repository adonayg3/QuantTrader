using Dock.Model.Core;
using QuantTrader.ViewModels.Interfaces;
using QuantTrader.ViewModels.Interfaces.Sidebar;
using ReactiveUI;

namespace QuantTrader.ViewModels
{
    public class MainWindowViewModel : ViewModelBase, IMainWindowViewModel
    {
        #region Dock Properties
        private IFactory? _factory;
        private IDock? _layout;
        private string? _currentView;
        
        public IFactory? Factory
        {
            get => _factory;
            set => this.RaiseAndSetIfChanged(ref _factory, value);
        }

        public IDock? Layout
        {
            get => _layout;
            set => this.RaiseAndSetIfChanged(ref _layout, value);
        }

        public string? CurrentView
        {
            get => _currentView;
            set => this.RaiseAndSetIfChanged(ref _currentView, value);
        }

        #endregion
        
        #region ViewModels
        public ISidebarViewModel? SidebarViewModel { get; }
        #endregion

        #region Constructors
        public MainWindowViewModel(ISidebarViewModel? sidebarViewModel)
        {
            SidebarViewModel = sidebarViewModel;

        }
        
        // Parameterless constructor required for data context binding 
        public MainWindowViewModel() { }
        #endregion
    }
}