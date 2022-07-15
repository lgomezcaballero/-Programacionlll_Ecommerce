<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMMarcas.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ABMMarcas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <%if (tipo == "a")
        { %>
        
        
        
     <%//----------------------------------------------------------------------------------------------- %>

    <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="LabelNombreMarca" runat="server" Text="Nombre de la marca"></asp:Label>
                <asp:TextBox ID="TextBoxNombreMarca" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
   </div>

        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="ButtonAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="ButtonAtras_Click" />
                <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" Text="Agregar" CssClass="btn btn-primary"/>                
            </div>
        </div>


        
        <%} %>
    <%else if(tipo=="e") { %>


        <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="LabelMarca" runat="server" Text="Nombre de la marca"></asp:Label>
                <asp:TextBox ID="TxtNombreMarca" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
   </div>
    

    <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="BtnAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="ButtonAtras_Click" />
                <asp:Button ID="BtnEditar" runat="server" onclick="BtnEditar_Click" Text="Editar" CssClass="btn btn-primary"/>            
            </div>
        </div>
               
        <%} %>



</asp:Content>
