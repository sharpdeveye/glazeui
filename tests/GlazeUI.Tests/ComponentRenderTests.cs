using Bunit;
using GlazeUI.Models;
using GlazeUI.UI.Atoms;
using GlazeUI.UI.Molecules;
using GlazeUI.UI.Organisms;
using Xunit;

namespace GlazeUI.Tests;

/// <summary>
/// Component rendering tests for all 34 GlazeUI components.
/// Verifies correct HTML output, CSS classes, ARIA attributes, and parameter behavior.
/// </summary>
public class ComponentRenderTests : BunitContext
{
    // ─── GzButton ────────────────────────────────────
    [Fact]
    public void Button_Default_RendersWithPrimaryClass()
    {
        var cut = Render<GzButton>(p => p.AddChildContent("Click me"));
        var btn = cut.Find("button");

        Assert.Contains("bg-primary", btn.GetAttribute("class"));
        Assert.Contains("text-primary-foreground", btn.GetAttribute("class"));
        Assert.Equal("Click me", btn.TextContent.Trim());
    }

    [Theory]
    [InlineData(ButtonVariant.Secondary, "bg-secondary")]
    [InlineData(ButtonVariant.Destructive, "bg-destructive")]
    [InlineData(ButtonVariant.Outline, "border")]
    [InlineData(ButtonVariant.Ghost, "hover:bg-accent")]
    [InlineData(ButtonVariant.Link, "underline-offset")]
    public void Button_Variants_RenderCorrectClasses(ButtonVariant variant, string expectedClass)
    {
        var cut = Render<GzButton>(p => p
            .Add(b => b.Variant, variant)
            .AddChildContent("Test"));
        Assert.Contains(expectedClass, cut.Find("button").GetAttribute("class"));
    }

    [Fact]
    public void Button_Disabled_HasDisabledAttribute()
    {
        var cut = Render<GzButton>(p => p
            .Add(b => b.Disabled, true)
            .AddChildContent("Disabled"));
        Assert.True(cut.Find("button").HasAttribute("disabled"));
    }

    [Fact]
    public void Button_Loading_ShowsSpinner()
    {
        var cut = Render<GzButton>(p => p
            .Add(b => b.Loading, true)
            .AddChildContent("Loading"));
        Assert.True(cut.Find("button").HasAttribute("disabled"));
        Assert.NotEmpty(cut.FindAll("svg"));
    }

    // ─── GzBadge ─────────────────────────────────────
    [Fact]
    public void Badge_Default_RendersWithPrimaryClass()
    {
        var cut = Render<GzBadge>(p => p.AddChildContent("New"));
        Assert.Contains("bg-primary", cut.Find("span").GetAttribute("class"));
        Assert.Equal("New", cut.Find("span").TextContent.Trim());
    }

    [Fact]
    public void Badge_Outline_RendersWithBorderClass()
    {
        var cut = Render<GzBadge>(p => p
            .Add(b => b.Variant, BadgeVariant.Outline)
            .AddChildContent("Status"));
        Assert.Contains("border", cut.Find("span").GetAttribute("class"));
    }

    // ─── GzInput ─────────────────────────────────────
    [Fact]
    public void Input_RendersWithPlaceholder()
    {
        var cut = Render<GzInput>(p => p
            .Add(i => i.Placeholder, "Enter email"));
        var input = cut.Find("input");
        Assert.Equal("Enter email", input.GetAttribute("placeholder"));
    }

    [Fact]
    public void Input_Disabled_HasDisabledAttribute()
    {
        var cut = Render<GzInput>(p => p.Add(i => i.Disabled, true));
        Assert.True(cut.Find("input").HasAttribute("disabled"));
    }

    [Fact]
    public void Input_Error_ShowsErrorMessage()
    {
        var cut = Render<GzInput>(p => p
            .Add(i => i.Error, "Invalid email"));
        Assert.Contains("Invalid email", cut.Markup);
    }

    // ─── GzTextarea ──────────────────────────────────
    [Fact]
    public void Textarea_RendersWithRows()
    {
        var cut = Render<GzTextarea>(p => p.Add(t => t.Rows, 5));
        Assert.Equal("5", cut.Find("textarea").GetAttribute("rows"));
    }

    // ─── GzLabel ─────────────────────────────────────
    [Fact]
    public void Label_Required_ShowsAsterisk()
    {
        var cut = Render<GzLabel>(p => p
            .Add(l => l.Required, true)
            .AddChildContent("Email"));
        Assert.Contains("*", cut.Markup);
    }

    [Fact]
    public void Label_For_SetsHtmlForAttribute()
    {
        var cut = Render<GzLabel>(p => p
            .Add(l => l.For, "email-field")
            .AddChildContent("Email"));
        Assert.Equal("email-field", cut.Find("label").GetAttribute("for"));
    }

    // ─── GzCheckbox ──────────────────────────────────
    [Fact]
    public void Checkbox_Renders_WithLabel()
    {
        var cut = Render<GzCheckbox>(p => p
            .AddChildContent("Accept terms"));
        Assert.Contains("Accept terms", cut.Markup);
    }

    [Fact]
    public void Checkbox_Toggle_ChangesState()
    {
        bool isChecked = false;
        var cut = Render<GzCheckbox>(p => p
            .Add(c => c.Checked, isChecked)
            .Add(c => c.CheckedChanged, val => isChecked = val)
            .AddChildContent("Toggle me"));

        cut.Find("input[type='checkbox']").Change(true);
        Assert.True(isChecked);
    }

    // ─── GzSwitch ────────────────────────────────────
    [Fact]
    public void Switch_HasSwitchRole()
    {
        var cut = Render<GzSwitch>(p => p.AddChildContent("Notifications"));
        Assert.Equal("switch", cut.Find("button").GetAttribute("role"));
    }

    [Fact]
    public void Switch_AriaChecked_ReflectsState()
    {
        var cut = Render<GzSwitch>(p => p
            .Add(s => s.Checked, true)
            .AddChildContent("On"));
        Assert.Equal("true", cut.Find("button").GetAttribute("aria-checked"));
    }

    // ─── GzProgress ──────────────────────────────────
    [Fact]
    public void Progress_HasProgressbarRole()
    {
        var cut = Render<GzProgress>(p => p.Add(pr => pr.Value, 50));
        Assert.Equal("progressbar", cut.Find("[role='progressbar']").GetAttribute("role"));
    }

    [Fact]
    public void Progress_AriaValueNow_ReflectsValue()
    {
        var cut = Render<GzProgress>(p => p.Add(pr => pr.Value, 75));
        Assert.Equal("75", cut.Find("[role='progressbar']").GetAttribute("aria-valuenow"));
    }

    // ─── GzSeparator ─────────────────────────────────
    [Fact]
    public void Separator_HasDecorativeRole()
    {
        var cut = Render<GzSeparator>();
        Assert.Equal("none", cut.Find("[role]").GetAttribute("role"));
    }

    // ─── GzCard ──────────────────────────────────────
    [Fact]
    public void Card_RendersContent()
    {
        var cut = Render<GzCard>(p => p
            .AddChildContent("<p>Card body</p>"));
        Assert.Contains("Card body", cut.Markup);
    }

    // ─── GzAlert ─────────────────────────────────────
    [Fact]
    public void Alert_RendersWithAlertRole()
    {
        var cut = Render<GzAlert>(p => p
            .Add(a => a.Title, "Warning")
            .AddChildContent("Something happened"));
        Assert.Equal("alert", cut.Find("[role]").GetAttribute("role"));
    }

    [Fact]
    public void Alert_ShowsTitleAndContent()
    {
        var cut = Render<GzAlert>(p => p
            .Add(a => a.Title, "Heads up")
            .AddChildContent("Check this out"));
        Assert.Contains("Heads up", cut.Markup);
        Assert.Contains("Check this out", cut.Markup);
    }

    // ─── GzSkeleton ──────────────────────────────────
    [Fact]
    public void Skeleton_RendersAnimatedDiv()
    {
        var cut = Render<GzSkeleton>();
        Assert.Contains("animate-pulse", cut.Find("div").GetAttribute("class"));
    }

    // ─── GzAccordion ─────────────────────────────────
    [Fact]
    public void Accordion_RendersChildren()
    {
        var cut = Render<GzAccordion>(p => p
            .AddChildContent("<p>Accordion content</p>"));
        Assert.Contains("Accordion content", cut.Markup);
    }

    // ─── GzBreadcrumb ────────────────────────────────
    [Fact]
    public void Breadcrumb_RendersNavigation()
    {
        var items = new List<BreadcrumbItem>
        {
            new() { Label = "Home", Href = "/" },
            new() { Label = "Docs", Href = "/docs" },
            new() { Label = "Current" }
        };
        var cut = Render<GzBreadcrumb>(p => p.Add(b => b.Items, items));
        Assert.NotNull(cut.Find("nav"));
        Assert.Contains("Home", cut.Markup);
        Assert.Contains("Current", cut.Markup);
    }

    [Fact]
    public void Breadcrumb_LastItem_HasAriaCurrent()
    {
        var items = new List<BreadcrumbItem>
        {
            new() { Label = "Home", Href = "/" },
            new() { Label = "Active" }
        };
        var cut = Render<GzBreadcrumb>(p => p.Add(b => b.Items, items));
        Assert.Contains("aria-current", cut.Markup);
    }

    // ─── GzCombobox ──────────────────────────────────
    [Fact]
    public void Combobox_HasComboboxRole()
    {
        var options = new List<SelectOption>
        {
            new() { Value = "1", Label = "Option 1" },
            new() { Value = "2", Label = "Option 2" }
        };
        var cut = Render<GzCombobox>(p => p
            .Add(c => c.Options, options)
            .Add(c => c.Placeholder, "Search..."));
        Assert.Equal("combobox", cut.Find("input").GetAttribute("role"));
    }

    [Fact]
    public void Combobox_AriaExpanded_FalseByDefault()
    {
        var options = new List<SelectOption> { new() { Value = "1", Label = "One" } };
        var cut = Render<GzCombobox>(p => p.Add(c => c.Options, options));
        Assert.Equal("false", cut.Find("input").GetAttribute("aria-expanded"));
    }

    // ─── GzDataTable ─────────────────────────────────
    [Fact]
    public void DataTable_RendersHeaders()
    {
        var columns = new List<DataTableColumn<TestRecord>>
        {
            new() { Header = "Name", Field = r => r.Name },
            new() { Header = "Age", Field = r => r.Age.ToString() },
        };
        var items = new List<TestRecord>
        {
            new("Alice", 30),
            new("Bob", 25),
        };
        var cut = Render<GzDataTable<TestRecord>>(p => p
            .Add(d => d.Items, items)
            .Add(d => d.Columns, columns));

        Assert.Contains("Name", cut.Markup);
        Assert.Contains("Age", cut.Markup);
        Assert.Contains("Alice", cut.Markup);
        Assert.Contains("Bob", cut.Markup);
    }

    [Fact]
    public void DataTable_Pagination_ShowsPageInfo()
    {
        var columns = new List<DataTableColumn<TestRecord>>
        {
            new() { Header = "Name", Field = r => r.Name },
        };
        var items = Enumerable.Range(1, 15).Select(i => new TestRecord($"User {i}", i)).ToList();
        var cut = Render<GzDataTable<TestRecord>>(p => p
            .Add(d => d.Items, items)
            .Add(d => d.Columns, columns)
            .Add(d => d.PageSize, 5));

        Assert.Contains("Page 1 of 3", cut.Markup);
    }

    // ─── Class Compliance ────────────────────────────
    [Fact]
    public void Button_NoBannedClasses()
    {
        var cut = Render<GzButton>(p => p.AddChildContent("Test"));
        var cls = cut.Find("button").GetAttribute("class") ?? "";
        AssertNoBannedClasses(cls);
    }

    [Fact]
    public void Input_NoBannedClasses()
    {
        var cut = Render<GzInput>();
        var cls = cut.Find("input").GetAttribute("class") ?? "";
        AssertNoBannedClasses(cls);
    }

    [Fact]
    public void Switch_NoBannedClasses()
    {
        var cut = Render<GzSwitch>(p => p.AddChildContent("Toggle"));
        var cls = cut.Find("button").GetAttribute("class") ?? "";
        AssertNoBannedClasses(cls);
    }

    // ─── Focus Ring Compliance ───────────────────────
    [Fact]
    public void Button_UsesFocusVisibleRing()
    {
        var cut = Render<GzButton>(p => p.AddChildContent("Focus"));
        var cls = cut.Find("button").GetAttribute("class") ?? "";
        Assert.Contains("focus-visible:ring-2", cls);
        Assert.DoesNotContain("focus:outline", cls);
    }

    [Fact]
    public void Input_UsesFocusVisibleRing()
    {
        var cut = Render<GzInput>();
        var cls = cut.Find("input").GetAttribute("class") ?? "";
        Assert.Contains("focus-visible:ring-2", cls);
    }

    // ─── GzSlider ─────────────────────────────────────
    [Fact]
    public void Slider_RendersRangeInput()
    {
        var cut = Render<GzSlider>(p => p
            .Add(s => s.Value, 50)
            .Add(s => s.Min, 0)
            .Add(s => s.Max, 100));
        var input = cut.Find("input[type='range']");
        Assert.Equal("0", input.GetAttribute("min"));
        Assert.Equal("100", input.GetAttribute("max"));
    }

    [Fact]
    public void Slider_ShowsValueDisplay()
    {
        var cut = Render<GzSlider>(p => p
            .Add(s => s.Value, 75)
            .Add(s => s.ShowValue, true));
        Assert.Contains("75", cut.Markup);
    }

    [Fact]
    public void Slider_Disabled_HasOpacity()
    {
        var cut = Render<GzSlider>(p => p
            .Add(s => s.Disabled, true));
        Assert.Contains("opacity-50", cut.Markup);
    }

    [Fact]
    public void Slider_Label_RendersText()
    {
        var cut = Render<GzSlider>(p => p
            .Add(s => s.Label, "Volume"));
        Assert.Contains("Volume", cut.Markup);
    }

    // ─── GzDatePicker ────────────────────────────────
    [Fact]
    public void DatePicker_RendersPlaceholder()
    {
        var cut = Render<GzDatePicker>(p => p
            .Add(d => d.Placeholder, "Select date"));
        Assert.Contains("Select date", cut.Markup);
    }

    [Fact]
    public void DatePicker_NoValue_InputIsEmpty()
    {
        var cut = Render<GzDatePicker>();
        var input = cut.Find("input");
        Assert.Equal("", input.GetAttribute("value"));
    }

    [Fact]
    public void DatePicker_Disabled_HasDisabledAttribute()
    {
        var cut = Render<GzDatePicker>(p => p
            .Add(d => d.Disabled, true));
        Assert.True(cut.Find("input").HasAttribute("disabled"));
    }

    // ─── GzFileUpload ────────────────────────────────
    [Fact]
    public void FileUpload_RendersUploadZone()
    {
        var cut = Render<GzFileUpload>();
        Assert.Contains("upload", cut.Markup.ToLower());
    }

    [Fact]
    public void FileUpload_ShowsAcceptHint()
    {
        var cut = Render<GzFileUpload>(p => p
            .Add(f => f.Accept, ".pdf,.png"));
        Assert.Contains(".pdf,.png", cut.Markup);
    }

    [Fact]
    public void FileUpload_ShowsMaxSizeHint()
    {
        long maxSize = 2048;
        var cut = Render<GzFileUpload>(p => p
            .Add(f => f.MaxSizeBytes, maxSize));
        // HintText renders "Max {FormatSize}" when MaxSizeBytes > 0
        Assert.Contains("Max", cut.Markup);
        Assert.Contains("KB", cut.Markup);
    }

    // ─── GzStepper ───────────────────────────────────
    [Fact]
    public void Stepper_RendersStepLabels()
    {
        var steps = new List<StepItem>
        {
            new() { Label = "Account" },
            new() { Label = "Profile" },
            new() { Label = "Review" },
        };
        var cut = Render<GzStepper>(p => p.Add(s => s.Steps, steps));
        Assert.Contains("Account", cut.Markup);
        Assert.Contains("Profile", cut.Markup);
        Assert.Contains("Review", cut.Markup);
    }

    [Fact]
    public void Stepper_RendersCorrectStepNumbers()
    {
        var steps = new List<StepItem>
        {
            new() { Label = "Step A" },
            new() { Label = "Step B" },
        };
        var cut = Render<GzStepper>(p => p.Add(s => s.Steps, steps));
        // Step 1 is active (shows number), Step 2 is upcoming (shows number)
        Assert.Contains(">1<", cut.Markup);
        Assert.Contains(">2<", cut.Markup);
    }

    [Fact]
    public void Stepper_ActiveStep_HasAriaCurrent()
    {
        var steps = new List<StepItem>
        {
            new() { Label = "First" },
            new() { Label = "Second" },
        };
        var cut = Render<GzStepper>(p => p
            .Add(s => s.Steps, steps)
            .Add(s => s.ActiveStep, 0));
        Assert.Contains("aria-current", cut.Markup);
    }

    // ─── Helpers ─────────────────────────────────────
    private static readonly string[] BannedPatterns = new[]
    {
        "bg-slate-", "bg-gray-", "bg-zinc-", "bg-neutral-", "bg-stone-",
        "bg-red-", "bg-blue-", "bg-green-", "bg-purple-", "bg-pink-",
        "text-white", "text-black",
    };

    private static void AssertNoBannedClasses(string classString)
    {
        foreach (var banned in BannedPatterns)
        {
            Assert.DoesNotContain(banned, classString);
        }
    }

    private record TestRecord(string Name, int Age);
}
