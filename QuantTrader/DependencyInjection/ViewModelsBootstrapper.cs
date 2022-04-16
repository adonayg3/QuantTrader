using QuantTrader.ViewModels;
using QuantTrader.ViewModels.Interfaces;
using QuantTrader.ViewModels.Interfaces.Sidebar;
using QuantTrader.ViewModels.Sidebar;
using Splat;

namespace QuantTrader.DependencyInjection;

public static class ViewModelsBootstrapper
{
    public static void RegisterViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        RegisterCommonViewModels(services, resolver);
    }

    private static void RegisterCommonViewModels(IMutableDependencyResolver services, IReadonlyDependencyResolver resolver)
    {
        services.Register<ISidebarLogoViewModel>(() => new SidebarLogoViewModel());
        services.Register<ISidebarNavViewModel>(() => new SidebarNavViewModel());
        services.Register<ISidebarViewModel>(() => new SidebarViewModel(
            resolver.GetRequiredService<ISidebarLogoViewModel>(),
            resolver.GetRequiredService<ISidebarNavViewModel>()
            ));
        
        services.Register<IMainWindowViewModel>(() => new MainWindowViewModel(
             resolver.GetRequiredService<ISidebarViewModel>()
            ));
    }
}