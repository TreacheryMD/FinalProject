$(function () {
    var validatorName = "validatedaterange";
    $.validator.addMethod(validatorName,
        function (value, element) {
            try {
                debugger;
                if ($(element).is('[data-val-validatedaterange]')) {
                    var from = $(element).val().split("-");
                    var dateToCheck = new Date(from[2], from[1] - 1, from[0]);
                    var date = new Date();
                    var minDate = new Date(date.getFullYear() - 120, date.getMonth(), date.getDate());
                    var maxDate = new Date(date.getFullYear() - 18, date.getMonth(), date.getDate());
                    return dateToCheck >= minDate && dateToCheck <= maxDate;
                }
                return false;
            } catch (e) {
                return false;
            }
        },
        "");
    $.validator.unobtrusive.adapters.addBool(validatorName);
}(jQuery));