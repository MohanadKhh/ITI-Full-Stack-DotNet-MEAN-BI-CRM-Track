$(document).ready(function () {

    $('#btnSelectEven').click(function () {
        $('*').removeClass('highlight');
        $('li:even').addClass('highlight')
    })


    $('#btnSelectFirst').click(function () {
        $('*').removeClass('highlight');
        $('p:first').addClass('highlight')

    })


    $('#btnSelectThird').click(function () {
        $('*').removeClass('highlight');
        $('p:eq(2)').addClass('highlight');
    })


})