(function() {
  "use strict";
  let map = null;
  let markers = [];
  let stepMarker = null;
  let features = [];


  $(document).ready(function() {
    map = L.map('map', {
      layers: L.tileLayer('https://cartodb-basemaps-{s}.global.ssl.fastly.net/rastertiles/voyager/{z}/{x}/{y}{r}.png', {
        attribution: '&copy; <a href="http://www.openstreetmap.org/copyright" target="_blank">OSM</a> &copy; <a href="http://cartodb.com/attributions" target="_blank">CartoDB</a>',
      }),
      center: [43.2961743, 5.3699525],
      zoom: 13,
    });

    $('#btnItinerary').click(function() {
      let button = $(this);
      loadingButton(button, false);
      resetItinerary();

      let inputStart = $('#inputStart');
      let inputStartVal = inputStart.val();
      let inputEnd = $('#inputEnd');
      let inputEndVal = inputEnd.val();

      let error = false;
      if (inputStartVal == "") {
        formError(inputStart, "You must enter a starting address");
        error = true;
      } else {
        formError(inputStart, "");
      }

      if (inputEndVal == "") {
        formError(inputEnd, "You must enter an arrival address");
        error = true;
      } else {
        formError(inputEnd, "");
      }

      if (error) return;

      let url = "http://localhost:8733/Design_Time_Addresses/RootingService/Service1/itineraire?origin=" + inputStartVal + "&destination=" + inputEndVal;
	  $.ajax({
          type: "GET",
          url: url,
          error: function() {
              displayError("Server error, please try again later.");
              loadingButton(button, true);
          },
          success: function (data) {
            let result = data.GetItineraryResult;
            if (result.success) {
              $('#itineraryDuration').html(formatDuration(result.duration));
              $('#itineraryDistance').html(formatDistance(result.distance));

              addItineraries(result.itineraries);
            } else {
              displayError(result.errorMsg)
            }
            loadingButton(button, true);
          }
      });
    });
  });

  /*
  * Add itineraries to the leaflet map
  */
  function addItineraries(itineraries) {
    for (let i = 0; i < itineraries.length; i++) {
      let coordinates = itineraries[i].paths[0].points.coordinates;
      let steps = itineraries[i].paths[0].steps;
      let stepList = $('#itinerarySteps');
      let color = "#ff7800";

      if (i == 0) {
        map.flyTo([coordinates[0][1], coordinates[0][0]], 15);
        addMarker(coordinates[0][0], coordinates[0][1], "start", "Starting position");
      }

      if (i == 1) {
        stepList.append(buildStep("Take a bike", coordinates[0]));
        addMarker(coordinates[0][0], coordinates[0][1], "station-start", "Take a bike");
        addMarker(coordinates[coordinates.length-1][0], coordinates[coordinates.length-1][1], "station-end", "Leave your bike here");
        color = "#5d86ec";
      }

      if (i == itineraries.length-1) {
        if (itineraries.length > 1) stepList.append(buildStep("Leave your bike", coordinates[0]));
        addMarker(coordinates[coordinates.length-1][0], coordinates[coordinates.length-1][1], "end", "Arrival");
      }

      for (let j = 0; j < steps.length; j++) {
        stepList.append(buildStep(steps[j].instruction, coordinates[steps[j].way_points[1]]));
      }

      features.push(L.geoJSON(itineraries[i].featureCollection, {color: color}).addTo(map));
    }
  }

  /*
  * Reset itinerary
  */
  function resetItinerary() {
    $('#itineraryDuration').empty();
    $('#itineraryDistance').empty();
    $('#itinerarySteps').empty();
    if (markers.length > 0) {
        markers.forEach((marker) => {
            marker.removeFrom(map);
        });
    }
    if (features.length > 0) {
        features.forEach((line) => {
            line.removeFrom(map);
        });
    }
    markers = [];
    features = [];
  }

  /*
  * Build html itinerary step
  */
  function buildStep(instruction, coordinate) {
    let res = $("<button class='list-group-item list-group-item-action flex-column align-items-start'>"
      + "<p class='mb-0'>" + instruction + "</p>"
      + "</button>"
    );
    res.click(function() {
      map.flyTo([coordinate[1], coordinate[0]], 18);
      if (stepMarker) {
        stepMarker.removeFrom(map);
      }
      stepMarker = addMarker(coordinate[0], coordinate[1], "step", instruction)
    });
    return res;
  }

  /*
  * Add a marker to the leaflet map
  */
  function addMarker(latitude, longitude, type, popup) {
    let icon = L.divIcon({
      className: 'custom-div-icon',
      html: "<div class='marker-pin marker-pin-" + type + "'></div><i class='fa'>",
      iconSize: [30, 42],
      iconAnchor: [15, 42]
    });

    let marker = L.marker([longitude, latitude], {icon: icon}).bindPopup(popup).addTo(map)
    markers.push(marker);
    return marker;
  }

  /*
  * Show form error
  */
  function formError(input, msg) {
    input.parent().find('.invalid-feedback').remove();
    if (msg == "") { //no error
      input.removeClass('is-invalid');
    } else { //error
      input.addClass('is-invalid');
      input.after("<div class='invalid-feedback'>" + msg + "</div>");
    }
  }

  /*
  * Enable/Disable a button
  */
  function loadingButton(button, enable) {
    button.prop('disabled', !enable);
    button.html(enable ? "Itinerary" : "<i class='fa fa-refresh fa-spin'></i>");
  }

  /*
  * Display a modal error
  */
  function displayError(msg) {
    let modal = $('#errorModal');
    modal.find('.modal-body').html(msg);
    modal.modal('show');
  }

  /*
  * Format duration
  */
  function formatDuration(duration) {
    var hour = Math.floor(duration / 3600);
    var min = Math.round(duration % 3600 / 60);
    return (hour > 0 ? hour + " h " : "") + min + " min";
  }

  /*
  * Format distance
  */
  function formatDistance(distance) {
    var km = Math.floor(distance / 1000);
    var m = Math.round(distance % 1000);
    return (km > 0 ? km + " km " : "") + m + " m";
  }
})();