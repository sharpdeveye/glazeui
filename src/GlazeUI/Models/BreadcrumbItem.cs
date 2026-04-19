namespace GlazeUI.Models;

/// <summary>A single item in a GzBreadcrumb trail.</summary>
public class BreadcrumbItem
{
    /// <summary>Display text.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Link URL. Last item is rendered as plain text regardless.</summary>
    public string? Href { get; set; }
}
