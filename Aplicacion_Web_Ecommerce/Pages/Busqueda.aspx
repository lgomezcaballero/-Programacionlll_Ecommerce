<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div id="Articulo" class="row row-cols-1 row-cols-md-4 g-4">
        <% foreach (var item in ListaFiltrada)
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
                    <a class="btn btn-primary" href="Home.aspx?id=<%:item.ID %>"> Agregar al carrito</a>
                </div>
            </div>
        </div>
        <%} %>
    </div>

</asp:Content>
