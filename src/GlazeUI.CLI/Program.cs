using System.Reflection;

namespace GlazeUI.CLI;

class Program
{
    private static readonly string Version = "1.1.0";

    // Component registry: name → (tier, filename)
    private static readonly Dictionary<string, (string Tier, string FileName)> Components = new(StringComparer.OrdinalIgnoreCase)
    {
        // Atoms
        ["button"]     = ("Atoms",     "GzButton.razor"),
        ["badge"]      = ("Atoms",     "GzBadge.razor"),
        ["input"]      = ("Atoms",     "GzInput.razor"),
        ["textarea"]   = ("Atoms",     "GzTextarea.razor"),
        ["label"]      = ("Atoms",     "GzLabel.razor"),
        ["checkbox"]   = ("Atoms",     "GzCheckbox.razor"),
        ["radio"]      = ("Atoms",     "GzRadio.razor"),
        ["switch"]     = ("Atoms",     "GzSwitch.razor"),
        ["avatar"]     = ("Atoms",     "GzAvatar.razor"),
        ["typography"] = ("Atoms",     "GzTypography.razor"),
        ["separator"]  = ("Atoms",     "GzSeparator.razor"),
        ["skeleton"]   = ("Atoms",     "GzSkeleton.razor"),
        ["progress"]   = ("Atoms",     "GzProgress.razor"),
        ["sidebarlink"] = ("Atoms",    "GzSidebarLink.razor"),
        ["slider"]     = ("Atoms",     "GzSlider.razor"),
        ["toggle"]     = ("Atoms",     "GzToggle.razor"),
        ["scrollarea"] = ("Atoms",     "GzScrollArea.razor"),
        // Molecules
        ["card"]          = ("Molecules", "GzCard.razor"),
        ["alert"]         = ("Molecules", "GzAlert.razor"),
        ["formfield"]     = ("Molecules", "GzFormField.razor"),
        ["tabs"]          = ("Molecules", "GzTabs.razor"),
        ["tooltip"]       = ("Molecules", "GzTooltip.razor"),
        ["select"]        = ("Molecules", "GzSelect.razor"),
        ["accordion"]     = ("Molecules", "GzAccordion.razor"),
        ["accordionitem"] = ("Molecules", "GzAccordionItem.razor"),
        ["breadcrumb"]    = ("Molecules", "GzBreadcrumb.razor"),
        ["fileupload"]    = ("Molecules", "GzFileUpload.razor"),
        ["stepper"]       = ("Molecules", "GzStepper.razor"),
        ["togglegroup"]   = ("Molecules", "GzToggleGroup.razor"),
        ["collapsible"]   = ("Molecules", "GzCollapsible.razor"),
        ["pagination"]    = ("Molecules", "GzPagination.razor"),
        ["inputotp"]      = ("Molecules", "GzInputOTP.razor"),
        // Organisms
        ["dialog"]           = ("Organisms", "GzDialog.razor"),
        ["dropdownmenu"]     = ("Organisms", "GzDropdownMenu.razor"),
        ["dropdownmenuitem"] = ("Organisms", "GzDropdownMenuItem.razor"),
        ["popover"]          = ("Organisms", "GzPopover.razor"),
        ["toast"]            = ("Organisms", "GzToast.razor"),
        ["combobox"]         = ("Organisms", "GzCombobox.razor"),
        ["datatable"]        = ("Organisms", "GzDataTable.razor"),
        ["datepicker"]       = ("Organisms", "GzDatePicker.razor"),
        ["sheet"]            = ("Organisms", "GzSheet.razor"),
        ["hovercard"]        = ("Organisms", "GzHoverCard.razor"),
        ["contextmenu"]      = ("Organisms", "GzContextMenu.razor"),
        ["command"]          = ("Organisms", "GzCommand.razor"),
    };

    // Shared dependencies
    private static readonly Dictionary<string, (string Dir, string FileName)> SharedFiles = new()
    {
        ["tw"]               = ("Utilities", "Tw.cs"),
        ["enums"]            = ("Models",    "Enums.cs"),
        ["selectoption"]     = ("Models",    "SelectOption.cs"),
        ["tabitem"]          = ("Models",    "TabItem.cs"),
        ["breadcrumbitem"]   = ("Models",    "BreadcrumbItem.cs"),
        ["datatablecolumn"]  = ("Models",    "DataTableColumn.cs"),
        ["stepitem"]         = ("Models",    "StepItem.cs"),
        ["togglegroupitem"]  = ("Models",    "ToggleGroupItem.cs"),
        ["commanditem"]      = ("Models",    "CommandItem.cs"),
    };

    // Component → required shared file keys
    private static readonly Dictionary<string, string[]> Dependencies = new(StringComparer.OrdinalIgnoreCase)
    {
        ["select"]        = new[] { "selectoption" },
        ["combobox"]      = new[] { "selectoption" },
        ["tabs"]          = new[] { "tabitem" },
        ["breadcrumb"]    = new[] { "breadcrumbitem" },
        ["datatable"]     = new[] { "datatablecolumn" },
        ["stepper"]       = new[] { "stepitem" },
        ["togglegroup"]   = new[] { "togglegroupitem" },
        ["command"]       = new[] { "commanditem" },
        ["dropdownmenu"]  = new[] { "dropdownmenuitem" },
    };

    // Bundled theme presets
    private static readonly Dictionary<string, ThemeColors> Themes = new(StringComparer.OrdinalIgnoreCase)
    {
        ["default"] = new(
            Primary: "oklch(0.55 0.18 250)",
            PrimaryFg: "oklch(0.99 0.005 250)",
            Destructive: "oklch(0.58 0.22 25)",
            Success: "oklch(0.62 0.17 145)",
            Warning: "oklch(0.75 0.15 85)",
            Info: "oklch(0.60 0.16 240)"
        ),
        ["rose"] = new(
            Primary: "oklch(0.58 0.22 12)",
            PrimaryFg: "oklch(0.98 0.01 12)",
            Destructive: "oklch(0.55 0.24 30)",
            Success: "oklch(0.62 0.17 145)",
            Warning: "oklch(0.75 0.15 85)",
            Info: "oklch(0.60 0.16 240)"
        ),
        ["emerald"] = new(
            Primary: "oklch(0.60 0.17 160)",
            PrimaryFg: "oklch(0.98 0.01 160)",
            Destructive: "oklch(0.58 0.22 25)",
            Success: "oklch(0.65 0.19 145)",
            Warning: "oklch(0.75 0.15 85)",
            Info: "oklch(0.60 0.16 240)"
        ),
        ["amber"] = new(
            Primary: "oklch(0.70 0.16 75)",
            PrimaryFg: "oklch(0.20 0.04 75)",
            Destructive: "oklch(0.58 0.22 25)",
            Success: "oklch(0.62 0.17 145)",
            Warning: "oklch(0.78 0.17 85)",
            Info: "oklch(0.60 0.16 240)"
        ),
        ["violet"] = new(
            Primary: "oklch(0.55 0.20 290)",
            PrimaryFg: "oklch(0.98 0.01 290)",
            Destructive: "oklch(0.58 0.22 25)",
            Success: "oklch(0.62 0.17 145)",
            Warning: "oklch(0.75 0.15 85)",
            Info: "oklch(0.60 0.16 240)"
        ),
    };

    static int Main(string[] args)
    {
        if (args.Length == 0)
        {
            PrintHelp();
            return 0;
        }

        var command = args[0].ToLowerInvariant();

        return command switch
        {
            "add"    => HandleAdd(args.Skip(1).ToArray()),
            "update" => HandleUpdate(args.Skip(1).ToArray()),
            "list"   => HandleList(),
            "init"   => HandleInit(),
            "theme"  => HandleTheme(args.Skip(1).ToArray()),
            "--version" or "-v" => PrintVersion(),
            "--help" or "-h" or "help" => PrintHelp(),
            _ => UnknownCommand(command)
        };
    }

    // ─── ADD ──────────────────────────────────────────────────

    static int HandleAdd(string[] args)
    {
        if (args.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: specify component name(s). Use 'glaze list' to see available components.");
            Console.ResetColor();
            return 1;
        }

        var outputDir = FindOutputDir();
        var added = new List<string>();
        var failed = new List<string>();

        foreach (var name in args)
        {
            if (name.Equals("--all", StringComparison.OrdinalIgnoreCase))
            {
                foreach (var kvp in Components)
                {
                    if (ExtractComponent(kvp.Key, kvp.Value.Tier, kvp.Value.FileName, outputDir, false))
                        added.Add(kvp.Value.FileName);
                    else
                        failed.Add(kvp.Key);
                }
                foreach (var kvp in SharedFiles)
                    ExtractSharedFile(kvp.Value.Dir, kvp.Value.FileName, outputDir, false);
                break;
            }

            var key = name.ToLowerInvariant();
            if (!Components.TryGetValue(key, out var comp))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"  ⚠ Unknown component: {name}");
                Console.ResetColor();
                failed.Add(name);
                continue;
            }

            if (ExtractComponent(key, comp.Tier, comp.FileName, outputDir, false))
                added.Add(comp.FileName);
            else
                failed.Add(name);
        }

        EnsureSharedDependencies(outputDir, added, false);
        PrintSummary(added, failed, outputDir);
        return failed.Count > 0 ? 1 : 0;
    }

    // ─── UPDATE ───────────────────────────────────────────────

    static int HandleUpdate(string[] args)
    {
        if (args.Length == 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: specify component name(s) or --all to update all installed components.");
            Console.ResetColor();
            return 1;
        }

        var outputDir = FindOutputDir();
        var updated = new List<string>();
        var failed = new List<string>();

        if (args.Any(a => a.Equals("--all", StringComparison.OrdinalIgnoreCase)))
        {
            // Update all components that already exist on disk
            foreach (var kvp in Components)
            {
                var targetDir = Path.Combine(outputDir, "UI", kvp.Value.Tier);
                var targetPath = Path.Combine(targetDir, kvp.Value.FileName);
                if (File.Exists(targetPath))
                {
                    if (ExtractComponent(kvp.Key, kvp.Value.Tier, kvp.Value.FileName, outputDir, true))
                        updated.Add(kvp.Value.FileName);
                    else
                        failed.Add(kvp.Key);
                }
            }
            // Also update shared files
            foreach (var kvp in SharedFiles)
            {
                var targetDir = Path.Combine(outputDir, kvp.Value.Dir);
                var targetPath = Path.Combine(targetDir, kvp.Value.FileName);
                if (File.Exists(targetPath))
                    ExtractSharedFile(kvp.Value.Dir, kvp.Value.FileName, outputDir, true);
            }
        }
        else
        {
            foreach (var name in args)
            {
                var key = name.ToLowerInvariant();
                if (!Components.TryGetValue(key, out var comp))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"  ⚠ Unknown component: {name}");
                    Console.ResetColor();
                    failed.Add(name);
                    continue;
                }

                if (ExtractComponent(key, comp.Tier, comp.FileName, outputDir, true))
                    updated.Add(comp.FileName);
                else
                    failed.Add(name);
            }

            EnsureSharedDependencies(outputDir, updated, true);
        }

        Console.WriteLine();
        if (updated.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✓ Updated {updated.Count} component(s) in {outputDir}");
            Console.ResetColor();
        }
        if (failed.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✗ Failed: {string.Join(", ", failed)}");
            Console.ResetColor();
        }

        return failed.Count > 0 ? 1 : 0;
    }

    // ─── INIT ─────────────────────────────────────────────────

    static int HandleInit()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Initializing GlazeUI...");
        Console.ResetColor();

        var outputDir = FindOutputDir();

        // Extract all shared files
        foreach (var kvp in SharedFiles)
            ExtractSharedFile(kvp.Value.Dir, kvp.Value.FileName, outputDir, false);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ✓ GlazeUI initialized. Run 'glaze add button' to add your first component.");
        Console.ResetColor();
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Next steps:");
        Console.WriteLine("    1. Add TailwindCSS v4 to your project");
        Console.WriteLine("    2. Copy the GlazeUI design tokens to your input.css");
        Console.WriteLine("    3. Install TailwindMerge.Blazor NuGet package");
        Console.WriteLine("    4. Run 'glaze add button badge input' to add components");
        Console.ResetColor();
        Console.WriteLine();

        return 0;
    }

    // ─── THEME ────────────────────────────────────────────────

    static int HandleTheme(string[] args)
    {
        if (args.Length == 0)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Available Themes");
            Console.ResetColor();
            Console.WriteLine();

            foreach (var theme in Themes)
            {
                var indicator = theme.Key == "default" ? " (active)" : "";
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"    {theme.Key,-12}");
                Console.ResetColor();
                Console.Write($"primary: {theme.Value.Primary}");
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine(indicator);
                Console.ResetColor();
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  Usage: glaze theme rose");
            Console.WriteLine("         glaze theme --custom \"oklch(0.55 0.20 180)\"");
            Console.ResetColor();
            Console.WriteLine();
            return 0;
        }

        var arg = args[0].ToLowerInvariant();

        if (arg == "--custom" && args.Length >= 2)
        {
            var customColor = string.Join(" ", args.Skip(1));
            return ApplyCustomTheme(customColor);
        }

        if (!Themes.TryGetValue(arg, out var colors))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  Unknown theme: {arg}. Available: {string.Join(", ", Themes.Keys)}");
            Console.ResetColor();
            return 1;
        }

        return ApplyTheme(arg, colors);
    }

    static int ApplyTheme(string name, ThemeColors colors)
    {
        var cssPath = FindInputCss();
        if (cssPath == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Could not find input.css. Run from your project root.");
            Console.ResetColor();
            return 1;
        }

        var content = File.ReadAllText(cssPath);

        // Replace primary color tokens
        content = ReplaceToken(content, "--color-primary:", colors.Primary);
        content = ReplaceToken(content, "--color-primary-foreground:", colors.PrimaryFg);
        content = ReplaceToken(content, "--color-destructive:", colors.Destructive);
        content = ReplaceToken(content, "--color-success:", colors.Success);
        content = ReplaceToken(content, "--color-warning:", colors.Warning);
        content = ReplaceToken(content, "--color-info:", colors.Info);

        File.WriteAllText(cssPath, content);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  ✓ Applied theme: {name}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"    Updated: {cssPath}");
        Console.ResetColor();
        Console.WriteLine();

        return 0;
    }

    static int ApplyCustomTheme(string primaryColor)
    {
        var cssPath = FindInputCss();
        if (cssPath == null)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("  Could not find input.css. Run from your project root.");
            Console.ResetColor();
            return 1;
        }

        var content = File.ReadAllText(cssPath);
        content = ReplaceToken(content, "--color-primary:", primaryColor);

        File.WriteAllText(cssPath, content);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($"  ✓ Applied custom primary: {primaryColor}");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"    Updated: {cssPath}");
        Console.ResetColor();
        Console.WriteLine();

        return 0;
    }

    static string ReplaceToken(string content, string token, string value)
    {
        var lines = content.Split('\n');
        for (var i = 0; i < lines.Length; i++)
        {
            var trimmed = lines[i].TrimStart();
            if (trimmed.StartsWith(token))
            {
                var indent = lines[i].Substring(0, lines[i].Length - trimmed.Length);
                lines[i] = $"{indent}{token} {value};";
            }
        }
        return string.Join('\n', lines);
    }

    static string? FindInputCss()
    {
        var cwd = Directory.GetCurrentDirectory();
        var candidates = new[]
        {
            Path.Combine(cwd, "Styles", "input.css"),
            Path.Combine(cwd, "wwwroot", "css", "input.css"),
            Path.Combine(cwd, "src", "input.css"),
            Path.Combine(cwd, "input.css"),
        };

        return candidates.FirstOrDefault(File.Exists);
    }

    // ─── LIST ─────────────────────────────────────────────────

    static int HandleList()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  GlazeUI Components");
        Console.ResetColor();
        Console.WriteLine();

        var grouped = Components.GroupBy(c => c.Value.Tier).OrderBy(g => g.Key switch
        {
            "Atoms" => 0, "Molecules" => 1, "Organisms" => 2, _ => 3
        });

        foreach (var group in grouped)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {group.Key.ToUpperInvariant()} ({group.Count()})");
            Console.ResetColor();

            foreach (var comp in group.OrderBy(c => c.Key))
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write($"    {comp.Key,-20}");
                Console.ResetColor();
                Console.WriteLine(comp.Value.FileName);
            }
            Console.WriteLine();
        }

        Console.WriteLine($"  Total: {Components.Count} components");
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine("  Usage: glaze add button badge input");
        Console.WriteLine("         glaze add --all");
        Console.ResetColor();
        Console.WriteLine();

        return 0;
    }

    // ─── EXTRACT HELPERS ──────────────────────────────────────

    static bool ExtractComponent(string key, string tier, string fileName, string outputDir, bool overwrite)
    {
        var resourceName = GetResourceName($"Templates.{tier}.{fileName}");
        if (resourceName == null) return false;

        var targetDir = Path.Combine(outputDir, "UI", tier);
        Directory.CreateDirectory(targetDir);
        var targetPath = Path.Combine(targetDir, fileName);

        if (File.Exists(targetPath) && !overwrite)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  · {fileName} (already exists, skipped)");
            Console.ResetColor();
            return true;
        }

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) return false;

        using var reader = new StreamReader(stream);
        var content = reader.ReadToEnd();
        File.WriteAllText(targetPath, content);

        var verb = overwrite && File.Exists(targetPath) ? "↻" : "+";
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"  {verb} ");
        Console.ResetColor();
        Console.WriteLine($"{tier}/{fileName}");

        // Also copy companion .razor.css if it exists (Blazor CSS isolation)
        var cssFileName = fileName + ".css";
        var cssResourceName = GetResourceName($"Templates.{tier}.{cssFileName}");
        if (cssResourceName != null)
        {
            var cssTargetPath = Path.Combine(targetDir, cssFileName);
            if (!File.Exists(cssTargetPath) || overwrite)
            {
                using var cssStream = assembly.GetManifestResourceStream(cssResourceName);
                if (cssStream != null)
                {
                    using var cssReader = new StreamReader(cssStream);
                    File.WriteAllText(cssTargetPath, cssReader.ReadToEnd());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"  {verb} ");
                    Console.ResetColor();
                    Console.WriteLine($"{tier}/{cssFileName}");
                }
            }
        }

        return true;
    }

    static void ExtractSharedFile(string dir, string fileName, string outputDir, bool overwrite)
    {
        var resourceName = GetResourceName($"Templates.{dir}.{fileName}");
        if (resourceName == null) return;

        var targetDir = Path.Combine(outputDir, dir);
        Directory.CreateDirectory(targetDir);
        var targetPath = Path.Combine(targetDir, fileName);

        if (File.Exists(targetPath) && !overwrite) return;

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) return;

        using var reader = new StreamReader(stream);
        File.WriteAllText(targetPath, reader.ReadToEnd());

        var verb = overwrite ? "↻" : "+";
        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"  {verb} ");
        Console.ResetColor();
        Console.WriteLine($"{dir}/{fileName} (dependency)");
    }

    static void EnsureSharedDependencies(string outputDir, List<string> addedFiles, bool overwrite)
    {
        if (addedFiles.Count == 0) return;

        // Always need Tw.cs and Enums.cs
        ExtractSharedFile("Utilities", "Tw.cs", outputDir, overwrite);
        ExtractSharedFile("Models", "Enums.cs", outputDir, overwrite);

        // Resolve per-component dependencies
        foreach (var comp in Components)
        {
            if (!addedFiles.Contains(comp.Value.FileName)) continue;
            if (!Dependencies.TryGetValue(comp.Key, out var deps)) continue;

            foreach (var dep in deps)
            {
                if (SharedFiles.TryGetValue(dep, out var shared))
                    ExtractSharedFile(shared.Dir, shared.FileName, outputDir, overwrite);

                // If dependency is a component (e.g. dropdownmenuitem)
                if (Components.TryGetValue(dep, out var compDep))
                    ExtractComponent(dep, compDep.Tier, compDep.FileName, outputDir, overwrite);
            }
        }
    }

    static void PrintSummary(List<string> added, List<string> failed, string outputDir)
    {
        Console.WriteLine();
        if (added.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"  ✓ Added {added.Count} component(s) to {outputDir}");
            Console.ResetColor();
        }
        if (failed.Count > 0)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"  ✗ Failed: {string.Join(", ", failed)}");
            Console.ResetColor();
        }
    }

    static string? GetResourceName(string suffix)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
    }

    static string FindOutputDir()
    {
        var cwd = Directory.GetCurrentDirectory();

        if (Directory.Exists(Path.Combine(cwd, "Components")))
            return Path.Combine(cwd, "Components");

        if (Directory.Exists(Path.Combine(cwd, "UI")))
            return cwd;

        return Path.Combine(cwd, "Components");
    }

    // ─── HELP ─────────────────────────────────────────────────

    static int PrintVersion()
    {
        Console.WriteLine($"glaze {Version}");
        return 0;
    }

    static int PrintHelp()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  GlazeUI CLI");
        Console.ResetColor();
        Console.ForegroundColor = ConsoleColor.DarkGray;
        Console.WriteLine($"  v{Version}");
        Console.ResetColor();
        Console.WriteLine();
        Console.WriteLine("  Usage:");
        Console.WriteLine("    glaze add <component...>      Add component(s) to your project");
        Console.WriteLine("    glaze add --all               Add all components");
        Console.WriteLine("    glaze update <component...>   Update component(s) to latest version");
        Console.WriteLine("    glaze update --all            Update all installed components");
        Console.WriteLine("    glaze list                    List all available components");
        Console.WriteLine("    glaze init                    Initialize shared utilities");
        Console.WriteLine("    glaze theme                   List available themes");
        Console.WriteLine("    glaze theme <name>            Apply a color theme");
        Console.WriteLine("    glaze theme --custom \"oklch(0.55 0.20 180)\"");
        Console.WriteLine("    glaze --version               Show version");
        Console.WriteLine("    glaze --help                  Show this help");
        Console.WriteLine();
        Console.WriteLine("  Themes: default, rose, emerald, amber, violet");
        Console.WriteLine();
        Console.WriteLine("  Examples:");
        Console.WriteLine("    glaze add button badge input");
        Console.WriteLine("    glaze add dialog select tooltip");
        Console.WriteLine("    glaze add --all");
        Console.WriteLine("    glaze update --all");
        Console.WriteLine("    glaze theme rose");
        Console.WriteLine();

        return 0;
    }

    static int UnknownCommand(string command)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"  Unknown command: {command}");
        Console.ResetColor();
        Console.WriteLine("  Run 'glaze --help' for usage.");
        return 1;
    }
}

// ─── Models ──────────────────────────────────────────────────

record ThemeColors(
    string Primary,
    string PrimaryFg,
    string Destructive,
    string Success,
    string Warning,
    string Info
);
