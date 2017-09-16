/******************/
var $isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
$(document).ready(function() {
	$(window).scroll(function() {
		if ($(this).scrollTop() > 10 && $isMobile == false) {
			$('.scrollToTop').fadeIn();
			$('.navbar').addClass("fixed");
		} else if ($isMobile == false) {
			$('.scrollToTop').fadeOut();
			$('.navbar').removeClass("fixed");
		}

		if ($(this).scrollTop() > 900) {
			$(".banner .container").hide();
		} else {
			$(".banner .container").show();
		}
	});

	//Click event to scroll to top
	$('.scrollToTop').click(function() {
		$('html, body').animate({
			scrollTop: 0
		}, 800);
		return false;
	});

	$(".btn-gettheme").click(function(){
		$this=$(this);
		Haravan.clear(function(){
			$this.parents('form').submit();
		});
		return false;
	});
	var flagcheckout=false;
	$(".update-cart").click(function(){
		var field=$(".shopdomain")[0]
		if (field.checkValidity() == false) {
			field.setCustomValidity("");
			if ($(field).val() == "") {
				field.setCustomValidity('Giá trị không được để trống');
			}
			return false;
		}
		sessionStorage.setItem("shopname","");
	});

	$(".btn-checkout").click(function(){
		var field=$(".shopdomain")[0]
		if (field.checkValidity() == false) {
			field.setCustomValidity("");
			if ($(field).val() == "") {
				field.setCustomValidity('Giá trị không được để trống');
			}

			field.reportValidity(); 
			return false;
		}

		if(flagcheckout==false){
			$this=$(this);
			Haravan.updateCartFromForm("formcart",function(){
				flagcheckout=true;
				sessionStorage.setItem("shopname","");
				$.get('//'+$(".shopdomain").val()+'.myharavan.com/meta.json',function(obj){window.location.href='/checkout?email='+obj.contact_email})
				//$(".btn-checkout").click();
			});
		}

		return false;
	});
});
/***************** Form register ******************/

var $isMobile = /Android|webOS|iPhone|iPad|iPod|BlackBerry|IEMobile|Opera Mini/i.test(navigator.userAgent);
$(document).ready(function() {
	/*
	$(".closemodel").click(function() {
		$(".modalcreateshop").fadeOut();
		if ($isMobile) {
			$('.scrollToTop').click();
		}
	});
	var parseQueryString = function() {

		var str = window.location.search;
		var objURL = {};

		str.replace(
			new RegExp("([^?=&]+)(=([^&]*))?", "g"),

			function($0, $1, $2, $3) {
				objURL[$1] = $3;
			});
		return objURL;
	};

	var params = parseQueryString();
	if (document.referrer.indexOf("google") >= 0 && $.cookie("referharavan") == undefined) {
		$.cookie("referharavan", "organic", {
			expires: 90
		});
		$('.typeregis').val("Affiliate");
		$('input[name="Ref"]').val('organic');
	}
	if (params["ref"] != undefined) {
		if ((params["ref"] == "bannertapchi" || params["ref"] == "tapchi" || params["ref"] == "organic") && $.cookie("referharavan") == undefined) {
			$.cookie("referharavan", "organic", {
				expires: 90
			});
			$('.typeregis').val("Affiliate");
			$('input[name="Ref"]').val("organic");
		} else if (params["ref"] != "bannertapchi" && params["ref"] != "tapchi" && params["ref"] != "organic") {
			$.cookie("referharavan", params["ref"], {
				expires: 90
			});
			$('.typeregis').val("Affiliate");
			$('input[name="Ref"]').val(params["ref"])
		} else if ($.cookie("referharavan") != undefined) {
			$('.typeregis').val("Affiliate");
			$('input[name="Ref"]').val($.cookie("referharavan"));
		} else {
			$('input[name="Ref"]').val(params["ref"]);
		}
	}
	if (params["is5giaystore"] != undefined) {
		$('#formregistry h2').text("Thông tin 5giay store của bạn");
		$('input[name="is5giaystore"]').val('true')
	} else if (params["isWTTstore"] != undefined) {

		$('#formregistry h2').text("Thông tin Webtretho store của bạn");
		$('input[name="iswttstore"]').val('true')
	}

	if (sessionStorage.getItem("is5giaystore") != undefined) {

		$('#formregistry h2').text("Thông tin 5giay store của bạn");
		$('input[name="is5giaystore"]').val('true')
	} else if (sessionStorage.getItem("isWTTstore") != undefined) {

		$('#formregistry h2').text("Thông tin Webtretho store của bạn");
		$('input[name="iswttstore"]').val('true')
	}


	$(".btn-regis,.menu-regis").click(function() {
		$(".modalcreateshop").fadeIn();
		$(".modalcreateshop").height($(document).height());
		if ($(this).prev('input').val() != "") {
			$("#formregistry .email").val($(this).prev('input').val());
		}
		if ($(window).width() <= 1137) {
			$('html, body').scrollTop(0);
		}
	});

	if (params["registry"] != undefined) {
		$(".btn-regis").click();
	}
*/
	var curentclick = null;
	if ($isMobile) {
		$("[data-toggle='popover']").popover({
			trigger: 'click',
			placement: 'top'
		});
		$("[data-toggle='popover']").on('show.bs.popover', function() {
			if (curentclick != null) {
				$(curentclick).popover('hide');
			}
			curentclick = $(this);
		});
		//$('.navbar').addClass("fixed");
	} else if($("[data-toggle='popover']").length >0){
		$("[data-toggle='popover']").popover();
	}
	$("nav a").each(function() {
		if ($(this).attr('href') == window.location.pathname.split('/').pop()) {
			$(this).addClass('active');
		}
	});
	if ($(".nav a").hasClass('active') == false) {
		$(".nav a:first").addClass('active');
	}
	//$(".modalcreateshop").swipe({
	//    //Generic swipe handler for all directions
	//    swipeUp: function (event, direction, distance, duration, fingerCount) {
	//        $(this).find('.model-content').animate({ marginTop: parseInt($(this).css('margin-top')) - distance });
	//    },
	//    swipeDown: function (event, direction, distance, duration, fingerCount) {
	//        $(this).find('.model-content').animate({ marginTop: parseInt($(this).css('margin-top')) + distance });
	//    },
	//});
	//$('.parallax').scrolly({ bgParallax: true });
	/*if($('.slideimage').length>0){
    function reloadimg(img) {
        if (img.attr('data-img')!=undefined){
        img.attr('src', "");
        img.attr('src', img.attr('data-img') + "#" + new Date().getTime());
        }
        img.fadeIn();
    }

    var timer = $.timer(function () {
        var curentcolor = "";
        var imagesrc = "";
        var curentimg = $(".slideimage img:visible");
        $(".slideimage img").hide();
        if (curentimg.next('img').length > 0) {
            imagesrc = curentimg.next('img').attr('data-img');

            var imgindex = $(".slideimage img").index(curentimg.next('img'));
            curentimg.next('img').attr('src', "");
            curentimg.next('img').attr('src', imagesrc + "#" + new Date().getTime());
            curentcolor = curentimg.attr("data-background");
            $(".banner").removeClass(curentcolor)
            curentcolor = curentimg.next('img').attr("data-background");
            $(".banner").addClass(curentcolor)
            curentimg.next('img').fadeIn();

            $(".slide-icons i").removeClass("active");
            $(".slide-icons i").eq(imgindex).addClass("active");
        }
        else {
            $(".slideimage img:first").fadeIn();
            curentcolor = curentimg.attr("data-background");
            $(".banner").removeClass(curentcolor);
            curentcolor=$(".slideimage img:first").attr("data-background");
            $(".banner").addClass(curentcolor);
            $(".slide-icons i").removeClass("active");
            $(".slide-icons i").eq(0).addClass("active");
        } 
    });
    timer.set({ time: 9000, autostart: true });


    var mytime;
    $(".slide-icons li").hover(function () {
        var $this = $(this);
        mytime =setTimeout(function(){
        timer.pause();
        var index = $(".slide-icons li").index($this);
        var img = $(".slideimage img").eq(index);
        var curentbg=$(".slideimage img:visible").attr("data-background");
        if (curentbg!=undefined){
            $(".banner").removeClass($(".slideimage img:visible").attr("data-background"));
        }
        $(".slideimage img").hide();
        $(".banner").addClass(img.attr("data-background"));
        setTimeout(function () { reloadimg(img) },100);
        $(".slide-icons i").removeClass("active");
        $this.children('i').addClass("active");
        },200)
    }, function () {
        clearTimeout(mytime);
        timer.play();
    })
        }  */
	$(window).scroll(function() {
		if($(window).width()>767){
			if ($(this).scrollTop() > 10) {
				$('.scrollToTop').fadeIn();
				$('.navbar').addClass("fixed");
				$('.intel-banner').hide();
			} else  {
				$('.scrollToTop').fadeOut();
				$('.navbar').removeClass("fixed");
				$('.intel-banner').show();
			}
		}
		if ($(this).scrollTop() > 900) {
			$(".banner .container").hide();
		} else {
			$(".banner .container").show();
		}
	});

	//Click event to scroll to top
	$('.scrollToTop').click(function() {
		$('html, body').animate({
			scrollTop: 0
		}, 800);
		return false;
	});
});


// JS
$(document).ready(function(){
	if($(window).width()<1025)
	{
		$('li.menu-right').removeClass('pull-right');
		$('.more-menu-wrap').css({'top':'9px','margin-top':'0px','height':'auto'})
	}

	/**************** MENU MAIN ******************/
	$('.intel-banner img').load(function(){
		$('.navbar').css('top', $('.intel-banner').css('height'));
	})
	$('.navbar').css('top', $('.intel-banner').css('height'));
	$(window).resize(function(){
		$('.navbar').css('top', $('.intel-banner').css('height'));
	})
	var curScrollTop = 0;
	if($(window).width()>767){
		$(window).scroll(function(){			
			if($(window).scrollTop() > 15 ) {
				$('.intel-banner').addClass('affix');
				$('nav.navbar').css('top',0);
			}else {
				$('.intel-banner').removeClass('affix');
				$('.navbar').css('top', $('.intel-banner').css('height'));
			}		
			if( $(window).scrollTop() > 600 ) {
				$('nav.navbar').addClass('affix');
			} else {
				$('nav.navbar').removeClass('affix');
			}	
			if ( $(window).scrollTop() < curScrollTop ) {
				$('nav.navbar').removeClass('affix');
			}		
			curScrollTop = $(window).scrollTop();
		});
	}
	/*** menu mobi update 25/08 ***/
	$(".wrap-header-mobile").append('<span class="background-rgba"></span>'); 
	$("#showmenu-mobile").click(function(e){
		e.preventDefault();
		$("#menu-mobile").toggleClass("show");
		$("#click-out-menu").toggleClass("show-menu");
		$('.background-rgba').css({'opacity':'1','z-index':'49','position':'fixed'});
		$('body').addClass('overflow-hidden');  
	});
	$('#click-out-menu').click(function(){
		$('#menu-mobile').removeClass("show");
		$(this).removeClass("show-menu");
		//$(".background-rgba").remove();
		//$('.background-rgba').addClass('hidden');
		$('.background-rgba').css({'opacity':'0','z-index':'-1','position':'relative'});
		$('body').removeClass('overflow-hidden'); 
	});

	/*
$('#showmenu-mobile').click(function(){
$('.background-rgba').css('position','fix');
});
$('#click-out-menu').click(function(){
$('.background-rgba').css('position','relative');
});
*/
});

$(document).ready(function() {
	if(jQuery(window).width() < 768){
		jQuery(document).ready(function() {
			var stickyNavTop = $('.form-inline').offset().top;  
			var stickyNav = function(){  
				var scrollTop = $(window).scrollTop();  
				if (scrollTop > stickyNavTop) {   
					jQuery('.form-inline').addClass('stick');
				} else {  
					jQuery('.form-inline').removeClass('stick');
				}    
			};    
			stickyNav();  
			jQuery(window).scroll(function() {  
				stickyNav();  
			}); 
		});
	}
});

$(document).ready(function(){
	jQuery(window).scroll(function() {
		if ($(this).scrollTop() > 100) {
			$('.scrollToTop').addClass('show');
		} else {
			$('.scrollToTop').removeClass('show');
		}
	});

	//Click event to scroll to top
	jQuery('.scrollToTop').on('click', function(){
		jQuery("html, body").animate({ scrollTop: 0 }, "slow");
	});
})