using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using Dock.Model.Core;
using QuantTrader.DependencyInjection;
using QuantTrader.Factories;
using QuantTrader.ViewModels.Interfaces;
using QuantTrader.Views;
using Splat;

namespace QuantTrader;

public class App : Application
{
    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        var factory = GetRequiredService<IMainDockFactory>();
        var layout = factory.CreateLayout();
        if (layout != null)
        {
            factory.InitLayout(layout);

            var mainWindowViewModel = GetRequiredService<IMainWindowViewModel>();
            mainWindowViewModel.Factory = factory;
            mainWindowViewModel.Layout = layout;

            if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
            {
                DataContext = mainWindowViewModel;
                desktop.MainWindow = new MainWindow
                {
                    DataContext = DataContext
                };

                desktop.MainWindow.Closing += (_, _) =>
                {
                    if (layout is IDock dock)
                    {
                        if (dock.Close.CanExecute(null))
                        {
                            dock.Close.Execute(null);
                        }
                    }
                };

                desktop.MainWindow = desktop.MainWindow;

                desktop.Exit += (_, _) =>
                {
                    if (layout is IDock dock)
                    {
                        if (dock.Close.CanExecute(null))
                        {
                            dock.Close.Execute(null);
                        }
                    }
                };
            }
        }

        base.OnFrameworkInitializationCompleted();
    }
    
    private static T GetRequiredService<T>() => Locator.Current.GetRequiredService<T>();
}