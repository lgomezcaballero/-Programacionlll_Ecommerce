<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="InformacionDelArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.InformacioDelArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="row row-cols-1 row-cols-md-4 g-4" style="padding-left:10%; padding-right:10%;">

        <a href="InformacionDelArticulo?IDinfoArt=<%: articulo.ID%>">
                <div class="col">
                    <div class="card h-100">
                        <img src="<%: articulo.Imagenes[0].URLImagen %>" class="card-img-top" style="max-width:100%;" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: articulo.Precio %></h5>
                            <p class="card-text"><%: articulo.Marca.Nombre %></p>
                            <p class="card-text"><%: articulo.Nombre %></p>
                        </div>
                    </div>
                </div>

               </a>
    </div>


</asp:Content>
