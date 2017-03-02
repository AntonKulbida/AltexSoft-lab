function initMap() {
    var centerLatLng = new google.maps.LatLng(49.057831, 33.402398);
    var mapOptions = {
        center: centerLatLng,
        zoom: 17
    };
 
    var map = new google.maps.Map(document.getElementById("map"), mapOptions);
 
    // Добавляем маркер
    var marker = new google.maps.Marker({
        position: centerLatLng,               
        map: map,                 
        title: "Текст всплывающей подсказки"
        // icon: "add_marker/images/marker.png"    
    });
}
google.maps.event.addDomListener(window, "load", initMap);