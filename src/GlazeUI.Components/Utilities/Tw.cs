using TailwindMerge;

namespace GlazeUI.Utilities;

/// <summary>
/// Static wrapper around TwMerge for Tailwind class conflict resolution.
/// All components use this instead of string concatenation to ensure
/// user class overrides work correctly without cascade bugs.
/// </summary>
public static class Tw
{
    private static readonly TwMerge _merger = new();

    /// <summary>
    /// Merges multiple Tailwind CSS class strings, resolving conflicts.
    /// Later arguments override conflicting classes from earlier arguments.
    /// Null/empty strings are ignored.
    /// </summary>
    /// <example>
    /// Tw.Merge("bg-primary px-4", "bg-red-500 px-8") → "bg-red-500 px-8"
    /// </example>
    public static string Merge(params string?[] classes)
    {
        var filtered = classes.Where(c => !string.IsNullOrWhiteSpace(c)).ToArray();
        if (filtered.Length == 0) return string.Empty;
        return _merger.Merge(filtered!);
    }
}
