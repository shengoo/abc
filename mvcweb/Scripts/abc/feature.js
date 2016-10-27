$(() => {
    $('.buy-lesson')
        .click(() => {
            if (window.top.CurrentUser) {
                location.href = $.url + "/Purchase/Buy";
            } else {
                window.top.showLogin();
            }
        });
});