$(function () {
    $.validator.addMethod("validatedaterange",
        function (value, element) {
            try {
                if (($element).is('disabled'))
                    return true;
                if (($element).is('[data-val-validatedaterange]')) {
                    var d = Date.parse($(element).val());
                    //var minDate = "<%=MinDateTime%>";
                    //var maxDate = "<%=MaxDateTime%>";
                    return d >= new Date("2008-01-10") && d <= new Date("2009-01-10");
                }
            } catch (e) {
                return false;
            }
        },
        "");
    $.validator.unobtrusive.adapters.addBool("validateDateRange");
}(jQuery));

