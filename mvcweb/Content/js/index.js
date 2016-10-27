

function setTab(name,cursel,n){
    for(var i=1;i<=n;i++){
	    var main_menu = document.getElementById(name+i);
		var sub_menu = document.getElementById('con-'+name+'-'+i); 
		main_menu.className = (i==cursel)?'hover':'';
		sub_menu.style.display = (i==cursel)?'block':'none';
	}
}


$('a[action="appDown"]').mouseover(function () {
    var el = $(this);

    $('.appDown').css({
        left: this.offsetLeft + 'px',
        top: 8 + document.body.scrollTop + this.offsetTop + this.offsetHeight + 'px'
    });
    $('.appDown').removeClass('hidden');

}).mouseout(function () {
    $('.appDown').addClass('hidden');
});

$(function(){
    $(".register .close").bind("click",function(){
	    $(".register").hide();
	});
	
	var nTop = $(".header").offset().top;
	$(window).scroll(function(){
		/*固定导航开始*/
	    var nSrolltop = $(this).scrollTop();
	      if(nSrolltop>=nTop){
		      $(".header").css({
			      "position":"fixed",
				  "top":0,
				  "left":0,
				  "z-index":1000
			  });
		  }
		  else if(nSrolltop<nTop){
		      $(".header").css({
			      "position":"static"
			  });
		  }
		  /*固定导航结束*/
		  
		  /*回到顶部开始*/
		  if($(window).scrollTop() >= 500){ 
			$('.back').fadeIn(300); 
		  }else{    
			  $('.back').fadeOut(300); 
		  }  
		  /*回到顶部结束*/
	});
	
	$('.back').click(function(){$('html,body').animate({scrollTop: '0px'}, 800);}); //火箭动画停留时间，越小消失的越快~
	
});


