<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <%if (Session["TeLogueaste"] != null && Session["Admin"]!= null)
         {  %>
    <div class="row">
         <div class="col-4">
        <div class="card bg-primary text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Marcas</div>
                   <%-- <div id="total-productos">40</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarMarcas.aspx">Ver Detalles</a>
                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
            </div>
        </div>
    </div>

    <%////////////////////////////////////////////////////////////////////////////////////////////// %>

       <div class="col-4">
        <div class="card bg-warning text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Categorias</div>
                    <%--<div id="total-marcas">30</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarCategorias.aspx">Ver Detalles</a>
                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
            </div>
        </div>
    </div>
        
    <%/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>



      <div class="col-4">
        <div class="card bg-warning text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Provincias
                    </div>
                    <%--<div id="total-marcas">30</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarProvincia.aspx">Ver Detalles</a>
                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
            </div>
        </div>
    </div>
</div>

    <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>
    <div class="row">
      <div class="col-4">
        <div class="card bg-warning text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Pais</div>
                    <%--<div id="total-marcas">30</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarPaises.aspx">Ver Detalles</a>
                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
            </div>
        </div>
    </div>

      <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>

          <div class="col-4">
        <div class="card bg-warning text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Articulos</div>
                    <%--<div id="total-marcas">30</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarArticulos.aspx">Ver Detalles</a>
                <div class="small text-white"><i class="fas fa-angle-right"></i></div>
            </div>
        </div>
    </div>

     <%////////////////////////////////////////////////////////////////////////////////////////////////////////////////// %>

       <div class="col-4">
        <div class="card bg-primary text-white mb-4">
            <div class="card-body">
                <div class="d-flex justify-content-between">
                    <div>Usuarios</div>
                    <%--<div id="total-productos">40</div>--%>
                </div>
            </div>
            <div class="card-footer d-flex align-items-center justify-content-between">
                <a class="small text-white stretched-link" href="ListarUsuarios.aspx">Ver Detalles</a>
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
