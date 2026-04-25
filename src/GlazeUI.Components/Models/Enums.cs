namespace GlazeUI.Models;

// ─── Button ─────────────────────────────────────────────

/// <summary>Visual style variant for GzButton.</summary>
public enum ButtonVariant
{
    Default,
    Secondary,
    Destructive,
    Outline,
    Ghost,
    Link
}

/// <summary>Size preset for GzButton.</summary>
public enum ButtonSize
{
    Sm,
    Md,
    Lg,
    Icon
}

// ─── Badge ──────────────────────────────────────────────

/// <summary>Visual style variant for GzBadge.</summary>
public enum BadgeVariant
{
    Default,
    Secondary,
    Destructive,
    Outline
}

// ─── Separator ──────────────────────────────────────────

/// <summary>Orientation for GzSeparator.</summary>
public enum SeparatorOrientation
{
    Horizontal,
    Vertical
}

// ─── Avatar ─────────────────────────────────────────────

/// <summary>Size preset for GzAvatar.</summary>
public enum AvatarSize
{
    Sm,
    Md,
    Lg
}

// ─── Typography ─────────────────────────────────────────

/// <summary>Typographic element for GzTypography.</summary>
public enum TypographyElement
{
    H1,
    H2,
    H3,
    H4,
    P,
    Lead,
    Large,
    Small,
    Muted,
    InlineCode
}

// ─── Alert ──────────────────────────────────────────────

/// <summary>Semantic variant for GzAlert.</summary>
public enum AlertVariant
{
    Default,
    Info,
    Success,
    Warning,
    Destructive
}

// ─── Progress ───────────────────────────────────────────

/// <summary>Size preset for GzProgress.</summary>
public enum ProgressSize
{
    Sm,
    Md,
    Lg
}

// ─── Skeleton ───────────────────────────────────────────

/// <summary>Shape variant for GzSkeleton.</summary>
public enum SkeletonVariant
{
    Line,
    Circle
}

// ─── Tooltip ────────────────────────────────────────────

/// <summary>Placement side for GzTooltip.</summary>
public enum TooltipPosition
{
    Top,
    Right,
    Bottom,
    Left
}

// ─── Dialog ─────────────────────────────────────────────

/// <summary>Size preset for GzDialog.</summary>
public enum DialogSize
{
    Sm,
    Md,
    Lg,
    Full
}

// ─── Toast ──────────────────────────────────────────────

/// <summary>Visual variant for GzToast.</summary>
public enum ToastVariant
{
    Default,
    Success,
    Error
}

// ─── DataTable ──────────────────────────────────────────

/// <summary>Sort direction for GzDataTable columns.</summary>
public enum SortDirection
{
    None,
    Ascending,
    Descending
}
