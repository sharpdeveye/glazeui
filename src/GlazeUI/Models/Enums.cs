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
    Error,
    Info,
    Warning
}

/// <summary>Position of the GzToaster container on the viewport.</summary>
public enum ToasterPosition
{
    TopRight,
    TopLeft,
    TopCenter,
    BottomRight,
    BottomLeft,
    BottomCenter
}

// ─── DataTable ──────────────────────────────────────────

/// <summary>Sort direction for GzDataTable columns.</summary>
public enum SortDirection
{
    None,
    Ascending,
    Descending
}

// ─── Toggle ─────────────────────────────────────────────

/// <summary>Visual variant for GzToggle.</summary>
public enum ToggleVariant
{
    Default,
    Outline
}

/// <summary>Size preset for GzToggle.</summary>
public enum ToggleSize
{
    Sm,
    Md,
    Lg
}

// ─── Sheet ──────────────────────────────────────────────

/// <summary>Which edge a GzSheet slides from.</summary>
public enum SheetSide
{
    Start,
    End,
    Top,
    Bottom
}

// ─── ScrollArea ─────────────────────────────────────────

/// <summary>Scroll direction for GzScrollArea.</summary>
public enum ScrollOrientation
{
    Vertical,
    Horizontal,
    Both
}

// ─── Select ─────────────────────────────────────────────

/// <summary>Size preset for GzSelect trigger height.</summary>
public enum SelectSize
{
    Default,
    Sm
}

// ─── Charts ─────────────────────────────────────────────

/// <summary>Sparkline visual type.</summary>
public enum SparklineType
{
    Line,
    Area
}

/// <summary>Bar chart orientation.</summary>
public enum ChartOrientation
{
    Vertical,
    Horizontal
}

// ─── Drawer ─────────────────────────────────────────────

/// <summary>Which edge the drawer slides in from.</summary>
public enum DrawerSide
{
    Bottom,
    Top,
    Left,
    Right
}

// ─── Spinner ────────────────────────────────────────────

/// <summary>Size preset for GzSpinner.</summary>
public enum SpinnerSize
{
    Sm,
    Md,
    Lg
}

// ─── Sidebar ────────────────────────────────────────────

/// <summary>Visual variant for GzSidebar.</summary>
public enum SidebarVariant
{
    /// <summary>Standard fixed sidebar.</summary>
    Default,
    /// <summary>Floating with gap and rounded corners.</summary>
    Floating,
    /// <summary>Inset within a padded container.</summary>
    Inset
}

/// <summary>Collapsible behavior for GzSidebar.</summary>
public enum SidebarCollapsible
{
    /// <summary>Slides entirely off-screen when collapsed.</summary>
    Offcanvas,
    /// <summary>Collapses to icon-only rail.</summary>
    Icon,
    /// <summary>Always visible, no collapse.</summary>
    None
}

/// <summary>Which side the sidebar is placed on.</summary>
public enum SidebarSide
{
    Left,
    Right
}
