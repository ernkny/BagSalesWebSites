

var card=document.getElementById("cardposition");
console.log(card.getBoundingClientRect())
$(window).scroll(function(){
var position=$(document).scrollTop();


});
$(function() {
    if ($('#cardposition').is(':visible')) {
      $('#cardposition').addClass('red');
    }
  });
  $(window).on('scroll', function() {
    var $elem = $('#cardposition');
    var $window = $(window);
  
    var docViewTop = $window.scrollTop();
    var docViewBottom = docViewTop + $window.height();
    var elemTop = $elem.offset().top;
    var elemBottom = elemTop + $elem.height();
    if (elemBottom < docViewBottom) {
     
        $('#cardposition').addClass('animate__pulse');
    }
  });


document.getElementById("hover").addEventListener("mouseover", mouseOver);
document.getElementById("hover").addEventListener("mouseout", mouseOut);

function mouseOver() {
    console.log("adasdas");
    const element = document.getElementById("demo");
    element.classList.add('animate__shakeY');
    
}
function mouseOut() {
     const element=document.getElementById("demo");
    element.classList.remove('animate__shakeY');
}