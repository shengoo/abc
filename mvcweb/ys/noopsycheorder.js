$(document).ready(function () {
    $('input[name="ordertimes"]').click(function () {
        var ordertime = this.value,
            orderdate;
        $.ajax({
            url: '../Member/NoopsycheOrder.aspx?ordertimes=' + ordertime,
            type: 'get',
            dataType: 'json',
            success: function (res) {
                var str = '';
                if (res.IsSuccess) {
                    for (var i = 0; i < res.Result.length; i++) {
                        str += '<div class="coursedate">' + res.Result[i] + '</div>';
                    }
                    $('.classdate').innerHTML = str;
                    $('.coursedate').click(function () {
                        orderdate = this.innerHTML;
                        $.ajax({
                            url: '../Member/NoopsycheOrder.aspx?ordertimes=' + ordertime + '&orderdate=' + orderdate,
                            type: 'get',
                            dataType: 'json',
                            success: function (res) {
                                var str = '';
                                if (res.IsSuccess) {
                                    for (var i = 0; i < res.Result.length; i++) {
                                        str += '<div class="coursedate time">' + res.Result[i][0] + '</div>';
                                        $('.select').add($('<option>' + res.Result[i][1] + '</option'));
                                    }
                                    $('.classtime').innerHTML = str;
                                }
                            }
                        });
                    })
                }
            }
        });
    });
})