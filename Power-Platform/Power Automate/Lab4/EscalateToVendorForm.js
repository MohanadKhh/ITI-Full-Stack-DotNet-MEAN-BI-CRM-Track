var EscalationActions = window.EscalationActions || {};

(function () {

    this.escalateToVendorForm = function (primaryControl) {

        var formContext = primaryControl;

        // Get ticket title directly from form
        var titleAttr = formContext.getAttribute("mhn_newcolumn"); // adjust to your title field logical name
        var primaryName = titleAttr ? titleAttr.getValue() : "Unknown Ticket";

        // Get priority directly from form — no WebAPI needed
        var priorityAttr = formContext.getAttribute("cr53d_status"); // adjust to your priority field logical name
        var priorityValue = priorityAttr ? priorityAttr.getValue() : "N/A";

        var priority;
        switch (priorityValue) {
            case 1:
                priority = "Low";
                break;

            case 2:
                priority = "Medium";
                break;

            case 3:
                priority = "High";
                break;

            case 4:
                priority = "Critical";
                break;

            default:
                priority = "N/A";
        }

        Xrm.Navigation.openAlertDialog({
            text: "Please note that the ticket '" + primaryName + "' priority is '" + priority + "'!",
            title: "Escalate to Vendor"
        });
    };

}).call(EscalationActions);