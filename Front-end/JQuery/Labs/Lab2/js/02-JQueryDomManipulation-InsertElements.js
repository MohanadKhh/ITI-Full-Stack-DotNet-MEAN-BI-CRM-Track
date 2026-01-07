$(document).ready(function () {

    // inset at end of selected element     [insert element]
    $("#btn-append").click(function () {
        $("#container").append("<div class='new-item'>appended item</div>")

    })

    // inset at beginning of selected element     [insert element]
    $("#btn-prepend").click(function () {
        $("#container").prepend("<div class='new-item'>appended item</div>")

    })

    // inset after  selected element     [outside element]
    $("#btn-after").click(function () {
        $("#container").after("<div class='new-item'>appended item</div>")

    })

    // inset before  selected element     [outside element]
    $("#btn-before").click(function () {
        $("#container").before("<div class='new-item'>appended item</div>")

    })


    $("#btn-multiple").click(function (){
        var htmlElement = "<div class='new-item'>HTML Element</div>"
        var jqueryElement = $("<div></div>").text("JQUERY Element").addClass("new-item");
        $("#container").append(htmlElement,jqueryElement)
    })



})