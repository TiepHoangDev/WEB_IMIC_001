/* 
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */

/*==================================
 CHECK TOUCH DEVICE
 ==================================*/
function isTouchDevice(){
    return true == ("ontouchstart" in window || window.DocumentTouch && document instanceof DocumentTouch);
}

var clickEvent;
if(isTouchDevice() === true) {
    clickEvent = 'click';
} else {
    clickEvent = 'touchstart';
}

/*==================================
 SMART RESIZE
 ==================================*/
(function($,sr){
    var debounce = function (func, threshold, execAsap) {
        var timeout;
        return function debounced () {
            var obj = this, args = arguments;
            function delayed () {
                if (!execAsap)
                    func.apply(obj, args);
                timeout = null;
            }
            if (timeout)
                clearTimeout(timeout);
            else if (execAsap)
                func.apply(obj, args);
            timeout = setTimeout(delayed, threshold || 400);
        };
    };
// smartresize2
    jQuery.fn[sr] = function(fn){ return fn ? this.bind('resize', debounce(fn)) : this.trigger(sr); };
})(jQuery,'smartresize2');

/*==================================
 ...
 ==================================*/
(function ($) {
    Drupal.behaviors.contact = {
        attach: function (context, settings) {
            var contact_selected = jQuery('#contact-site-form').find(".form-item-country option:selected");
            if (contact_selected.val() != "") {
                jQuery('#contact-site-form').find(".form-item-country label").hide();
            }

        }
    };
})(jQuery);



/*=====================================================================================================================================
CUSTOM 2.0 ============================================================================================================================
=====================================================================================================================================*/

var _imic = {
    init: function () {
        'use strict';

        if ($(".node-type-one-page").length)                                _imic.onePage.init('.one-page-scroll', '.scroll-section');
        if ($(".view-filters").length)                                      _imic.filterOnMobile.init();
        if ($("#instafeed-container").length)                               _imic.getinstafeed.init();
        if ($(".portfolio-content").length)                                 _imic.onloadContent.init('.portfolio-content .portfolio-loading', '.view-content');
        if ($(".faqs-accordion").length)                                    _imic.toggleGroup.init('.faqs-accordion li > h3', '.faqs-accordion li > div', '', 'hidden');
        if ($(".career-group").length)                                      _imic.toggleGroup.init('.group-career-title', '.group-career-data');
        if ($(".region-sidebar-second").length)                             _imic.toggleGroup.init('.region-sidebar-second .block-contents > .block-title', '.region-sidebar-second .block-contents > .content');
        if($('.icon-top').length)                                           _imic.middleTitle.init('.icon-top h3');
        if($('.sh-lastest-news .blog-title').length)                        _imic.equalHeight.init('.sh-lastest-news .blog-title');
        if($('.capbilities-hero-image .img-grid').length)                   _imic.equalHeight.init('.capbilities-hero-image .img-grid', true);
        if($('.portfolio-video-block .client-info').length)                 _imic.equalHeight.init('.portfolio-video-block .client-info');
        if($('.career-life-at-smart .group-title').length)                  _imic.middleTitle.init('.career-life-at-smart .group-title');
        if($('.career-life-at-smart ul li').length)                         _imic.equalHeight.init('.career-life-at-smart ul li');
        if($('.home-team-grid .portfolio-content .views-row').length)       _imic.mobileCarousel.init('.home-team-grid .portfolio-content .view-content');
        if($('.about-us-team-grid .portfolio-content .views-row').length)   _imic.mobileCarousel.init('.about-us-team-grid .portfolio-content .view-content');
        if($('.article-carousel .view-content .views-row').length)          _imic.mobileCarousel.init('.article-carousel .view-content', '.blog-title');
        if($('.portfolio-video-block .view-content .views-row').length)     _imic.mobileCarousel.init('.portfolio-video-block .view-content', '.client-info');

        _imic.careersPopup.init();
        _imic.socialUpdate.init();
        _imic.resizeAction.init();
        _imic.loadedAction.init();

        //===========================================================================================================

        if (navigator.userAgent.indexOf('Safari') != -1 && navigator.userAgent.indexOf('Chrome') == -1) {
            $('body').addClass('safari-browser');
        }

        $('#section-header .block-superhero-dropdown .content > .superhero-mobile-menu-toggle').on('click', function(e){
            e.preventDefault();
            return false
        });

        $(".scroll").click(function (event) {
            event.preventDefault();
            $('html,body').animate({scrollTop: $(this.hash).offset().top}, 1500);
        });

        if($('.case-study-scope-of-work dl dd').length){
            var workCounter = 'scope-of-work-'+$('.case-study-scope-of-work dl dd').length;
            $('.case-study-scope-of-work').addClass(workCounter);
        }

        if($('.careers-homepage #section-banner .featured-banner-item .views-row').length){
            _imic.equalHeight.init('.careers-homepage #section-banner .featured-banner-item .views-row');
            _imic.middleTitle.init('.careers-homepage #section-banner .featured-banner-item .views-row h4');
        }

        if($('.first-load').length && $('.loading-block').length){
            $(window).load(function(){
                $('.first-load').hide().next('.loading-block').addClass('loaded');
            });
        }

        if ($('#instafeed-container .empty').length) {
            $('#instafeed-container .empty').remove();
        }

        if(isTouchDevice() === true) {
            $("html").addClass('is-touch-device');
            //$('body').on('touchstart', '.portfolio-item', function(){
            //    $(this).trigger('click');
            //});
        }

        if($('.home-team-grid .views-row a').length) {
            $('.home-team-grid .views-row a').attr('href', 'javascript:void(0);');
        }

        if ($('.about-us-team-grid .views-row a').length) {
            $('.about-us-team-grid .views-row a').each(function () {
                if (!$(this).closest('.redirect-link')) {
                    $(this).attr('href', 'javascript:void(0);');
                }
            });
        }

        if($('.portfolio-homepage').length) {
            if($('.portfolio-homepage .portfolio-content .view-content > .views-row').length < 13) {
                $('.portfolio-content').addClass('count-12');
            }
        }

        if ($(".youtube-video-full-screen").length) {
            $('.home-page-banner-content').width($(window).width()).height($(window).height());
            _imic.fullScreenVideo.initVideo();
        }

    },
    loadedAction: {
        init: function () {
            'use strict';

            $(window).load(function () {

                if ($(".portfolio-content").length) $('.portfolio-content .view-content').addClass('loaded');
                if($('.portfolio-content .view-content .views-row').not('.home-case-row').length) {
                    $('.portfolio-content .view-content .views-row').not('.home-case-row').each(function () {
                        _imic.imageCenter.init($(this).find(".jm-portfolio"), $(this).find('.portfolio-item > img'));
                    });
                    $(window).resize(function () {
                        $('.portfolio-content .view-content .views-row .portfolio-item > img').removeAttr('style');
                    });
                }

                //if(!$('#section-banner').length){
                //    $('#section-header').removeClass('bg-transparent');
                //}

                $(window).trigger('scroll');

                //$('body').addClass('loaded');
                //$('.waiting-block').fadeOut(500, function(){
                //    $(this).addClass('hidden');
                //    $(window).trigger('scroll');
                //});

                $(window).bind('beforeunload', function(){
                    //$('#section-header').removeClass('fixed-transition').addClass('bg-transparent redirect-now');
                    //$('.waiting-block').removeClass('hidden');
                    //$('body').removeClass('loaded');
                    //$(window).unbind("scroll");
                });

                if ($('#instafeed-container .insta-item').length) {
                    if (isTouchDevice() === true) {
                        $('#instafeed-container .insta-item').on('touchstart', function () {
                            if ($(this).hasClass('focus')) {
                                $(this).remove('focus');
                            } else {
                                if ($('#instafeed-container .insta-item').removeClass('focus')) {
                                    $(this).addClass('focus');
                                }
                            }
                        });
                    } else {
                        $('#instafeed-container .item').hoverdir({
                            hoverElem: '.caption'
                        });
                    }
                }

            });
        }
    },
    resizeAction: {
        init: function () {
            'use strict';

            $(window).smartresize2(function () {

                if ($(window).width() >= 992) {
                    $('.before-bottom-fixed').css({
                        marginBottom: $('.bottom-fixed').height()
                    });
                } else {
                    $('.before-bottom-fixed').css({
                        marginBottom: 0
                    });
                }

                if($('.portfolio-content .view-content .views-row').not('.home-case-row').length) {
                    $('.portfolio-content .view-content .views-row').not('.home-case-row').each(function () {
                         _imic.imageCenter.init($(this).find(".jm-portfolio"), $(this).find('.portfolio-item > img'));
                    });
                }

            });
        }
    },
    fullScreenVideo: {
        initVideo: function(){
            'use strict';

            var _this = $(".youtube-video-full-screen");

            if (isTouchDevice() !== true) {
                var ytID = _this.attr('data-video-id');
                //console.log(ytID);
                var ytOptions = {
                    ratio: 16 / 9, // usually either 4/3 or 16/9
                    videoId: ytID,
                    mute: false,
                    repeat: true,
                    width: $(window).width(),
                    wrapperZIndex: 1,
                    shieldBg: false,
                    shieldOpacity: 0.3,
                    playButtonClass: 'tubular-play',
                    pauseButtonClass: 'tubular-pause',
                    muteButtonClass: 'tubular-mute',
                    volumeUpClass: 'tubular-volume-up',
                    volumeDownClass: 'tubular-volume-down',
                    increaseVolumeBy: 10,
                    start: 0,
                    setBlockHeight: false
                };
                _this.empty().tubular(ytOptions);
                $(window).load(function(){
                    if(_this.find('iframe').length){
                        $('.home-page-banner-content .banner-img').fadeOut(1000);
                    }
                });
            }

        }
    },
    getinstafeed: {
        init: function () {
            'use strict';

            var userFeed = new Instafeed({
                get: 'user',
                userId: 1549753999,
                accessToken: '1549753999.33184ef.e3f97dbbd10644278eac432a2e3196c1',
                target: 'instafeed-container',
                sortBy: 'most-recent',
                limit: 6,
                links: true,
                template: '<a title="{{caption}}" class="insta-item"><span class="item"><img src="{{image}}" alt="{{caption}}" width="612" height="612"/><span class="caption"><span>{{caption}}</span></span></span></a>',
                resolution: 'standard_resolution'
            });
            userFeed.run();

            $(window).load(function () {
                _imic.mobileCarousel.init('#instafeed-container');
            });
        }
    },
    imageCenter: {
        init: function (container, img) {
            'use strict';

            if ($(container).length && $(img).length) {
                var blockW = $(container).width();
                var blockH = $(container).height();
                var imgW = $(img).width();
                var imgH = $(img).height();

                if (imgH < blockH) {
                    $(img).css({
                        'position': 'absolute',
                        'max-width': 'inherit',
                        'width': 'auto',
                        'height': '100%',
                        'top': '0',
                        'left': '50%',
                        '-webkit-transform': 'translate(-50%, 0)',
                        '-moz-transform': 'translate(-50%, 0)',
                        '-ms-transform': 'translate(-50%, 0)',
                        '-o-transform': 'translate(-50%, 0)',
                        'transform': 'translate(-50%, 0)'
                    });
                }
                if (imgW <= blockW && imgH >= blockH) {
                    $(img).css({
                        'position': 'absolute',
                        'max-height': 'inherit',
                        'width': '100%',
                        'height': 'auto',
                        'top': '50%',
                        'left': '0',
                        '-webkit-transform': 'translate(0, -50%)',
                        '-moz-transform': 'translate(0, -50%)',
                        '-ms-transform': 'translate(0, -50%)',
                        '-o-transform': 'translate(0, -50%)',
                        'transform': 'translate(0, -50%)'
                    });
                }
            }
        }
    },
    onloadContent: {
        init: function(loading, content){
            'use strict';

            var loadingIMG = $(loading);
            $(window).load(function(){
                if(loadingIMG.hide()){
                    loadingIMG.next(content).addClass('loaded').show();
                }
            });
        }
    },
    mobileCarousel: {
        init: function (container, equalHeightEle) {
            'use strict';

            var owl = $(container);

            if ($(window).width() < 768) {
                if (typeof equalHeightEle !== 'undefined') {
                    _imic.mobileCarousel.carouselInit(container, equalHeightEle);
                } else {
                    _imic.mobileCarousel.carouselInit(container);
                }
            } else {
                if (owl.find('.owl-stage-outer').length) {
                    owl.trigger('destroy.owl.carousel').removeClass('owl-carousel');
                }
            }

            $(window).resize(function () {
                if ($(window).width() >= 768) {
                    if (owl.find('.owl-stage-outer').length) {
                        owl.trigger('destroy.owl.carousel').removeClass('owl-carousel');
                    }
                } else {
                    if (typeof equalHeightEle !== 'undefined') {
                        _imic.mobileCarousel.carouselInit(container, equalHeightEle);
                    } else {
                        _imic.mobileCarousel.carouselInit(container);
                    }
                }
            });

        },
        carouselInit: function (container, equalHeightEle) {
            'use strict';

            $(container).addClass('owl-carousel').owlCarousel({
                loop: true,
                margin: 0,
                nav: false,
                dots: true,
                autoHeight: false,
                responsive: {
                    0: {
                        items: 1
                    },
                    480: {
                        items: 2
                    }
                },
                onInitialized: function () {
                    if (typeof equalHeightEle !== 'undefined') {
                        if ($(container).find(equalHeightEle).length) {
                            var block = container + ' ' + equalHeightEle;
                            _imic.mobileCarousel.equalHeight(block);
                        }
                    }
                },
                onResized: function () {
                    if (typeof equalHeightEle !== 'undefined') {
                        if ($(container).find(equalHeightEle).length) {
                            var block = container + ' ' + equalHeightEle;
                            _imic.mobileCarousel.equalHeight(block);
                        }
                    }
                }
            })
        },
        equalHeight: function (block) {
            'use strict';

            if ($(block).css('height', 'auto')) {
                var tallest = 0;
                $(block).each(function () {
                    var thisHeight = $(this).outerHeight();
                    if (thisHeight > tallest) {
                        tallest = thisHeight;
                    }
                });
                $(block).height(tallest);
            }
        }
    },
    middleTitle: {
        init: function (container) {
            'use strict';

            _imic.middleTitle.calc(container);
            $(window).resize(function(){
                $(container).css({'padding-top': 0, 'padding-bottom': 0});
            });
            $(window).smartresize2(function(){
                _imic.middleTitle.calc(container);
            });
        },
        calc: function(container){
            'use strict';

            if ($(container).css({'padding-top': 0, 'padding-bottom': 0})) {
                var maxHeight = Math.max.apply(Math, $(container).map(function () {
                    return $(this).outerHeight();
                }));

                $(container).each(function () {
                    var thisHeight = $(this).outerHeight();
                    if (thisHeight < maxHeight) {
                        $(this).css({
                            'padding-top': (maxHeight - thisHeight) / 2,
                            'padding-bottom': (maxHeight - thisHeight) / 2
                        });
                    }
                });
            }
        }
    },
    equalHeight: {
        init: function (container, afterLoad) {
            'use strict';

            if (typeof afterLoad !== 'undefined') {
                $(window).load(function () {
                    _imic.equalHeight.calc(container);
                });
            } else {
                _imic.equalHeight.calc(container);
            }
            $(window).resize(function () {
                $(container).css('height', 'auto');
            });
            $(window).smartresize2(function () {
                _imic.equalHeight.calc(container);
            });
        },
        calc: function(container){
            'use strict';

            if ($(window).width() >= 768) {
                if ($(container).css('height', 'auto')) {
                    var tallest = 0;
                    $(container).each(function () {
                        var thisHeight = $(this).outerHeight();
                        if (thisHeight > tallest) {
                            tallest = thisHeight;
                        }
                    });
                    $(container).height(tallest);
                }
            }
            //} else {
            //    $(container).css('height', 'auto');
            //}
        }
    },
    toggleGroup: {
        init: function (groupTitle, groupContainer, defaultMobile, defaultDesktop) {
            'use strict';

            if ($(window).width() < 768) {
                if (typeof defaultMobile !== 'undefined' && defaultMobile == 'open') {
                    $(groupTitle).addClass('active').append("<span class='status'>-</span>");
                    $(groupContainer).show();
                } else {
                    $(groupTitle).append("<span class='status'>+</span>");
                    $(groupContainer).hide();
                }
            } else {
                if (typeof defaultDesktop !== 'undefined' && defaultDesktop == 'hidden') {
                    $(groupTitle).append("<span class='status'>+</span>");
                    $(groupContainer).hide();
                } else {
                    $(groupTitle).addClass('active').append("<span class='status'>-</span>");
                    $(groupContainer).show();
                }
            }

            $(groupTitle).on('click', function () {

                var title = $(this);
                var container = $(this).next(groupContainer);

                if (container.is(':hidden')) {
                    container.slideDown('200', function () {
                        title.addClass('active').find('.status').html("-");
                    });
                } else {
                    container.slideUp('200', function () {
                        title.removeClass('active').find('.status').html("+");
                    });
                }

            });
        }
    },
    filterOnMobile: {
        init: function(){
            'use strict';

            var filterItem = $('.view-filters .form-type-bef-link');

            if (filterItem.length) {
                filterItem.parent().parent().addClass('filter-on-mobile');
                var currentItem = $('.view-filters .form-type-bef-link a.active').text();
                $("<div class='filter-title' style='display: none;'>Filter : <span>" + currentItem + "</span><i class='fa fa-angle-down'></i></div>").insertBefore(filterItem.parent());
                $(".filter-on-mobile .filter-title").on('click', function(){
                    var title = $(this);
                    var container = $(this).next();

                    if (container.hasClass('active')) {
                        container.slideUp('200', function () {
                            container.removeClass('active');
                        });
                    } else {
                        container.slideDown('200', function () {
                            container.addClass('active');
                        });
                    }
                });
            }
        }
    },
    socialUpdate: {
        init: function(){
            'use strict';

            /*update js social*/
            jQuery('.social-likes').find('.social-likes__icon_facebook').click(function () {
                var count_num = jQuery(this).parent().parent().find('.social-likes__counter_facebook').text();
                if (count_num == '') {
                    count_num = '0';
                    jQuery('.social-likes__counter_facebook').removeClass('social-likes__counter_empty');
                }
                jQuery('.social-likes__counter_facebook').text(parseInt(count_num) + 1);
            });
            jQuery('.social-likes').find('.social-likes__icon_twitter').click(function () {
                var count_num = jQuery(this).parent().parent().find('.social-likes__counter_twitter').text();
                if (count_num == '') {
                    count_num = '0';
                    jQuery('.social-likes__counter_twitter').removeClass('social-likes__counter_empty');
                }
                jQuery('.social-likes__counter_twitter').text(parseInt(count_num) + 1);
            });
            jQuery('.social-likes').find('.social-likes__icon_plusone').click(function () {
                var count_num = jQuery(this).parent().parent().find('.social-likes__counter_plusone').text();
                if (count_num == '') {
                    count_num = '0';
                    jQuery('.social-likes__counter_plusone').removeClass('social-likes__counter_empty');
                }
                jQuery('.social-likes__counter_plusone').text(parseInt(count_num) + 1);
            });
        }
    },
    onePage: {
        init: function(wrapper, section){
            'use strict';

            $('html').addClass('node-type-one-page');

            if ($(wrapper).length && $(section).length) {
                $(window).load(function () {
                    if ($('.loader').length) {
                        $('.loader').hide().next(wrapper).show();
                    } else {
                        $(wrapper).show();
                    }
                    $(wrapper).onepage_scroll({
                        sectionContainer: section,
                        responsiveFallback: 600,
                        loop: true
                    });
                    $('.btn-start').on('click', function(e){
                        e.preventDefault();
                        $(wrapper).moveDown();
                        return false;
                    });
                });
            }
        }
    },
    careersPopup: {
        init: function(){
            'use strict';

            $('.apply-btn a, a.apply-btn').on('click', function () {

                var popupText = $(this).closest('.field-name-field-apply').siblings('.field-name-field-popup-content').html();

                var popupHTML = "<div class='careers-popup show-popup'><div class='popup-content'><h3>APPLY THIS JOB</h3><a href='javascript:void(0);' class='close-btn'><i class='fa fa-close'></i></a>"+popupText+"</div></div><div class='popup-shield show-popup'>&nbsp;</div>";

                if ($('.careers-popup').length) {
                    $('.careers-popup, .popup-shield').removeClass('hide-popup').addClass('show-popup').show();
                } else {
                    $('body').append(popupHTML);
                    setTimeout(function(){
                        $('.careers-popup .close-btn').on('click', function () {
                            $('.careers-popup, .popup-shield').removeClass('show-popup').addClass('hide-popup').hide();
                        });
                    }, 200);
                }
                return false;
            });
        }
    }
};

(function ($) {
    $(document).ready(function(){
        'use strict';

        _imic.init();
    });

    $(window).resize(function () {
        'use strict';

        if ($(".youtube-video-full-screen").length) {
            $('.home-page-banner-content').width($(window).width()).height($(window).height());
             _imic.imageCenter.init('.home-page-banner-content', '.home-page-banner-content .banner-img img');
        }
    });

    $(window).load(function(){

        if ($(".youtube-video-full-screen").length) {
            $('.home-page-banner-content .banner-shield img').fadeOut(500, function(){
                 _imic.imageCenter.init('.home-page-banner-content', '.home-page-banner-content .banner-img img');
                $('.home-page-banner-content .banner-shield').addClass('transparent');
                $('.banner-description-center').addClass('loaded').show();
            });
        }

    });
})(jQuery);