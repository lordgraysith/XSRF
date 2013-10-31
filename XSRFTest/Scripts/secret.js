$(function () {
    $('#add-admin').submit(function (e) {
        $.ajax('/XSRFTest/admin/create', 
        {
            type: "GET"
            , data: { username: $('#add-admin input[name="username"]').val() }
            , success: function (data) {
                document.location.reload();
            }
        });
        e.preventDefault();
    });
});