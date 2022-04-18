using Dock.Model.Core;


namespace QuantTrader.ViewModels.Interfaces;

public interface IMainWindowViewModel
{
    IFactory? Factory { get; set; }
    IDock? Layout { get; set; }
}