<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <form>
  <div class="mb-3">
      <asp:Label ID="LabelNombreUsuario" runat="server" Text="Label" for="TxtEmail" class="form-label">Usuario</asp:Label>
      <asp:TextBox ID="TxtNombreUsuario" runat="server" class="form-control" ></asp:TextBox>
    <div id="emailHelp" class="form-text"></div>
  </div>

  <div class="mb-3">
    <label for="exampleInputPassword1" class="form-label">Contraseña</label>
      <asp:TextBox ID="TxtContraseña" runat="server" type="password" class="form-control"></asp:TextBox>
  </div>

    <%if(SeLogueo == false)
            { %>
                <div>
                <asp:Label ID="Label1" runat="server" Text="Usuario o contraseña incorrectos, intente nuevamente" ></asp:Label>
                </div>
           <% } %>

  <%--<div class="mb-3 form-check">
    <input type="checkbox" class="form-check-input" id="exampleCheck1">
    <label class="form-check-label" for="exampleCheck1">Check me out</label>
  </div>--%>
  <asp:Button ID="Button1" runat="server" Text="Ingresar" type="submit" OnClick="Button1_Click" class="btn btn-primary" />
  <%--<button type="submit" class="btn btn-primary">Ingresar</button>--%>

  <a href="Registro.aspx">Click aqui para registrarse</a>

    <div>
        <asp:Label ID="LabelDatosIncorrectos" runat="server" Text=""></asp:Label>
    </div>
</form>


</asp:Content>
