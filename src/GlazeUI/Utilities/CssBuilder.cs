namespace GlazeUI.Utilities;

/// <summary>
/// Fluent CSS class builder for composing Tailwind utility classes.
/// Provides a clean API for conditional and variant-based class composition.
/// </summary>
public sealed class CssBuilder
{
    private readonly List<string> _classes = [];

    public CssBuilder(string? baseClass = null)
    {
        if (!string.IsNullOrWhiteSpace(baseClass))
            _classes.Add(baseClass.Trim());
    }

    /// <summary>Appends a class string unconditionally.</summary>
    public CssBuilder Add(string? value)
    {
        if (!string.IsNullOrWhiteSpace(value))
            _classes.Add(value.Trim());
        return this;
    }

    /// <summary>Appends a class string only when the condition is true.</summary>
    public CssBuilder AddWhen(string? value, bool condition)
    {
        if (condition && !string.IsNullOrWhiteSpace(value))
            _classes.Add(value.Trim());
        return this;
    }

    /// <summary>Appends a class string only when the condition is false.</summary>
    public CssBuilder AddUnless(string? value, bool condition)
    {
        return AddWhen(value, !condition);
    }

    /// <summary>Appends the class string returned by the selector for the given enum value.</summary>
    public CssBuilder AddFromEnum<TEnum>(TEnum value, Func<TEnum, string> selector) where TEnum : Enum
    {
        return Add(selector(value));
    }

    /// <summary>Builds the final space-separated class string.</summary>
    public string Build() => string.Join(" ", _classes);

    public override string ToString() => Build();

    /// <summary>Creates a new CssBuilder with an optional base class.</summary>
    public static CssBuilder Create(string? baseClass = null) => new(baseClass);
}
