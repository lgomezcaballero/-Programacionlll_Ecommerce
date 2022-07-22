<%@ Page Title="" Language="C#" MasterPageFile="~/RegistroMaster.Master" AutoEventWireup="true" CodeBehind="Registrarse.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.Registrarse" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>

     <style>
    body {background-color: black;} 
</style>

    <section class="vh-100 gradient-custom">
  <div class="container py-5 h-100">
    <div class="row d-flex justify-content-center align-items-center h-100">
      <div class="col-12 col-md-8 col-lg-6 col-xl-5" style="width:50rem">
        <div class="card bg-dark text-white" style="border-radius: 1rem;">
          <div class="card-body p-5 text-center">

            <div class="mb-md-5 mt-md-4 pb-5">

              <h2 class="fw-bold mb-2 text-uppercase">Registrarse</h2>
              <p class="text-white-50 mb-5">Ingrese sus datos para registrarse</p>

              <div class="form-outline form-white mb-4">
               <asp:TextBox ID="TxtNombres" oninput="this.value = this.value.replace(/[^a-zA-ZáéíóúÁÉÍÓÚñÑ ]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label" for="typeEmailX">Nombres</label>
              </div>

              <div class="form-outline form-white mb-4">
                 <asp:TextBox ID="TxtApellidos" oninput="this.value = this.value.replace(/[^a-zA-ZáéíóúÁÉÍÓÚñÑ ]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label">Apellidos</label>
              </div>

              <div class="form-outline form-white mb-4">
                   <asp:TextBox ID="TxtDNI" oninput="this.value = this.value.replace(/[^a-zA-Z0-9]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label">Dni</label>
              </div>

               <div class="form-outline form-white mb-4">
                   <asp:TextBox ID="TxtNombreUsuario" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label">Nombre de usuario</label>
              </div>

              <div class="form-outline form-white mb-4">
                <asp:TextBox ID="TxtContraseña" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label">Contraseña</label>
              </div>

              <div class="form-outline form-white mb-4">
                <asp:TextBox ID="TxtRepetirContraseña" type="password" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="LabelRepetirContraseña" runat="server"  Text="RepetirContraseña"></asp:Label>
              </div>

              <div class="form-outline form-white mb-4">
                <asp:TextBox ID="TxtEmail" CssClass="form-control" runat="server"></asp:TextBox>
                <asp:Label ID="LabelEmail" runat="server" Text="Email"></asp:Label>
              </div>

              <div class="form-outline form-white mb-4">      
                <asp:TextBox ID="TxtTelefono" oninput="this.value = this.value.replace(/[^0-9+]/,'')" CssClass="form-control" runat="server"></asp:TextBox>
                <label class="form-label">Telefono</label>
             </div>

        <asp:UpdatePanel ID="UpdatePanel3" runat="server">
            <ContentTemplate>
             <div class="mb-3 row">
                  <div class="col">
                      <asp:Label ID="LabelPais" runat="server" Text="Pais"></asp:Label>
                      <asp:DropDownList ID="DropDownListPaises" CssClass="form-select" runat="server" AutoPostBack="true"
                          OnSelectedIndexChanged="DropDownListPaises_SelectedIndexChanged"></asp:DropDownList>
                  </div>

                  <div class="col">
                    <asp:Label ID="LabelProvincia" runat="server" Text="Provincia"></asp:Label>
                      <asp:DropDownList ID="DropDownListProvincia" CssClass="form-select" runat="server" AutoPostBack="true" 
                          OnSelectedIndexChanged="DropDownListProvincia_SelectedIndexChanged"></asp:DropDownList>
                  </div>

                    <div class="col">
                   <%-- <asp:Label ID="Label1" runat="server" Text="Provincia"></asp:Label>--%>
                        <asp:Label ID="LabelLocalidad" runat="server" Text="Localidad"></asp:Label>
                      <asp:DropDownList ID="DropDownListLocalidad" CssClass="form-select" runat="server" AutoPostBack="true"></asp:DropDownList>
                  </div>
              </div>  
            </ContentTemplate>
        </asp:UpdatePanel>
         


                <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                  <ContentTemplate>
                    <div>
                      <asp:Button ID="BtnAgregarUsuario" runat="server" class="btn btn-outline-light btn-lg px-5" onclick="BtnAgregarUsuario_Click" Text="Registrarse" type="submit"/>        
                    </div>         
                  </ContentTemplate>         
                </asp:UpdatePanel>

               
                
                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                    <ContentTemplate>
                    <div>
                        <asp:Label ID="LabelErrorCampos" runat="server" Text="" style="color:red"></asp:Label>
                    </div>         
                    </ContentTemplate>         
                </asp:UpdatePanel>
                
              

  <%--  <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
             <asp:Button ID="Button1" runat="server" class="btn btn-outline-light btn-lg px-5"  Text="Ingresar" type="submit" OnClick="Button1_Click"/>        
            </ContentTemplate>
    </asp:UpdatePanel>--%>


      

            </div>

          

          </div>
        </div>
      </div>
    </div>
  </div>



</section>


</asp:Content>
