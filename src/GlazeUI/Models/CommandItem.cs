using Microsoft.AspNetCore.Components;

namespace GlazeUI.Models;

/// <summary>A group of related command items in GzCommand.</summary>
public class CommandGroup
{
    /// <summary>Group heading label.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Commands in this group.</summary>
    public List<CommandItem> Items { get; set; } = new();
}

/// <summary>A single command item in GzCommand.</summary>
public class CommandItem
{
    /// <summary>Display label.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Optional icon content.</summary>
    public RenderFragment? Icon { get; set; }

    /// <summary>Optional keyboard shortcut label.</summary>
    public string? Shortcut { get; set; }

    /// <summary>Callback when this command is selected.</summary>
    public EventCallback OnSelect { get; set; }
}
