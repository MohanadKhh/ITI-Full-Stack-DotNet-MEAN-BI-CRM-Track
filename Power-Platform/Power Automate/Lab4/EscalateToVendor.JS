var EscalationActions = window.EscalationActions || {};

(function () {

    this.escalateToVendor = async function (selectedControl) {

        var selectedRecords = selectedControl.getGrid().getSelectedRows();

        if (selectedRecords.getLength() === 0) {
            Xrm.Navigation.openAlertDialog({
                text: "Please select a record first.",
                title: "No Record Selected"
            });
            return;
        }

        var message = "";

        for (var i = 0; i < selectedRecords.getLength(); i++) {
            var row = selectedRecords.get(i);
            var entity = row.getData().getEntity();
            var primaryName = entity.getPrimaryAttributeValue();
            var recordId = entity.getId();

            try {
                var result = await Xrm.WebApi.retrieveRecord(
                    "mhn_ticket",
                    recordId,
                    "?$select=cr53d_status"
                );
                var priorityValue = result ? result["cr53d_status"] : "N/A";
            } catch (e) {
                var priorityValue = "Error";
            }

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

            message += "Ticket: " + primaryName + " → Priority: '" + priority + "'\n";
        }

        Xrm.Navigation.openAlertDialog({
            text: message,
            title: "Escalate to Vendor"
        });
    };

}).call(EscalationActions);