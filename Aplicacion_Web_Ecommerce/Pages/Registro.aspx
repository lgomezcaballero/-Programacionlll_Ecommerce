<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Registro.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.Registro" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

     <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="LabelApellidos" runat="server" Text="Apellidos del usuario"></asp:Label>
                <asp:TextBox ID="TxtApellidos" oninput="this.value = this.value.replace(/[^a-zA-ZáéíóúÁÉÍÓÚñÑ ]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

             <div class="col">
                <asp:Label ID="LabelNombres" runat="server" Text="Nombres"></asp:Label>
                <asp:TextBox ID="TxtNombres" oninput="this.value = this.value.replace(/[^a-zA-ZáéíóúÁÉÍÓÚñÑ ]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
            </div>

            <div class="col">
                <asp:Label ID="LabelDNI" runat="server" Text="DNI"></asp:Label>
                <asp:TextBox ID="TxtDNI" oninput="this.value = this.value.replace(/[^a-zA-Z0-9]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
         <div class="mb-3 row">


              <div class="col">
                <asp:Label ID="LabelNombreUsuario" runat="server" Text="Nombre de usuario"></asp:Label>
                <asp:TextBox ID="TxtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
              </div>


              <div class="col">
                <asp:Label ID="LabelContraseña" runat="server" Text="Contraseña"></asp:Label>
                <asp:TextBox ID="TxtContraseña" type="password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>
            
             <div class="col">
                <asp:Label ID="LabelRepetirContraseña" runat="server"  Text="RepetirContraseña"></asp:Label>
                <asp:TextBox ID="TxtRepetirContraseña" type="password" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

            </div>


          <div class="mb-3 row">

               <div class="col">
                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
              </div>

              <div class="col">
                <asp:Label ID="LabelTelefono"  runat="server" Text="Telefono"></asp:Label>
                <asp:TextBox ID="TxtTelefono" oninput="this.value = this.value.replace(/[^0-9+]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
              </div>  
          </div>

          <div class="mb-3 row">

              <div class="col">
                  <asp:Label ID="LabelPais" runat="server" Text="Pais"></asp:Label>
                  <asp:DropDownList ID="DropDownListPaises" runat="server" AutoPostBack="true"
                      OnSelectedIndexChanged="DropDownListPaises_SelectedIndexChanged"></asp:DropDownList>
              </div>

              <div class="col">
                <asp:Label ID="LabelProvincia" runat="server" Text="Provincia"></asp:Label>
                  <asp:DropDownList ID="DropDownListProvincia" runat="server" AutoPostBack="true" 
                      OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged"></asp:DropDownList>
              </div>

                <div class="col">
               <%-- <asp:Label ID="Label1" runat="server" Text="Provincia"></asp:Label>--%>
                    <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad"></asp:Label>
                  <asp:DropDownList ID="DropDownListLocalidad" runat="server" AutoPostBack="true"></asp:DropDownList>
              </div>
          
         
          </div>
   </div>

    <asp:Button ID="BtnAgregarUsuario" runat="server" Class="btn btn-primary" onclick="BtnAgregarUsuario_Click" Text="Registrarse" />

    <asp:Label ID="LabelErrorCampos" runat="server" Text="" style="color:red"></asp:Label>

</asp:Content>
