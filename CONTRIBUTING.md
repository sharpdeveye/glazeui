# Contributing to GlazeUI

Thank you for your interest in contributing to GlazeUI! This document provides guidelines and information to help you contribute effectively.

## Table of Contents

- [Code of Conduct](#code-of-conduct)
- [Current Governance Model](#current-governance-model)
- [How to Contribute](#how-to-contribute)
- [Development Setup](#development-setup)
- [Component Contribution Requirements](#component-contribution-requirements)
- [Pull Request Process](#pull-request-process)
- [Style Guide](#style-guide)
- [Reporting Issues](#reporting-issues)

## Code of Conduct

This project follows the [Contributor Covenant Code of Conduct](CODE_OF_CONDUCT.md). By participating, you are expected to uphold this code.

## Current Governance Model

GlazeUI is in its **foundational phase** and currently operates under a **BDFL (Benevolent Dictator for Life)** governance model. This means:

- All architectural decisions and design direction are made by the project lead
- Pull requests are reviewed and merged at the project lead's discretion
- The design token system, component API patterns, and UX guidelines are established before community contributions are accepted for core components

As the project matures toward v1.0, governance will gradually transition to a community-driven model with defined roles (committers, reviewers, maintainers).

## How to Contribute

### Good First Contributions

- **Documentation improvements** — Fix typos, clarify explanations, add examples
- **Bug reports** — File detailed bug reports with reproduction steps
- **Accessibility testing** — Test components with screen readers, keyboard navigation
- **UX feedback** — Review guidelines and suggest improvements from your experience

### Contributions That Require Discussion First

- **New components** — Open a [Component Request](https://github.com/sharpdeveye/glazeui/issues/new?template=component_request.yml) issue first
- **Design token changes** — Changes to the token system affect all components
- **API changes** — Changes to component parameter signatures need design review

## Development Setup

### Prerequisites

- [.NET 9 SDK](https://dotnet.microsoft.com/download) or later
- [Node.js](https://nodejs.org/) 18+ (for Tailwind CSS CLI)
- A code editor (VS Code, Rider, or Visual Studio recommended)

### Setup

```bash
# Clone the repository
git clone https://github.com/sharpdeveye/glazeui.git
cd glazeui

# Restore .NET dependencies
dotnet restore

# Install Node dependencies (Tailwind CLI)
npm install

# Run the development server
dotnet run
```

## Component Contribution Requirements

Every component submitted to GlazeUI **must** include:

### 1. Source Code
- `.razor` component file with Tailwind styling
- `.razor.cs` code-behind (if logic exceeds ~20 lines)
- Use design tokens exclusively — no hardcoded colors, spacing, or font sizes

### 2. Accessibility
- Correct semantic HTML elements
- ARIA attributes where required
- Keyboard interaction support (documented in a table)
- Tested with at least one screen reader (NVDA, VoiceOver, or JAWS)

### 3. Documentation
- **Usage guidelines** — When to use this component vs. alternatives
- **Writing guidelines** — Microcopy conventions (labels, error messages, etc.)
- **API reference** — All parameters with types, defaults, and descriptions
- **Examples** — At least 3 usage examples (basic, common, advanced)

### 4. Figma Component
- Pixel-perfect match to the coded component
- All states represented (default, hover, focus, active, disabled)
- Light and dark mode variants
- Uses the shared GlazeUI Figma token variables

### 5. Tests
- Component renders correctly in Blazor Interactive Server mode
- Accessibility tests pass
- All variants and states render as expected

## Pull Request Process

1. **Fork the repository** and create a feature branch from `main`
2. **Follow the style guide** (below)
3. **Include all required deliverables** for component PRs
4. **Fill out the PR template** completely
5. **Request review** — the project lead will review within 5 business days

### Commit Convention

Use [Conventional Commits](https://www.conventionalcommits.org/):

```
feat(button): add ghost variant
fix(input): correct focus ring color in dark mode
docs(dialog): add keyboard interaction table
chore: update Tailwind to v4.1
```

Scopes: component names (`button`, `input`, `dialog`), `tokens`, `docs`, `cli`, `primitives`

## Style Guide

### Blazor Components
- Use `Gz` prefix for all components: `GzButton`, `GzInput`, `GzDialog`
- Parameters use PascalCase: `Variant`, `Size`, `Disabled`
- Events use `On` prefix: `OnClick`, `OnChange`, `OnDismiss`
- Support `[Parameter(CaptureUnmatched = true)]` for HTML attribute passthrough
- Use `RenderFragment` for child content, `RenderFragment<T>` for templated content

### Tailwind Classes
- Use design token-based utilities exclusively (`bg-primary-500`, not `bg-blue-500`)
- Keep class strings readable — use multi-line strings or helper methods for long class lists
- Prefer semantic token names (`bg-surface`, `text-on-surface`) over scale values where available

### File Organization
```
registry/
├── primitives/          # Headless primitives (Portal, FocusTrap, etc.)
├── atoms/               # Single-purpose elements (Button, Input, Badge)
│   └── button/
│       ├── GzButton.razor
│       ├── GzButton.razor.cs    # (if needed)
│       └── ButtonVariant.cs     # Enums / supporting types
├── molecules/           # Composed elements (FormField, Card, Alert)
└── organisms/           # Complex interactive components (Dialog, DataTable)
```

## Reporting Issues

### Bug Reports
Use the [Bug Report template](https://github.com/sharpdeveye/glazeui/issues/new?template=bug_report.yml). Include:
- Clear description of the bug
- Steps to reproduce
- Expected vs. actual behavior
- Browser and .NET version
- Screenshots if applicable

### Feature Requests
Use the [Feature Request template](https://github.com/sharpdeveye/glazeui/issues/new?template=feature_request.yml).

### Component Requests
Use the [Component Request template](https://github.com/sharpdeveye/glazeui/issues/new?template=component_request.yml).

---

Thank you for contributing to GlazeUI! 🎨
