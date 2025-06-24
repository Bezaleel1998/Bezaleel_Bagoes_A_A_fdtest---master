document.addEventListener('DOMContentLoaded', function () {
    const body = document.body;
    const btn = document.getElementById('themeToggle');
    if (!btn) return; // Safety check

    function applyTheme(theme) {
        body.dataset.theme = theme;
        localStorage.setItem('theme', theme);
        btn.textContent = theme === 'dark' ? '☀️' : '🌙';
    }

    const saved = localStorage.getItem('theme');
    if (saved) {
        applyTheme(saved);
    } else {
        const prefersDark = window.matchMedia('(prefers-color-scheme: dark)').matches;
        applyTheme(prefersDark ? 'dark' : 'light');
    }

    btn.addEventListener('click', () => {
        const newTheme = body.dataset.theme === 'dark' ? 'light' : 'dark';
        applyTheme(newTheme);
    });

    console.log("Theme toggle ready.");
});
