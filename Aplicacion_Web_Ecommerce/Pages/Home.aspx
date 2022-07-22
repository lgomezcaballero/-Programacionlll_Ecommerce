<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <style>
        a {
            text-decoration: none;
            color: black;
        }
    </style>


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
                <a href="Busqueda?value=Femenino">
                    <img src="../img/carousel1.png" alt="Los Angeles" class="d-block w-100">
                </a>
            </div>
            <div class="carousel-item">
                <a href="Busqueda.aspx?value=sweater">
                    <img src="../img/carousel2.png" alt="Los Angeles" class="d-block w-100">
                </a>
            </div>
            <div class="carousel-item">
                <a href="Busqueda.aspx?value=blusa">
                    <img src="../img/carousel3.png" alt="Los Angeles" class="d-block w-100">
                </a>
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

    <div class="row" style="padding-left: 10%; padding-right: 10%;">
        <div class="col">
            <div class="border-0 card col">
                <a href="Busqueda.aspx?value=i47">
                    <img src="../img/home_1.jpg" class="card-img-top" />
                </a>
            </div>
        </div>
        <div class="col">
            <div class="row">
                <div class="border-0 card col">
                    <a href="Busqueda.aspx?value=Portsaid">
                        <img src="../img/home_2.jpg" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text">Portsaid</p>
                            <p class="card-text">New Collection AW 22</p>
                        </div>
                    </a>
                </div>
                <div class="border-0 card col">
                    <a href="Busqueda.aspx?value=LadyStork">
                        <img src="../img/home_3.jpg" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text">Lady Stork Winter 22</p>
                            <p class="card-text">Collection</p>
                        </div>
                    </a>
                </div>
            </div>
            <div class="row">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <a href="Busqueda.aspx?value=Prune">
                        <img src="../img/home_4.jpg" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text">Elegí Prune</p>
                            <p class="card-text">New In</p>
                        </div>
                    </a>
                </div>
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <a href="Busqueda.aspx?value=XL">
                        <img src="../img/home_5.jpg" class="card-img-top" alt="...">
                        <div class="card-body">
                            <p class="card-text">XL: Bolsos, Billeteras y Más</p>
                            <p class="card-text">New Collection</p>
                        </div>
                    </a>
                </div>
            </div>
        </div>
    </div>



    <div class="m-3 row">
        <hr />
    </div>

    <div class="row" style="padding-left: 10%; padding-right: 10%;">

        <div class="col">
            <a href="Busqueda.aspx?value=levi">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_6.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">People Make Icons-FW22</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=tascani">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_7.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Otoño Invierno '22</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=penguin">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_8.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Perspective: Fall Winter 2022</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=lacoste">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_9.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Urban Spirit F/W 2022</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
    </div>

    <div class="m-3 row">
        <hr />
    </div>

    <div class="row" style="padding-left: 10%; padding-right: 10%;">
        <div class="col">
            <a href="Busqueda.aspx?value=cheeky">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_10.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Zapatillas Infantiles</p>
                        <p class="card-text">Hasta 30% OFF</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=adidas">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_11.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">¡Para todas sus aventuras!</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=wanama">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_12.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">¡Hasta 40% OFF!</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
        <div class="col">
            <a href="Busqueda.aspx?value=cheeky">
                <div class="border-0 card col" style="margin-top: 1rem;">
                    <img src="../img/home_13.jpg" class="card-img-top" alt="...">
                    <div class="card-body">
                        <p class="card-text">Hasta 40% OFF</p>
                        <p class="card-text">Shop Now</p>
                    </div>
                </div>
            </a>
        </div>
    </div>

    <%} %>


    <%//Esto lo puse aca para probar la ventana de editar/eliminar y agregar articulo %>
    <% //Response.Redirect("HomeAdmin.aspx", false); %>

    <%// Response.Redirect("ABMPais.aspx", false); %>
</asp:Content>
