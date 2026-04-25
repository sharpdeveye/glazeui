using System.Reflection;

namespace GlazeUI.CLI;

class Program
{
    private static readonly string Version = "1.0.0";

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
        // Molecules
        ["card"]       = ("Molecules", "GzCard.razor"),
        ["alert"]      = ("Molecules", "GzAlert.razor"),
        ["formfield"]  = ("Molecules", "GzFormField.razor"),
        ["tabs"]       = ("Molecules", "GzTabs.razor"),
        ["tooltip"]    = ("Molecules", "GzTooltip.razor"),
        ["select"]     = ("Molecules", "GzSelect.razor"),
        // Organisms
        ["dialog"]            = ("Organisms", "GzDialog.razor"),
        ["dropdownmenu"]      = ("Organisms", "GzDropdownMenu.razor"),
        ["dropdownmenuitem"]  = ("Organisms", "GzDropdownMenuItem.razor"),
        ["popover"]           = ("Organisms", "GzPopover.razor"),
        ["toast"]             = ("Organisms", "GzToast.razor"),
        ["combobox"]          = ("Organisms", "GzCombobox.razor"),
        ["datatable"]         = ("Organisms", "GzDataTable.razor"),
        ["datepicker"]        = ("Organisms", "GzDatePicker.razor"),
        // Molecules (new)
        ["accordion"]         = ("Molecules", "GzAccordion.razor"),
        ["accordionitem"]     = ("Molecules", "GzAccordionItem.razor"),
        ["breadcrumb"]        = ("Molecules", "GzBreadcrumb.razor"),
        ["fileupload"]        = ("Molecules", "GzFileUpload.razor"),
        ["stepper"]           = ("Molecules", "GzStepper.razor"),
        // Atoms (new)
        ["sidebarlink"]       = ("Atoms",     "GzSidebarLink.razor"),
        ["slider"]            = ("Atoms",     "GzSlider.razor"),
    };

    // Shared dependencies
    private static readonly Dictionary<string, (string Dir, string FileName)> SharedFiles = new()
    {
        ["tw"]              = ("Utilities", "Tw.cs"),
        ["enums"]           = ("Models",    "Enums.cs"),
        ["selectoption"]    = ("Models",    "SelectOption.cs"),
        ["tabitem"]         = ("Models",    "TabItem.cs"),
        ["breadcrumbitem"]  = ("Models",    "BreadcrumbItem.cs"),
        ["datatablecolumn"] = ("Models",    "DataTableColumn.cs"),
        ["stepitem"]        = ("Models",    "StepItem.cs"),
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
            "add" => HandleAdd(args.Skip(1).ToArray()),
            "list" => HandleList(),
            "init" => HandleInit(),
            "--version" or "-v" => PrintVersion(),
            "--help" or "-h" or "help" => PrintHelp(),
            _ => UnknownCommand(command)
        };
    }

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
                // Add all components
                foreach (var kvp in Components)
                {
                    if (ExtractComponent(kvp.Key, kvp.Value.Tier, kvp.Value.FileName, outputDir))
                        added.Add(kvp.Value.FileName);
                    else
                        failed.Add(kvp.Key);
                }
                // Also add shared files
                foreach (var kvp in SharedFiles)
                    ExtractSharedFile(kvp.Value.Dir, kvp.Value.FileName, outputDir);
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

            if (ExtractComponent(key, comp.Tier, comp.FileName, outputDir))
                added.Add(comp.FileName);
            else
                failed.Add(name);
        }

        // Always ensure shared dependencies exist
        EnsureSharedDependencies(outputDir, added);

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

        return failed.Count > 0 ? 1 : 0;
    }

    static bool ExtractComponent(string key, string tier, string fileName, string outputDir)
    {
        var resourceName = GetResourceName($"Templates.{tier}.{fileName}");
        if (resourceName == null) return false;

        var targetDir = Path.Combine(outputDir, "UI", tier);
        Directory.CreateDirectory(targetDir);
        var targetPath = Path.Combine(targetDir, fileName);

        if (File.Exists(targetPath))
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

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write($"  + ");
        Console.ResetColor();
        Console.WriteLine($"{tier}/{fileName}");

        // Also copy companion .razor.css if it exists (Blazor CSS isolation)
        var cssFileName = fileName + ".css";
        var cssResourceName = GetResourceName($"Templates.{tier}.{cssFileName}");
        if (cssResourceName != null)
        {
            var cssTargetPath = Path.Combine(targetDir, cssFileName);
            if (!File.Exists(cssTargetPath))
            {
                using var cssStream = assembly.GetManifestResourceStream(cssResourceName);
                if (cssStream != null)
                {
                    using var cssReader = new StreamReader(cssStream);
                    File.WriteAllText(cssTargetPath, cssReader.ReadToEnd());

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write($"  + ");
                    Console.ResetColor();
                    Console.WriteLine($"{tier}/{cssFileName}");
                }
            }
        }

        return true;
    }

    static void ExtractSharedFile(string dir, string fileName, string outputDir)
    {
        var resourceName = GetResourceName($"Templates.{dir}.{fileName}");
        if (resourceName == null) return;

        var targetDir = Path.Combine(outputDir, dir);
        Directory.CreateDirectory(targetDir);
        var targetPath = Path.Combine(targetDir, fileName);

        if (File.Exists(targetPath)) return;

        var assembly = Assembly.GetExecutingAssembly();
        using var stream = assembly.GetManifestResourceStream(resourceName);
        if (stream == null) return;

        using var reader = new StreamReader(stream);
        File.WriteAllText(targetPath, reader.ReadToEnd());

        Console.ForegroundColor = ConsoleColor.DarkCyan;
        Console.Write($"  + ");
        Console.ResetColor();
        Console.WriteLine($"{dir}/{fileName} (dependency)");
    }

    static void EnsureSharedDependencies(string outputDir, List<string> addedFiles)
    {
        if (addedFiles.Count == 0) return;

        // Always need Tw.cs and Enums.cs
        ExtractSharedFile("Utilities", "Tw.cs", outputDir);
        ExtractSharedFile("Models", "Enums.cs", outputDir);

        // Select/Combobox needs SelectOption
        if (addedFiles.Any(f => f.Contains("Select") || f.Contains("Combobox")))
            ExtractSharedFile("Models", "SelectOption.cs", outputDir);

        // Tabs needs TabItem
        if (addedFiles.Any(f => f.Contains("Tabs")))
            ExtractSharedFile("Models", "TabItem.cs", outputDir);

        // Breadcrumb needs BreadcrumbItem
        if (addedFiles.Any(f => f.Contains("Breadcrumb")))
            ExtractSharedFile("Models", "BreadcrumbItem.cs", outputDir);

        // DataTable needs DataTableColumn
        if (addedFiles.Any(f => f.Contains("DataTable")))
            ExtractSharedFile("Models", "DataTableColumn.cs", outputDir);

        // Stepper needs StepItem
        if (addedFiles.Any(f => f.Contains("Stepper")))
            ExtractSharedFile("Models", "StepItem.cs", outputDir);
    }

    static string? GetResourceName(string suffix)
    {
        var assembly = Assembly.GetExecutingAssembly();
        return assembly.GetManifestResourceNames()
            .FirstOrDefault(n => n.EndsWith(suffix, StringComparison.OrdinalIgnoreCase));
    }

    static string FindOutputDir()
    {
        // Look for Components/ or UI/ directory in current path
        var cwd = Directory.GetCurrentDirectory();

        // Check if we're in a Blazor project
        var componentsDir = Path.Combine(cwd, "Components", "UI");
        if (Directory.Exists(Path.Combine(cwd, "Components")))
            return Path.Combine(cwd, "Components");

        // Check if UI folder exists
        if (Directory.Exists(Path.Combine(cwd, "UI")))
            return cwd;

        // Default: create Components/
        return Path.Combine(cwd, "Components");
    }

    static int HandleList()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  GlazeUI Components");
        Console.ResetColor();
        Console.WriteLine();

        var grouped = Components.GroupBy(c => c.Value.Tier);
        foreach (var group in grouped)
        {
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine($"  {group.Key.ToUpperInvariant()}");
            Console.ResetColor();

            foreach (var comp in group)
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

    static int HandleInit()
    {
        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.White;
        Console.WriteLine("  Initializing GlazeUI...");
        Console.ResetColor();

        var outputDir = FindOutputDir();

        // Extract all shared files
        foreach (var kvp in SharedFiles)
            ExtractSharedFile(kvp.Value.Dir, kvp.Value.FileName, outputDir);

        Console.WriteLine();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("  ✓ GlazeUI initialized. Run 'glaze add button' to add your first component.");
        Console.ResetColor();
        Console.WriteLine();

        return 0;
    }

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
        Console.WriteLine("    glaze add <component...>   Add component(s) to your project");
        Console.WriteLine("    glaze add --all            Add all 34 components");
        Console.WriteLine("    glaze list                 List all available components");
        Console.WriteLine("    glaze init                 Initialize shared utilities (Tw.cs, Enums.cs)");
        Console.WriteLine("    glaze --version            Show version");
        Console.WriteLine("    glaze --help               Show this help");
        Console.WriteLine();
        Console.WriteLine("  Examples:");
        Console.WriteLine("    glaze add button badge input");
        Console.WriteLine("    glaze add dialog select tooltip");
        Console.WriteLine("    glaze add --all");
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
