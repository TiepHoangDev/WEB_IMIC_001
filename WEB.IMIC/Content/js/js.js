var $ = jQuery.noConflict();
$(document).ready(function($) {
	$('.animated').waypoint(function () {
        var animation = $(this).attr('data-animation');
        var xposition = $(this).attr('data-xposition');
        var yposition = $(this).attr('data-yposition');
        var delay = $(this).attr('data-animation-delay');
		
        $(this).addClass(animation, function () {
            $(this).css({
                opacity: '1',
                marginLeft: xposition + 'px',
                marginTop: '-' + yposition + 'px',
                animationDelay: delay + 'ms'
            });
       });

    }, {
        offset: '85%',
        triggerOnce: true
    });
	
	/*Lang*/

	
});