$(function () {
    unavailableDates.forEach(function (date) {
        date.Date = new Date(parseInt(date.Date.replace(/[^0-9 +]/g, '')));
    });

    datesWithPrice.forEach(function (date) {
        date.Date = new Date(parseInt(date.Date.replace(/[^0-9 +]/g, '')));
    });

    let todayDate = new Date();
    let newDay = todayDate.getDate();
    let newMonth = todayDate.getMonth() + 1;
    let newYear = todayDate.getFullYear();

    let monthNames =
        [
            'January', 'February', 'March', 'April', 'May', 'June',
            'July', 'August', 'September', 'October', 'November', 'December'
        ];

    let years = ['2018', '2019', '2020', '2021'];

    let days = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];

    let mainDiv = $('#myDatepicker');
    let dropdownMonth = getDropDownList('month','monthId', monthNames);
    dropdownMonth.val(monthNames[todayDate.getMonth()]);
    let dropdownYear = getDropDownList('year', 'yearId', years);
    dropdownYear.val(todayDate.getFullYear());
    mainDiv.append(dropdownMonth);
    mainDiv.append(dropdownYear);

    //Call teh entire date function
    entireDate();

    //Entire date
    function entireDate() {
        var executed = false;

        if (!executed) {
            executed = true;
            
            $('#tableId').remove();

            //Call the function for calendar creating
            createCalendar([newYear, newMonth, newDay]);
            addPriceOfEachDay();
            markAllUnavailableDays();
        }    
    }
    

    //Choosing the motnh
    $('#monthId').change(function (e) {
        newMonth = $(this).val();
        newMonth = monthNames.indexOf(newMonth) + 1;
        $('#tableId').remove();

        //Call the function for calendar creating
        createCalendar([newYear, newMonth, newDay]);
        addPriceOfEachDay();
        markAllUnavailableDays();
    });

    //Choosing the year
    $('#yearId').change(function (e) {
        newYear = $(this).val();
        $('#tableId').remove();

        //Call the function for calendar creating
        createCalendar([newYear, newMonth, newDay]);
        addPriceOfEachDay();
        markAllUnavailableDays();
    });

    //Calendar creating function
    function createCalendar(arr) {
        let date = new Date(arr[0], arr[1], arr[2]);
        let lastDayOfMonth = new Date(date.getFullYear(), date.getMonth(), 0);
        let firstDayOfMonth = new Date(date.getFullYear(), date.getMonth() - 1, 1);
        let firstDayOfFirstWeek = firstDayOfMonth.getDay();

        let weeksCount = function () {
            let year = arr[0];
            let month_number = arr[1];
            let firstOfMonth = new Date(year, month_number - 1, 1);
            let day = firstOfMonth.getDay() || 6;
            day = day === 1 ? 0 : day;
            if (day) {
                day--;
            }
            let diff = 7 - day;
            let lastOfMonth = new Date(year, month_number, 0);
            let lastDate = lastOfMonth.getDate();
            if (lastOfMonth.getDay() === 1) {
                diff--;
            }
            let result = Math.ceil((lastDate - diff) / 7);
            return result + 1;
        };

        let table = $('<table/>');
        table.attr('id', 'tableId');
        let tBody = $('<tbody/>');
        table.append(tBody);

        //Calendar days
        let trDays = $('<tr/>');
        for (let index = 0; index < days.length; index++) {
            trDays.append('<th class="thDays">' + days[index] + '</th>');
        }

        table.append(trDays);
        let count = 1;
        let secondCount = 1;
        for (let index = 0; index < weeksCount(); index++) {
            let tr = $('<tr/>');
            for (let i = 1; i <= 7; i++) {
                if (count > lastDayOfMonth.getDate()) {
                    tr.append('<td class="thDays"></td>');
                    continue;
                }

                //Days of Week
                if (secondCount < firstDayOfFirstWeek) {
                    tr.append('<td class="thDays"></td>');
                    secondCount++;
                    continue;
                }
                let td = $('<td class="tdDays" id="' + count + '">' + count + '</td>');
                td.click(click);
                if (count === date.getDate()) {
                    td.addClass('today');
                }
                tr.append(td);
                count++;
                table.append(tr);
            }
            mainDiv.append(table);
        }
    }

    function addPriceOfEachDay() {
        let month = monthNames.indexOf($('#monthId').val());
        let year = $('#yearId').val();

        let filteredDays = filterByMonthAndYear(month, year);

        console.log(datesWithPrice);
        console.log(filteredDays);

        filteredDays.forEach(function (date) {
            let day = date.Date.getDate();
            $('#'+ day).append("<br><small>" + date.Price + "$" + "</small>")
        })
    }

    function filterByMonthAndYear(month, year) {
        let result = [];

        datesWithPrice.forEach(function (date) {
            if (date.Date.getMonth() == month && date.Date.getFullYear() == year) {
                result.push(date);
            }
        });

        return result;
    }

    function markAllUnavailableDays() {
        let month = monthNames.indexOf($('#monthId').val());
        let year = $('#yearId').val();

        //Filter the chosen dates
        let filteredDays = filterDates(month, year);

        //Mark the unavailable days into the calendar
        filteredDays.forEach(function (day) {
            $('#'+ day).css("background-color", "grey");
            $('#'+ day).css("cursor", "default");
            $('#' + day).unbind("click");
        });
    };

    function filterDates(month, year) {
        let result = [];

        unavailableDates.forEach(function (date) {          
            if (date.Date.getMonth() == month && date.Date.getFullYear() == year) {
                result.push(date.Date.getDate());
            }
        });

        return result;
    };

    function click() {
        $('tr td').removeClass('today');
        let activeEl = $(this);
        activeEl.addClass('today');
        let day = activeEl.attr('id');
        activeEl.css("background-color", "grey");
        let month = $('#monthId').val();
        let year = $('#yearId').val();

        //fill the date
        $("#datepicker").val([year, monthNames.indexOf(month) + 1, day].join('-'));

        //Clear the Id of datepickers
        $(".datepicker").attr("id", "");
     

        //hide the calendar
        $('#myDatepicker').hide('slow');
        $('.UnavailableMark').hide('slow');
        setTimeout(function () {
            activeEl.css("background-color", "");
        }, 1000);
    };

    //Func DropDown
    function getDropDownList(name, id, optionList) {
        var combo = $('<select></select>').attr("id", id).attr("name", name);
        $.each(optionList, function (i, el) {
            combo.append("<option>" + el + "</option>");
        });
        return combo;
    }
});
