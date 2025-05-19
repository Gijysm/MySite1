window.updateProgressBarManually = function (value) {
    const bar = document.querySelector('.progress-bar');
    if (bar) {
        bar.setAttribute("data-value", value.toFixed(2));
        bar.style.setProperty('--progress', value.toFixed(2));

        const progressElement = document.getElementById('progress-percent');
        if (progressElement) {
            progressElement.textContent = `Прогрес: ${value.toFixed(2)}%`;
        }

        bar.classList.remove("animate");
        void bar.offsetWidth;
        bar.classList.add("animate");

        console.log("✔️ Прогрес оновлено до", value.toFixed(2));
    } else {
        console.warn("⚠️ .progress-bar не знайдено!");
    }
};