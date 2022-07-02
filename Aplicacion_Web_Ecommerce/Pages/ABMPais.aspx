<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMPais.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ABMPais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">






     <%if (tipo == "a")
        { %>
        
             <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblNombrePais" runat="server" Text="NombrePais"></asp:Label>
                <asp:TextBox ID="txtNombrePais" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

     <%//Cuando apreto el boton para agregar la pantalla se pone en blanco, ver eso%>

    <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" Text="Agregar" />
        
     <%//----------------------------------------------------------------------------------------------- %>

        
        
        <%} %>
    <%else if(tipo=="e") { %>
        
    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblPais" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtPais" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

    <asp:Button ID="BtnModificar" runat="server" onclick="BtnModificar_Click" Text="Editar" />

        <%} %>

</asp:Content>
