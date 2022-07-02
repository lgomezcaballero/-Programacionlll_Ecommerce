<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMCategoria.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ABMCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%if (tipo == "a")
        { %>
        
        
        
     <%//----------------------------------------------------------------------------------------------- %>

    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="LabelNombreCategoria" runat="server" Text="Nombre de categoria"></asp:Label>
                <asp:TextBox ID="TextBoxNombreCategoria" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" Text="Aceptar" />
        
        
        
        
        
        
        <%} %>
    <%else if(tipo=="e") { %>


         <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="LabelCategoriaNombre" runat="server" Text="Nombre de categoria"></asp:Label>
                <asp:TextBox ID="TxtCategoriaNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <asp:Button ID="BtnEditar" runat="server" onclick="BtnEditar_Click" Text="Editar" />


               
        <%} %>


</asp:Content>
