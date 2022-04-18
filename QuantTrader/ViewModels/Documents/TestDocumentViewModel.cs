using Dock.Model.ReactiveUI.Controls;
using QuantTrader.ViewModels.Interfaces.Document;

namespace QuantTrader.ViewModels.Documents
{
    public class TestDocumentViewModel : Document, ITestDocumentViewModel
    {
        public string Greeting => "Welcome to Avalonia!";
    }
}
