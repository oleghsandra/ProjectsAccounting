$(document).ready(function () {
    $("#projectsTable").dataTable({ ordering: false });

    $("#synchronize").click(function () {
        var url = $(this).data("request-url");

        $.post(url, {}, function () {
            window.location.reload();
        });
    });
    
    $(".customer-info").change(function () {
        var input = $(this);
        var row = input.parents().eq(1);
        var url = row.data("request-url");

        var param = {
            ProjectId: row.data("project-id"),
            CustomerName: row.find(".name").val(),
            CustomerPhone: row.find(".phone").val(),
            CustomerEmail: row.find(".email").val(),
            CustomerAddress: row.find(".address").val(),
        };

        $.post(url, param, () => { });
    });
});