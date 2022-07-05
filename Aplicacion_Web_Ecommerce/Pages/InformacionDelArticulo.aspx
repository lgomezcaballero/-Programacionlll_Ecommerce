<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="InformacionDelArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.InformacioDelArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
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
<div class="btn-group">
  <button type="button" class="btn btn-secondary dropdown-toggle" data-bs-toggle="dropdown" data-bs-display="static" aria-expanded="false">
    Left-aligned but right aligned when large screen
  </button>
  <ul class="dropdown-menu dropdown-menu-lg-end">
    <li><button class="dropdown-item" type="button">Action</button></li>
    <li><button class="dropdown-item" type="button">Another action</button></li>
    <li><button class="dropdown-item" type="button">Something else here</button></li>
  </ul>
</div>
            </div>
        </div>
    </div>

</asp:Content>
