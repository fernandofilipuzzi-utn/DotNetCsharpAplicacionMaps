<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="MapsAppWeb._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="container">

        <div class="row">

            <div class="card col-lg-4 col-md-5 col-sm-6 m-2 p-3">
                <img class="card-img-top img-fluid" src="/img/inicio.jpg"  style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title text-center">
                        <h2>APIs</h2>
                    </div>

                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Ver Documentación - swagger</p>
                    </div>
                    <div class="text-center">
                        <a class="btn btn-primary" target="_blank" href="swagger">Ir</a>
                    </div>
                </div>
            </div>

            <div class="card col-lg-4 col-md-5 col-sm-6 m-2 p-3">
                <img src="/img/elegir_ubicacion.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title"><h2>Ver Mapa 1</h2></div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Forma 1-Probando llamadas a java scritp</p>
                    </div>
                </div>
                <div class="text-center">
                    <a class="btn btn-primary" target="_blank" href="/VerMapa1.aspx">Ir</a>
                </div>
            </div>

            <div class="card col-lg-4 col-md-5 col-sm-6 m-2 p-3">
                <img src="/img/elegir_ubicacion.jpg" class="card-img-top img-fluid" style="height: 200px; object-fit: cover;" />
                <div class="card-body">
                    <div class="card-title"><h2>Ver Mapa 2</h2></div>
                    <div class="card-text" style="max-height: 60px; overflow: hidden;">
                        <p>Forma 2-Probando llamadas a java scritp</p>
                    </div>
                </div>
                <div class="text-center">
                    <a class="btn btn-primary" target="_blank" href="/VerMapa2.aspx">Ir</a>
                </div>
            </div>
        </div>
    </div>

</asp:Content>
