<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ListarProvincia.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ListarProvincia" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

      <ol class="breadcrumb mb-4 mt-4">
        <li class="breadcrumb-item"><a href="HomeAdmin.aspx" style="text-decoration: none;">Inicio</a></li>
        <li class="breadcrumb-item active">Provincias</li>
    </ol>

    <div class="card mb-4">
        <div class="card-header">
            <i class="fas fa-table me-1"></i>Listado de Provincias
        </div>
        <div class="card-body">
            <div class="row">
                <div class="col-sm-12">
                    <a class="btn btn-success" href="ABMProvincia?Type=a">Crear Provincia</a>
                </div>
            </div>

            <hr />
            <table id="tablaProvincia" class="display responsive table table-striped" style="width: 100%">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>NombreProvincia</th>   
                        <th>NombrePais</th>   
                        <%--<th>Stock</th>--%>
                        <th>Acciones</th>
                        <th></th>
                    </tr>
                </thead>
                <tbody>
                    <%foreach (var item in listaProvincias)
                        { %>
                    <tr>
                        <td><%: item.ID %></td>
                        <td><%: item.NombreProvincia %></td>
                        <td><%: item.Pais.NombrePais %></td>

                        <td>
<%--                            <a href="ABMProvincia?ID=<%: item.ID %>&Type=v" class="btn">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-box-arrow-up-right" viewBox="0 0 16 16">
                                    <path fill-rule="evenodd" d="M8.636 3.5a.5.5 0 0 0-.5-.5H1.5A1.5 1.5 0 0 0 0 4.5v10A1.5 1.5 0 0 0 1.5 16h10a1.5 1.5 0 0 0 1.5-1.5V7.864a.5.5 0 0 0-1 0V14.5a.5.5 0 0 1-.5.5h-10a.5.5 0 0 1-.5-.5v-10a.5.5 0 0 1 .5-.5h6.636a.5.5 0 0 0 .5-.5z" />
                                    <path fill-rule="evenodd" d="M16 .5a.5.5 0 0 0-.5-.5h-5a.5.5 0 0 0 0 1h3.793L6.146 9.146a.5.5 0 1 0 .708.708L15 1.707V5.5a.5.5 0 0 0 1 0v-5z" />
                                </svg></a>--%>
                            <a href="ABMProvincia?ID=<%: item.ID %>&Type=e" class="btn">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-pencil-square" viewBox="0 0 16 16">
                                    <path d="M15.502 1.94a.5.5 0 0 1 0 .706L14.459 3.69l-2-2L13.502.646a.5.5 0 0 1 .707 0l1.293 1.293zm-1.75 2.456-2-2L4.939 9.21a.5.5 0 0 0-.121.196l-.805 2.414a.25.25 0 0 0 .316.316l2.414-.805a.5.5 0 0 0 .196-.12l6.813-6.814z" />
                                    <path fill-rule="evenodd" d="M1 13.5A1.5 1.5 0 0 0 2.5 15h11a1.5 1.5 0 0 0 1.5-1.5v-6a.5.5 0 0 0-1 0v6a.5.5 0 0 1-.5.5h-11a.5.5 0 0 1-.5-.5v-11a.5.5 0 0 1 .5-.5H9a.5.5 0 0 0 0-1H2.5A1.5 1.5 0 0 0 1 2.5v11z" />
                                </svg></a>
                            <a href="ABMProvincia?ID=<%: item.ID %>&Type=d" class="btn">
                                <svg xmlns="http://www.w3.org/2000/svg" width="16" height="16" fill="currentColor" class="bi bi-trash-fill" viewBox="0 0 16 16">
                                    <path d="M2.5 1a1 1 0 0 0-1 1v1a1 1 0 0 0 1 1H3v9a2 2 0 0 0 2 2h6a2 2 0 0 0 2-2V4h.5a1 1 0 0 0 1-1V2a1 1 0 0 0-1-1H10a1 1 0 0 0-1-1H7a1 1 0 0 0-1 1H2.5zm3 4a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 .5-.5zM8 5a.5.5 0 0 1 .5.5v7a.5.5 0 0 1-1 0v-7A.5.5 0 0 1 8 5zm3 .5v7a.5.5 0 0 1-1 0v-7a.5.5 0 0 1 1 0z" />
                                </svg></a>
                        </td>
                    </tr>
                    <%} %>
                </tbody>
            </table>
            <asp:Button ID="btnAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtras_Click"/>
        </div>
    </div>



</asp:Content>
