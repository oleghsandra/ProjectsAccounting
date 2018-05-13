var bindIterationChange = function () {
    $("#IterationId").change(function () {
        var input = $(this);
        var saveInvoiceBtn = $("#saveInvoiceBtn");
        tasksContainer = $("#invoicesTasksContainer");
        tasksContainer.empty();
        var iterationId = input.val();
        saveInvoiceBtn.prop("disabled", true);

        if (iterationId !== "") {
            var url = input.data("request-url");

            tasksContainer.load(url, { iterationId }, function () {
                $("#tasksTable").dataTable({});
                saveInvoiceBtn.prop("disabled", false);
            });
        }
    });
};

$(document).ready(function () {
    $('.datepicker').datepicker();

    $("#ProjectId").change(function () {
        var input = $(this);
        var iterationsList = $("#IterationId");
        $("#invoicesTasksContainer").empty();
        $("#saveInvoiceBtn").prop("disabled", true);
        iterationsList.empty().prop("disabled", true);
        var projectId = input.val();

        if (projectId !== "") {
            var url = input.data("request-url");

            $.post(url, { projectId }, function (iterationsPartial) {
                iterationsList.replaceWith(iterationsPartial);
                bindIterationChange();
                iterationsList.empty().prop("disabled", false);
            });
        }
    });

    $("#saveInvoiceBtn").click(function () {
        event.preventDefault();
        var url = $(this).data("request-url");
        var form = $("#invoicingForm");

        $.post(url, form.serialize(), function () {
            alert("Invoice saved!");
            window.location.reload();
        });

    });
});