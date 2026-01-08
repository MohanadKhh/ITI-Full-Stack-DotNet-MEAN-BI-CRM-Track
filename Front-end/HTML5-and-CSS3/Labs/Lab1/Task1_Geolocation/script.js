  if (!navigator.geolocation) {
    alert("Geolocation is not supported");
  } else {
    navigator.geolocation.getCurrentPosition(
      function (position) {
        const lat = position.coords.latitude;
        const lng = position.coords.longitude;

        // Create map
        const map = L.map("map").setView([lat, lng], 15);

        // Add map tiles (OpenStreetMap)
        L.tileLayer("https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png").addTo(map);

        // Marker
        L.marker([lat, lng])
          .addTo(map)
          .bindPopup("You are here 📍")
          .openPopup();
      },
      function () {
        alert("Location access denied");
      }
    );
  }