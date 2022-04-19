using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Documents;

public partial class DashboardView : UserControl
{
    public DashboardView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}