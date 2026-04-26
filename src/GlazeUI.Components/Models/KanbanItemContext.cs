namespace GlazeUI.Models;

/// <summary>Context passed to GzKanban item templates.</summary>
public class KanbanItemContext<T>
{
    /// <summary>The data item.</summary>
    public T Item { get; init; } = default!;

    /// <summary>Column ID this item belongs to.</summary>
    public string Column { get; init; } = string.Empty;

    /// <summary>Index within the column.</summary>
    public int Index { get; init; }

    /// <summary>Whether this item is currently being dragged.</summary>
    public bool IsDragging { get; init; }

    /// <summary>Whether this is the current drop target.</summary>
    public bool IsDropTarget { get; init; }
}

/// <summary>Event data when a kanban item is moved.</summary>
public class KanbanMoveEvent
{
    /// <summary>Source column ID.</summary>
    public string SourceColumn { get; init; } = string.Empty;

    /// <summary>Source index within the column.</summary>
    public int SourceIndex { get; init; }

    /// <summary>Destination column ID.</summary>
    public string TargetColumn { get; init; } = string.Empty;

    /// <summary>Destination index within the column.</summary>
    public int TargetIndex { get; init; }
}
