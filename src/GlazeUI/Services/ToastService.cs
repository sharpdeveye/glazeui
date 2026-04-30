using GlazeUI.Models;

namespace GlazeUI.Services;

/// <summary>
/// Manages toast notifications. Register as scoped and inject where needed.
/// Use <c>Show</c>, <c>Success</c>, <c>Error</c>, <c>Info</c>, or <c>Warning</c>
/// to push a new toast. The <see cref="GlazeUI.Components.UI.Organisms.GzToaster"/>
/// component subscribes to <see cref="OnChange"/> and renders the stack.
/// </summary>
public sealed class ToastService
{
    private readonly List<ToastItem> _toasts = new();
    private readonly object _lock = new();

    /// <summary>Raised whenever the toast list changes.</summary>
    public event Action? OnChange;

    /// <summary>Read-only snapshot of active toasts.</summary>
    public IReadOnlyList<ToastItem> Toasts
    {
        get { lock (_lock) { return _toasts.ToList(); } }
    }

    // ─── Convenience methods ────────────────────────

    /// <summary>Show a toast with full control.</summary>
    public void Show(ToastItem toast)
    {
        lock (_lock) { _toasts.Add(toast); }
        OnChange?.Invoke();
    }

    /// <summary>Show a default toast.</summary>
    public void Show(string title, string? message = null, int duration = 5000, string? actionLabel = null, Action? onAction = null)
        => Show(new ToastItem { Title = title, Message = message, Duration = duration, ActionLabel = actionLabel, OnAction = onAction });

    /// <summary>Show a success toast.</summary>
    public void Success(string title, string? message = null, int duration = 5000)
        => Show(new ToastItem { Title = title, Message = message, Variant = ComponentVariant.Success, Duration = duration });

    /// <summary>Show an error toast.</summary>
    public void Error(string title, string? message = null, int duration = 8000)
        => Show(new ToastItem { Title = title, Message = message, Variant = ComponentVariant.Destructive, Duration = duration });

    /// <summary>Show an info toast.</summary>
    public void Info(string title, string? message = null, int duration = 5000)
        => Show(new ToastItem { Title = title, Message = message, Variant = ComponentVariant.Info, Duration = duration });

    /// <summary>Show a warning toast.</summary>
    public void Warning(string title, string? message = null, int duration = 6000)
        => Show(new ToastItem { Title = title, Message = message, Variant = ComponentVariant.Warning, Duration = duration });

    /// <summary>Dismiss a specific toast by ID.</summary>
    public void Dismiss(string id)
    {
        lock (_lock) { _toasts.RemoveAll(t => t.Id == id); }
        OnChange?.Invoke();
    }

    /// <summary>Dismiss all toasts.</summary>
    public void DismissAll()
    {
        lock (_lock) { _toasts.Clear(); }
        OnChange?.Invoke();
    }
}
