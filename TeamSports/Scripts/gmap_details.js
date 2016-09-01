var map;
var marker;
var MyLatLng = {};
function initMap() {
    var MyLatLng = new google.maps.LatLng(parseFloat($("#GeoLat").val()), parseFloat($("#GeoLng").val()));

    map = new google.maps.Map(document.getElementById('map'), {
        center: MyLatLng,
        zoom: 8
    });

    marker = new google.maps.Marker({
        position: MyLatLng,
        map: map
    });
}