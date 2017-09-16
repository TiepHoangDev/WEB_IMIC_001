$(document).ready(function() {
$('.text-slider:first').fadeIn(2000);
 $("#owl-demo").owlCarousel({
      slideSpeed : 300,
      paginationSpeed : 400,
      singleItem:true,
	  transitionStyle: "fade",
 	  pagination:false,
	  autoPlay: true,
	  afterMove : function (elem) {
		  var current = this.currentItem;
		  $('.text-slider').hide();
		   elem.find(".owl-item").eq(current).find(".text-slider").fadeIn(2000);
    }
});  
	

  $('.owl-item').each(function(index, element){       
   $(this).find('.banner-number').text(index+1);
   });
   
   
});
$('.owl-prev').click(function(){
		var owl = $(".owl-carousel").data('owlCarousel');
		owl.prev();
	});
	$('.owl-next').click(function(){
		var owl = $(".owl-carousel").data('owlCarousel');
		owl.next();
	});
 $('#bg-green-desktop').click(function(){
	 if (window.matchMedia('(min-width: 320px) and (max-width:768px)').matches){
	 if($('#content-blue').css('display')!='none')$('#content-blue').slideToggle("fast");
	 if($('#content-orange').css('display')!='none')$('#content-orange').slideToggle("fast");
	 $('#content-green').slideToggle("fast");
	 }
	 });
	 $('#bg-blue-desktop').click(function(){
		 if (window.matchMedia('(min-width: 320px) and (max-width:768px)').matches){
      if($('#content-green').css('display')!='none')$('#content-green').slideToggle("fast");
	 if($('#content-orange').css('display')!='none')$('#content-orange').slideToggle("fast");
	 $('#content-blue').slideToggle("fast");
		 }
    });
	 $('#bg-orange-desktop').click(function(){
		 if (window.matchMedia('(min-width: 320px) and (max-width:768px)').matches){
      if($('#content-blue').css('display')!='none')$('#content-blue').slideToggle("fast");
	 if($('#content-green').css('display')!='none')$('#content-green').slideToggle("fast");
	 $('#content-orange').slideToggle("fast");
		 }
    });
	$(window).resize(function(){
     var win = $(this);
	 	if(window.matchMedia('(min-width:769px)').matches){
			$('#content-orange').css("display","block");
			$('#content-green').css("display","block");
			$('#content-blue').css("display","block");
		}
		else if (window.matchMedia('(min-width: 320px) and (max-width:768px)').matches){
			$('#content-orange').css("display","none");
			$('#content-green').css("display","none");
			$('#content-blue').css("display","none");
		}
	});// JavaScript Document