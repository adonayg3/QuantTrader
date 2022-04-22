using QuantTrader.Factories.Implementation;
using QuantTrader.Factories.Interfaces;
using QuantTrader.ViewModels;
using QuantTrader.ViewModels.Documents;
using QuantTrader.ViewModels.Interfaces;
using QuantTrader.ViewModels.Interfaces.Document;
using QuantTrader.ViewModels.Interfaces.Sidebar;
using QuantTrader.ViewModels.Sidebar;
using Splat;

namespace QuantTrader.DependencyInjection;

public static class ViewModelsBootstrapper
{
    public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterFactories(services);
        RegisterCommonViewModels(services, resolver);
    }

    private static void RegisterFactories(IMutableDependencyResolver services)
    {
        services.RegisterLazySingleton<IMainDockFactory>(() => new MainDockFactory());
    }

    private static void RegisterCommonViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register<IDashboardViewModel>(() => new DashboardViewModel());
        services.Register<IAnalyticsViewModel>(() => new AnalyticsViewModel());
        services.Register<ISidebarLogoViewModel>(() => new SidebarLogoViewModel());
        services.Register<ISidebarNavViewModel>(() => new SidebarNavViewModel(
            resolver.GetRequiredService<IMainDockFactory>(),
            resolver.GetRequiredService<ISidebarLogoViewModel>()
            ));
        services.Register<ISidebarViewModel>(() => new SidebarViewModel(
            resolver.GetRequiredService<ISidebarNavViewModel>()
            ));
        services.Register<IMainViewModel>(() => new MainViewModel());
        services.Register<IMainWindowViewModel>(() => new MainWindowViewModel(
             resolver.GetRequiredService<ISidebarViewModel>()
            ));
    }
}