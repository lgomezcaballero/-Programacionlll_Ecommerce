<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <%if (Session["TeLogueaste"] != null && Session["Admin"]!= null)
         {  %>
    <div class="row">
        <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div><b>Resumen de Ventas</b></div>
                    <%-- <div id="total-productos">40</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <table class="table">
                    <tr>
                        <th scope="col">Cantidad de Ventas</th>
                        <th scope="col">Total Recaudado</th>
                        <th scope="col">Articulo más vendido</th>
                        <th scope="col">Forma de Pago mas solicitada</th>
                    </tr>
                    <tr>
                        <td><%: cantidadVentas %></td>
                        <td><%: string.Format("{0:C}",recaudado)%></td>
                        <td><%: articulo %></td>
                        <td><%: FormaPago %></td>
                    </tr>
                </table>
            </div>
        </div>
    </div>

     <%////////////////////////////////////////////////////////////////////////////////////////////// %>

    <div class="row">
        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Marcas</b></div>
                        <div><b><%: listademarcas.Count %></b></div>
                        <%-- <div id="total-productos">40</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarMarcas.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>

        <%////////////////////////////////////////////////////////////////////////////////////////////// %>

        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Categorias</b></div>
                        <div><b><%: listacategoria.Count %></b></div>
                        <%--<div id="total-marcas">30</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarCategorias.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>

        <%/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>



        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Provincias</b></div>
                        <div><b><%: listaProvincias.Count %></b></div>
                        <%--<div id="total-marcas">30</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarProvincia.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
    </div>

    <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>
    <div class="row">
        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Pais</b></div>
                        <div><b><%: listaPaises.Count %></b></div>
                        <%--<div id="total-marcas">30</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarPaises.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>

        <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>

        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Articulos</b></div>
                        <div><b><%: listaArticulos.Count %></b></div>
                        <%--<div id="total-marcas">30</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarArticulos.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>

        <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>

        <div class="col-4">
            <div class="card mb-4" style="background: linear-gradient(90deg, rgba(170,170,170,1) 0%, rgba(170,170,170,1) 100%);">
                <div class="card-body">
                    <div class="d-flex justify-content-between">
                        <div><b>Usuarios</b></div>
                        <div><b><%: listausuarios.Count %></b></div>
                        <%--<div id="total-productos">40</div>--%>
                    </div>
                </div>
                <div class="card-footer d-flex align-items-center justify-content-between">
                    <a class="small stretched-link text-black-50" href="ListarUsuarios.aspx">Ver Detalles</a>
                    <div class="small text-white"><i class="fas fa-angle-right"></i></div>
                </div>
            </div>
        </div>
    </div>

    <%/////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>









    <%////////////////////////////////////////////////////////////////////////////////////////////////// %>

     


     <%////////////////////////////////////////////////////////////////////////////////////////////////// %>


      

     <%////////////////////////////////////////////////////////////////////////////////////////////////// %>



      

     <%////////////////////////////////////////////////////////////////////////////////////////////////// %>

     
 
     <%////////////////////////////////////////////////////////////////////////////////////////////////// %>

   


    <%} %>


</asp:Content>
