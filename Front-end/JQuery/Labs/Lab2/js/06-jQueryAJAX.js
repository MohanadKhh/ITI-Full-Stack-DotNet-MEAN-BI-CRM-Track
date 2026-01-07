$(document).ready(function () {

    // using $.ajax()
    $("#btn-ajax").click(function () {
        $.ajax({
            url: "https://jsonplaceholder.typicode.com/posts/1",
            method: "GET",
            success: function (data) {
                $("#ajax-result").html(
                    "<h3>" + data.title + "</h3>" +
                    "<p>" + data.body + "</p>"
                )
            }
        })
    })


    // zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz


    // using $.get()
    $("#btn-get").click(function () {
        $.get("https://jsonplaceholder.typicode.com/posts/2", function (data) {
            $("#get-result").html(
                "<h3>" + data.title + "</h3>" +
                "<p>" + data.body + "</p>"
            )
            console.log(data);
            
        })
    })

    // zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

    // using .getJSON
    $("#btn-getjson").click(function () {
        $.getJSON("https://jsonplaceholder.typicode.com/users/1", function (user) {
            $("#getjson-result").html(
                "<h3>" + user.name + "</h3>" +
                "<p>" + user.email + "</p>"
            )
            console.log(user);
            
        })
    })

    // zzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzzz

    // using $.post()
    $("#btn-post").click(function () {
        $.post("https://jsonplaceholder.typicode.com/posts", {
            title: "My JQuery post",
            body: "hello hello hello",
            userID: 1
        }, function (data) {
            $("#post-result").html(
                "<h3>" + data.title + "</h3>" +
                "<p>" + data.body + "</p>"
            )
            console.log(data);
                      
        })
    })

})