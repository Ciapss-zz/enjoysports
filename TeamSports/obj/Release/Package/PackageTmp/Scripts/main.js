$(document).on('ready', function () {
    $('.date-picker').datetimepicker({
        showTodayButton: true,
        format: 'L'
    });
    $('.time-picker').datetimepicker({
        showTodayButton: true,
        format: 'LT'
    });
});