<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%if (Session["Carrito"] != null)
        {  %>

    <div id="demo" class="carousel slide" data-bs-ride="carousel">

        <!-- Indicators/dots -->
        <div class="carousel-indicators">
            <button type="button" data-bs-target="#demo" data-bs-slide-to="0" class="active"></button>
            <button type="button" data-bs-target="#demo" data-bs-slide-to="1"></button>
            <button type="button" data-bs-target="#demo" data-bs-slide-to="2"></button>
        </div>

        <!-- The slideshow/carousel -->
        <div class="carousel-inner">
            <div class="carousel-item active">
                <img src="../img/carousel1.png" alt="Los Angeles" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../img/carousel2.png" alt="Los Angeles" class="d-block w-100">
            </div>
            <div class="carousel-item">
                <img src="../img/carousel3.png" alt="Los Angeles" class="d-block w-100">
            </div>
        </div>

        <!-- Left and right controls/icons -->
        <button class="carousel-control-prev" type="button" data-bs-target="#demo" data-bs-slide="prev">
            <span class="carousel-control-prev-icon"></span>
        </button>
        <button class="carousel-control-next" type="button" data-bs-target="#demo" data-bs-slide="next">
            <span class="carousel-control-next-icon"></span>
        </button>
    </div>

    <div class="m-3 row">
        <hr />
    </div>

    <div class="row" style="padding-left:10%; padding-right:10%;">
        <div class="col">
            <div class="border-0 card col">
                <img src="../img/home_1.jpg" class="card-img-top" />
            </div>
        </div>
        <div class="col">
            <div class="row">
                <div class="border-0 card col">
                    <img src="../img/home_2.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
                <div class="border-0 card col">
                    <img src="../img/home_3.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_4.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_5.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                    </div>
                </div>
            </div>
        </div>
    </div>



    <div class="m-3 row">
        <hr />
    </div>

    <div class="row" style="padding-left:10%; padding-right:10%;">
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_6.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_7.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_8.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_9.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
    </div>

        <div class="m-3 row">
        <hr />
    </div>

    <div class="row" style="padding-left:10%; padding-right:10%;">
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_6.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_7.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_8.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
        <div class="col">
            <div class="border-0 card col" style="margin-top: 1rem;">
                <img src="../img/home_9.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <p class="card-text">Some quick example text to build on the card title and make up the bulk of the card's content.</p>
                </div>
            </div>
        </div>
    </div>

    <%} %>


    <%//Esto lo puse aca para probar la ventana de editar/eliminar y agregar articulo %>
    <% //Response.Redirect("HomeAdmin.aspx", false); %>

    <%// Response.Redirect("ABMPais.aspx", false); %>
</asp:Content>
