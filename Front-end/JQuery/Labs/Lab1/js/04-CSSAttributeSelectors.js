$(document).ready(function () {

    $('#btnAttrEquals').click(function () {
        $('*').removeClass('highlight');
        $('[data-type="fruit"]').addClass('highlight')
    })

    $('#btnAttrNotEquals').click(function () {
        $('*').removeClass('highlight');
        $('[data-type!="fruit"]').addClass('highlight')
        $('[data-type="fruit"]').addClass('highlight2')
    })


    // ~ -> contain word (fruit berry) ok but (fruitberry) not ok
    $('#btnAttrContainsWord').click(function () {
        $('*').removeClass('highlight');
        $('*').removeClass('highlight2');
        $('[data-type~=berry]').addClass('highlight')
    })


    // ^ -> START WITH
    $('#btnAttrStartsWith').click(function () {
        $('*').removeClass('highlight');
        $('[data-category^="food"]').addClass('highlight')
    })



    // $ -> END WITH
    $('#btnAttrEndsWith').click(function () {
        $('*').removeClass('highlight');
        $('[data-category$="item"]').addClass('highlight')
    })

    // * contain (any matched chars) (important note) ok and (importantnote) ok too
    $('#btnAttrContains').click(function () {
        $('*').removeClass('highlight');
        $('[data-info*="note"]').addClass('highlight')
    })
})