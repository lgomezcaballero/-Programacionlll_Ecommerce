<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row" style="margin-top: 1rem;">
        <div class="col-7">
            <div class="row">
                <h4>Datos de Contacto</h4>
            </div>
            <table class="table w-75">
                <tbody>
                    <tr>
                        <td><p>Nombre y Apellido:</p></td>
                        <td><p><%: usuario.Nombres %>, <%: usuario.Apellidos%></p></td>
                    </tr>
                    <tr>
                        <td><p>Email:</p></td>
                        <td><p><%: usuario.Contacto.Email%></p></td>
                    </tr>
                    <tr>
                        <td><p>Teléfono:</p></td>
                        <td><p><%: usuario.Contacto.Telefono%></p></td>
                    </tr>
                    <tr>
                        <td><p>Código Postal:</p></td>
                        <td><p><%: usuario.Localidad.CodigoPostal%></p></td>
                    </tr>
                    <tr>
                        <td><p>Localidad:</p></td>
                        <td><p><%: usuario.Localidad.NombreLocalidad%></p></td>
                    </tr>
                    <tr>
                        <td><p>Provincia:</p></td>
                        <td><p><%: usuario.Localidad.Provincia.NombreProvincia%></p></td>
                    </tr>
                    <tr>
                        <td><p>Pais:</p></td>
                        <td><p><%: usuario.Localidad.Provincia.Pais.NombrePais%></p></td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <p>Envío (a acordar con el vendedor)</p>
                            <p>Retirar en la dirección del vendedor</p>
                            <p>Puede retirar desde el <%: fechaHoy %></p>
                        </td>
                    </tr>
                </tbody>
            </table>
        </div>
        <div class="col-5 overflow-auto">
            <%foreach (var item in factura.Carrito.ArticulosCarrito)
                {%>
            <div class="row">
                <div class="col-3" >
                    <img src="<%:item.Articulo.Imagenes[0].URLImagen %>" alt="Imagen de artículo" style="width: 100%;"/></div>
                <div class="col-9">
                    <div class ="row">
                    <div class="col-8"><%: item.Articulo.Nombre %></div>
                    <div class="col-4"><%: item.Articulo.Precio %></div>
                    </div>
                    <div class="row"><p>(Talla <%: obtenerTalla(item.IDTalle) %>) x <%: item.Cantidad %></p></div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-9"><p>Subtotal</p></div>
                <div class="col-3"><%: factura.PrecioTotal %></div>
            </div>
            <div class="row">
                <div class="col-9"><p>Total</p></div>
                <div class="col-3"><%: factura.PrecioTotal %></div>
            </div>

        </div>
    </div>
</asp:Content>
