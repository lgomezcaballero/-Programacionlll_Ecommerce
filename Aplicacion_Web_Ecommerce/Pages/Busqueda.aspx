<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Busqueda.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Busqueda" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

       <%//Esto lo hago para validar cuando el usuario quiere ingresar a esta ventana pero no esta logueado %>
    <%if (Session["TeLogueaste"] != null)
        {%>


     <div class="row row-cols-1 row-cols-md-4 g-4" style="padding-left:10%; padding-right:10%;">

        <%foreach (var item in ListaFiltrada)
            {%><a href="InformacionDelArticulo?IDinfoArt=<%: item.ID%>" class="text-black text-decoration-none">
                <div class="col">
                    <div class="card h-100">
                        <img src="<%: item.Imagenes[0].URLImagen %>" class="card-img-top" style="max-width:100%;" alt="...">
                        <div class="card-body">
                            <h5 class="card-title"><%: string.Format("{0:C}", item.Precio) %></h5>
                            <p class="card-text"><b><%: item.Marca.Nombre %></b></p>
                            <p class="card-text"><%: item.Nombre %></p>
                        </div>
<%--                        <div class="card-footer">
                            <small class="text-muted">Last updated 3 mins ago</small>
                        </div>--%>
                    </div>
                </div>

               </a>
            <%} %>
    </div>
    <%} %>

</asp:Content>
