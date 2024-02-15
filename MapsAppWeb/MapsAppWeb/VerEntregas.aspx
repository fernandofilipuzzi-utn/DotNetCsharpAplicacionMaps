<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerEntregas.aspx.cs" Inherits="MapsAppWeb.VerEntregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.7.1/dist/leaflet.css" />
    <style>
        #leaflet-map {
            width: 100%;
            height: 600px;
        }
    </style>

    <div class="container">
        <div id="leaflet-map"></div>
    </div>

    <script src="https://unpkg.com/leaflet/dist/leaflet.js"></script>
    <script src="https://unpkg.com/leaflet-pip/leaflet-pip.min.js"></script>
    <script>
        const initMap = () => {
            var map = L.map('leaflet-map').setView([-37.0638296, -61.9403603], 13);

            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
            }).addTo(map);

            var polygon = L.polygon([]).addTo(map);
            var polygonVertices = [];

            map.on('click', function (e) {
                var latlng = e.latlng;
                polygonVertices.push(latlng);
                polygon.setLatLngs(polygonVertices);
            });

            //agregando marcadores
            var marker1 = L.marker([-37.062, -61.925]).addTo(map);
            var marker2 = L.marker([-37.0621, -61.926]).addTo(map)

            //lista de de marcadores
            var markers = [marker1, marker2];
            var markerLayer = L.layerGroup().addTo(map);

            function addMarker(latlng) {
                var marker = L.marker(latlng).addTo(markerLayer);
                markers.push(marker);
            }

            map.on('click', function (e) {
                addMarker(e.latlng);
            });
        }

        document.addEventListener('DOMContentLoaded', () => {
            initMap();
        });

        function checkMarkers() {
            var markersInside = 0;
            var markersOutside = 0;

            markers.forEach(function (marker) {
                var isInside = leafletPip.pointInLayer(marker.getLatLng(), polygon);
                if (isInside) {
                    markersInside++;
                    marker.setIcon(L.icon({ iconUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon.png' }));
                } else {
                    markersOutside++;
                    marker.setIcon(L.icon({ iconUrl: 'https://cdnjs.cloudflare.com/ajax/libs/leaflet/1.7.1/images/marker-icon-red.png' }));
                }
            });

            alert("Markers inside polygon: " + markersInside + "\nMarkers outside polygon: " + markersOutside);
        }
    </script>

</asp:Content>

