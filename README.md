<p align="center">
  <img src="https://img.shields.io/badge/GlazeUI-Design_System-4f46e5?style=for-the-badge&labelColor=0f172a" alt="GlazeUI" />
</p>

<h1 align="center">GlazeUI</h1>

<p align="center">
  <strong>The design system for Blazor + Tailwind CSS v4</strong><br/>
  Beautifully designed. Fully accessible. You own the code.
</p>

<p align="center">
  <a href="https://github.com/sharpdeveye/glazeui/blob/main/LICENSE"><img src="https://img.shields.io/badge/License-Apache_2.0-blue.svg?style=flat-square" alt="License" /></a>
  <a href="https://dotnet.microsoft.com/"><img src="https://img.shields.io/badge/.NET-9.0-512bd4?style=flat-square&logo=dotnet&logoColor=white" alt=".NET 9" /></a>
  <a href="https://tailwindcss.com/"><img src="https://img.shields.io/badge/Tailwind_CSS-v4-06b6d4?style=flat-square&logo=tailwindcss&logoColor=white" alt="Tailwind CSS v4" /></a>
  <a href="https://learn.microsoft.com/aspnet/core/blazor/"><img src="https://img.shields.io/badge/Blazor-Server-7c3aed?style=flat-square&logo=blazor&logoColor=white" alt="Blazor Server" /></a>
  <a href="https://github.com/sharpdeveye/glazeui/stargazers"><img src="https://img.shields.io/github/stars/sharpdeveye/glazeui?style=flat-square&color=e2b340" alt="GitHub Stars" /></a>
  <a href="https://github.com/sharpdeveye/glazeui/issues"><img src="https://img.shields.io/github/issues/sharpdeveye/glazeui?style=flat-square&color=f97316" alt="Issues" /></a>
  <img src="https://img.shields.io/badge/PRs-welcome-22c55e?style=flat-square" alt="PRs Welcome" />
  <img src="https://img.shields.io/badge/Status-v1.0-22c55e?style=flat-square" alt="Status: v1.0" />
</p>

<p align="center">
  <a href="#about">About</a> •
  <a href="#components">Components</a> •
  <a href="#quick-start">Quick Start</a> •
  <a href="#design-tokens">Design Tokens</a> •
  <a href="#roadmap">Roadmap</a> •
  <a href="#contributing">Contributing</a> •
  <a href="#license">License</a>
</p>

---

## About

**GlazeUI** is an open-source design system that combines [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) (.NET 9) with [Tailwind CSS](https://tailwindcss.com/) v4 to deliver premium, production-ready UI components.

- **Components you own** — Copy source code into your project. Modify everything. No hidden dependencies.
- **UX guidelines** — Research-backed guidance on *when* and *why* to use each component.
- **Design tokens** — A unified semantic token system via Tailwind v4's `@theme` directive.
- **Accessible** — WCAG 2.1 AA compliant with keyboard interaction tables and ARIA specs.
- **Figma kit** — Pixel-perfect components with shared token variables.
- **CLI distribution** — Install components with a single command.

> *"Glazing" is the process of applying a refined, aesthetic finish to raw structural material.*
> *Blazor provides the structure — Tailwind CSS provides the glaze.*

## Components

GlazeUI ships **23 components** — 13 atoms, 6 molecules, and 4 organisms — with full variant coverage, loading states, accessible focus rings, and dark mode support via semantic tokens.

### Atoms

| Component | Variants | Features |
|---|---|---|
| **GzButton** | Default, Secondary, Destructive, Outline, Ghost, Link | 4 sizes, Loading spinner, Icon slot, tactile press |
| **GzBadge** | Default, Secondary, Destructive, Outline | Inset-shadow depth on solid variants |
| **GzInput** | — | Inset-ring border, StartContent/EndContent slots, validation error |
| **GzTextarea** | — | Inset-ring border, validation error, configurable rows |
| **GzLabel** | — | Required indicator, peer-disabled styling |
| **GzCheckbox** | — | SVG checkmark, tactile press wrapper |
| **GzRadio** | — | Inner dot indicator, group naming |
| **GzSwitch** | — | Sliding thumb, role="switch", ARIA checked |
| **GzAvatar** | — | Image, initials fallback, default icon, 3 sizes |
| **GzTypography** | H1–H4, P, Lead, Large, Small, Muted, InlineCode | Semantic HTML elements |
| **GzSeparator** | Horizontal, Vertical | Decorative by default, ARIA semantics |
| **GzSkeleton** | Line, Circle | Animated pulse placeholder, dimension overrides via class |
| **GzProgress** | — | 3 sizes, smooth fill transition, ARIA progressbar role |

### Molecules

| Component | Features |
|---|---|
| **GzCard** | Header, Content, Footer slots. Subtle border + shadow |
| **GzAlert** | 5 semantic variants (Default, Info, Success, Warning, Destructive) with auto-icons |
| **GzFormField** | Composes Label + Control + Description/Error. Required indicator |
| **GzTabs** | ARIA tablist/tab/tabpanel pattern, two-way binding, lazy panel rendering |
| **GzTooltip** | CSS-only, 4 positions (Top/Right/Bottom/Left), zero JS/SignalR |
| **GzSelect** | ARIA combobox, keyboard nav (arrows/enter/escape), checkmark indicator |

### Organisms

| Component | Features |
|---|---|
| **GzDialog** | Modal with backdrop blur, click-outside-to-close, 4 sizes, Header/Footer slots |
| **GzDropdownMenu** | Trigger + floating menu, Escape to close, start/end alignment |
| **GzDropdownMenuItem** | Icon + label + shortcut layout, disabled state |
| **GzPopover** | Click-triggered floating panel, 3 alignment modes, any content |

### Premium by Default

Every component includes:

```
✓ TailwindMerge class composition (user overrides work)
✓ active:scale-[0.98] tactile press
✓ focus-visible:ring-2 accessible focus rings
✓ inset-shadow-sm depth on solid variants
✓ Semantic tokens only — zero hardcoded colors
✓ Light + Dark mode via tokens alone
✓ GetFilteredAttributes() for clean attribute splatting
```

## Quick Start

### Option A: CLI (Recommended)

```bash
# Install the CLI as a global tool
dotnet tool install -g GlazeUI.CLI

# Add components to your project
glaze add button badge input

# Or add everything
glaze add --all

# List available components
glaze list
```

### Option B: NuGet Package

```bash
dotnet add package GlazeUI
```

### Option C: Clone Source

```bash
# Clone the repository
git clone https://github.com/sharpdeveye/glazeui.git
cd glazeui/src/GlazeUI

# Restore .NET dependencies
dotnet restore

# Install Tailwind CSS v4
npm install

# Build (compiles Tailwind automatically via MSBuild)
dotnet build

# Run the dev server
dotnet run
```

Then open `http://localhost:5011` and navigate to `/components` to see all 23 components.

### Development Workflow

```bash
# Terminal 1: Blazor dev server with hot reload
dotnet watch

# Terminal 2: Tailwind CSS watcher
npm run css:watch
```

## Design Tokens

GlazeUI uses Tailwind v4's CSS-first `@theme` directive for design tokens. No JavaScript config files.

```css
/* Styles/input.css — Single source of truth */
@import "tailwindcss";

@theme {
  --color-primary: oklch(0.55 0.18 250);
  --color-primary-foreground: oklch(0.99 0.005 250);
  --color-secondary: oklch(0.96 0 0);
  --color-destructive: oklch(0.58 0.22 25);
  --color-background: oklch(0.99 0 0);
  --color-foreground: oklch(0.14 0 0);
  --font-sans: "Inter", system-ui, sans-serif;
  --radius-md: 0.375rem;
  /* ... full palette, shadows, transitions */
}
```

Tokens flow to Tailwind utilities (`bg-primary`), CSS variables (`var(--color-primary)`), and Figma variables — all from one file.

### Token Categories

| Category | Examples |
|---|---|
| **Color** | `primary`, `secondary`, `accent`, `destructive`, `success`, `warning` |
| **Surface** | `background`, `foreground`, `surface`, `muted`, `card`, `popover` |
| **Border** | `border`, `input`, `ring` |
| **Typography** | `--font-sans` (Inter), `--font-mono` (JetBrains Mono) |
| **Radius** | `sm` (4px), `md` (6px), `lg` (8px), `xl` (12px) |
| **Shadow** | `xs`, `sm`, `md`, `lg`, `xl` — warm and soft |

## Project Structure

```
glazeui/
├── src/GlazeUI/
│   ├── Components/
│   │   ├── Layout/MainLayout.razor   # Header, footer, dark mode toggle
│   │   ├── Pages/
│   │   │   ├── Home.razor            # Landing page
│   │   │   └── Components.razor      # Atom library showcase
│   │   └── UI/Atoms/                 # All atom components
│   │       ├── GzButton.razor
│   │       ├── GzBadge.razor
│   │       ├── GzInput.razor
│   │       └── ...
│   ├── Models/Enums.cs               # Shared enums (variants, sizes)
│   ├── Utilities/Tw.cs               # TailwindMerge static wrapper
│   ├── Styles/input.css              # 🎨 Design token source of truth
│   └── wwwroot/
│       ├── css/app.css               # Compiled Tailwind output
│       └── js/glaze-theme.js         # Dark mode interop
├── .github/                          # Issue templates, PR template
├── CONTRIBUTING.md
├── CODE_OF_CONDUCT.md
├── SECURITY.md
└── LICENSE                           # Apache 2.0
```

## Roadmap

| Phase | Status | Deliverables |
|---|---|---|
| **Phase 0** | ✅ Complete | Blazor + Tailwind v4 template, design tokens, dark mode, project infrastructure |
| **Phase 1** | ✅ Complete | Semantic token system, 13 atom components, TailwindMerge, showcase page |
| **Phase 2** | ✅ Complete | 6 molecules, Docs page, NuGet RCL, UX guidelines, Writing guidelines, RTL support |
| **Phase 3** | ✅ Complete | 4 organisms (Dialog, DropdownMenu, DropdownMenuItem, Popover), Pattern recipes |
| **Phase 4** | ✅ Complete | Accessibility matrices, API Reference, CONTRIBUTING.md, PR/issue templates, CHANGELOG |

### Every component ships with:

| Deliverable | Description |
|---|---|
| 🧩 **Source code** | `.razor` — yours to modify |
| 🎨 **Design tokens** | Semantic utilities via `@theme` — no hardcoded values |
| 📖 **UX guidelines** | When to use, when not to, alternatives |
| ♿ **Accessibility** | Keyboard interaction, ARIA roles, focus management |
| 🖌️ **Figma component** | Pixel-perfect, all states, light + dark mode |

## Contributing

We welcome contributions! Please read our [Contributing Guide](CONTRIBUTING.md) and [Code of Conduct](CODE_OF_CONDUCT.md) before getting started.

### Ways to contribute

- 🐛 **Report bugs** — Use the [bug report template](https://github.com/sharpdeveye/glazeui/issues/new?template=bug_report.yml)
- ✨ **Request features** — Use the [feature request template](https://github.com/sharpdeveye/glazeui/issues/new?template=feature_request.yml)
- 🧩 **Request components** — Use the [component request template](https://github.com/sharpdeveye/glazeui/issues/new?template=component_request.yml)
- 📝 **Improve docs** — Typos, examples, clarifications
- ♿ **Test accessibility** — Screen readers, keyboard navigation

## License

Licensed under the [Apache License 2.0](LICENSE).

The Apache 2.0 license includes an **explicit patent grant**, providing enterprise legal teams with the assurance needed to adopt GlazeUI in commercial products without patent litigation risk.

---

<p align="center">
  <sub>Built with precision by the GlazeUI contributors</sub>
</p>

<p align="center">
  <a href="https://github.com/sharpdeveye/glazeui/stargazers">⭐ Star this repo</a> to follow the journey to v1.0
</p>
