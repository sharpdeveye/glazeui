namespace GlazeUI.Models;

public record SbNavItem(string Id, string Label, string IconPath);
public record SbMenuItem(string Label, string? IconPath = null, bool HasDropdown = false, bool IsActive = false, SbMenuItem[]? Children = null);
public record SbMenuSection(string Title, SbMenuItem[] Items);
public record SbContentPanel(string Title, SbMenuSection[] Sections);
