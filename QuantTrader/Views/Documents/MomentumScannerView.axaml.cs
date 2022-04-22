using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Documents;

public partial class MomentumScannerView : UserControl
{
    public MomentumScannerView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}