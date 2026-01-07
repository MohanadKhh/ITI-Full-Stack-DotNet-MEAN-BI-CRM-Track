/*
*****************************_Summary of all Symbols_*****************************

🟢 # — select by id
$("#title")   // <p id="title">

🟢 . — select by class
$(".item")   // <div class="item">

🟢 * — select everything
$("*")      // all elements on the page

🟢 [] — attribute selector
$("input[type='text']")     // input where type="text"
$("a[href^='https']")       // href starts with https
$("img[alt]")               // has alt attribute

🟢 : — pseudo-selector / filter (jQuery & CSS)
$("p:first")
$("p:last")
$("p:empty")
$(":input")         // all form elements (jQuery special)
$(":checked")
$(":disabled")

🟢 > — direct child selector
$("p > span")   // span directly inside p (NOT grandchildren)

🟢 (space) — descendant selector (any level inside)
$("p span")     // any span inside p (children or deeper)

🟢 + — adjacent sibling (next element only)
$("h1 + p")     // the first <p> right after <h1>

🟢 ~ — general sibling (all next siblings)
$("h1 ~ p")     // all <p> after <h1> in same parent

🟢 , — multiple selectors
$("p, div, span")   // selects all p + div + span

🟢 = != ^= $= *= — attribute matching
$("a[href='google.com']")    // exact match
$("a[href != '#']")            // not equal
$("a[href ^= 'https']")        // starts with
$("a[href $= '.pdf']")         // ends with
$("a[href *= 'login']")        // contains matching chars
$("a[href ~= 'login']")        // contains matching words

🟢 () — used with functions / filters
$("li:eq(2)")      // element at index 2
$("li:lt(3)")      // index < 3
$("li:gt(1)")      // index > 1

*/


$(document).ready(function () {
    // select all elements
    $('#btnSelectAll').click(function () {
        $('*').removeClass('highlight')
        $('*').addClass('highlight');
    })



    // select children of paragraph
    // $("p > *") (direct children to p)
    // $("p *") (ALL descendants of p)
    $('#btnSelectChildren').click(function () {
        $('*').removeClass('highlight')
        $("p > *").addClass('highlight')
    })

    // select special ID
    $('#btnSelectById').click(function () {
        $('*').removeClass('highlight')
        $('#specialID').addClass('highlight')
    })


    // select special CLASS
    $('#btnSelectByClass').click(function () {
        $('*').removeClass('highlight')
        $('.specialClass').addClass('highlight')
    })

    // select p empty 
    // <p></p>              Matched
    // <p>Hi</p>            No has text
    // <p>   </p>           No spaces count as content
    // <p><span></span></p> No has a child element

    $('#btnSelectEmpty').click(function () {
        $('*').removeClass('highlight')
        $('p:empty').addClass('highlight')
    })

    // Select Nested Links 
    $('#btnSelectNested').click(function () {
        $('*').removeClass('highlight')
        $('p a.specialClass').addClass('highlight')
    })
})