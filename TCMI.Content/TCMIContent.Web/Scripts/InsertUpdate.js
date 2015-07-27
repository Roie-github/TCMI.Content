
$(document).ready(function () {
    $("input[type=text]").addClass("form-control");
    $("textarea").addClass("form-control");
    $("input[type=email]").addClass("form-control");
    $("input[type=datetime]").addClass("form-control");
    $("select").addClass("form-control");
    $("span").addClass("text-danger");

    $("#Name").attr("placeholder", "Name");
    $("#Email").attr("placeholder", "Email");
    $("#Phone").attr("placeholder", "Phone");
    $("#PrayerRequest").attr("placeholder", "PrayerRequest");
    
});
