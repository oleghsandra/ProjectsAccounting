var initInvoicePrint = function () {
    $("#printInvoive").click(function () {
        var invoiceDoc = $("#invoice");
        var newWin = window.open('', 'Invoice');
        newWin.document.open();
        newWin.document.write('<html><body onload="window.print()">' + invoiceDoc.html() + '</body></html>');
        newWin.document.close();
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