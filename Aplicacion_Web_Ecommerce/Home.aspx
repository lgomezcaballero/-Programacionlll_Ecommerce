<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView style="display:none" ID="grillaArticulos" runat="server"></asp:GridView>

      <% foreach (var item in ListaDeArticulos)
        {%>

          <div class="row row-cols-1 row-cols-md-2 g-4">
  <div class="col">
    <div class="card">
      <img src="https://http2.mlstatic.com/D_NQ_NP_797408-MLA31113004338_062019-O.webp" class="card-img-top" alt="...">
      <div class="card-body">
        <h5 class="card-title"><%: item.Nombre %></h5>
        <p class="card-text"><%:item.Descripcion %></p>
      </div>
    </div>
  </div>
</div>
        <%} %>
   


</asp:Content>
