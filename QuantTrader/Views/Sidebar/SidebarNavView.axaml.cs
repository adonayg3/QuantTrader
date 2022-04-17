using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace QuantTrader.Views.Sidebar;

public partial class SidebarNavView : UserControl
{
    public SidebarNavView()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}