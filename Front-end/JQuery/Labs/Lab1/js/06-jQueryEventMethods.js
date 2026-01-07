$(document).ready(function () {


    $("#clickablePara").click(function () {
        $(this).hide();
        // $(this).hide(500);       500ms duration
        // show()	                show element
        // toggle()	                switch between hide/show
        // slideToggle()	        slide animation
        // fadeToggle()	            fade animation
    })

    $("#doubleClickPara").dblclick(function () {
        $(this).css("backgroundColor", "red")
    })

    $("#eventButton").click(function () {
        alert("hello was clicked")
    })

    $("#keyInput").keypress(function () {
        console.log($(this).val())
    })
})