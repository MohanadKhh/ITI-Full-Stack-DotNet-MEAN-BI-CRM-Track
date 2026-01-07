$(document).ready(function () {

    $('#btnFirst').click(function () {
        $('*').removeClass('highlight');
        $("div p").first().addClass('highlight')
    })


    $('#btnLast').click(function () {
        $('*').removeClass('highlight');
        $("div p").last().addClass('highlight')
    })


    $('#btnEq').click(function () {
        $('*').removeClass('highlight');
        $("div p").eq(1).addClass('highlight')
    })


    $('#btnNext').click(function () {
        $('*').removeClass('highlight');
        $("p.intro").next().addClass('highlight')
    })


    $('#btnNextAll').click(function () {
        $('*').removeClass('highlight');
        $("li.start").nextAll().addClass('highlight')
    })



    $('#btnSiblings').click(function () {
        $('*').removeClass('highlight');
        $("li.start").siblings().addClass('highlight')
    })

    $('#btnNextUntil').click(function () {
        $('*').removeClass('highlight');
        $("li.start").nextUntil("li.stop").addClass('highlight')
    })


    $('#btnContains').click(function () {
        $('*').removeClass('highlight');
        $("span:contains('A')").addClass('highlight')
    })


    $("#btnFilter").click(function () {
        $('*').removeClass('highlight');
        $("p").filter(".intro").addClass('highlight')

    })

    $("#btnNot").click(function () {
        $('*').removeClass('highlight');
        $("p").not(".intro").addClass('highlight')

    })
})