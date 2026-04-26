namespace GlazeUI.Models;

/// <summary>Context passed to GzSortable item templates.</summary>
public class SortableItemContext<T>
{
    /// <summary>The data item.</summary>
    public T Item { get; init; } = default!;

    /// <summary>Current index in the list.</summary>
    public int Index { get; init; }

    /// <summary>Whether this item is currently being dragged.</summary>
    public bool IsDragging { get; init; }

    /// <summary>Whether this is the current drop target.</summary>
    public bool IsDropTarget { get; init; }
}
