$(document).ready(function () {

    $("#btn-blue").click(function () {
        $("#main-heading").css("color", "blue")
    })

    $("#btn-red").click(function () {
        $("#main-heading").css("color", "red")
    })

    $("#btn-green").click(function () {
        $("#main-heading").css("color", "green")
    })

    $("#btn-magic").click(function () {
        $("#magic-box").toggleClass("rainbow")
    })

    $("#btn-secret").click(function () {
        // $("#secret-message").toggle()
        // $("#secret-message").toggle(500)
        // $("#secret-message").slideToggle()
        $("#secret-message").fadeToggle(1000)
    })

    $("#btn-counter").click(function () {
        var currCounter = $("#counter-value").text()
        currCounter = Number(currCounter) + 1
        $(".counter #counter-value").text(currCounter)
    })
})