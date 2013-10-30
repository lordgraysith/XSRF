$(function () {
    $('#secret').click(function () {
        $.ajax('/XSRFTest/home/protected', 
        {
            type: "POST"
            , beforeSend: function (xhr) {
                xhr.setRequestHeader('X-XSRF-TOKEN', $.cookie('XSRF-TOKEN'));
            }
            , success: function (data) {
                alert(JSON.stringify(data));
            }
        });
    });
});