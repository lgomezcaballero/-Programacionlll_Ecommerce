<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ModificarArticulo" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (tipo == "a")
        { %>
        
        
        
     <%//----------------------------------------------------------------------------------------------- %>

    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="Label1" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="TextBoxNombreArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="LabelNombreMarcaArticulo" runat="server" Text="Marca"></asp:Label>
                <asp:TextBox ID="TextBoxNombreMarcaArticulo" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="Categoria" runat="server" Text="Categoria"></asp:Label>
                <asp:TextBox ID="TextBoxNombreCategoria" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="Label2" runat="server" Text="Genero"></asp:Label>
                <asp:TextBox ID="TextBoxGenero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="Label3" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="TextBoxPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="NombreTalla" runat="server" Text="NombreTalla"></asp:Label>
                <asp:TextBox ID="TextBoxNombreTalla" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="Label4" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="TextBoxDescripcion" TextMode="MultiLine" CssClass="form-control" Rows="3" runat="server"></asp:TextBox>
                
            </div>

        </div>
        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
<%--                <asp:Button ID="btnAtrás" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtrás_Click" />
                <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Agregar Articulo" OnClick="btnEditar_Click"/>--%>
            </div>
        </div>
    </div>


    <asp:Button ID="BtnAceptar" runat="server" OnClick="BtbAgregarArticulo_Click" Text="Aceptar" />
        
        
        
        
        
        
        <%} %>
    <%else if(tipo=="e") { %>
        
    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="lblMarca" runat="server" Text="Marca"></asp:Label>
                <asp:TextBox ID="txtMarca" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria"></asp:Label>
                <asp:TextBox ID="txtCategoria" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblGenero" runat="server" Text="Genero"></asp:Label>
                <asp:TextBox ID="txtGenero" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="lblPrecio" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="txtDescripcion" TextMode="MultiLine" CssClass="form-control" Rows="3" runat="server"></asp:TextBox>
                
            </div>

        </div>
        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="btnAtrás" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtrás_Click" />
                <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Agregar Articulo" OnClick="btnEditar_Click"/>
            </div>
        </div>
    </div>
    
        
        
        
        
        <%} %>

</asp:Content>
