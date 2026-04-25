using Microsoft.AspNetCore.Components;

namespace GlazeUI.Models;

/// <summary>Step definition for GzStepper.</summary>
public class StepItem
{
    /// <summary>Step label text.</summary>
    public string Label { get; set; } = string.Empty;

    /// <summary>Optional description shown below the label.</summary>
    public string? Description { get; set; }

    /// <summary>Step body content (rendered when this step is active).</summary>
    public RenderFragment? Content { get; set; }
}
