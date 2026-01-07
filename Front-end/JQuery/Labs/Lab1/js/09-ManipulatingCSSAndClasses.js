$(document).ready(function () {

    $("#btnAddClass").click(function () {
        $("#styleDiv").addClass("intro")
    })

    $("#btnRemoveClass").click(function () {
        $("#styleDiv").removeClass("intro")
    })


    $("#btnToggleClass").click(function () {
        $("#styleDiv").toggleClass("intro")
    })


    $("#btnHasClass").click(function () {
        alert($("#styleDiv").hasClass("intro"))
    })


    $("#btnCssGet").click(function () {
        alert($("#styleDiv").css("color"))
    })


      $("#btnCssSet").click(function () {
       $("#styleDiv").css("color", "green")
    })
})