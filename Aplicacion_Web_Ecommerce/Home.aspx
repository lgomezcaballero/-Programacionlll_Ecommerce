<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView style="display:none" ID="grillaArticulos" runat="server"></asp:GridView>


              

           

          <div class="row row-cols-1 row-cols-md-5 g-4" style ="margin-left:100px" >
      <% foreach (var item in ListaDeArticulos)
        {%>

  <div class="col">
    <div class="card">
      <img src="" class="card-img-top" alt="...">
      <div class="card-body">
        <h5 class="card-title"><%: item.Nombre %></h5>
        <p class="card-text"><%:item.Descripcion %></p>
      </div>
    </div>
  </div>
        <%} %>
</div>
   


</asp:Content>
