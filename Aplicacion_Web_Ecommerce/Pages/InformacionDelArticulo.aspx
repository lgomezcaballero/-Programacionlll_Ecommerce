<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="InformacionDelArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.InformacioDelArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    
      <% if (Session["TeLogueaste"] != null)
              {%>
     
    <ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="Home.aspx" style="text-decoration: none;">Inicio</a></li>
        <li class="breadcrumb-item"><a href="Busqueda?value=<%:articulo.Genero.Nombre%>" style="text-decoration: none;"><%: articulo.Genero.Nombre %></a></li>
        <li class="breadcrumb-item"><a href="Busqueda?value=<%:articulo.Categoria.Nombre%>" style="text-decoration: none;"><%: articulo.Categoria.Nombre %></a></li>
        <li class="breadcrumb-item"><a href="Busqueda?value=<%:articulo.Marca.Nombre%>" style="text-decoration: none;"><%: articulo.Marca.Nombre %></a></li>
        <li class="breadcrumb-item active"><%: articulo.Nombre %></li>
    </ol>

    <div class="row">
        <div class="col">
            <img src="<%: articulo.Imagenes[0].URLImagen %>" class="img-fluid" alt="<%: articulo.Nombre %>" />
        </div>
        <div class="col">
            <div class="row"><p><%: articulo.Marca.Nombre %></p></div>
            <div class="row"><p><%: articulo.Nombre %></p></div>
            <div class="row"><p><%: articulo.Precio%></p></div>
            <div class="row"><p>Talles</p></div>
            <%if (ddlTalles.Items.Count > 0) { %>
                <div class="col-4 row">
                    <asp:DropDownList CssClass="form-select mb-3" ID="ddlTalles" runat="server"></asp:DropDownList>
                </div>
                
                <%} %>

            <%if (Session["Admin"] != null)
                {%>
            <asp:Button ID="button1" Visible="false" CssClass="btn btn-primary" runat="server" Text="Agregar al carrito" OnClick="btnComprar_Click" />
            <% }%>


            <%else
                {%>
            <%if (ddlTalles.Items.Count > 0)
                { %>
            <asp:Button ID="btnComprar" CssClass="btn btn-primary" runat="server" Text="Agregar al carrito" OnClick="btnComprar_Click" />
            <%} %>
            <%else
            { %>
            <asp:Label Text="Sin Stock" Style="color: red;" runat="server" />
            <%}%>
            <%--<asp:Label ID="lblAgregado" Text="Artículo agregado al carrito" Visible="false" runat="server" />--%>
            <% } %>
        </div>
    </div>
    <div class="row col-6">
        <h4>Descripción</h4>
        <p><%: articulo.Descripcion %></p>

    </div>

    <% }%>

</asp:Content>
