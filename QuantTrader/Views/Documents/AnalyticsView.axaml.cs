using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Documents;

public partial class AnalyticsView : UserControl
{
    public AnalyticsView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}