namespace GlazeUI.Models;

/// <summary>A single data point for chart components.</summary>
public class ChartDataPoint
{
    /// <summary>Display label (x-axis, legend, or tooltip).</summary>
    public string Label { get; set; } = "";

    /// <summary>Numeric value.</summary>
    public double Value { get; set; }

    /// <summary>Optional per-point color override (CSS value).</summary>
    public string? Color { get; set; }
}

/// <summary>A named series of values for multi-series charts.</summary>
public class ChartSeries
{
    /// <summary>Series name shown in legend/tooltip.</summary>
    public string Name { get; set; } = "";

    /// <summary>Series color (CSS value). Falls back to chart token.</summary>
    public string? Color { get; set; }

    /// <summary>Ordered list of numeric values.</summary>
    public List<double> Values { get; set; } = new();
}
