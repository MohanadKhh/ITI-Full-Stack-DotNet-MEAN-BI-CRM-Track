$(document).ready(function () {

    $("#btn-remove").click(function () {
        $(".remove").remove();
    })

    $("#btn-remove-filtered").click(function () {
        $(".item").remove(".remove");
    })


    // remove all children
    $("#btn-empty").click(function () {
        $("#container2").empty();
    })
})