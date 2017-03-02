// alert("Javacript подключен");

$.fn.infiniteCarousel = function(config){
    config = $.extend({
        itemsPerMove : 2,
        duration : 500,
        vertical : false
    },config);

    var viewportEl = this.find('.viewport'), listEl = viewportEl.find('.list');
    var first = listEl.children(":first"), last = listEl.children(":last");
    
    var distance, prevProp, nextProp;
    if(config.vertical){
        distance = Math.max(first.outerHeight(true),last.outerHeight(true)) * config.itemsPerMove;
        prevProp = { 'scrollTop' : "-=" + distance };
        nextProp = { 'scrollTop' : distance }; 
    }else{
        distance = Math.max(first.outerWidth(true),last.outerWidth(true)) * config.itemsPerMove;
        prevProp = { 'scrollLeft' : "-=" + distance };
        nextProp = { 'scrollLeft' : '+=' + distance };
    }

    function move(config) {
        if (config.dir === 'next') {
            viewportEl.stop().animate(nextProp,{
                duration : config.duration,
                complete : function() {
                    config.vertical ? viewportEl.scrollTop(0) : viewportEl.scrollLeft(0);
                    repeatRun(function(){
                        listEl.children(":last").after(listEl.children(":first"));
                    },config.itemsPerMove);
                }
            });
        }

        if (config.dir === 'pre') {
            for(var i = 0; i < config.itemsPerMove; i++){
                listEl.prepend(listEl.children(":last"));
            }
            viewportEl[config.vertical ? 'scrollTop' : 'scrollLeft'](distance)
            .stop().animate(prevProp, {
                duration : config.duration
            });
        }
    }

    function repeatRun(func,times){
        for(var i = 0; i < times; i++){
            func();
        }
    }

    this.find('.pre').click(function() {
        move($.extend(config,{
            dir: "pre"
        }));
    });

    this.find('.next').click(function() {
        move($.extend(config,{
            dir: "next"
        }));
    });
    return this;
};




// init
// slides = document.getElementsByClassName("slide");
// containerWidth = 65;

// Array.prototype.forEach.call(slides, function (el, i) {//set the initial position of each slide
//   el.style.left = (i * containerWidth) + "px";
// });

// window.moveSlides = function (direction) {
//   run = true;
//   tracker = containerWidth; //500 in this example. We make a separate variable so we can decrement it

//   if (((direction == "next" && (parseInt(slides[0].style.left) <= (0 - (containerWidth * (slides.length - 1)))))) //compare against 2nd-to-last slide's index, otherwise it'll go 1 slide too far
//      || (direction == "prev" && (parseInt(slides[0].style.left) >= 0))) { run = false; }

//   if (run) {
//     var slideInterval = setInterval(function () {
//       moveRate = 2; //set the speed here (use numbers that the container's width can be divided by without a remainder)
//         Array.prototype.forEach.call(slides, function (el, i) {
//           if (tracker <= 0) {
//              clearInterval(slideInterval)
//           } else {
//             el.style.left = (direction == "next") ? (parseInt(el.style.left) - moveRate) + "px" : (parseInt(el.style.left) + moveRate) + "px";
//           }
//         });
//         tracker -= moveRate;
//     }, 1);
//   }
// }


