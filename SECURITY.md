# Security Policy

## Supported Versions

| Version | Supported |
|---------|-----------|
| Latest `main` branch | ✅ Yes |
| Pre-release / development | ⚠️ Best effort |

## Reporting a Vulnerability

**Please do NOT report security vulnerabilities through public GitHub issues.**

If you discover a security vulnerability in GlazeUI, please report it responsibly:

1. **Email:** Send a detailed report to **security@glazeui.dev** (or your preferred contact email)
2. **Include:**
   - Description of the vulnerability
   - Steps to reproduce
   - Potential impact
   - Suggested fix (if any)

## What to Expect

- **Acknowledgment:** We will acknowledge your report within 48 hours
- **Assessment:** We will investigate and provide an initial assessment within 5 business days
- **Resolution:** Critical vulnerabilities will be patched as quickly as possible
- **Credit:** With your permission, we will credit you in the security advisory

## Scope

GlazeUI is a **client-side component library**. Components are copied into the user's project as source code. Security considerations include:

- **XSS vulnerabilities** in component rendering
- **Unsafe HTML injection** through component parameters
- **Dependency vulnerabilities** in the build pipeline (Tailwind CLI, npm packages)
- **CLI tool security** (the `glaze-cli` .NET Global Tool)

### Out of Scope

- Vulnerabilities in user-modified copies of GlazeUI components
- Issues in third-party dependencies not maintained by GlazeUI
- Security of the user's hosting environment or Blazor Server configuration

## Security Best Practices for GlazeUI Users

- Always sanitize user input before rendering in components
- Keep your .NET SDK and Tailwind CLI versions up to date
- Review component source code before using in production (you own the code!)
- Follow Blazor's built-in XSS protection guidelines

---

Thank you for helping keep GlazeUI and its community safe.
