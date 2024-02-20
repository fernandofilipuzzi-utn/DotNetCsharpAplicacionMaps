<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="VerMapa.aspx.cs" Inherits="MapsAppWeb.VerMapa" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <link rel="stylesheet" href="https://unpkg.com/leaflet@1.9.4/dist/leaflet.css" integrity="sha256-p4NxAoJBhIIN+hmNHrzRCf9tD/miZyoHS5obTRR9BMY=" crossorigin="" />
     <style>
         #map {
             height: 100vh;
             width: 100%;
         }
     </style>
        
    <div class="container">
        <div class="row">
            <div class="col-12">
                <div id="dvContenido"/>
                <button type="button" id="btn1" onclick="btn1AddMarkers_click()">aceptar</button>
                <asp:Button ID="btn2" runat="server" Text="Aceptar"  OnClientClick="return btn2ClientClick();" />
                <asp:Button ID="btn3" runat="server" Text="Aceptar"  OnClientClick="btn3_Click" />
            </div>

            <div class="col-12">
                <div id="map" class="justify-content-center"></div>
            </div>
        </div>
    </div>

    <script src="https://unpkg.com/leaflet@1.9.4/dist/leaflet.js" integrity="sha256-20nQCchB9co0qIjJZRGuk2/Z9VM+kNiyxNV1lvTlZBo=" crossorigin=""></script>

    <script>

        function btn2ClientClick()
        {
            // Ejecuta el código JavaScript del lado del cliente aquí
            btn1AddMarkers_click();
            // Devuelve true para permitir que el evento del lado del servidor continúe o false para detenerlo
            return true;
        }

        const marks = [];

        function btn1AddMarkers_click()
        {
            let prueba = [{ lat: -37.064604, lng: -61.948729, message: 'mark1' },
            { lat: -37.067934, lng: -61.942677, message: 'mark2' },
            { lat: -37.064218, lng: -61.944437, message: 'mark3' }];

            prueba.forEach(function (coord)
            {
               const mark = L.marker(coord).bindPopup(coord.message).addTo(map);
                marks.push(mark);
                //document.getElementById("b").innerHTML = JSON.stringify(coord);               
               document.getElementById("dvContenido").innerHTML = document.getElementById("dvContenido").innerHTML + "<br/>hola"
          });
        }


      //  function btn_click()
     //   {
      //      document.getElementById("dvContenido").innerHTML = document.getElementById("dvContenido").innerHTML + "<br/>hola"
        //}

        function initMap(centro)
        {
            fetch("https://localhost:44349/api/GetMapaCentro").then(function (response)
            {
                if (!response.ok)
                {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            }
            ).then(function (centro)
            {
                map = L.map('map').setView([centro.lat, centro.lng], 11);
                L.tileLayer('https://tile.openstreetmap.org/{z}/{x}/{y}.png',
                    {
                        attribution: '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors'
                    }).addTo(map);
                //
                console.log(centro);
            }
            ).catch(function (error)
            {
                console.error('There was a problem with the fetch operation:', error);
            });
        }

        document.addEventListener('DOMContentLoaded', initMap);
    </script>
</asp:Content>
