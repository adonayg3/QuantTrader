using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Sidebar;

public partial class SidebarView : UserControl
{
    public SidebarView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}