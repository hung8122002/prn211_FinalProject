﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.
$(document).ready(function () {
    var datepicker = $(".datepicker");
    changeDate()
    showListDay()
    submitAttendance()
    datepicker.on("input", () => {
        changeDate()
    })

    var datepicker_picker = $(".datepicker-picker");
    datepicker_picker.click(() => {
        changeDate()
    })

    $(".datepicker").click(() => {
        $(".datepicker-dropdown").show()
    })

    $(".datepicker-dropdown").click(() => {
        $(".datepicker-dropdown").hide()
    })

    function getWeekDatesContainingDate(dateString) {
        const [day, month, year] = dateString.split('/'); // Tách chuỗi thành ngày, tháng và năm
        const date = new Date(`${month}/${day}/${year}`); // Tạo đối tượng Date từ chuỗi ngày tháng năm

        const dates = [];

        for (let i = date.getDay(); i >= 0; i--) {
            const nextDay = new Date(date.getTime());
            nextDay.setDate(date.getDate() - i); // Tính toán ngày trong tuần
            const nextDayString = `${nextDay.getDate().toString().padStart(2, '0')}/${(nextDay.getMonth() + 1).toString().padStart(2, '0')}/${year}`; // Định dạng ngày trong tuần
            dates.push(nextDayString);
        }

        for (let i = 1; i < 7 - date.getDay(); i++) {
            const nextDay = new Date(date.getTime());
            nextDay.setDate(date.getDate() + i); // Tính toán ngày trong tuần
            const nextDayString = `${nextDay.getDate().toString().padStart(2, '0')}/${(nextDay.getMonth() + 1).toString().padStart(2, '0')}/${year}`; // Định dạng ngày trong tuần
            dates.push(nextDayString);
        }

        return dates;
    }

    function changeDate() {
        if (!datepicker.val()) {
            return
        }
        const weekDates = getWeekDatesContainingDate(datepicker.val());
        var th = $(".schedule th")
        var td = $(".schedule td")
        const date = new Date().toISOString();
        for (var i = 1; i < 8; i++) {
            th.eq(i).text(th.eq(i).text().slice(0, 4) + " - " + weekDates[i - 1].slice(0, 5))
        }
        for (var i = 0; i < td.length; i++) {
            td.eq(i).text("-")
        }

        $.get("/MainPage", {
            handler: "Data",
            startDate: weekDates[0],
            endDate: weekDates[6]
        }, function (data) {
            console.log(data)
            var day = 1;
            var list = data.scheduleDetailDTOs
            for (var i = 0; i < list.length; i++) {
                const item = list[i];
                if (i > 0 && item.scheduleDetail.date > list[i - 1].scheduleDetail.date) {
                    day++;
                }
                const index = (item.scheduleDetail.slot - 1) * 7 + day
                td.eq(index).html(`<p class="table-title">Course: <a data-bs-toggle="modal" data-bs-target="#exampleModal" data-bs-whatever="@mdo">${item.scheduleDetail.shedule.course.courseName}</a> </br> at ${item.scheduleDetail.room.roomName}</p>`)
                $(td.eq(index)).find("a").click(() => {
                    showDetail(item.scheduleDetail.shedule.class.className, item.scheduleDetail.shedule.course.courseName, item.scheduleDetail.shedule.course.courseDescription)
                })
                td.eq(index).append(`<p class="${item.attendance1 ? 'attended' : item.scheduleDetail.date <= date ? 'absent' : 'not-yet'}">(${item.attendance1 ? 'Attended' : item.scheduleDetail.date <= date ? 'Absent' : 'Not yet'})</p>`)
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

    //hiện chi tiết môn học
    function showDetail(group, courseName, courseDecription) {
        var td = $(".activity td")
        $.get("/MainPage", {
            handler: "Teacher",
            group,
            courseName
        }, function (data) {
            td.eq(0).text(group)
            td.eq(1).text(data.userDTO.fullName)
            td.eq(2).text(data.userDTO.email)
            td.eq(3).text(courseDecription + "(" + courseName + ")")
        });
    }

    function showListDay() {
        var listDay = $(".list-day");
        const today = new Date();
        const yyyy = today.getFullYear();
        let mm = today.getMonth() + 1; // Months start at 0!
        let dd = today.getDate();

        if (dd < 10) dd = '0' + dd;
        if (mm < 10) mm = '0' + mm;

        const formattedToday = dd + '/' + mm + '/' + yyyy;
        var date = getWeekDatesContainingDate("18/07/2023");
        for (var i = 1; i < date.length - 1; i++) {
            listDay.append(`<p><a href="/Teacher/AttdendanceReport?handler=Date&date=${date[i]}">${date[i]}</a></p>`)
        }
    }

    function submitAttendance() {
        var form = $(".attendance-form");
        var button = form.find("button");
        console.log(button)
        button.click((e) => {
            e.preventDefault();
            var data = [];
            var attendanceIdList = form.find(".attendanceId");
            var attendanceList = form.find(".attendance");
            for (var i = 0; i < attendanceIdList.length; i++) {
                data.push({
                    id: attendanceIdList.eq(i).val(),
                    status: attendanceList.eq(i).prop("checked")
                })
            }
            $.get("/Teacher/AttdendanceReport", {
                handler: "Data",
                data: JSON.stringify(data)
            })
        })
    }
});