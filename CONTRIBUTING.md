# Contributing to GlazeUI

Thank you for your interest in contributing to GlazeUI! This guide will help you get started.

## Ground Rules

1. **Every component follows the Component Contract**
2. **Zero raw Tailwind colors** — use semantic tokens only (`bg-primary`, `text-foreground`, never `bg-blue-500`)
3. **CSS-only visual states** — hover, focus, active handled via CSS, not `@onmouseover` (SignalR latency)
4. **RTL support** — use logical properties (`ms-*`, `me-*`, `start-*`, `end-*`)
5. **TwMerge** — all class composition via `Tw.Merge()`, never string concatenation

## Development Setup

```bash
git clone https://github.com/sharpdeveye/glazeui.git
cd glazeui/src/GlazeUI
dotnet restore
npm install
dotnet build
dotnet run
# Open http://localhost:5011
```

## Project Structure

```
src/
├── GlazeUI/                    # Showcase web app
│   ├── Components/
│   │   ├── Pages/              # Route pages (Home, Docs, Components)
│   │   ├── Layout/             # MainLayout, NavMenu
│   │   └── UI/
│   │       ├── Atoms/          # GzButton, GzInput, GzBadge...
│   │       ├── Molecules/      # GzCard, GzAlert, GzTooltip...
│   │       └── Organisms/      # GzDialog, GzDropdownMenu...
│   ├── Models/                 # Enums, SelectOption, TabItem
│   ├── Utilities/              # Tw.cs (TwMerge wrapper)
│   └── Styles/input.css        # Design tokens
│
└── GlazeUI.Components/         # NuGet Razor Class Library
    ├── UI/                     # Copies of all components
    ├── Models/                 # Shared models
    └── Utilities/              # Tw.cs
```

## Adding a New Component

### 1. Create the component

Create a `.razor` file in the appropriate tier (`Atoms/`, `Molecules/`, or `Organisms/`).

### 2. Quality checklist

Before submitting, verify:

- [ ] Premium at rest (not only on hover)
- [ ] Looks good in grayscale
- [ ] All states defined: default, hover, active, focus-visible, disabled, loading
- [ ] Zero raw color names — semantic tokens only
- [ ] `focus-visible:ring-2` pattern (NOT outline)
- [ ] `active:scale-[0.98]` for interactive elements
- [ ] `size-*` instead of `h-* w-*` where applicable
- [ ] RTL: `ms-*`/`me-*` instead of `ml-*`/`mr-*`, `start-*`/`end-*` instead of `left-*`/`right-*`
- [ ] Light + dark mode works via tokens alone
- [ ] Would it look good next to shadcn/Linear/Vercel?

### 3. Add to showcase

Add a demo section in `Components.razor` and a sidebar link.

### 4. Add to API Reference

Add a `ComponentInfo` entry in `ApiReference.razor` with all parameters.

### 5. Sync to RCL

Copy the component to `GlazeUI.Components/UI/{Tier}/`.

## Pull Request Process

1. Fork the repository
2. Create a feature branch: `git checkout -b feat/gz-my-component`
3. Make your changes following the rules above
4. Run `dotnet build` — must produce **0 warnings, 0 errors**
5. Submit a PR with:
   - Component name and tier
   - Screenshot (light + dark mode)
   - Checklist confirmation

## Reporting Issues

Use [GitHub Issues](https://github.com/sharpdeveye/glazeui/issues) with one of:
- **bug**: Something broken
- **enhancement**: New component or feature request
- **docs**: Documentation improvement

## Code of Conduct

Be respectful. Be constructive. Focus on the work.
