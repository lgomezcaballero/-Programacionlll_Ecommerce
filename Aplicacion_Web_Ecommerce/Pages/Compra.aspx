<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Compra.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Compra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
   
    
    <%if (Session["TeLogueaste"] != null)
            {%>

           
    
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
                            <div class="bg-opacity-10 bg-success p-2 rounded row text-dark" style="margin-bottom: 0.5rem;">
                                <div class="col-1">
                                    <asp:RadioButton ID="rdbEnvio" Text="" runat="server" GroupName="Entrega"/>
                                </div>
                                <div class="col">
                                    <p>Envío (a acordar con el vendedor)</p>
                                </div>
                            </div>
                            <div class="bg-opacity-10 bg-success p-2 rounded row text-dark">
                                <div class="col-1">
                                    <asp:RadioButton ID="rdbRetiro" Checked Text="" runat="server" GroupName="Entrega" />
                                </div>
                                <div class="col">
                                    <p>Retirar en la dirección del vendedor</p>                                    
                                    <p>Puede retirar desde el <%: fechaHoy %></p>
                                </div>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div class="bg-opacity-10 bg-success p-2 rounded row text-dark" style="margin-bottom: 0.5rem;">
                                <div class="col-1">
                                    <asp:RadioButton ID="rdbEfectivo" Text="" Checked="true" runat="server" GroupName="FormaPago"/>
                                </div>
                                <div class="col">
                                    <p>Efectivo</p>
                                </div>
                            </div>
                            <div class="bg-opacity-10 bg-success p-2 rounded row text-dark">
                                <div class="col-1">
                                    <asp:RadioButton ID="rdbMP" Text="" runat="server" GroupName="FormaPago" />
                                </div>
                                <div class="col">
                                    <p>Mercado Pago</p>
                                </div>
                            </div>
                        </td>
                    </tr>
                </tbody>
            </table>
            <asp:Button ID="btnCompra" CssClass="btn btn-success" runat="server" Text="Finalizar Compra" 
                data-bs-toggle="modal" data-bs-target="#staticBackdrop" OnClick="btnCompra_Click"/>

<%--            <div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        ...
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Understood</button>
      </div>
    </div>
  </div>
</div>--%>
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
                    <div class="col-4"><%: string.Format("{0:C}", item.Articulo.Precio) %></div>
                    </div>
                    <div class="row"><p>(Talla <%: obtenerTalla(item.IDTalle) %>) x <%: item.Cantidad %></p></div>
                </div>
            </div>
            <%} %>
            <div class="row">
                <div class="col-9"><p>Subtotal</p></div>
                <div class="col-3"><%: string.Format("{0:C}", factura.PrecioTotal) %></div>
            </div>
            <div class="row">
                <div class="col-9"><p>Total</p></div>
                <div class="col-3"><%: string.Format("{0:C}", factura.PrecioTotal) %></div>
            </div>

        </div>
    </div>
     <%}%>
</asp:Content>
