using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Avalonia.Themes.Fluent;
using QuantTrader.ViewModels;
using QuantTrader.ViewModels.Sidebar;
using QuantTrader.Views;

namespace QuantTrader;

public partial class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.MainWindow = new MainWindow
            {
                DataContext = new MainWindowViewModel(new SidebarViewModel(new SidebarLogoViewModel(), new SidebarNavViewModel())),
            };
        }

        base.OnFrameworkInitializationCompleted();
    }
}