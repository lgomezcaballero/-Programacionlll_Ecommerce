<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="InformacionDelArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.InformacioDelArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    



    <ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="Home.aspx">Home</a></li>
        <li class="breadcrumb-item"><a href="Busqueda.aspx"><%: articulo.Genero.Nombre %></a></li>
        <li class="breadcrumb-item"><a href="Busqueda.aspx"><%: articulo.Categoria.Nombre %></a></li>
        <li class="breadcrumb-item"><a href="Busqueda.aspx"><%: articulo.Marca.Nombre %></a></li>
        <li class="breadcrumb-item active"><a href="Busqueda.aspx"><%: articulo.Nombre %></a></li>
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
            <div class="row">
                <asp:DropDownList CssClass="form-select mb-3" ID="ddlTalles" runat="server"></asp:DropDownList>
            </div>

            <%if(Session["Admin"] != null)
            {%>
                <asp:Button ID="button1" Visible="false" CssClass="btn btn-primary" runat="server" Text="Comprar" onclick="btnComprar_Click"/>
           <% }%>


            <%else
            {%>
            <asp:Button ID="btnComprar"  CssClass="btn btn-primary" runat="server" Text="Comprar" onclick="btnComprar_Click"/>
           <% } %>

        </div>
    </div>

</asp:Content>
