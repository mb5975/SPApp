var map;
//var mapShown = false;
//var mapSize = screen.width > 480 ? 2 : 1; //1,2 prvi ali drugi trenutno narisan

//window.addEventListener('resize', initialize);

window.onload = function() {
    initialize();
    //mapShown = true;
}

function showLocation(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;
    newLocation(latitude, longitude); /*show on map*/

    if (document.getElementById("gps-result-span")) {
        document.getElementById("gps-result-span").remove();
    }

    var node = document.createElement("span");
    node.id = "gps-result-span";
    var textnode = document.createTextNode("Zemljepisna širina: " + Math.round(latitude * 1000) / 1000 + ". Zemljepisna dolžina: " + Math.round(longitude * 1000) / 1000 + ".");
    node.appendChild(textnode);
    document.getElementById("gps-result").appendChild(node);


    //document.getElementById("gps-result").appendChild("<p>Latitude: " + latitude + " Longitude: " + longitude + "</p>");
}

function errorHandler(err) {
    if (err.code == 1) {
        alert("Dostop je zavrnjen!");
    }
    else if (err.code == 2) {
        alert("Lokacija je nedostopna!");
    }
}

function getGPSLocation() {
    if (navigator.geolocation) {
        var options = { timeout: 10000 };// 10s   //success function
        navigator.geolocation.getCurrentPosition(showLocation, errorHandler, options);
    }

    else {
        alert("Brskalnik ne podpira GPS lokacije!");
    }
}

function initialize() {
    //if (mapShown && ((mapSize == 1 && screen.width <= 480) || (mapSize == 2 && screen.width > 480))) {
    //    return;
    //}
    var mapCanvas = document.getElementById("google-maps");
    var mapOptions = {
        center: new google.maps.LatLng(46.0506628, 14.5025265),
        zoom: 13
    }
    map = new google.maps.Map(mapCanvas, mapOptions);
}

function newLocation(newLat, newLng) {
    // the next line is required to work around a bug in WebKit (Chrome / Safari)
    location.href = "#";
    location.href = "#google-maps";
 
    map.panTo(new google.maps.LatLng(newLat, newLng));
    setTimeout("map.setZoom(15)", 1000); // Zoom in after 1 sec
}