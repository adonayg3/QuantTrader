using Dock.Model.Core;
using Dock.Model.ReactiveUI.Controls;

namespace QuantTrader.Factories.Interfaces;

public interface IMainDockFactory : IFactory
{
    public void GetOrAddDocument(Document document);
    public void CreateDocument(Document document);
}