
const initMap = () => {
    var map = L.map('leaflet-map').setView([-37.0638296, -61.9403603], 13);

    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
    }).addTo(map);

  
}

document.addEventListener('DOMContentLoaded', () => {
    initMap();
});

const initMap = () => {
	const map = L.map('leaflet-map').setView([-37.0638296, -61.9403603], 12);

	L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
		attribution: '© <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
	}).addTo(map);

	const marker = L.marker([-37.0638296, -61.9403603], { alt: 'Cuidad de Huangulén' }).addTo(map);
	marker.bindPopup('<a class="btn btn-primary" href="http://localhost:7777">click</a>').openPopup();

}

document.addEventListener('DOMContentLoaded', () => {
	initMap();
});