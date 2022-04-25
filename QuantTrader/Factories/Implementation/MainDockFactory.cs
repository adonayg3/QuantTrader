using System;
using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Data;
using Dock.Avalonia.Controls;
using Dock.Model.Controls;
using Dock.Model.Core;
using Dock.Model.ReactiveUI;
using Dock.Model.ReactiveUI.Controls;
using QuantTrader.Factories.Interfaces;
using QuantTrader.ViewModels;
using QuantTrader.ViewModels.Documents;
using QuantTrader.ViewModels.Tools;
using ReactiveUI;

namespace QuantTrader.Factories.Implementation;

public class MainDockFactory : Factory, IMainDockFactory
{
    private IDocumentDock? _documentDock;

    public override IRootDock CreateLayout()
    {
        var document1 = new DashboardViewModel
        {
            Id = "Dashboard",
            Title = "Dashboard"
        };

        var document2 = new AnalyticsViewModel
        {
            Id = "Analytics",
            Title = "Analytics"
        };

        var rightTopTool1 = new RightTopTool1ViewModel
        {
            Id = "RightTop1",
            Title = "RightTop1"
        };

        var documentDock = new DocumentDock
        {
            Id = "DocumentsPane",
            Title = "DocumentsPane",
            Proportion = 1,
            ActiveDockable = document1,
            VisibleDockables = CreateList<IDockable>
            (
                document1,
                document2
            ),
            CanCreateDocument = true,
        };

        documentDock.CreateDocument = ReactiveCommand.Create(() =>
        {
            var index = documentDock.VisibleDockables.Count;
            var document = new AnalyticsViewModel {Id = $"Analytics{index}", Title = $"Analytics{index}"};
            AddDockable(documentDock, document);
            SetActiveDockable(document);
            SetFocusedDockable(documentDock, document);
        });

        var mainLayout = new ProportionalDock
        {
            Id = "MainLayout",
            Title = "MainLayout",
            Proportion = 0.5,
            Orientation = Orientation.Horizontal,
            ActiveDockable = null,
            VisibleDockables = CreateList<IDockable>
            (
                documentDock,
                new ProportionalDockSplitter()
                {
                    Id = "RightSplitter",
                    Title = "RightSplitter"
                },
                new ProportionalDock
                {
                    Id = "RightPane",
                    Title = "RightPane",
                    Proportion = 0.5,
                    Orientation = Orientation.Vertical,
                    ActiveDockable = null,
                    VisibleDockables = CreateList<IDockable>
                    (
                        new ToolDock
                        {
                            Id = "RightPaneTop",
                            Title = "RightPaneTop",
                            Proportion = 0.5,
                            ActiveDockable = rightTopTool1,
                            VisibleDockables = CreateList<IDockable>
                            (
                                rightTopTool1
                            ),
                            Alignment = Alignment.Right,
                            GripMode = GripMode.Visible
                        }
                    )
                }
            )
        };

        var mainView = new MainViewModel
        {
            Id = "Main",
            Title = "Main",
            ActiveDockable = mainLayout,
            VisibleDockables = CreateList<IDockable>(mainLayout)
        };

        var root = CreateRootDock();

        root.Id = "Root";
        root.Title = "Root";
        root.ActiveDockable = mainView;
        root.DefaultDockable = mainView;
        root.VisibleDockables = CreateList<IDockable>(mainView);

        _documentDock = documentDock;

        return root;
    }

    public override void InitLayout(IDockable layout)
    {
        HostWindowLocator = new Dictionary<string, Func<IHostWindow>>
        {
            [nameof(IDockWindow)] = () =>
            {
                var hostWindow = new HostWindow()
                {
                    [!Window.TitleProperty] = new Binding("ActiveDockable.Title")
                };
                return hostWindow;
            }
        };

        DockableLocator = new Dictionary<string, Func<IDockable>>()!;

        base.InitLayout(layout);

        if (_documentDock != null)
        {
            SetActiveDockable(_documentDock);
            SetFocusedDockable(_documentDock, _documentDock.VisibleDockables?.FirstOrDefault());
        }
    }

    public void GetOrAddDocument(Document document)
    {
        if (_documentDock?.VisibleDockables != null && _documentDock.VisibleDockables.Any(d => d.Id == document.Id))
        {
            var foundDocument = _documentDock.VisibleDockables.First(d => d.Id == document.Id);
            SetActiveDockable(foundDocument);
            SetFocusedDockable(_documentDock, foundDocument);
        }
        else
            CreateDocument(document);
    }
    public void CreateDocument(Document document)
    {
        if (_documentDock?.VisibleDockables == null) return;
        AddDockable(_documentDock, document);
        SetActiveDockable(document);
        SetFocusedDockable(_documentDock, document);
    }
}