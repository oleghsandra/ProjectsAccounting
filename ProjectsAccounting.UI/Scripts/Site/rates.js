$(document).ready(function () {
    $("#usersTable").dataTable({});
    $("#externalRatesTable").dataTable({});

    $("#synchronize").click(function () {
        var url = $(this).data("request-url");

        $.post(url, {}, function () {
            window.location.reload();
        });
    });
    
    $("#saveExteralRate").click(function () {
        var url = $(this).data("request-url");

        var param = {
            ProjectId: $("#projectSelector").val(),
            UserId: $("#userSelector").val(),
            ExternalRate: Number($("#externalRate").val())
        };

        $.post(url, param, function () {
            window.location.reload();
        });
    });

    $(".internal-rate").change(function () {
        var input = $(this);
        var url = input.data("request-url");
        var userId = input.data("user-id");
        var internalRate = Number(Number(input.val()).toFixed(2));

        $.post(url, { userId, internalRate }, function () {
            window.location.reload();
        });
    });
});