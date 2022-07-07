<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="CarritoUsuario.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="HomeAdmin">HomeAdmin</a></li>
        <li class="breadcrumb-item active">Productos</li>
    </ol>

    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table me-1"></i>Listado de Productos
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-sm-12">
                    <a class="btn btn-success" href="ABMArticulo?Type=a">Crear Nuevo</a>
                </div>
            </div>

            <hr />
            <table id="tabla" class="display responsive table table-striped" style="width: 100%">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Marca</th>
                        <th>Categoria</th>  
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in carrito.ArticulosCarrito)
                        { %>
                    <tr>
                        <td>
                            <div>
                                <img src="<%: item.Articulo.Imagenes[0].URLImagen %>" style="width: 15rem;" alt="Alternate Text" />
                            </div>
                        </td>
                        <td>
                            <div class="row"><%: item.Articulo.Marca.Nombre %></div>
                            <div class="row"><%: item.Articulo.Nombre %></div>
                            <div class="row"><%: item.Articulo.ID %></div>
                            <div class="row"><%: item.Articulo.Genero.Nombre %></div>
                            <div class="row">
                                <a href="CarritoUsuario?IDArt=<%: item.Articulo.ID %>&IDT=<%: item.IDTalle %>">Eliminar Articulo</a>
                            </div>
                        </td>
                        <td>
                            <div class="row"><%: item.IDTalle %></div>
                            <div class="row"><%: item.Cantidad %></div>
                        </td>
                        <td>
                            <div class="row">Precio Unitario    <%: item.Articulo.Precio %></div>
                            <hr />
                            <div class="row">Precio Final   <%: (item.Articulo.Precio * item.Cantidad) %></div>
                        </td>
                    </tr>



                    <%} %>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>
