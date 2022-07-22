<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="CarritoUsuario.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <% if (Session["TeLogueaste"] != null)
            { %>
                      

    <ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="Home.aspx">Inicio</a></li>
        <li class="breadcrumb-item active">Productos</li>
    </ol>
    <div class="card mb-4" style="margin-left: 10%; margin-right: 10%;">
            <%if (carrito.ArticulosCarrito.Count > 0)
                { %>
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
                            <div class="row col-10" style="padding-left: 0px;">
                                <div class="col" style="padding-left:0px;">
                                    <a href="CarritoUsuario?updateArt=-1&idA=<%: item.Articulo.ID %>&idT=<%: item.IDTalle %>" class="btn btn-danger" style="max-width:100%; max-height:100%;"><b>-</b>
                                    </a>
                                </div>
                                <div class="col" style="padding-left:0px; padding-right:0px; padding-top: .4rem;">
<%--                                    <!--<%: txtCantidadArtCarrito.Text = item.Cantidad.ToString() %>-->
                                    <asp:TextBox ID="txtCantidadArtCarrito" runat="server" CssClass="form-control" Style="width: 100%;"></asp:TextBox>--%>
                                    <!--<%: lblCantidadArtCarrito.Text = item.Cantidad.ToString() %>-->
                                    <asp:Label ID="lblCantidadArtCarrito" runat="server" />
                                    <%if (Request.QueryString["updateArt"] != null)
                                        { %>
                                    <%if (int.Parse(Request.QueryString["updateArt"]) == -1)
                                        {%>
                                    <!--<%: valor -= item.Articulo.Precio %>-->

                                    <%} %>
                                    <%else
                                    { %>
                                    <!--<%: valor += item.Articulo.Precio * (long.Parse(lblCantidadArtCarrito.Text)) %>-->
                                    <%} %>
                                    <!--<%: aux = valor.ToString() %>-->

                                    <%}%>
                                </div>
                                <div class="col" style="padding-left:0px;">
                                    <a href="CarritoUsuario?updateArt=1&idA=<%: item.Articulo.ID %>&idT=<%: item.IDTalle %>" class="btn btn-success" style="max-width:100%; max-height:100%;"><b>+</b></a>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col" style="padding-left: 0px;">
                                    <p>(<%:obtenerStock(item.Articulo.ID, item.IDTalle)-int.Parse(lblCantidadArtCarrito.Text) %> disponibles)</p>
                                </div>
                            </div>
                        </td>
                        <td>
                            <div class="row">
                                <div class="col">
                                    <p>Precio Unitario</p>
                                </div>
                                <div class="col">
                                    <p><%: aux = string.Format("{0:C}", item.Articulo.Precio) %></p>
                                </div>
                            </div>
                            <hr />
                            <div class="row">
                                <div class="col">
                                    <p>Precio Final</p>
                                </div>
                                <div class="col">
                                    <p><%: aux = string.Format("{0:C}", (item.Articulo.Precio * item.Cantidad)) %></p>
                                </div>
                                <!--<%: PrecioTotal += item.Articulo.Precio * item.Cantidad %>-->
                            </div>
                        </td>
                    </tr>


                    <%} %>
                </tbody>
            </table>
        </div>

        <div class="card mb-4" style="margin-left: 10%; margin-right: 10%;">
            <div class="row">
                <div class="col">
                    <p>Subtotal</p>
                </div>
                <div class="col"><%: aux = string.Format("{0:C}", PrecioTotal)%></div>
                <div class="col">
                    <a href="Compra.aspx" class="btn btn-success">Realizar Compra</a>
                    <%--<asp:Button ID="btnCompra" CssClass="btn btn-success" runat="server" Text="Realizar Compra" OnClick="btnCompra_Click" />--%>
                </div>
            </div>
        </div>
        <%}
            else
            {%>
        <div class="card-body">
            <h6>No existen artículos agregados al carrito.</h6>
        </div>
        <%}%>
    </div>

     <%  }  %>

</asp:Content>
