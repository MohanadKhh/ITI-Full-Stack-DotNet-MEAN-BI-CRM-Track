function updateVisits() {
    let name = getCookie("name");
    if (!name) return;

    let key = "visits_" + name;
    let count = parseInt(getCookie(key)) || 0;
    count++;

    setCookie(key, count, 7);
    return count;
}

let visits = updateVisits()

$(document).ready(function () {
    $("span:eq(1)").text(getCookie("name"));
    $("#userData span:eq(1)").css("color", getCookie("color"));

    $("span:eq(2)").text(" you have visted site " + (visits || 0) + " times");

    if (getCookie("gender") === "male") {
        $("#resultPage img").attr("src", "./assets/male.png")
    }
    else {
        $("#resultPage img").attr("src", "./assets/female.png")
    }

    $("#backBtn").click(function () {
        window.location.href = "form.html"
    });
})
