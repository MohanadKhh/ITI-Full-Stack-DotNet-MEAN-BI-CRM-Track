// $("div div").        Select all <div> elements that are inside another <div>
// $("<div></div>").    So this creates a new empty <div> element in memory.


$(document).ready(function () {


    // with HTML string
    $("#btn-create-html").click(function () {
        var newElement = "<div class='new-element'> created with HTML string</div>";
        $("#element-container").append(newElement);
    })


    // with JQuery
    $("#btn-create-jquery").click(function () {
        var newElement = $("<div></div>").text("created with JQuery").addClass("new-element");
        $("#element-container").append(newElement);

    })

    // Dom
    $("#btn-create-dom").click(function () {
        var newElement = document.createElement("div");
        newElement.className = "new-element";
        newElement.innerHTML = "created with DOM";
        $("#element-container").append(newElement);
    })
})