using System;
using System.Collections.Generic;
using QuantTrader.DependencyInjection;
using QuantTrader.ViewModels.Interfaces;
using Splat;
using Xunit;

namespace QuantTrader.Tests.DependencyInjection;

public class DependencyInjectionTests
{
    [Fact]
    public void TestRegistrations()
    {
        // Arrange
        var resolver = new MutableDependencyResolver(Locator.CurrentMutable);
        Bootstrapper.Register(resolver, Locator.Current);
        
        // Act
        resolver
            .RegisteredTypes
            .ForEach(type => Locator.Current.GetRequiredService(type));
        
        // Assert
        Assert.True(resolver.HasRegistration(typeof(IMainWindowViewModel)));
    }
    
    [Fact]
    public void TestInvalidRegistration()
    {
        // Arrange
        var resolver = new MutableDependencyResolver(Locator.CurrentMutable);

        // Act
        Bootstrapper.Register(resolver, Locator.Current);
        
        // Assert
        Assert.Throws<InvalidOperationException>(() => Locator.Current.GetRequiredService(typeof(string)));
        Assert.Throws<InvalidOperationException>(() => Locator.Current.GetRequiredService<string>());
    }
    
    [Fact]
    public void TestUnregisterCurrent()
    {
        // Arrange
        var resolver = new MutableDependencyResolver(Locator.CurrentMutable);
        Bootstrapper.Register(resolver, Locator.Current);
        
        // Act
        resolver.UnregisterCurrent(typeof(IMainWindowViewModel));

        // Assert
        Assert.False(resolver.HasRegistration(typeof(IMainWindowViewModel)));
    }
    
    [Fact]
    public void TestUnregisterAll()
    {
        // Arrange
        var resolver = new MutableDependencyResolver(Locator.CurrentMutable);
        Bootstrapper.Register(resolver, Locator.Current);
        
        // Act
        resolver.UnregisterAll(typeof(IMainWindowViewModel));

        // Assert
        Assert.False(resolver.HasRegistration(typeof(IMainWindowViewModel)));
    }
    
    private class MutableDependencyResolver : IMutableDependencyResolver
    {
        private readonly IMutableDependencyResolver _inner;

        public List<Type> RegisteredTypes { get; }

        public MutableDependencyResolver(IMutableDependencyResolver inner)
        {
            _inner = inner;

            RegisteredTypes = new List<Type>();
        }

        public bool HasRegistration(Type serviceType, string? contract = null) =>
            _inner.HasRegistration(serviceType, contract);

        public void Register(Func<object> factory, Type serviceType, string? contract = null)
        {
            RegisteredTypes.Add(serviceType);

            _inner.Register(factory, serviceType, contract);
        }

        public void UnregisterCurrent(Type serviceType, string? contract = null) =>
            _inner.UnregisterCurrent(serviceType, contract);

        public void UnregisterAll(Type serviceType, string? contract = null) =>
            _inner.UnregisterAll(serviceType, contract);

        public IDisposable ServiceRegistrationCallback(Type serviceType, string contract, Action<IDisposable> callback) =>
            _inner.ServiceRegistrationCallback(serviceType, contract, callback);
    }
}