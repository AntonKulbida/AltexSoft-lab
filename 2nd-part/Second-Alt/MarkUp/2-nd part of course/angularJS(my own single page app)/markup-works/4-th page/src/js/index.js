
function getData() {
  //JSON
  var Data_ = [];
  var serializeSet = {};
  serializeSet.IncomeJSON = document.querySelector('#Income').value;// создаем свойство "IncomeJSON" и присваиваем значение
  Data_.push(serializeSet);
  var jsons = JSON.stringify(Data_);//переобразовываем объект в массив состаящий из строк
  localStorage.setItem("jsons", jsons);//так как локальное хранилеще может хранить только строки,мы туда и помещаем ---> переобразованый объект в массив состоящий из строк
}

$(document).ready(function(){
  //animation
  var start = Date.now(); // сохранить время начала

  var timer = setInterval(function() {
    // вычислить сколько времени прошло с начала анимации
    var timePassed = Date.now() - start;

    if (timePassed >= 15000) {
      clearInterval(timer); // конец через 2 секунды
      return;
    }
    // рисует состояние анимации, соответствующее времени timePassed
    draw(timePassed);

  }, 20);


  function draw(timePassed) {
    meteor.style.right = timePassed / 4 + 'px';
    meteor.style.top = timePassed / 4 + 'px';
  }

  // MENU

  $('.top-bottom .top-content-menu-gamburger').hide();

    $b = $('.top-bottom .cross-for-menu');

    $b.on('click',function(event){
      event.preventDefault();
      $b.not(this).next().slideUp(600);
      $(this).next().slideToggle(600);
    });


  $('.top-bottom-login .menu-basket').hide();

   $a = $('.top-bottom-login .go-menu-basket');

   $a.on('click', function(event) {
     event.preventDefault();
     $a.not(this).next().slideUp(600);
     $(this).next().slideToggle(600);
   });




  // var elem = document.querySelector('.grid');
  // var msnry = new Masonry( elem, {
  // // options
  // itemSelector: '.content-menu-jaquetas',
  // columnWidth: 200
  // });


// Hover events

// $(document).on("mouseenter", "#wrapper", function(){
//
//     tl.play();
//
// }).on("mouseleave", "#wrapper", function(){
//
//     tl.reverse();
//
// });

});
