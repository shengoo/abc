$(() => {
    window.top.$('.footer').css('background-color', '#D73240');
    window.onunload = () => {
        window.top.$('.footer').css('background-color', '');
    }
})