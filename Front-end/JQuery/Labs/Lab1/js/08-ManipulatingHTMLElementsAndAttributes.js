$(document).ready(function () {

    $("#btnGetAttr").click(function () {
        alert($("#myImage").attr("src"))
    })

    $("#btnSetAttr").click(function () {
        $("#myImage").attr("src", "/assets/superman.jpg")
    })


    $("#btnHtmlGet").click(function () {
        alert($("#content").html())
    })


    $("#btnHtmlSet").click(function () {
        $("#content").html("<p><strong>HTML</strong> new content</p>")
    })


    $("#btnTextGet").click(function () {
        alert($("#content").text())
    })


    $("#btnTextSet").click(function () {
        $("#content").text("new content changed")
    })


    $("#btnGetVal").click(function () {
        alert($("#nameInput").val())
    })

    
   $("#btnSetVal").click(function () {
        $("#nameInput").val("ali ali")
    })
})