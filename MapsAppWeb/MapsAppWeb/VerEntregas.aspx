<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master"  MaintainScrollPositionOnPostback="true" AutoEventWireup="true" CodeBehind="VerEntregas.aspx.cs" Inherits="MapsAppWeb.VerEntregas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
    <style>
        #map {
            height: 100vh;
            width: 100%;
        }
    </style>

    <div>
        <div id="b"></div>

        <div class="row p-3 justify-content-center">
            <div class="row">
                <button id="btnAddMarkers" type="button" onclick="btnAddMarkers_Click()">Agregar Marcas</button>
                <button id="btnMovMarkers" type="button"  onclick="btnMovMarkers_click()">Mover Marcas</button>
                <button id="btnClearMarkers" type="button"  onclick="btnClearMarkers_click()">Borrar Marcas</button>
                <button id="btnToolTips" type="button"  onclick="btnToolTips_click()">Toolt Tips</button>
                <button id="btnToolTipsRich" type="button"  onclick="btnToolTipsRich_click()">Toolt Tips Rich</button>
                <button id="btnClearAll" type="button"  onclick="btnClearAll_click()">Borrar Todo</button>
            </div>

            <div class="col-12">
                <div id="map" class="justify-content-center"></div>
            </div>

            <div>
                <a href="https://leafletjs.com/examples/quick-start/">referencias</a>
                <a href="https://www.nperf.com/es/map/5g">ejemplo</a>
            </div>
        </div>
    </div>

    <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>

    <script>
       

        
        //  console.log(coord);
        //const newContent = document.createElement('p');
        //  newContent.textContent = JSON.stringify(coord);
        //  document.getElementById("b").appendChild(newContent);

        // #region inicializaciones de constantes
        var options = { enableHighAccuracy: true, maximumAge: 100, timeout: 10000 };
        const LeafIcon = L.Icon.extend(
            {
                options:
                {
                    shadowUrl: 'img/leaf-shadow.png',
                    iconSize: [38, 95],
                    shadowSize: [50, 64],
                    iconAnchor: [22, 94],
                    shadowAnchor: [4, 62],
                    popupAnchor: [-3, -76]
                }
            });
        let map = null;
        const greenIcon = new LeafIcon({ iconUrl: '/img/leaf-green.png' });
        const redIcon = new LeafIcon({ iconUrl: '/img/leaf-red.png' });
        const orangeIcon = new LeafIcon({ iconUrl: '/img/leaf-orange.png' });
     


        function btnMovMarkers_click() {
            marks.forEach(function (mark) {
                mark.setLatLng([-37.064604, -61.948729]);
            });
        }

        function btnClearMarkers_click() {
            marks.forEach(function (mark) {
                map.removeLayer(mark);
            });
        }

        function btnToolTips_click() {
            let prueba = [{ lat: -37.064604, lng: -61.948729 },
            { lat: -37.067934, lng: -61.942677 },
            { lat: -37.064218, lng: -61.944437 }];

            prueba.forEach(function (coord) {
                //console.log(coord);
                //map.panBy(L.point([coord.lat, coord.lng]));
                var tooltip = L.tooltip()
                    .setLatLng([coord.lat, coord.lng])
                    .setContent(`
                Hello world!<br />
                This is a nice tooltip.`)
                    .addTo(map);
            })
        }

        function accion_click() {
            alert('hola!');
        }

        function btnToolTipsRich_click()
        {
            let prueba = [{ lat: -37.064604, lng: -61.948729 },
            { lat: -37.067934, lng: -61.942677 },
            { lat: -37.064218, lng: -61.944437 }];

            prueba.forEach(function (coord) {
                const options = { direction: 'top', permanent: true, interactive: true };
                var tooltip = L.tooltip(options)
                    .setLatLng([coord.lat, coord.lng])
                    .setContent(`
                            <div class="row text-center">
                                <div class="col">
                                    <h3>Título</h3>
                                    <label>Mensaje</label>
                                    <div>
                                        <button type="button" id="btn" class="btn btn-primary"" onclick="accion_click()">button</button>
                                    </div>
                                </div>
                            </div>
                            `)
                    .addTo(map);
            })
        }

        //#endregion

        // #region eventos

        function btnAddMarkers_Click()
        {
            getMarkers();
        }

        // #endregion

        //#region 

        const marks = [];

        function mostrarMarkers(coords)
        {
            coords.forEach(function (coord)
            {
                const mark = L.marker(coord).bindPopup(coord.message).addTo(map);
                marks.push(mark);            
            });
        }
        
        function initMap(centro)
        {
            console.log(JSON.stringify(centro));

            //initMap({ lat: -37.063829, lng: -61.9403603 });
            map = L.map('map').setView([centro.lat, centro.lng], 11);
            L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png',
                {
                    attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                }).addTo(map);
            //
           
        }

        //#endregion

        //#region llamadas a la api web

        function init() {
            fetch("https://localhost:44349/api/GetMapaCentro").then(function (response) {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            }
            ).then(function (centro)
            {
                initMap(centro);
            }
            ).catch(function (error)
            {
                console.log(JSON.stringify(centro));
                console.error('There was a problem with the fetch operation:', error);
            });
        }

        function getMarkers()
        {
            fetch("https://localhost:44349/api/GetMarkers").then(function (response)
            {
                if (!response.ok)
                {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            }
            ).then(function (coords)
            {
                mostrarMarkers(coords);
            }
            ).catch(function (error)
            {
                console.error('There was a problem with the fetch operation:', error);
            });
        }

        //#endregion

        document.addEventListener('DOMContentLoaded', init);

    </script>

</asp:Content>

