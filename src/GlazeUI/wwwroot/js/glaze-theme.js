// GlazeUI — Dark mode toggle via JS interop
// Manages the .dark class on <html> and persists preference to localStorage

window.glazeTheme = {
    init: function () {
        const saved = localStorage.getItem('glazeui-theme');
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        const isDark = saved === 'dark' || (!saved && prefersDark);

        document.documentElement.classList.toggle('dark', isDark);
        return isDark;
    },

    toggle: function () {
        const isDark = document.documentElement.classList.toggle('dark');
        localStorage.setItem('glazeui-theme', isDark ? 'dark' : 'light');
        return isDark;
    },

    get: function () {
        return document.documentElement.classList.contains('dark');
    }
};

// Auto-initialize on load
window.glazeTheme.init();
