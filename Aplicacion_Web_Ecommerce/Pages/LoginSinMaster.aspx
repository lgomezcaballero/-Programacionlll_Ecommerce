<%@ Page Title="" Language="C#" MasterPageFile="~/LoginMaster.Master" AutoEventWireup="true" CodeBehind="LoginSinMaster.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.LoginSinMaster" %>
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
      <div class="col-12 col-md-8 col-lg-6 col-xl-5">
        <div class="card bg-dark text-white" style="border-radius: 1rem;">
          <div class="card-body p-5 text-center">

            <div class="mb-md-5 mt-md-4 pb-5">

              <h2 class="fw-bold mb-2 text-uppercase">Login</h2>
              <p class="text-white-50 mb-5">Ingrese su usuario y contraseña</p>

              <div class="form-outline form-white mb-4">
              <asp:TextBox ID="TxtNombreUsuario" runat="server" class="form-control"  ></asp:TextBox>
                <label class="form-label" for="typeEmailX">Nombre de usuario</label>
              </div>

              <div class="form-outline form-white mb-4">
                 <asp:TextBox ID="TxtContraseña" type="password"  class="form-control form-control-lg"  runat="server"></asp:TextBox>
                <label class="form-label" for="typePasswordX">Contraseña</label>
              </div>


                <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <div>
                    <asp:Label ID="LabelError" runat="server" Text="" style="color:red"></asp:Label>
                </div>
            </ContentTemplate>
    </asp:UpdatePanel>

                
              <%--<p class="small mb-5 pb-lg-2"><a class="text-white-50" href="#!">¿Olvidaste tu contraseña?</a></p>--%>

    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
            <ContentTemplate>
             <asp:Button ID="Button1" runat="server" class="btn btn-outline-light btn-lg px-5"  Text="Ingresar" type="submit" OnClick="Button1_Click"/>        
            </ContentTemplate>
    </asp:UpdatePanel>


              <div class="d-flex justify-content-center text-center mt-4 pt-1">
                <a href="#!" class="text-white"><i class="fab fa-facebook-f fa-lg"></i></a>
                <a href="#!" class="text-white"><i class="fab fa-twitter fa-lg mx-4 px-2"></i></a>
                <a href="#!" class="text-white"><i class="fab fa-google fa-lg"></i></a>
              </div>

            </div>

            <div>
              <p class="mb-0">¿No tenes cuenta? <a href="Registrarse.aspx" class="text-white-50 fw-bold">Registrarse</a>
              </p>
            </div>

          </div>
        </div>
      </div>
    </div>
  </div>



</section>


</asp:Content>
