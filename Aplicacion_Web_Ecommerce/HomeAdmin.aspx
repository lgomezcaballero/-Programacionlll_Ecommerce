<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.HomeAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView runat="server" ID="gvABMArticulos" CssClass="table table-bordered table-responsive table-striped" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField HeaderText="ID" DataField="ID" />
            <asp:ButtonField HeaderText="" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" Text="editar"/>
            <asp:ButtonField HeaderText="" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" Text="editar"/>
            <asp:ButtonField HeaderText="" ControlStyle-CssClass="btn btn-warning" ButtonType="Button" Text="editar"/>
        </Columns>
    </asp:GridView>
</asp:Content>
