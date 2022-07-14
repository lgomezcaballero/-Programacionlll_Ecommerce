<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="FinalCompra.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.FinalCompra" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row align-items-center justify-content-center">
        <div class="bg-white col-sm-4 text-center">
            <p class="text-center">Su compra ha sido procesada.</p>
            <p class="text-center">¡Su pedido se ha realizado con éxito!</p>
            <p class="text-center">Se ha enviado un mensaje a su correo electrónico para proseguir con la compra.</p>
            <p class="text-center">De esta forma podrá finalizar la misma.</p>
            <p class="text-center">¡Gracias por elegirnos!</p>
            <div class="row"><a href="Home" class="btn btn-success">Continuar</a></div>
        </div>
    </div>
</asp:Content>
