using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Documents;

public partial class ValueScannerView : UserControl
{
    public ValueScannerView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}