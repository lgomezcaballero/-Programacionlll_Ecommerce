<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMPais.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ABMPais" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">






     <%if (tipo == "a")
        { %>
        
             <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="lblNombrePais" runat="server" Text="NombrePais"></asp:Label>
                <asp:TextBox ID="txtNombrePais" CssClass="form-control" oninput="this.value = this.value.replace(/[^a-zA-Z0]/,'')" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

     <%//Cuando apreto el boton para agregar la pantalla se pone en blanco, ver eso%>

    

       <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="BtnAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="BtnAtras_Click" />
                <asp:Button ID="BtnAgregar" runat="server" onclick="BtnAgregar_Click" Text="Agregar" CssClass="btn btn-primary"/>     
            </div>
        </div>
        
     <%//----------------------------------------------------------------------------------------------- %>

        
        
        <%} %>
    <%else if(tipo=="e") { %>
        
    <div class="form-control">
        <div class="mb-3 row">
            <div class="col-4">
                <asp:Label ID="lblPais" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="txtPais" CssClass="form-control" oninput="this.value = this.value.replace(/[^a-zA-Z0]/,'')" runat="server"></asp:TextBox>
            </div>
        </div>
    </div>

   

        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="ButtonAtras" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="BtnAtras_Click" />
                <asp:Button ID="BtnModificar" runat="server" onclick="BtnModificar_Click" Text="Editar" CssClass="btn btn-primary"/>
            </div>
        </div>
        <%} %>

</asp:Content>
