var expireDate = new Date("2026-3-01").toUTCString();
var expireDate2 = new Date("2026-5-01").toUTCString();
var oldDate = new Date("2025-12-01").toUTCString();

$(document).ready(function () {
    $("#nameInput").change(function () {
        setCookie("name", $(this).val(), expireDate);
    });

    $("#ageInput").change(function () {
        setCookie("age", $(this).val(), expireDate2);
    });

    $("#maleImg").click(function () {
        setCookie("gender", "male", expireDate);
    });

    $("#femaleImg").click(function () {
        setCookie("gender", "female", expireDate2);
    });

    $("#colorInput").click(function () {
        setCookie("color", $(this).val(), expireDate);
    });

    $("#submitBtn").click(function () {
        window.location.href = "result.html"
    });
});