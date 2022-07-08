<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="CarritoUsuario.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Carrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


<ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="HomeAdmin">HomeAdmin</a></li>
        <li class="breadcrumb-item active">Productos</li>
    </ol>

    <div class="card mb-4" style="margin-left:10%; margin-right:10%;">
        <div class="card-body">
            <div class="border-bottom row">
                <p>Listado de artículos en carrito</p>
            </div>
            <table id="tabla" class="display responsive table table-striped" style="width: 100%">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Nombre</th>
                        <th>Marca</th>
                        <th>Categoria</th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in carrito.ArticulosCarrito)
                        { %>
                    <tr>
                        <td>
                            <div>
                                <img src="<%: item.Articulo.Imagenes[0].URLImagen %>" style="width: 5rem;" alt="Alternate Text" />
                            </div>
                        </td>
                        <td>
                            <div class="row">Marca: <%: item.Articulo.Marca.Nombre %></div>
                            <div class="row">Articulo: <%: item.Articulo.Nombre %></div>
                            <div class="row">Código de articulo: <%: item.Articulo.ID %></div>
                            <div class="row">Género: <%: item.Articulo.Genero.Nombre %></div>
                            <div class="row">
                                <div class="col-6" style="padding-left: 0px;">
                                    <a href="CarritoUsuario?IDArt=<%: item.Articulo.ID %>&IDT=<%: item.IDTalle %>" class="btn btn-outline-danger" style="--bs-btn-padding-y: .25rem; --bs-btn-padding-x: .5rem; --bs-btn-font-size: .75rem;">Eliminar Articulo</a>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="row">Talle: <%: obtenerTalle(item.IDTalle) %></div>
                            <div class="row" style="padding-left: 0px;">Cantidad: </div>
                                <div class="row" style="padding-left: 0px;">
                                    <asp:TextBox ID="txtCantidadArtCarrito" runat="server" CssClass="form-control" style="width: 3rem;"></asp:TextBox>
                                    <!--<%: txtCantidadArtCarrito.Text = item.Cantidad.ToString() %>-->
                                    <!--<%:PrecioTotal+=item.Articulo.Precio*(long.Parse(txtCantidadArtCarrito.Text)) %>-->
                                </div>
                            <div class="row">
                                <div class="col" style="padding-left: 0px;">
                                    <p>(<%:obtenerStock(item.Articulo.ID, item.IDTalle) %> disponibles)</p>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="row"><p><s>Precio Unitario    <%: item.Articulo.Precio %></s></p></div>
                            <hr />
                            <div class="row"><p>Precio Final   <%: (item.Articulo.Precio * item.Cantidad) %></p></div>
                        </td>
                    </tr>


                    <%} %>
                </tbody>
            </table>
        </div>
        <div class="row">
            <div class="col">
                <div class="row">
                    <div class="col">
                        <p>Subtotal</p>
                    </div>
                    <div class="col">$<%: PrecioTotal%></div>
                </div>
            </div>
        </div>
    </div>

    
</asp:Content>
