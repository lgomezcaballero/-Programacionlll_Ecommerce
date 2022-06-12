<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView style="display:none" ID="grillaArticulos" runat="server"></asp:GridView>

      <% foreach (var item in ListaDeArticulos)
        {%>

            <div>
                <%--<img src="<%: item.ImagenUrl %>" alt="Alternate Text" />--%>
                <p><%: item.Nombre %></p>
                <p><%: item.Imagen %></p>
                <p><%: item.Descripcion %></p>
                



                <% //string pupi = item.ID.ToString(); %>

            </div>
        <%} %>
   


</asp:Content>
