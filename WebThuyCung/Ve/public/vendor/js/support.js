 $(function(){

 	$('.ndsection').slideUp();

 	$('.section1-1 h6,.section2-1 h6,.section3-1 h6').click(function(){
 		$(this).next().slideToggle();
 	});
 })
 $(function(){
 	
 	$('div .ndnut1').on('click',function(event){
 		event.preventDefault();
 		$("html, body").animate({scrollTop:$('.section1').offset().top});
 	});
 	$('.ndnut2').on('click',function(event){
 		event.preventDefault();
 		$("html, body").animate({scrollTop:$('.section2').offset().top});
 	});
 	$('.ndnut3').on('click',function(event){
 		event.preventDefault();
 		$("html, body").animate({scrollTop:$('.section2').offset().top});
 	});
 	$('.ndnut4').on('click',function(event){
 		event.preventDefault();
 		$("html, body").animate({scrollTop:$('.section3').offset().top});
 	});
 	$('.ndnut5').on('click',function(event){
 		event.preventDefault();
 		$("html, body").animate({scrollTop:$('.section3').offset().top});
 	});

 })
 // spport2
 $(function(){
 	$(window).bind('scroll',function(){
 		console.log('cuon thanh cong')
 	 if ($(window).scrollTop() > 600) {
        $('.right').addClass('fixed');
       
     
    } else {      
        $('.right').removeClass('fixed');
        
    }
 	})
 });
 // $(function(){
 // 	$(window).bind('scroll',function() {
 // 		if($(window).scrollTop()>600){
 // 			$('.menu').addClass('fixed-menu');
 // 		}else{
 // 			$('.menu')removeClass('fixed-menu');
 // 		}
 // 	})
 // });