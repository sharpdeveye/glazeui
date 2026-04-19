# Changelog

All notable changes to GlazeUI are documented in this file.

## [1.0.0] — 2026-04-19

### Added
- **CLI tool** (`glaze`): `glaze add button`, `glaze list`, `glaze init`, `glaze add --all`
  - Extracts embedded components into user projects
  - Auto-resolves shared dependencies (Tw.cs, Enums.cs, SelectOption, TabItem)
  - Packaged as dotnet global tool (`dotnet tool install -g GlazeUI.CLI`)
- **Accessibility page**: Keyboard matrix, ARIA roles table, focus management, RTL mapping
- **API Reference page**: Full props tables for all 23 components
- Community contribution model: CONTRIBUTING.md, PR template, issue templates
- v1.0 version bump across all packages

## [0.3.0] — 2026-04-19

### Added
- **Organisms**: GzDialog, GzDropdownMenu, GzDropdownMenuItem, GzPopover
- **Molecules**: GzTooltip (CSS-only, 4 positions), GzSelect (ARIA combobox, keyboard nav)
- **Pattern Recipes** page: Login form, Settings page, Dashboard cards, Pricing table, Empty state
- **API Reference** page: Full props tables for all 23 components
- **Accessibility** page: Keyboard matrix, ARIA roles, focus management, RTL mapping
- **UX Guidelines** page: Per-component usage guide, overlay comparison
- **Writing Guidelines** page: Tone, button labels, error formula, placeholders
- **RTL support**: All 23 components use CSS logical properties
- **Sidebar navigation**: Sticky sidebar on Components, Docs, and all guideline pages

### Fixed
- Fragment-only `#section` links routing to home page in Blazor Server
- Component section anchor IDs not matching sidebar links
- Missing `scroll-mt-24` on component sections

## [0.2.0] — 2026-04-18

### Added
- **NuGet RCL**: GlazeUI.Components Razor Class Library package
- **Molecules**: GzCard, GzAlert, GzFormField, GzTabs
- **Atoms**: GzSkeleton, GzProgress
- **Docs page**: Getting Started with installation, tokens, dark mode, customization, architecture
- Component showcase page with interactive demos

## [0.1.0] — 2026-04-18

### Added
- Initial release with 11 atom components
- Semantic token system (oklch-based, light + dark mode)
- Tailwind CSS v4 integration with `@theme` directive
- TwMerge class composition utility
- Homepage with feature cards and hero section
- Dark mode toggle via `.dark` class on `<html>`

### Components (Atoms)
- GzButton (6 variants, 4 sizes, loading, icon slot)
- GzBadge (4 variants)
- GzInput (icon slots, validation)
- GzTextarea (validation, configurable rows)
- GzLabel (required indicator)
- GzCheckbox (SVG checkmark)
- GzRadio (inner dot indicator)
- GzSwitch (sliding thumb, role=switch)
- GzAvatar (image, initials, default icon)
- GzTypography (11 variants)
- GzSeparator (horizontal, vertical)
