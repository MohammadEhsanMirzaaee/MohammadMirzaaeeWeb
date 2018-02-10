
function main() {

(function () {
   'use strict';

	// Hide .navbar first
	$(".navbar").hide();
	
	// Fade in .navbar
	$(function () {
		$(window).scroll(function () {
            // set distance user needs to scroll before we fadeIn navbar
			if ($(this).scrollTop() > 200) {
				$('.navbar').fadeIn();
			} else {
				$('.navbar').fadeOut();
			}
		});

	
	});
	
	// Preloader */
	  	$(window).load(function() {

   	// will first fade out the loading animation 
    	$("#status").fadeOut("slow"); 

    	// will fade out the whole DIV that covers the website. 
    	$("#preloader").delay(500).fadeOut("slow").remove();      

  	}) 

   // Page scroll
  	$('a.page-scroll').click(function() {
        if (location.pathname.replace(/^\//,'') == this.pathname.replace(/^\//,'') && location.hostname == this.hostname) {
          var target = $(this.hash);
          target = target.length ? target : $('[name=' + this.hash.slice(1) +']');
          if (target.length) {
            $('html,body').animate({
              scrollTop: target.offset().top - 40
            }, 900);
            return false;
          }
        }
      });

    // Show Menu on Book
    $(window).bind('scroll', function() {
        var navHeight = $(window).height() - 100;
        if ($(window).scrollTop() > navHeight) {
            $('.navbar-default').addClass('on');
        } else {
            $('.navbar-default').removeClass('on');
        }
    });

    $('body').scrollspy({ 
        target: '.navbar-default',
        offset: 80
    })

  	$(document).ready(function() {
  	    $("#testimonial").owlCarousel({
        navigation : false, // Show next and prev buttons
        slideSpeed : 300,
        paginationSpeed : 400,
        singleItem:true
        });

  	});

  	// Portfolio Isotope Filter
    $(window).load(function() {
        var $container = $('.portfolio-items');
        $container.isotope({
            filter: '*',
            animationOptions: {
                duration: 750,
                easing: 'linear',
                queue: false
            }
        });
        $('.cat a').click(function() {
            $('.cat .active').removeClass('active');
            $(this).addClass('active');
            var selector = $(this).attr('data-filter');
            $container.isotope({
                filter: selector,
                animationOptions: {
                    duration: 750,
                    easing: 'linear',
                    queue: false
                }
            });
            return false;
        });

    });
	
	

  // jQuery Parallax
  function initParallax() {
    $('#intro').parallax("100%", 0.3);
    $('#services').parallax("100%", 0.3);
    $('#aboutimg').parallax("100%", 0.3);	
    $('#testimonials').parallax("100%", 0.1);

  }
  initParallax();

  	// Pretty Photo
	$("a[rel^='prettyPhoto']").prettyPhoto({
		social_tools: false
	});	

}());

    bindServices();
}


function showServicePage(serviceId) {
    var servicesBlock = $("#service-area").html();      // Stores categories list.
    $("#back").on("click", function () {        // If back link in building clicked, categories will replace.
        $("#service-area").fadeOut(400, function () {       // Add fading out animation to the building page
            $(this).html(servicesBlock);        // Replace the categories page
            $(this).fadeIn(400);        // Add fade in animation to the categories page
        });
    });
    var xmlObj = new XMLHttpRequest();
    xmlObj.onreadystatechange = function () {
        if(xmlObj.status == 200 && xmlObj.readyState == 4){     // Response is ready
            var jsonResult = JSON.parse(xmlObj.responseText);       // Parse response text to the json object
            var result = "";    // Final result that should replace with categories content
            for(var i = 0; i < jsonResult[0].length; i++){      // Loops in buildings list
                var currentbuilding = jsonResult[0][i];
                result += '<div class="col-md-3 col-sm-6"><div class="service category" sid="' + currentbuilding.CategoryID + '">';
                result += '<img alt="' + currentbuilding.Name +'" title="'+ currentbuilding.Name +'"';
                result += 'src="' + currentbuilding.ImageAddress+'"><h3>' + currentbuilding.Name +'</h3></div></div>';
                if(i == 4){
                    result += '<div class="space"></div>'
                }
            }
            result += '<a title="بازگشت" href="#" id="back"><span>بازگشت</span></a>';
            $("#service-area").fadeOut(400, function () {       // Add fading out animation to the categories page
                $(this).html(result);        // Replace the building page
                $(this).fadeIn(400);        // Add fade in animation to the building page
            });
        }
        bindBuilding();
    };
	xmlObj.open("POST", "/Home/BuildingsList", true);
	xmlObj.setRequestHeader('Content-Type', 'application/x-www-form-urlencoded');   // Set request header
	xmlObj.send("&CategoryID=" + serviceId);
}

function bindServices() {
    $(".service").on("click", function () {
        var catId = $(this).attr("sid");
        showServicePage(catId);
    });
}

function gotToBuilding(buildingId) {
}

function bindBuilding() {
    $(".category").on("click", function () {
        var buildId = $(this).attr("sid");
        gotToBuilding(buildId);
    })
}

main();
