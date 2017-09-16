
//tim kiem
$('.textfield').focusin(function() {
					$("#Box-field").css('display','block');
					
					});
			
			 
					$(".close-from").click(function(){
						$("#Box-field").css('display','none');
						
					});
					$("#Box-field li span").click(function(){
					$(".autoText").val($(this).html());
					$("#Box-field").css('display','none');
			  });




//slider

jQuery('#wowslider').wowSlider({
	effect:"carousel", 
	prev:"", 
	next:"", 
	duration: 20*100, 
	delay:20*100, 
	width:960,
	height:360,
	autoPlay:true,
	autoPlayVideo:false,
	playPause:false,
	stopOnHover:false,
	loop:false,
	bullets:1,
	caption: true, 
	captionEffect:"fade",
	controls:true,
	responsive:2,
	fullScreen:false,
	gestures: 2,
	onBeforeStep:0,
	images:0
});



//Loads the correct sidebar on window load,
//collapses the sidebar on window resize.
// Sets the min-height of #page-wrapper to window size
$(function() {
    $(window).bind("load resize", function() {
        topOffset = 50;
        width = (this.window.innerWidth > 0) ? this.window.innerWidth : this.screen.width;
        if (width < 768) {
            $('div.navbar-collapse').addClass('collapse')
            topOffset = 100; // 2-row-menu
        } else {
            $('div.navbar-collapse').removeClass('collapse')
        }

        height = (this.window.innerHeight > 0) ? this.window.innerHeight : this.screen.height;
        height = height - topOffset;
        if (height < 1) height = 1;
        if (height > topOffset) {
            $("#page-wrapper").css("min-height", (height) + "px");
        }
    })
})
/////


