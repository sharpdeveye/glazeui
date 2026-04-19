namespace GlazeUI.Models;

/// <summary>Represents a single option in a GzSelect component.</summary>
public class SelectOption
{
    /// <summary>Internal value submitted with forms.</summary>
    public required string Value { get; set; }

    /// <summary>Display label shown to the user.</summary>
    public required string Label { get; set; }

    /// <summary>Whether this option is disabled.</summary>
    public bool Disabled { get; set; }
}
