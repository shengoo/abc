function OpenTeacher(){
    var getData = [{ id: 1, name: '老师1', intro: '丰富的教学经验，诙谐的上课指导，每次课程都广受好评' },
    { id: 2, name: '老师2', intro: '丰富的教学经验，诙谐的上课指导，每次课程都广受好评' },
    { id: 3, name: '老师3', intro: '丰富的教学经验，诙谐的上课指导，每次课程都广受好评' }];

    var str = '';
    data.forEach(function (item) {
        str += '<li data=' + item.id + '><div class="win_table_name">' + item.name + '</div><div class="win_table_intro">' + item.intro + '</div></li>';
    });
    $('.win_table').append(str);
    $('#searchteacher').bind('keyup', function () {
        var text = this.value;
        $('.win_grid li[data] .win_table_name').each(function (index, item) {
            for (var i = 0; i < data.length; i++)
                if (item.innerHTML.indexOf(text) > -1 || text == '')
                    $(item.parentElement).removeClass('hidden');
                else
                    $(item.parentElement).addClass('hidden');
        });
    })
    $('.win_grid li[data]').click(function () {
        var el = this,
            id = el.attributes.data.value,
            select;
        data.forEach(function (item) { if (item.id == id) select = item; });
        $('div[name="teacher"]')[0].innerHTML = select.name;
        $('div[name="teacher"]')[0].datavalue = select.id;
        $('.win_grid').addClass('hidden');
    });
}
