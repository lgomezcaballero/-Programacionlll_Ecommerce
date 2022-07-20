<%@ Page Title="" Language="C#" MasterPageFile="~/ErrorMaster.Master" AutoEventWireup="true" CodeBehind="ErrorAcceso.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ErrorAcceso" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

     <%-- <asp:Label ID="Label1" runat="server" Text=""></asp:Label>--%>

    
  
    <%if(Session["Admin"]!= null)
            {%>
                  <a href="HomeAdmin.aspx" style="text-decoration: none">
                  <h3 class="fw-semibold">Volver al homeadmin</h3>
                  </a>
           <% }%>

    <%      else
            {%>
        <a href="Home.aspx" style="text-decoration: none">
        <h3 class="fw-semibold">Volver al home</h3>
        </a>
            <%} %>
</asp:Content>
