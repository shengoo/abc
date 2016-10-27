'use strict';

$(function () {
    window.top.$('.footer').css('background-color', '#D73240');
    window.onunload = function () {
        window.top.$('.footer').css('background-color', '');
    };
});

