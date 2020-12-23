 
 $(function(){
 	$(window).bind('scroll', function () {
 		console.log('dsds')
    if ($(window).scrollTop() > 600) {
        $('.menu').addClass('fixed');
        $('.menu').addClass('logo-to');
        $('.menu').removeClass('pt-3');
        $('.menu').removeClass('col-xs-8');
        $('.menu').removeClass('push-xs-2');
    } else {
        $('.menu').removeClass('fixed');
         $('.menu').removeClass('logo-to');
        $('.menu').addClass('pt-3');
        $('.menu').addClass('col-xs-8');
        $('.menu').addClass('push-xs-2');
    }
});

    });
// hieu ung slide

 $(function() {
    
   $('.next').click(function(event) {
        var sau = $('.active').next();
        //console.log(sau.length);
        if(sau.length == 0){
            $('.active').addClass('bien-mat-ben-trai').one('webkitAnimationEnd', function(event) {
            $('.bien-mat-ben-trai').removeClass('bien-mat-ben-trai');
            });

            $('.anhslide ._1slide:nth-child(1)').addClass('di-vao-tu-ben-phai').one('webkitAnimationEnd', function(event) {
                //bo active
                $('.active').removeClass('active');
                $('.di-vao-tu-ben-phai').addClass('active').removeClass('di-vao-tu-ben-phai');
            });

        }
        else
        {
            //code cho viec addcalss ban dau
            $('.active').addClass('bien-mat-ben-trai').one('webkitAnimationEnd', function(event) {
                $('.bien-mat-ben-trai').removeClass('bien-mat-ben-trai');
            });
            sau.addClass('di-vao-tu-ben-phai').one('webkitAnimationEnd', function(event) {
                //bo active
                $('.active').removeClass('active');
                $('.di-vao-tu-ben-phai').addClass('active').removeClass('di-vao-tu-ben-phai');
            });
            // ham doi chuyen dong xong moi lam one('webktAnimationEnd'.function)
    }


    });

    $('.prev').click(function(event) {
        var truoc = $('.active').prev();

    if(truoc.length == 1){
        $('.active').addClass('bien-mat-ben-phai').one('webkitAnimationEnd', function(event) {
            $('.bien-mat-ben-phai').removeClass('bien-mat-ben-phai');
            });
        truoc.addClass('di-vao-tu-ben-trai').one('webkitAnimationEnd', function(event) {
                
                $('.active').removeClass('active');
                $('.di-vao-tu-ben-trai').addClass('active').removeClass('di-vao-tu-ben-trai');
            });}
    else
    {
        $('.active').addClass('bien-mat-ben-phai').one('webkitAnimationEnd', function(event) {
            $('.bien-mat-ben-phai').removeClass('bien-mat-ben-phai');
            });
        $('.anhslide ._1slide:nth-child(3)').addClass('di-vao-tu-ben-trai').one('webkitAnimationEnd', function(event) {
                
                $('.active').removeClass('active');
                $('.di-vao-tu-ben-trai').addClass('active').removeClass('di-vao-tu-ben-trai');
            }); 
    }
    });
});


