using Microsoft.AspNetCore.Components;

namespace GlazeUI.Models;

/// <summary>Defines an item in a GzToggleGroup.</summary>
public class ToggleGroupItem
{
    /// <summary>Unique value for this toggle option.</summary>
    public string Value { get; set; } = string.Empty;

    /// <summary>Optional text label.</summary>
    public string? Label { get; set; }

    /// <summary>Optional icon content.</summary>
    public RenderFragment? Icon { get; set; }
}
