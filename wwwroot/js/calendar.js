// 1.Lấy phần tử từ HTML
const daysTag = document.querySelector(".days");
const currentDate = document.querySelector(".current-date");
const prevNextIcon = document.querySelectorAll(".icons span");
// 2.Lấy ngày mới, năm và tháng hiện tại
let date = new Date(),
    currYear = date.getFullYear(),
    currMonth = date.getMonth();

// 3.Tạo mảng lưu tên đầy đủ của tất cả các tháng
const months = [
    "Tháng 1",
    "Tháng 2",
    "Tháng 3",
    "Tháng 4",
    "Tháng 5",
    "Tháng 6",
    "Tháng 7",
    "Tháng 8",
    "Tháng 9",
    "Tháng 10",
    "Tháng 11",
    "Tháng 12"
];

const renderCalendar = () => {
    let firstDayofMonth = new Date(currYear, currMonth, 1).getDay(); // Lấy ngày đầu tiên của tháng
    const lastDateofMonth = new Date(currYear, currMonth + 1, 0).getDate(); // Lấy ngày cuối cùng của tháng
    const lastDayofMonth = new Date(currYear, currMonth, lastDateofMonth).getDay(); // Lấy ngày cuối cùng của tháng (theo thứ)
    const lastDateofLastMonth = new Date(currYear, currMonth, 0).getDate(); // Lấy ngày cuối cùng của tháng trước

    // Điều chỉnh thứ bắt đầu từ Thứ Hai (0)
    if (firstDayofMonth === 0) {
        firstDayofMonth = 7;
    }

    let liTag = "";

    // Tạo các thẻ li cho những ngày cuối cùng của tháng trước
    for (let i = firstDayofMonth; i > 0; i--) {
        liTag += `<li class="inactive">${lastDateofLastMonth - i + 1}</li>`;
    }

    // Tạo các thẻ li cho tất cả các ngày trong tháng hiện tại
    for (let i = 1; i <= lastDateofMonth; i++) { 
        // Thêm lớp "active" cho li nếu khớp với ngày, tháng và năm hiện tại
        let isToday = i  === date.getDate() && currMonth === new Date().getMonth()
            && currYear === new Date().getFullYear() ? "active" : "";
        liTag += `<li id="date" class="${isToday}">${i}</li>`;
    }

    // Tạo các thẻ li cho những ngày đầu tiên của tháng sau
    for (let i = lastDayofMonth; i < 6; i++) {
        liTag += `<li class="inactive">${i - lastDayofMonth + 1}</li>`
    }
    // Hiển thị tháng và năm hiện tại
    currentDate.innerText = `${months[currMonth]}`+'-'+`${currYear}`;
    daysTag.innerHTML = liTag;

    addClickEventToDays(currMonth, currYear);
}
// Gọi hàm renderCalendar để hiển thị lịch
renderCalendar();

prevNextIcon.forEach(icon => { // getting prev and next icons
    icon.addEventListener("click", () => { // adding click event on both icons
        // if clicked icon is previous icon then decrement current month by 1 else increment it by 1
        currMonth = icon.id === "prev" ? currMonth - 1 : currMonth + 1;

        if (currMonth < 0 || currMonth > 11) { // if current month is less than 0 or greater than 11
            // creating a new date of current year & month and pass it as date value
            date = new Date(currYear, currMonth, new Date().getDate());
            currYear = date.getFullYear(); // updating current year with new date year
            currMonth = date.getMonth(); // updating current month with new date month
        } else {
            date = new Date(); // pass the current date as date value
        }
        renderCalendar(); // calling renderCalendar function
    });
});

const formBox = document.querySelector('.formBox');
const close = document.querySelector('#close');
const datetime = document.querySelector('#datetime');

function addClickEventToDays(CurrMonth, CurrYear) {
    const calendarDays = document.querySelectorAll('#date');
    calendarDays.forEach(day => {
        day.addEventListener('click', (event) => {
            const selectedDay = parseInt(event.target.textContent);
            datetime.value = new Date(CurrYear, CurrMonth, selectedDay+1).toISOString().slice(0, 10);
            formBox.style.display = 'block';
        });
    });
}

close.addEventListener('click', () => {
    formBox.style.display = 'none';  // Change display to 'block' on click
});


