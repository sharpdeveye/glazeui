namespace GlazeUI.Models;

/// <summary>
/// Shared sidebar state cascaded from GzSidebarProvider to all children.
/// </summary>
public class SidebarState
{
    /// <summary>Whether the sidebar is expanded (true) or collapsed (false).</summary>
    public bool IsExpanded { get; set; } = true;

    /// <summary>Whether we are in mobile viewport (sheet mode).</summary>
    public bool IsMobile { get; set; }

    /// <summary>Whether the mobile sheet is open.</summary>
    public bool MobileOpen { get; set; }

    /// <summary>Collapsible behavior.</summary>
    public SidebarCollapsible Collapsible { get; set; } = SidebarCollapsible.Offcanvas;

    /// <summary>Which side the sidebar is on.</summary>
    public SidebarSide Side { get; set; } = SidebarSide.Left;

    /// <summary>Visual variant.</summary>
    public SidebarVariant Variant { get; set; } = SidebarVariant.Default;

    /// <summary>Delegate to notify the provider to re-render.</summary>
    public Action? NotifyStateChanged { get; set; }

    /// <summary>Toggle sidebar state (expand/collapse on desktop, open/close on mobile).</summary>
    public void Toggle()
    {
        if (IsMobile)
            MobileOpen = !MobileOpen;
        else
            IsExpanded = !IsExpanded;

        NotifyStateChanged?.Invoke();
    }

    /// <summary>CSS data attribute value for current state.</summary>
    public string StateValue => IsExpanded ? "expanded" : "collapsed";

    /// <summary>CSS data attribute for collapsible mode.</summary>
    public string CollapsibleValue => Collapsible switch
    {
        SidebarCollapsible.Offcanvas => "offcanvas",
        SidebarCollapsible.Icon => "icon",
        SidebarCollapsible.None => "none",
        _ => "offcanvas"
    };

    /// <summary>CSS data attribute for side.</summary>
    public string SideValue => Side == SidebarSide.Right ? "right" : "left";
}
