$(document).ready(function () {
    $('.btn').click(function () {
        var el = $(this),
            action = el.attr('action');

        if (action == 'finish') {
            window.close();
        }
        else if (action == 'close') {
            window.close();
        }
    });
});