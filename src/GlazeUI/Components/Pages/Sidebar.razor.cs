using GlazeUI.Models;
namespace GlazeUI.Components.Pages;

public partial class Sidebar
{
    private string _activeSection = "dashboard";
    private readonly HashSet<string> _expandedItems = new();
    private bool _detailCollapsed;
    private string _search = "";

    private void SetSection(string id) { _activeSection = id; _expandedItems.Clear(); }
    private void ToggleExpand(string key) { if (!_expandedItems.Remove(key)) _expandedItems.Add(key); }
    private void ToggleDetail() => _detailCollapsed = !_detailCollapsed;

    // Heroicon 24px outline paths
    private const string IcoSquares = "M3.75 6A2.25 2.25 0 0 1 6 3.75h2.25A2.25 2.25 0 0 1 10.5 6v2.25a2.25 2.25 0 0 1-2.25 2.25H6a2.25 2.25 0 0 1-2.25-2.25V6Zm0 9.75A2.25 2.25 0 0 1 6 13.5h2.25a2.25 2.25 0 0 1 2.25 2.25V18a2.25 2.25 0 0 1-2.25 2.25H6A2.25 2.25 0 0 1 3.75 18v-2.25ZM13.5 6a2.25 2.25 0 0 1 2.25-2.25H18A2.25 2.25 0 0 1 20.25 6v2.25A2.25 2.25 0 0 1 18 10.5h-2.25a2.25 2.25 0 0 1-2.25-2.25V6ZM13.5 15.75a2.25 2.25 0 0 1 2.25-2.25H18a2.25 2.25 0 0 1 2.25 2.25V18A2.25 2.25 0 0 1 18 20.25h-2.25a2.25 2.25 0 0 1-2.25-2.25v-2.25Z";
    private const string IcoClipboard = "M11.35 3.836c-.065.21-.1.433-.1.664 0 .414.336.75.75.75h4.5a.75.75 0 0 0 .75-.75 2.25 2.25 0 0 0-.1-.664m-5.8 0A2.251 2.251 0 0 1 13.5 2.25H15c1.012 0 1.867.668 2.15 1.586m-5.8 0c-.376.023-.75.05-1.124.08C9.095 4.01 8.25 4.973 8.25 6.108V19.5a2.625 2.625 0 0 0 2.625 2.625h5.25a2.625 2.625 0 0 0 2.625-2.625V6.108c0-1.135-.845-2.098-1.976-2.192a48.424 48.424 0 0 0-1.123-.08m-5.8 0c-.065.21-.1.433-.1.664";
    private const string IcoFolder = "M2.25 12.75V12A2.25 2.25 0 0 1 4.5 9.75h15A2.25 2.25 0 0 1 21.75 12v.75m-8.69-6.44-2.12-2.12a1.5 1.5 0 0 0-1.061-.44H4.5A2.25 2.25 0 0 0 2.25 6v12a2.25 2.25 0 0 0 2.25 2.25h15A2.25 2.25 0 0 0 21.75 18V9a2.25 2.25 0 0 0-2.25-2.25h-5.379a1.5 1.5 0 0 1-1.06-.44Z";
    private const string IcoCal = "M6.75 3v2.25M17.25 3v2.25M3 18.75V7.5a2.25 2.25 0 0 1 2.25-2.25h13.5A2.25 2.25 0 0 1 21 7.5v11.25m-18 0A2.25 2.25 0 0 0 5.25 21h13.5A2.25 2.25 0 0 0 21 18.75m-18 0v-7.5A2.25 2.25 0 0 1 5.25 9h13.5A2.25 2.25 0 0 1 21 11.25v7.5";
    private const string IcoUsers = "M18 18.72a9.094 9.094 0 0 0 3.741-.479 3 3 0 0 0-4.682-2.72m.94 3.198.001.031c0 .225-.012.447-.037.666A11.944 11.944 0 0 1 12 21c-2.17 0-4.207-.576-5.963-1.584A6.062 6.062 0 0 1 6 18.719m12 0a5.971 5.971 0 0 0-.941-3.197m0 0A5.995 5.995 0 0 0 12 12.75a5.995 5.995 0 0 0-5.058 2.772m0 0a3 3 0 0 0-4.681 2.72 8.986 8.986 0 0 0 3.74.477m.94-3.197a5.971 5.971 0 0 0-.94 3.197M15 6.75a3 3 0 1 1-6 0 3 3 0 0 1 6 0Zm6 3a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Zm-13.5 0a2.25 2.25 0 1 1-4.5 0 2.25 2.25 0 0 1 4.5 0Z";
    private const string IcoChart = "M3 13.125C3 12.504 3.504 12 4.125 12h2.25c.621 0 1.125.504 1.125 1.125v6.75C7.5 20.496 6.996 21 6.375 21h-2.25A1.125 1.125 0 0 1 3 19.875v-6.75ZM9.75 8.625c0-.621.504-1.125 1.125-1.125h2.25c.621 0 1.125.504 1.125 1.125v11.25c0 .621-.504 1.125-1.125 1.125h-2.25a1.125 1.125 0 0 1-1.125-1.125V8.625ZM16.5 4.125c0-.621.504-1.125 1.125-1.125h2.25C20.496 3 21 3.504 21 4.125v15.75c0 .621-.504 1.125-1.125 1.125h-2.25a1.125 1.125 0 0 1-1.125-1.125V4.125Z";
    private const string IcoDoc = "M19.5 14.25v-2.625a3.375 3.375 0 0 0-3.375-3.375h-1.5A1.125 1.125 0 0 1 13.5 7.125v-1.5a3.375 3.375 0 0 0-3.375-3.375H8.25m2.25 0H5.625c-.621 0-1.125.504-1.125 1.125v17.25c0 .621.504 1.125 1.125 1.125h12.75c.621 0 1.125-.504 1.125-1.125V11.25a9 9 0 0 0-9-9Z";
    private const string IcoCog = "M9.594 3.94c.09-.542.56-.94 1.11-.94h2.593c.55 0 1.02.398 1.11.94l.213 1.281c.063.374.313.686.645.87.074.04.147.083.22.127.325.196.72.257 1.075.124l1.217-.456a1.125 1.125 0 0 1 1.37.49l1.296 2.247a1.125 1.125 0 0 1-.26 1.431l-1.003.827c-.293.241-.438.613-.43.992a7.723 7.723 0 0 1 0 .255c-.008.378.137.75.43.991l1.004.827c.424.35.534.955.26 1.43l-1.298 2.248a1.125 1.125 0 0 1-1.369.491l-1.217-.456c-.355-.133-.75-.072-1.076.124a6.47 6.47 0 0 1-.22.128c-.331.183-.581.495-.644.869l-.213 1.281c-.09.543-.56.94-1.11.94h-2.594c-.55 0-1.019-.398-1.11-.94l-.213-1.281c-.062-.374-.312-.686-.644-.87a6.52 6.52 0 0 1-.22-.127c-.325-.196-.72-.257-1.076-.124l-1.217.456a1.125 1.125 0 0 1-1.369-.49l-1.297-2.247a1.125 1.125 0 0 1 .26-1.431l1.004-.827c.292-.24.437-.613.43-.991a6.932 6.932 0 0 1 0-.255c.007-.38-.138-.751-.43-.992l-1.004-.827a1.125 1.125 0 0 1-.26-1.43l1.297-2.247a1.125 1.125 0 0 1 1.37-.491l1.216.456c.356.133.751.072 1.076-.124.072-.044.146-.086.22-.128.332-.183.582-.495.644-.869l.214-1.28Z M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z";
    private const string IcoSearch = "m21 21-5.197-5.197m0 0A7.5 7.5 0 1 0 5.196 5.196a7.5 7.5 0 0 0 10.607 10.607Z";
    private const string IcoUser = "M15.75 6a3.75 3.75 0 1 1-7.5 0 3.75 3.75 0 0 1 7.5 0ZM4.501 20.118a7.5 7.5 0 0 1 14.998 0A17.933 17.933 0 0 1 12 21.75c-2.676 0-5.216-.584-7.499-1.632Z";
    private const string IcoChevDown = "m19.5 8.25-7.5 7.5-7.5-7.5";
    private const string IcoPlus = "M12 4.5v15m7.5-7.5h-15";
    private const string IcoFunnel = "M12 3c2.755 0 5.455.232 8.083.678.533.09.917.556.917 1.096v1.044a2.25 2.25 0 0 1-.659 1.591l-5.432 5.432a2.25 2.25 0 0 0-.659 1.591v2.927a2.25 2.25 0 0 1-1.244 2.013L9.75 21v-6.568a2.25 2.25 0 0 0-.659-1.591L3.659 7.409A2.25 2.25 0 0 1 3 5.818V4.774c0-.54.384-1.006.917-1.096A48.32 48.32 0 0 1 12 3Z";
    private const string IcoClock = "M12 6v6h4.5m4.5 0a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z";
    private const string IcoCheck = "M9 12.75 11.25 15 15 9.75M21 12a9 9 0 1 1-18 0 9 9 0 0 1 18 0Z";
    private const string IcoFlag = "M3 3v1.5M3 21v-6m0 0 2.77-.693a9 9 0 0 1 6.208.682l.108.054a9 9 0 0 0 6.086.71l3.114-.732a48.524 48.524 0 0 1-.005-10.499l-3.11.732a9 9 0 0 1-6.085-.711l-.108-.054a9 9 0 0 0-6.208-.682L3 4.5M3 15V4.5";
    private const string IcoArchive = "m20.25 7.5-.625 10.632a2.25 2.25 0 0 1-2.247 2.118H6.622a2.25 2.25 0 0 1-2.247-2.118L3.75 7.5M10 11.25h4M3.375 7.5h17.25c.621 0 1.125-.504 1.125-1.125v-1.5c0-.621-.504-1.125-1.125-1.125H3.375c-.621 0-1.125.504-1.125 1.125v1.5c0 .621.504 1.125 1.125 1.125Z";
    private const string IcoEye = "M2.036 12.322a1.012 1.012 0 0 1 0-.639C3.423 7.51 7.36 4.5 12 4.5c4.638 0 8.573 3.007 9.963 7.178.07.207.07.431 0 .639C20.577 16.49 16.64 19.5 12 19.5c-4.638 0-8.573-3.007-9.963-7.178Z M15 12a3 3 0 1 1-6 0 3 3 0 0 1 6 0Z";
    private const string IcoStar = "M11.48 3.499a.562.562 0 0 1 1.04 0l2.125 5.111a.563.563 0 0 0 .475.345l5.518.442c.499.04.701.663.321.988l-4.204 3.602a.563.563 0 0 0-.182.557l1.285 5.385a.562.562 0 0 1-.84.61l-4.725-2.885a.562.562 0 0 0-.586 0L6.982 20.54a.562.562 0 0 1-.84-.61l1.285-5.386a.562.562 0 0 0-.182-.557l-4.204-3.602a.562.562 0 0 1 .321-.988l5.518-.442a.563.563 0 0 0 .475-.345L11.48 3.5Z";
    private const string IcoShield = "M9 12.75 11.25 15 15 9.75m-3-7.036A11.959 11.959 0 0 1 3.598 6 11.99 11.99 0 0 0 3 9.749c0 5.592 3.824 10.29 9 11.623 5.176-1.332 9-6.03 9-11.622 0-1.31-.21-2.571-.598-3.751h-.152c-3.196 0-6.1-1.248-8.25-3.285Z";
    private const string IcoBell = "M14.857 17.082a23.848 23.848 0 0 0 5.454-1.31A8.967 8.967 0 0 1 18 9.75V9A6 6 0 0 0 6 9v.75a8.967 8.967 0 0 1-2.312 6.022c1.733.64 3.56 1.085 5.455 1.31m5.714 0a24.255 24.255 0 0 1-5.714 0m5.714 0a3 3 0 1 1-5.714 0";
    private const string IcoPuzzle = "M14.25 6.087c0-.355.186-.676.401-.959.221-.29.349-.634.349-1.003 0-1.036-1.007-1.875-2.25-1.875s-2.25.84-2.25 1.875c0 .369.128.713.349 1.003.215.283.401.604.401.959v0a.64.64 0 0 1-.657.643 48.491 48.491 0 0 0-4.163.3v0a.64.64 0 0 1-.657-.643v0c0-.355.186-.676.401-.959.221-.29.349-.634.349-1.003 0-1.035-1.008-1.875-2.25-1.875-1.243 0-2.25.84-2.25 1.875";
    private const string IcoUpload = "M12 16.5V9.75m0 0 3 3m-3-3-3 3M6.75 19.5a4.5 4.5 0 0 1-1.41-8.775 5.25 5.25 0 0 1 10.233-2.33 3 3 0 0 1 3.758 3.848A3.752 3.752 0 0 1 18 19.5H6.75Z";
    private const string IcoShare = "M7.217 10.907a2.25 2.25 0 1 0 0 2.186m0-2.186c.18.324.283.696.283 1.093s-.103.77-.283 1.093m0-2.186 9.566-5.314m-9.566 7.5 9.566 5.314m0 0a2.25 2.25 0 1 0 3.935 2.186 2.25 2.25 0 0 0-3.935-2.186Zm0-12.814a2.25 2.25 0 1 0 3.933-2.185 2.25 2.25 0 0 0-3.933 2.185Z";
    private const string IcoArrowPath = "M16.023 9.348h4.992v-.001M2.985 19.644v-4.992m0 0h4.992m-4.993 0 3.181 3.183a8.25 8.25 0 0 0 13.803-3.7M4.031 9.865a8.25 8.25 0 0 1 13.803-3.7l3.181 3.182";
    private const string IcoFolderOpen = "M3.75 9.776c.112-.017.227-.026.344-.026h15.812c.117 0 .232.009.344.026m-16.5 0a2.25 2.25 0 0 0-1.883 2.542l.857 6a2.25 2.25 0 0 0 2.227 1.932H19.05a2.25 2.25 0 0 0 2.227-1.932l.857-6a2.25 2.25 0 0 0-1.883-2.542m-16.5 0V6A2.25 2.25 0 0 1 6 3.75h3.879a1.5 1.5 0 0 1 1.06.44l2.122 2.12a1.5 1.5 0 0 0 1.06.44H18A2.25 2.25 0 0 1 20.25 9v.776";

    private static string Ico(string d, string cls = "size-4") =>
        $"<svg class='{cls}' fill='none' viewBox='0 0 24 24' stroke-width='1.5' stroke='currentColor'><path stroke-linecap='round' stroke-linejoin='round' d='{d}'/></svg>";

    private static readonly SbNavItem[] NavItems =
    {
        new("dashboard", "Dashboard", IcoSquares),
        new("tasks", "Tasks", IcoClipboard),
        new("projects", "Projects", IcoFolder),
        new("calendar", "Calendar", IcoCal),
        new("teams", "Teams", IcoUsers),
        new("analytics", "Analytics", IcoChart),
        new("files", "Files", IcoDoc),
    };

    private SbContentPanel GetContent() => _activeSection switch
    {
        "dashboard" => new("Dashboard", new SbMenuSection[] {
            new("Dashboard Types", new SbMenuItem[] {
                new("Overview", IcoEye, IsActive: true),
                new("Executive Summary", IcoSquares, true, Children: new SbMenuItem[] { new("Revenue Overview"), new("Key Performance Indicators"), new("Strategic Goals Progress"), new("Department Highlights") }),
                new("Operations", IcoChart, true, Children: new SbMenuItem[] { new("Project Timeline"), new("Resource Allocation"), new("Team Performance"), new("Capacity Planning") }),
                new("Financial", IcoChart, true, Children: new SbMenuItem[] { new("Budget vs Actual"), new("Cash Flow Analysis"), new("Expense Breakdown"), new("Profit & Loss Summary") }),
            }),
            new("Report Summaries", new SbMenuItem[] {
                new("Weekly Reports", IcoDoc, true, Children: new SbMenuItem[] { new("Team Productivity: 87%"), new("Project Completion: 12/15"), new("Budget Utilization: 73%"), new("Client Satisfaction: 4.6/5") }),
                new("Monthly Insights", IcoStar, true, Children: new SbMenuItem[] { new("Revenue Growth: +15.3%"), new("New Clients: 24"), new("Team Expansion: 8 hires"), new("Cost Reduction: 7.2%") }),
            }),
        }),
        "tasks" => new("Tasks", new SbMenuSection[] {
            new("Quick Actions", new SbMenuItem[] { new("New task", IcoPlus), new("Filter tasks", IcoFunnel) }),
            new("My Tasks", new SbMenuItem[] {
                new("Due today", IcoClock, true, Children: new SbMenuItem[] { new("Review design mockups", IcoFlag), new("Update documentation", IcoCheck), new("Test new feature", IcoArrowPath) }),
                new("In progress", IcoArrowPath, true, Children: new SbMenuItem[] { new("Implement user auth", IcoClipboard), new("Database migration", IcoClipboard) }),
                new("Completed", IcoCheck, true, Children: new SbMenuItem[] { new("Fixed login bug", IcoCheck), new("Updated dependencies", IcoCheck), new("Code review completed", IcoCheck) }),
            }),
            new("Other", new SbMenuItem[] {
                new("Priority tasks", IcoFlag, true, Children: new SbMenuItem[] { new("Security update", IcoFlag), new("Client presentation", IcoFlag) }),
                new("Archived", IcoArchive),
            }),
        }),
        "projects" => new("Projects", new SbMenuSection[] {
            new("Quick Actions", new SbMenuItem[] { new("New project", IcoPlus), new("Filter projects", IcoFunnel) }),
            new("Active Projects", new SbMenuItem[] {
                new("Web Application", IcoFolderOpen, true, Children: new SbMenuItem[] { new("Frontend development", IcoClipboard), new("API integration", IcoClipboard), new("Testing & QA", IcoClipboard) }),
                new("Mobile App", IcoFolderOpen, true, Children: new SbMenuItem[] { new("UI/UX design", IcoClipboard), new("Native development", IcoClipboard) }),
            }),
            new("Other", new SbMenuItem[] { new("Completed", IcoCheck), new("Archived", IcoArchive) }),
        }),
        "calendar" => new("Calendar", new SbMenuSection[] {
            new("Views", new SbMenuItem[] { new("Month view", IcoEye), new("Week view", IcoCal), new("Day view", IcoClock) }),
            new("Events", new SbMenuItem[] {
                new("Today's events", IcoClock, true, Children: new SbMenuItem[] { new("Team standup (9:00 AM)", IcoUsers), new("Client call (2:00 PM)", IcoUser), new("Project review (4:00 PM)", IcoUsers) }),
                new("Upcoming events", IcoCal),
            }),
            new("Quick Actions", new SbMenuItem[] { new("New event", IcoPlus), new("Share calendar", IcoShare) }),
        }),
        "teams" => new("Teams", new SbMenuSection[] {
            new("My Teams", new SbMenuItem[] {
                new("Development Team", IcoUsers, true, Children: new SbMenuItem[] { new("John Doe (Lead)", IcoUser), new("Jane Smith", IcoUser), new("Mike Johnson", IcoUser) }),
                new("Design Team", IcoUsers, true, Children: new SbMenuItem[] { new("Sarah Wilson", IcoUser), new("Tom Brown", IcoUser) }),
            }),
            new("Quick Actions", new SbMenuItem[] { new("Invite member", IcoPlus), new("Manage teams", IcoUsers) }),
        }),
        "analytics" => new("Analytics", new SbMenuSection[] {
            new("Reports", new SbMenuItem[] { new("Performance report", IcoDoc), new("Task completion", IcoChart), new("Team productivity", IcoChart) }),
            new("Insights", new SbMenuItem[] {
                new("Key metrics", IcoStar, true, Children: new SbMenuItem[] { new("Tasks completed: 24", IcoCheck), new("Avg. completion: 2.5d", IcoClock), new("Team efficiency: 87%", IcoUsers) }),
            }),
        }),
        "files" => new("Files", new SbMenuSection[] {
            new("Quick Actions", new SbMenuItem[] { new("Upload file", IcoUpload), new("New folder", IcoPlus) }),
            new("Recent Files", new SbMenuItem[] {
                new("Recent documents", IcoDoc, true, Children: new SbMenuItem[] { new("Project proposal.pdf", IcoDoc), new("Meeting notes.docx", IcoDoc), new("Design specs.figma", IcoDoc) }),
                new("Shared with me", IcoShare),
            }),
            new("Organization", new SbMenuItem[] { new("All folders", IcoFolder), new("Archived files", IcoArchive) }),
        }),
        "settings" => new("Settings", new SbMenuSection[] {
            new("Account", new SbMenuItem[] { new("Profile settings", IcoUser), new("Security", IcoShield), new("Notifications", IcoBell) }),
            new("Workspace", new SbMenuItem[] {
                new("Preferences", IcoCog, true, Children: new SbMenuItem[] { new("Theme settings", IcoEye), new("Time zone", IcoClock), new("Default notifications", IcoBell) }),
                new("Integrations", IcoPuzzle),
            }),
        }),
        _ => new("Dashboard", Array.Empty<SbMenuSection>()),
    };
}
