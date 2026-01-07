$(document).ready(function () {
    $("#load-all").click(function () {
        $.ajax({
            url: "https://jsonplaceholder.typicode.com/posts",
            method: "GET",
            success: function (data) {
                $(".posts-container").empty()
                for (const post of data) {
                    var newPost = "<h3>" + post.title + "</h3>" + "<p>" + post.body + "</p>"
                    $(".posts-container").append(newPost)
                }
                $("#post-count").text(data.length)
            }
        })
    })


    $("#load-user1").click(function () {
        $.get("https://jsonplaceholder.typicode.com/user/1/posts", function (data) {
            $(".posts-container").empty()
            for (const post of data) {
                var newPost = "<h3>" + post.title + "</h3>" + "<p>" + post.body + "</p>"
                $(".posts-container").append(newPost)
            }
            $("#post-count").text(data.length)
        })
    })


    $("#load-user2").click(function () {
        $.getJSON("https://jsonplaceholder.typicode.com/user/2/posts", function (data) {
            $(".posts-container").empty()
            for (const post of data) {
                var newPost = "<h3>" + post.title + "</h3>" + "<p>" + post.body + "</p>"
                $(".posts-container").append(newPost)
            }
            $("#post-count").text(data.length)
        })
    })


    $("#postBtn").click(function () {
        $.post("https://jsonplaceholder.typicode.com/posts",
            {
                body: "Mohanad's is posting now",
                title: "Mohanad's post",
                userId: 5000,
                id: 5000
            },
            function (data) {
                $(".posts-container").empty()
                var newPost = "<h3>" + data.title + "</h3>" + "<p>" + data.body + "</p>"
                $(".posts-container").append(newPost)
                $("#post-count").text("1")
            })
    })
})