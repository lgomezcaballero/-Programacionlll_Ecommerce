<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

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

    <div class="row">
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








    <div id="Articulo" class="row row-cols-1 row-cols-md-4 g-4">
        <% foreach (var item in ListaDeArticulos)
            {%>
        <div class="col">
            <div class="card">

                <div id="carouselImagenesArticulo<%: item.ID %>" class="carousel slide" data-bs-touch="false" data-bs-interval="false">
                    <div class="carousel-inner">
                        <% bool primero = true;
                            foreach (var x in item.Imagenes)
                            {%>
                        <%if (primero)
                            { %>
                        <div class="carousel-item active">
                            <img src="<%: x.URLImagen %>" class="d-block w-100" alt="https://thumbs.dreamstime.com/b/ninguna-imagen-de-la-u%C3%B1a-del-pulgar-placeholder-para-los-foros-blogs-y-las-p%C3%A1ginas-web-148010362.jpg">
                        </div>
                        <%} %>
                        <%else
                            {%>
                        <div class="carousel-item">
                            <img src="<%: x.URLImagen %>" class="d-block w-100" alt="https://thumbs.dreamstime.com/b/ninguna-imagen-de-la-u%C3%B1a-del-pulgar-placeholder-para-los-foros-blogs-y-las-p%C3%A1ginas-web-148010362.jpg">
                        </div>
                        <%} %>
                        <%primero = false;
                            }%>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselImagenesArticulo<%: item.ID %>" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselImagenesArticulo<%: item.ID %>" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>

                <%--<img src="<%: item.Imagenes[0].URLImagen %>" class="card-img-top" alt="https://thumbs.dreamstime.com/b/ninguna-imagen-de-la-u%C3%B1a-del-pulgar-placeholder-para-los-foros-blogs-y-las-p%C3%A1ginas-web-148010362.jpg">--%>
                <div class="card-body">
                    <h5 class="card-title"><a style="text-decoration: none" href="InformacioDelArticulo.aspx"><%: item.Nombre %></a></h5>
                    <p class="card-text"><%:item.Descripcion %></p>
                    <a class="btn btn-primary" href="Home.aspx?id=<%:item.ID %>">Agregar al carrito</a>
                </div>
            </div>
        </div>
        <%} %>
    </div>

    <%//Esto lo puse aca para probar la ventana de editar/eliminar y agregar articulo %>
    <% //Response.Redirect("HomeAdmin.aspx", false); %>

    <%// Response.Redirect("ABMPais.aspx", false); %>
</asp:Content>
