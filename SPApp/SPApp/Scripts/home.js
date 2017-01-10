$(document).ready(function () {
    $('.return-item-btn').click(function () {
        var code = $(this).attr("data-code");
        var parameters = {
            url: "/Home/ReturnItem",
            type: "POST",
            dataType: "json",
            data: { code: code },
            success: function (data) {
                console.log(data);
                //redirect na home
                // similar behavior as an HTTP redirect
                window.location.replace(data.redirectTo);

                // similar behavior as clicking on a link
                //window.location.href = "http://stackoverflow.com";
            },
            failure: function (response) {
                alert(response.responseText);
            },
            error: function (response) {
                alert(response.responseText);
            }
        }
        $.ajax(parameters);
    });

})