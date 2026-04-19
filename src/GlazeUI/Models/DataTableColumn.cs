namespace GlazeUI.Models;

/// <summary>Column definition for GzDataTable.</summary>
public class DataTableColumn<TItem>
{
    /// <summary>Column header label.</summary>
    public string Header { get; set; } = string.Empty;

    /// <summary>Property accessor for the cell value.</summary>
    public Func<TItem, object?> Field { get; set; } = _ => null;

    /// <summary>Whether this column is sortable.</summary>
    public bool Sortable { get; set; } = true;

    /// <summary>Optional CSS class for the column.</summary>
    public string? Class { get; set; }

    /// <summary>Column width, e.g. "120px" or "1fr".</summary>
    public string? Width { get; set; }
}
