

var ajaxCountLoader = $.ajax();
var mapNetworksData = '';
var userMoved = false;
var ispNames = {};
var geoInfo = '';
var bgLayer;
var stdBgLayer;

var nominatim_map_init = {
    "minZoom": 2,
    "maxZoom": 16,
    "zoom": 2,
    "lat": 20,
    "lon": 0,
    "tile_url": "https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png",
    "tile_attribution": '<span class="copyright">&copy; <a href="https://osm.org/copyright">OpenStreetMap</a> contributors</span>'
};

var nominatim_results = [];
var nominatim_nPerf_tile_url = 'https://app.nperf.com/nr-map-{z}-{x}-{y}.png';

var map = new L.map('map-canvas', {
    attributionControl: (nominatim_map_init.tile_attribution && nominatim_map_init.tile_attribution.length),
    scrollWheelZoom: true, // !L.Browser.touch,
    touchZoom: false,
    minZoom: nominatim_map_init.minZoom,
    maxZoom: nominatim_map_init.maxZoom
});

map.setView([nominatim_map_init.lat, nominatim_map_init.lon], nominatim_map_init.zoom);
