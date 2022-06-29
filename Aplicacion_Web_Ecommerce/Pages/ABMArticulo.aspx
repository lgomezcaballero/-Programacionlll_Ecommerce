<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ModificarArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (tipo.Equals("a"))
        { %>
        
        
        
    <asp:Button Text="agregar" runat="server" />
        
        
        
        
        
        <%} %>
    <%else { %>
        
        
    <asp:Button Text="otra cosa" runat="server" />
        
        
        
        
        <%} %>

</asp:Content>
