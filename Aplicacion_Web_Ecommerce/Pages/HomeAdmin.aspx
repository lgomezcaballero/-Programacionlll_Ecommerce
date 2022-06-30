<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <table class="table table-bordered table-responsive">
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>
                <th scope="col">Marca</th>
                <th scope="col">Categoria</th>
                <th scope="col">Genero</th>
                <th scope="col">Precio</th>
                <th scope="col">Acciones</th>
            </tr>
        </thead>
        <tbody>
           <%foreach (var item in listaArticulos) { %>
               <tr>
                   <td><%: item.ID %></td>
                   <td><%: item.Nombre %></td>
                   <td><%: item.Marca.Nombre %></td>
                   <td><%: item.Categoria.Nombre %></td>
                   <td><%: item.Genero %></td>
                   <td><%: item.Precio %></td>
                   <td>
                       <a href="ABMArticulo?ID=<%: item.ID %>&Type=v">Ver</a>
                       <a href="ABMArticulo?ID=<%: item.ID %>&Type=e">Editar</a>
                       <a href="ABMArticulo?ID=<%: item.ID %>&Type=d">Eliminar</a>
                   </td>
               </tr>
               
               
               
               <%} %>

        </tbody>
    </table>
    <a href="ABMArticulo?Type=a">content</a>


    <%//Esto muestra la lista de paises que en la base, esto es temporal, los paises no se tendrian que mostrar en esta pagina %>
    <table class="table table-bordered table-responsive">
        <thead class="table-dark">
            <tr>
                <th scope="col">ID</th>
                <th scope="col">Nombre</th>  
            </tr>
        </thead>
        <tbody>
           <%foreach (var item in listaPaises) { %>
               <tr>
                   <td><%: item.ID %></td>
                   <td><%: item.NombrePais %></td>
                   <td>
                       <a href="ABMPais?ID=<%: item.ID %>&Type=v">Ver</a>
                       <a href="ABMPais?ID=<%: item.ID %>&Type=e">Editar</a>
                       <a href="ABMPais?ID=<%: item.ID %>&Type=d">Eliminar</a>
                   </td>
               </tr>
               
               
               
               <%} %>

        </tbody>
    </table>

    <a href="ABMPais?Type=a">content</a>


     <%//Esto muestra la lista de provincias que hay en la base, esto es temporal, las provincias no se tendrian que mostrar en esta pagina %>

</asp:Content>
