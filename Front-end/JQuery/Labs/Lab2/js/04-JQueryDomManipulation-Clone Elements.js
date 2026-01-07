$(document).ready(function () {
    {
        $("#original-element").click(function () {
            $(this).css("backgroundColor", "red");
        })


        $("#btn-clone").click(function () {
            var clone = $("#original-element").clone();
            $("#clone-container").append(clone)

        })

        $("#btn-clone-events").click(function () {
            var clone = $("#original-element").clone(true).removeClass("original").addClass("clone");
            $("#clone-container").append(clone)

        })

    }
})