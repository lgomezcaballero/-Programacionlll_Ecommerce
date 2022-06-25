<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <!DOCTYPE html>
<html lang="en">
<head>
<meta charset="utf-8">
<meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
<title>Bootstrap Simple Data Table</title>
<link rel="stylesheet" href="https://fonts.googleapis.com/css?family=Roboto">
<link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/css/bootstrap.min.css">
<link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons">
<link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.7.0/css/font-awesome.min.css">
<script src="https://code.jquery.com/jquery-3.5.1.min.js"></script>
<script src="https://cdn.jsdelivr.net/npm/popper.js@1.16.0/dist/umd/popper.min.js"></script>
<script src="https://stackpath.bootstrapcdn.com/bootstrap/4.5.0/js/bootstrap.min.js"></script>
<style>
body {
    color: #566787;
    background: #f5f5f5;
    font-family: 'Roboto', sans-serif;
}
.table-responsive {
    margin: 30px 0;
}
.table-wrapper {
    min-width: 1000px;
    background: #fff;
    padding: 20px;
    box-shadow: 0 1px 1px rgba(0,0,0,.05);
}
.table-title {
    padding-bottom: 10px;
    margin: 0 0 10px;
    min-width: 100%;
}
.table-title h2 {
    margin: 8px 0 0;
    font-size: 22px;
}
.search-box {
    position: relative;        
    float: right;
}
.search-box input {
    height: 34px;
    border-radius: 20px;
    padding-left: 35px;
    border-color: #ddd;
    box-shadow: none;
}
.search-box input:focus {
    border-color: #3FBAE4;
}
.search-box i {
    color: #a0a5b1;
    position: absolute;
    font-size: 19px;
    top: 8px;
    left: 10px;
}
table.table tr th, table.table tr td {
    border-color: #e9e9e9;
}
table.table-striped tbody tr:nth-of-type(odd) {
    background-color: #fcfcfc;
}
table.table-striped.table-hover tbody tr:hover {
    background: #f5f5f5;
}
table.table th i {
    font-size: 13px;
    margin: 0 5px;
    cursor: pointer;
}
table.table td:last-child {
    width: 130px;
}
table.table td a {
    color: #a0a5b1;
    display: inline-block;
    margin: 0 5px;
}
table.table td a.view {
    color: #03A9F4;
}
table.table td a.edit {
    color: #FFC107;
}
table.table td a.delete {
    color: #E34724;
}
table.table td i {
    font-size: 19px;
}    
.pagination {
    float: right;
    margin: 0 0 5px;
}
.pagination li a {
    border: none;
    font-size: 95%;
    width: 30px;
    height: 30px;
    color: #999;
    margin: 0 2px;
    line-height: 30px;
    border-radius: 30px !important;
    text-align: center;
    padding: 0;
}
.pagination li a:hover {
    color: #666;
}	
.pagination li.active a {
    background: #03A9F4;
}
.pagination li.active a:hover {        
    background: #0397d6;
}
.pagination li.disabled i {
    color: #ccc;
}
.pagination li i {
    font-size: 16px;
    padding-top: 6px
}
.hint-text {
    float: left;
    margin-top: 6px;
    font-size: 95%;
}    
</style>
<script>
    $(document).ready(function () {
        $('[data-toggle="tooltip"]').tooltip();
    });
</script>
</head>
<body>
<div class="container-xl">
    <div class="table-responsive">
        <div class="table-wrapper">
            <div class="table-title">
                <div class="row">
                    <div class="col-sm-8"><h2>Lista de articulos</h2></div>
                    <div class="col-sm-4">
                        <div class="search-box">

                            <i class="material-icons">&#xE8B6;</i>
                            <input type="text" class="form-control" placeholder="Search&hellip;">
                            <% //<asp:Button type="button" class="btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop" ID="AgregarArticulo" runat="server" OnClick="AgregarArticulo_Click" Text="Agregar un articulo" />%>

                            <%//Esto es el boton con el modal %>

                            <!-- Button trigger modal -->
<button type="button" class="btn btn-primary" data-bs-toggle="modal" data-bs-target="#staticBackdrop">
  Launch static backdrop modal
</button>

<!-- Modal -->
<div class="modal fade" id="staticBackdrop" data-bs-backdrop="static" data-bs-keyboard="false" tabindex="-1" aria-labelledby="staticBackdropLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="staticBackdropLabel">Modal title</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
          <asp:Label ID="LabelIDArticulo" runat="server" Text="IDArticulo"></asp:Label>
          <asp:TextBox ID="TxtIDArticulo" runat="server"></asp:TextBox>
 
          <asp:Table ID="IDMarca" runat="server"></asp:Table>
          <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
          <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
          <asp:Label ID="Label2" runat="server" Text="Nombre de marca"></asp:Label>
          <asp:Table ID="Table1" runat="server"></asp:Table>
          <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
          <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
          <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
          <asp:Table ID="Table2" runat="server"></asp:Table>
          <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
          <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
          <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
          <asp:Table ID="Table3" runat="server"></asp:Table>
          <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
          <asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
          <asp:Label ID="Label8" runat="server" Text="Label"></asp:Label>
          <asp:Table ID="Table4" runat="server"></asp:Table>
          <asp:Label ID="Label9" runat="server" Text="Label"></asp:Label>
          <asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
          <asp:Label ID="Label10" runat="server" Text="Label"></asp:Label>
          <asp:Table ID="Table5" runat="server"></asp:Table>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-secondary" data-bs-dismiss="modal">Close</button>
        <button type="button" class="btn btn-primary">Understood</button>
      </div>
    </div>
  </div>
</div>

                        </div>
                    </div>
                </div>
            </div>
            <table class="table table-striped table-hover table-bordered">
                <thead>
                    <tr>
                        <th>#</th>
                        <th>Nombre <i class="fa fa-sort"></i></th>
                        <th>Descripcion</th>
                        <th>Precio <i class="fa fa-sort"></i></th>
                        <th>Stock</th>
                        <th>Marca <i class="fa fa-sort"></i></th>
                        <th>Actions</th>
                    </tr>
                </thead>
                
                <% foreach (var item in ListaDeArticulos)
                    { %>


                <tbody>
                    <tr>
                        <td>1</td>
                        <td><%: item.Nombre %></td>
                        <td><%: item.Descripcion %></td>
                        <td><%:item.Precio %></td>
                        <td><%: item.Stock %></td>
                        <td><%: item.Marca.Nombre %></td>
                        <td>
                            <%//Botoncitos para eliminar, editar y ver %>
                            <a href="#" class="view" title="View" data-toggle="tooltip"><i class="material-icons">&#xE417;</i></a>
                            <a href="HomeAdmin.aspx?id=<%:item.ID%>" class="edit" title="Edit" data-toggle="tooltip"><i class="material-icons">&#xE254;</i></a>
                            <a href="HomeAdmin.aspx?id=<%:item.ID%>"  class="delete" title="Delete" id="EliminarArticulo" data-toggle="tooltip"><i class="material-icons">&#xE872;</i></a>
                            
                        </td>
                    </tr>
                    </tbody>

                   <% } %>     
                
            </table>
            <div class="clearfix">
                <div class="hint-text">Showing <b>5</b> out of <b>25</b> entries</div>
                <ul class="pagination">
                    <li class="page-item disabled"><a href="#"><i class="fa fa-angle-double-left"></i></a></li>
                    <li class="page-item"><a href="#" class="page-link">1</a></li>
                    <li class="page-item"><a href="#" class="page-link">2</a></li>
                    <li class="page-item active"><a href="#" class="page-link">3</a></li>
                    <li class="page-item"><a href="#" class="page-link">4</a></li>
                    <li class="page-item"><a href="#" class="page-link">5</a></li>
                    <li class="page-item"><a href="#" class="page-link"><i class="fa fa-angle-double-right"></i></a></li>
                </ul>
            </div>
        </div>
    </div>  
</div>   
</body>
</html>




</asp:Content>
