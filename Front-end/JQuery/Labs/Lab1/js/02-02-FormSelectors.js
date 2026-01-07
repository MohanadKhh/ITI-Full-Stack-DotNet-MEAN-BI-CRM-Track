$(document).ready(function () {


    // select all inputs
    // <input>
    // <textarea>
    // <select>
    // <button>
    $("#btnSelectInputs").click(function () {
        $('*').removeClass('highlight');
        $(':input').addClass('highlight')
    })

    // Select text type inputs
    // <input type="text">
    $("#btnSelectText").click(function () {
        $('*').removeClass('highlight');
        $(':text').addClass('highlight')
    })

})