using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Documents;

public partial class IndexFundsView : UserControl
{
    public IndexFundsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}