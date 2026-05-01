namespace GlazeUI.Models;

/// <summary>Represents a single toast notification in the stack.</summary>
public class ToastItem
{
    /// <summary>Unique identifier for this toast.</summary>
    public string Id { get; init; } = Guid.NewGuid().ToString("N")[..8];

    /// <summary>Toast heading.</summary>
    public string? Title { get; init; }

    /// <summary>Toast body message.</summary>
    public string? Message { get; init; }

    /// <summary>Visual variant: Default, Success, Destructive, Info, Warning.</summary>
    public ComponentVariant Variant { get; init; } = ComponentVariant.Default;

    /// <summary>Auto-dismiss after this many milliseconds. 0 = never.</summary>
    public int Duration { get; init; } = 5000;

    /// <summary>Optional action button label.</summary>
    public string? ActionLabel { get; init; }

    /// <summary>Optional action button callback.</summary>
    public Action? OnAction { get; init; }

    /// <summary>Timestamp when the toast was created.</summary>
    public DateTime CreatedAt { get; init; } = DateTime.UtcNow;
}
