$(document).ready(function () {


    // showing and hiding
    $("#btn-show").click(function () {
        $("#box1").show("slow")
    })

    $("#btn-hide").click(function () {
        $("#box1").hide("slow")
    })


    $("#btn-toggle").click(function () {
        $("#box1").toggle("slow")
    })


    // fading effects
    $("#btn-fadein").click(function () {
        $("#box2").fadeIn("slow")
    })

    $("#btn-fadeout").click(function () {
        $("#box2").fadeOut("slow")
    })

    $("#btn-fadeto").click(function () {
        $("#box2").fadeTo("slow", 0.5)
    })
    $("#btn-fadetoggle").click(function () {
        $("#box2").fadeToggle("slow")
    })


    // sliding effects
    $("#btn-slidedown").click(function () {
        $("#box3").slideDown("slow")
    })

    $("#btn-slideup").click(function () {
        $("#box3").slideUp("slow")
    })

    $("#btn-slidetoggle").click(function () {
        $("#box3").slideToggle("slow")
    })



    // custom animation

    $("#btn-animate").click(function () {
        $("#animated-box").animate({
            opacity: '0.5',
            width: '150px',
            height: '150px',
            left: '250px'
        }, 1000)
    })


    $("#btn-animate-multiple").click(function () {
        $("#animated-box")
        .animate({left:'250px'},1000)
        .animate({top:'50px'},1000)
        .animate({left:'0px' , top:'0px'},1000)
    })

       $("#btn-animate-reset").click(function () {
        $("#animated-box").animate({
            left: '0px',
            top: '0px',
            opacity: '1',
            width: '100px',
            height: '100px',
        }, 500)
    })
})