using Microsoft.AspNetCore.Components;

namespace GlazeUI.Models;

/// <summary>Represents a single tab in a GzTabs component.</summary>
public class TabItem
{
    /// <summary>Unique key identifying this tab.</summary>
    public required string Key { get; set; }

    /// <summary>Display label shown on the tab button.</summary>
    public required string Label { get; set; }

    /// <summary>Content rendered when this tab is active.</summary>
    public RenderFragment? Content { get; set; }
}
