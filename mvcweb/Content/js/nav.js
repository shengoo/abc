$(document).ready(function(){
    var nav = $(".nav ul");
	var navLi = nav.find("li");
	var hover = $(".nav .hover");
	var index,left,mythis,width = 100;
	navLi.eq(0).addClass("color-white");
	navLi.hover(function(){
		index = $(this).index();
		left = width*index;
		navLi.removeClass("color-white");
		$(this).addClass("color-white");
	    hover.stop().animate({"left":left+"px"},100);
		
	});
});