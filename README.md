<p align="center">
  <img src="https://img.shields.io/badge/GlazeUI-Design_System-4f46e5?style=for-the-badge&labelColor=0f172a" alt="GlazeUI" />
</p>

<h1 align="center">GlazeUI</h1>

<p align="center">
  <strong>The design system for Blazor + TailwindCSS</strong><br/>
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
  <img src="https://img.shields.io/badge/Status-Phase_0-f59e0b?style=flat-square" alt="Status: Phase 0" />
</p>

<p align="center">
  <a href="#about">About</a> •
  <a href="#philosophy">Philosophy</a> •
  <a href="#quick-start">Quick Start</a> •
  <a href="#roadmap">Roadmap</a> •
  <a href="#contributing">Contributing</a> •
  <a href="#license">License</a>
</p>

---

## About

**GlazeUI** is an open-source design system that combines the power of [Blazor](https://dotnet.microsoft.com/apps/aspnet/web-apps/blazor) (.NET) with [TailwindCSS](https://tailwindcss.com/) v4 to deliver production-ready UI components, comprehensive UX guidelines, and pixel-perfect design resources.

Inspired by [shadcn/ui](https://ui.shadcn.com/)'s ownership model and [Amazon Cloudscape](https://cloudscape.design/)'s design philosophy, GlazeUI gives you:

- 🧩 **Components you own** — Copy source code into your project. Modify everything. No hidden dependencies.
- 📖 **UX guidelines** — Research-backed guidance on *when* and *why* to use each component.
- 🎨 **Design tokens** — A unified token system via Tailwind v4's `@theme` that keeps Figma and code in sync.
- ♿ **Accessibility** — WCAG 2.1 AA compliant with keyboard interaction tables and screen reader specs.
- 🖌️ **Figma kit** — Pixel-perfect components with shared token variables.
- ⌨️ **CLI distribution** — Install components with a single command.

> *"Glazing" is the process of applying a refined, aesthetic finish to raw structural material.*
> *Blazor provides the structure — TailwindCSS provides the glaze.*

## Philosophy

GlazeUI is **not a component library**. It's a **design system**.

| Component Library | GlazeUI Design System |
|---|---|
| Pre-built UI elements you import | Pre-built UI elements **you own and modify** |
| A theme object | A **design token pipeline** synced between code and Figma |
| API reference docs | **UX guidelines** — when to use a Modal vs. a Drawer, error message patterns, cognitive load analysis |
| Isolated components | **Pattern recipes** — auth flows, dashboards, settings pages, empty states |
| Compiled package dependency | **Source code** copied into your project with zero runtime dependencies |

### Technical Stack

| Layer | Technology | Why |
|---|---|---|
| **Framework** | Blazor Interactive Server (.NET 9+) | Full .NET ecosystem, real-time interactivity via SignalR |
| **Styling** | TailwindCSS v4 | CSS-first `@theme` tokens, automatic content detection, Oxide engine |
| **Tokens** | `@theme` in `input.css` | Single source of truth — no `tailwind.config.js`, tokens become CSS variables |
| **Design** | Figma | Pixel-perfect components with shared variable system |
| **Distribution** | CLI (.NET Global Tool) | `glaze add button` copies source files with namespace adjustment |
| **License** | Apache 2.0 | Explicit patent grant for enterprise confidence |

## Quick Start

> 🚧 **GlazeUI is in active development.** We're in Phase 0 (foundational template). Star the repo to follow progress.

### Prerequisites

| Requirement | Version |
|---|---|
| [.NET SDK](https://dotnet.microsoft.com/download) | 9.0 or later |
| [Node.js](https://nodejs.org/) | 18+ (for Tailwind CLI) |

### Installation

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

### Development Workflow

```bash
# Terminal 1: Blazor dev server with hot reload
dotnet watch

# Terminal 2: Tailwind CSS watcher
npm run css:watch
```

The Tailwind CLI watches your `.razor` files and recompiles on every change. Blazor hot reload picks up the new CSS automatically.

## Project Structure

```
glazeui/
├── src/GlazeUI/
│   ├── Components/
│   │   ├── App.razor                 # Root layout with SEO, fonts, theme
│   │   ├── Layout/
│   │   │   └── MainLayout.razor      # Header, footer, dark mode toggle
│   │   └── Pages/
│   │       └── Home.razor            # Landing page
│   ├── Styles/
│   │   └── input.css                 # 🎨 Design token source of truth
│   ├── wwwroot/
│   │   ├── css/app.css               # Compiled Tailwind output
│   │   └── js/glaze-theme.js         # Dark mode interop
│   ├── GlazeUI.csproj                # MSBuild + Tailwind pipeline
│   └── package.json                  # Tailwind CLI dependency
├── .github/                          # Issue templates, PR template
├── CONTRIBUTING.md                   # Contribution guidelines
├── CODE_OF_CONDUCT.md                # Contributor Covenant
├── SECURITY.md                       # Security policy
└── LICENSE                           # Apache 2.0
```

## Roadmap

| Phase | Timeline | Status | Deliverables |
|---|---|---|---|
| **Phase 0** | Foundation | ✅ Complete | Blazor + Tailwind v4 template, design tokens, dark mode, project infrastructure |
| **Phase 1** | Months 1-3 | 🔜 Next | Token system, 10-12 atom components (Button, Input, Badge...), docs scaffold, Figma kit start |
| **Phase 2** | Months 4-6 | 📋 Planned | 6-8 molecules (Card, Alert, Tabs...), UX guidelines, writing guidelines |
| **Phase 3** | Months 7-10 | 📋 Planned | Headless primitives, 4-5 organisms (Dialog, Dropdown, Popover...), pattern recipes |
| **Phase 4** | Months 11-13 | 📋 Planned | CLI tool, accessibility matrices, community contribution model, v1.0 release |

### Every component ships with:

| Deliverable | Description |
|---|---|
| 🧩 **Source code** | `.razor` + `.razor.cs` — yours to modify |
| 🎨 **Design tokens** | Tailwind utilities via `@theme` — no hardcoded values |
| 📖 **UX guidelines** | When to use, when not to, alternatives, cognitive load analysis |
| ✍️ **Writing guidelines** | Microcopy standards — button labels, error messages, tone |
| ♿ **Accessibility matrix** | Keyboard interaction table, ARIA roles, screen reader behavior |
| 🖌️ **Figma component** | Pixel-perfect, all states, light + dark mode |

## Design Tokens

GlazeUI uses Tailwind v4's CSS-first `@theme` for design tokens. No JavaScript config files.

```css
/* Styles/input.css — Single source of truth */
@import "tailwindcss";

@theme {
  --color-primary-500: oklch(0.62 0.18 250);
  --color-destructive:  oklch(0.58 0.22 25);
  --color-surface:      oklch(1 0 0);
  --font-sans: "Inter", system-ui, sans-serif;
  --radius-md: 0.375rem;
  /* ... full palette, shadows, transitions */
}
```

Tokens flow to Tailwind utilities (`bg-primary-500`), CSS variables (`var(--color-primary-500)`), and Figma variables — all from one file.

## Contributing

We welcome contributions! Please read our [Contributing Guide](CONTRIBUTING.md) and [Code of Conduct](CODE_OF_CONDUCT.md) before getting started.

GlazeUI is currently in its foundational phase under a **BDFL** governance model. As the project matures toward v1.0, governance will transition to a community-driven model with defined roles.

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
  <a href="https://github.com/sharpdeveye/glazeui/stargazers">⭐ Star this repo</a> to follow the journey from Phase 0 to v1.0
</p>
