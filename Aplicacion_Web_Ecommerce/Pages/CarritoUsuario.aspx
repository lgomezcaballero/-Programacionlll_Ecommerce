<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="CarritoUsuario.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <asp:GridView ID="GrillaArticulos" runat="server"></asp:GridView>


    
       <%if (Session["TeLogueaste"] != null)
           {%>
     <% foreach (var item in ListaCarrito)
         {%>
            <div id="Articulo" class="card mb-3" style="height: 200px">
  <div class="row g-0">
    <div class="col-md-4">
      <img id="Imagencita" src="<%:item.Imagenes[0].URLImagen %>" class="img-fluid rounded-start" alt="..." style="height: 180px">
    </div>
    <div class="col-md-8">
      <div class="card-body">
        <h5 class="card-title"><%: item.Nombre %></h5>
        <p class="card-text"><%:item.Descripcion %></p>
        <p class="card-title">$<%: item.Precio %> </p>
        <p class="card-text"><small class="text-muted">Last updated 3 mins ago</small></p>

      </div>
    </div>
  </div>
</div>
        <%} %>

         <span >Precio Total: <%:PrecioTotal%></span>
    <%} %>

</asp:Content>
