$(function () {
    $('#add-admin').submit(function (e) {
        $.ajax('/XSRFTest/admin/create', 
        {
            type: "POST"
            , data: { username: $('#add-admin input[name="username"]').val() }
            , beforeSend: function (xhr) {
                xhr.setRequestHeader('X-XSRF-TOKEN', document.cookie.match(/XSRF-TOKEN=(.*?)(?:$|;)/)[1]);
            }
            , success: function (data) {
                document.location.reload();
            }
        });
        e.preventDefault();
    });
});