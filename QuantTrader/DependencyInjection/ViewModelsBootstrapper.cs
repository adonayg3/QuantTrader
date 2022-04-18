using QuantTrader.Factories;
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
        RegisterFactories(services, resolver);
        RegisterCommonViewModels(services, resolver);
    }

    private static void RegisterFactories(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register<IMainDockFactory>(() => new MainDockFactory());
    }

    private static void RegisterCommonViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register<ITestDocumentViewModel>(() => new TestDocumentViewModel());
        services.Register<ISidebarLogoViewModel>(() => new SidebarLogoViewModel());
        services.Register<ISidebarNavViewModel>(() => new SidebarNavViewModel());
        services.Register<ISidebarViewModel>(() => new SidebarViewModel(
            resolver.GetRequiredService<ISidebarLogoViewModel>(),
            resolver.GetRequiredService<ISidebarNavViewModel>()
            ));
        services.Register<IMainViewModel>(() => new MainViewModel());
        services.Register<IMainWindowViewModel>(() => new MainWindowViewModel(
             resolver.GetRequiredService<ISidebarViewModel>()
            ));
    }
}