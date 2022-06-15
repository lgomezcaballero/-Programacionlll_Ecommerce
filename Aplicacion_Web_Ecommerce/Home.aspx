<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="Aplicacion_Web_Ecommerce._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:GridView style="display:none" ID="grillaArticulos" runat="server"></asp:GridView>


<%--            <style>

           #Articulo{
                margin-left: 40px;
                margin-right: 40px;
           }

           </style>--%>

    <div id="Articulo" class="row row-cols-1 row-cols-md-5 g-4">
        <% foreach (var item in ListaDeArticulos)
            {%>

        <div class="col">
            <div class="card">
                <img src="https://thumbs.dreamstime.com/b/ninguna-imagen-de-la-u%C3%B1a-del-pulgar-placeholder-para-los-foros-blogs-y-las-p%C3%A1ginas-web-148010362.jpg" class="card-img-top" alt="...">
                <div class="card-body">
                    <h5 class="card-title"><%: item.Nombre %></h5>
                    <p class="card-text"><%:item.Descripcion %></p>
                </div>
            </div>
        </div>
        <%} %>
    </div>
   


</asp:Content>
