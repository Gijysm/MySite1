const header = document.querySelector('.Calendar_h3');
const dates = document.querySelector('.dates'); // правильний селектор!
const prevBtn = document.querySelector('#prev');
const nextBtn = document.querySelector('#next');

const months = [
    "Січень", "Лютий", "Березень", "Квітень", "Травень", "Червень",
    "Липень", "Серпень", "Вересень", "Жовтень", "Листопад", "Грудень"
];

let date = new Date();
let month = date.getMonth();
let year = date.getFullYear();

function renderCalendar() {
    let firstDayIndex = new Date(year, month, 1).getDay();
    let lastDate = new Date(year, month + 1, 0).getDate();
    let prevLastDate = new Date(year, month, 0).getDate();
    let lastDayIndex = new Date(year, month, lastDate).getDay();

    firstDayIndex = firstDayIndex === 0 ? 6 : firstDayIndex - 1;
    lastDayIndex = lastDayIndex === 0 ? 6 : lastDayIndex - 1;

    let datesHTML = '';
    
    for (let i = firstDayIndex; i > 0; i--) {
        datesHTML += `<li class="inactive">${prevLastDate - i + 1}</li>`;
    }
    
    for (let i = 1; i <= lastDate; i++) {
        const isToday =
            i === new Date().getDate() &&
            month === new Date().getMonth() &&
            year === new Date().getFullYear();
        datesHTML += `<li class="${isToday ? 'today' : ''}">${i}</li>`;
    }
    
    for (let i = 1; i < 7 - lastDayIndex - 1; i++) {
        datesHTML += `<li class="inactive">${i}</li>`;
    }

    header.textContent = `${months[month]} ${year}`;
    dates.innerHTML = datesHTML;
}

renderCalendar();

prevBtn.addEventListener("click", () => {
    month--;
    if (month < 0) {
        month = 11;
        year--;
    }
    renderCalendar();
});

nextBtn.addEventListener("click", () => {
    month++;
    if (month > 11) {
        month = 0;
        year++;
    }
    renderCalendar();
});
