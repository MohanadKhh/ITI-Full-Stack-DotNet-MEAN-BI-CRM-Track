// Namespace best practice — avoids global variable conflicts
var IncidentValidation = window.IncidentValidation || {};

(function () {

    // Function registered on the form OnSave event
    this.validateCriticalIncident = function (executionContext) {

        var formContext = executionContext.getFormContext();

        // 1. Read field values
        var priorityAttr    = formContext.getAttribute("cr53d_status");   // Priority field
        var descriptionAttr = formContext.getAttribute("cr53d_description");   // Description field

        var priorityValue    = priorityAttr    ? priorityAttr.getValue()    : null;
        var descriptionValue = descriptionAttr ? descriptionAttr.getValue() : "";

        // 2. Priority option value for "Critical" — verify this value in your environment
        //1-low         2-medium        3-high      4-critical
        var CRITICAL_VALUE = 4; // <-- adjust to match your Priority option set value

        // 3. Validation logic
        if (priorityValue === CRITICAL_VALUE) {
            if (!descriptionValue || descriptionValue.length < 50) {

                // Cancel the save transaction
                executionContext.getEventArgs().preventDefault();

                // Show prominent form-level error notification banner
                formContext.ui.setFormNotification(
                    "Critical Tickets required a Description of at least 50 characters. " +
                    "Please provide sufficient context for the resolution team.",
                    "ERROR",                    // ERROR level = red banner with error icon
                    "CRITICAL_DESC_VALIDATION"   // Unique ID for this notification (used to clear it later if needed)
                );
            } else {
                // Compliant — clear any previous validation notification and allow save
                formContext.ui.clearFormNotification("CRITICAL_DESC_VALIDATION");
            }
            
        }
        else {
                // Compliant — clear any previous validation notification and allow save
                formContext.ui.clearFormNotification("CRITICAL_DESC_VALIDATION");}
    };

}).call(IncidentValidation);