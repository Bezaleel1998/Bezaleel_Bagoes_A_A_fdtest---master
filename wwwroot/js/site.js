// Please see documentation at https://learn.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
document.addEventListener('DOMContentLoaded', function () {
    const clock = document.getElementById("clock");
    if (clock) {
        function updateClock() {
            const now = new Date();
            clock.textContent = "🕒 " + now.toLocaleString();
        }
        updateClock();
        setInterval(updateClock, 1000);
    }
});