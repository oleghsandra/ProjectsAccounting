var initInvoicePrint = function () {
    $("#printInvoive").click(function () {
        var invoiceDoc = $("#invoice");
        invoiceDoc.print();
    });
}

$(document).ready(function () {
    $("#invoicesTable").dataTable({});

    $(".generateReportButton").click(function () {
        var btn = $(this);
        var invoiceId = btn.data("invoice-id");
        var url = btn.data("request-url");

        $("#invoiceContainer").load(url, { invoiceId }, function () {
            initInvoicePrint();
        });
    });
});