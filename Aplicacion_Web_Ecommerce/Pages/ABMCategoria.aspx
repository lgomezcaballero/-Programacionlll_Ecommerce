<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMCategoria.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ABMCategoria" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <%if (tipo == "a")
        { %>
        
        
        
     <%//----------------------------------------------------------------------------------------------- %>

    <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="LabelNombreCategoria" runat="server" Text="Nombre de categoria"></asp:Label>
                <asp:TextBox ID="TextBoxNombreCategoria" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

        

    </div>


         <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="ButtonAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtrás_Click" />
                <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" Text="Aceptar" CssClass="btn btn-primary"/>
            </div>
        </div>
        
        
        
        
        
        
        <%} %>
    <%else if(tipo=="e") { %>


         <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="LabelCategoriaNombre" runat="server" Text="Nombre de categoria"></asp:Label>
                <asp:TextBox ID="TxtCategoriaNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>

              <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="btnAtrás" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtrás_Click" />
                <asp:Button ID="BtnEditar" runat="server" onclick="BtnEditar_Click" Text="Editar" CssClass="btn btn-primary"/>
            </div>
        </div>

    </div>

    
<%--    <div>
    <a href="ListarCategorias.aspx"> Volver Atras</a>
    </div>--%>


               
        <%} %>


</asp:Content>
