using System;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.ReactiveUI;
using QuantTrader.DependencyInjection;
using Splat;

namespace QuantTrader
{
    static class Program
    {
        // Initialization code. Don't use any Avalonia, third-party APIs or any
        // SynchronizationContext-reliant code before AppMain is called: things aren't initialized
        // yet and stuff might break.
        [STAThread]
        public static void Main(string[] args)
        {
            RegisterDependencies();
            BuildAvaloniaApp()
                .StartWithClassicDesktopLifetime(args);
        }

        private static void RegisterDependencies() 
            => Bootstrapper.Register(Locator.CurrentMutable, Locator.Current);

        // Avalonia configuration, don't remove; also used by visual designer.
        private static AppBuilder BuildAvaloniaApp()
            => AppBuilder.Configure<App>()
                .UsePlatformDetect()
                .LogToTrace()
                .UseReactiveUI();
    }
}