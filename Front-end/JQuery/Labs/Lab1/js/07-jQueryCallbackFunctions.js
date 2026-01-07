$(document).ready(function () {

    $("#callbackButton").click(function () {
        $("#callbackPara").hide("slow", function () {
            alert("hello from button ")
        })
    })
})