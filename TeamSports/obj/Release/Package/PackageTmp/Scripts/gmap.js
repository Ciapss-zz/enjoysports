var map;
var marker;
var MyLatLng = {};
var selectChanged = false;
function initMap() {

    if (!selectChanged) {
        if (!$("#GeoLat").val() || !$("#GeoLng").val())
        {
            MyLatLng = new google.maps.LatLng(parseFloat("47.424060"), parseFloat("9.377446"));
        } else {
            MyLatLng = new google.maps.LatLng(parseFloat($("#GeoLat").val()), parseFloat($("#GeoLng").val()));
        }
    }

    map = new google.maps.Map(document.getElementById('map'), {
        center: MyLatLng,
        zoom: 8
    });

    marker = new google.maps.Marker({
        position: MyLatLng,
        map: map
    });

    google.maps.event.addListener(map, 'click', function (event) {
        addMarker(event.latLng);
    });
    selectChanged = true;
}

function addMarker(location) {
    if (!marker) {
        marker = new google.maps.Marker({
            position: location,
            map: map
        });
    }
    else { marker.setPosition(location); }

    $("#GeoLat").attr("value", marker.position.lat);
    $("#GeoLng").attr("value", marker.position.lng);
}

$(document).on('ready', function () {
    $('select#CityID').on('change', function () {
        marker = [];
        var city = this.value;
        MyLatLng = new google.maps.LatLng(parseFloat($('#' + city).attr('data-lat')), parseFloat($('#' + city).attr('data-lng')));
        selectChanged = true;
        initMap();
        addMarker(MyLatLng);
    });
});