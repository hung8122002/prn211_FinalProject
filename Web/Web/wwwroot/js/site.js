// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var datepicker = $(".datepicker");
    changeDate()
    datepicker.on("input", () => {
        changeDate()
    })

    var datepicker_picker = $(".datepicker-picker");
    datepicker_picker.click(() => {
        changeDate()
    })

    function getWeekDatesContainingDate(dateString) {
        const [day, month, year] = dateString.split('/'); // Tách chuỗi thành ngày, tháng và năm
        const date = new Date(`${month}/${day}/${year}`); // Tạo đối tượng Date từ chuỗi ngày tháng năm

        const dates = [];

        for (let i = date.getDay(); i >= 0; i--) {
            const nextDay = new Date(date.getTime());
            nextDay.setDate(date.getDate() - i); // Tính toán ngày trong tuần
            const nextDayString = `${nextDay.getDate().toString().padStart(2, '0')}/${(nextDay.getMonth() + 1).toString().padStart(2, '0')}`; // Định dạng ngày trong tuần
            dates.push(nextDayString);
        }

        for (let i = 1; i < 7 - date.getDay(); i++) {
            const nextDay = new Date(date.getTime());
            nextDay.setDate(date.getDate() + i); // Tính toán ngày trong tuần
            const nextDayString = `${nextDay.getDate().toString().padStart(2, '0')}/${(nextDay.getMonth() + 1).toString().padStart(2, '0')}`; // Định dạng ngày trong tuần
            dates.push(nextDayString);
        }

        return dates;
    }

    function changeDate() {
        const weekDates = getWeekDatesContainingDate(datepicker.val());
        var th = $("th")
        var td = $("td")
        const date = new Date().toISOString();
        for (var i = 1; i < 8; i++) {
            th.eq(i).text(th.eq(i).text().slice(0, 4) + " - " + weekDates[i - 1])
        }
        $.get("/MainPage", {
            handler: "Data",
            startDate: weekDates[0],
            endDate: weekDates[6]
        }, function (data) {
            var day = 1;
            var list = data.scheduleDetailDTOs
            for (var i = 0; i < list.length; i++) {
                if (i > 0 && list[i].date > list[i - 1].date) {
                    day++;
                }
                const index = (list[i].slot - 1) * 7 + day
                td.eq(index).html(`<p class="table-title">Course: <a>${list[i].course.courseName}</a> </br> at ${list[i].class.className}</p>`)
                td.eq(index).append(`<p class="${list[i].attendance ? 'attended' : list[i].date <= date ? 'absent' : 'not-yet'}">(${list[i].attendance ? 'Attended' : list[i].date <= date ? 'Absent' : 'Not yet'})</p>`)
            }
        });
    }

    function ShowAlert(attr, title, mess) {
        var alertList = $(".alert-list");
        var el = document.createElement("div");
        el.classList.add("flex")
        el.classList.add("justify-end")
        el.innerHTML = (`<div class="alert z-10 flex p-3 w-fit mb-2 text-sm text-white border border-${attr}-300 rounded-lg bg-${attr}-50 dark:bg-${attr}-700 dark:text-green-400 dark:border-green-800" role="alert">
  <svg aria-hidden="true" class="flex-shrink-0 inline w-5 h-5 mr-3" fill="currentColor" viewBox="0 0 20 20" xmlns="http://www.w3.org/2000/svg"><path fill-rule="evenodd" d="M18 10a8 8 0 11-16 0 8 8 0 0116 0zm-7-4a1 1 0 11-2 0 1 1 0 012 0zM9 9a1 1 0 000 2v3a1 1 0 001 1h1a1 1 0 100-2v-3a1 1 0 00-1-1H9z" clip-rule="evenodd"></path></svg>
  <span class="sr-only">Info</span>
  <div>
    <span class="font-medium">${title} alert!</span> ${mess}
  </div>
</div>
</div>`);
        alertList.append(el);
        setTimeout(() => {
            $(el).remove();
        }, 3500);
    }
});