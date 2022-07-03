<%@ Page Title="" Language="C#" MasterPageFile="~/Ecommerce.Master" AutoEventWireup="true" CodeBehind="ABMArticulo.aspx.cs" Inherits="Aplicacion_Web_Ecommerce.Pages.ModificarArticulo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <%if (tipo == "a")
        { %>
    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="a_lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="a_txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="a_lblMarcas" runat="server" Text="Marcas"></asp:Label>
                <asp:DropDownList ID="a_ddlMarcas" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:Label ID="a_lblCategorias" runat="server" Text="Categorias"></asp:Label>
                <asp:DropDownList ID="a_ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:Label ID="a_lblGeneros" runat="server" Text="Generos"></asp:Label>
                <asp:DropDownList ID="a_ddlGeneros" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="a_lblPrecio" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="a_txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="a_lblUrlImagen" runat="server" Text="URL de Imagen"></asp:Label>
                <asp:TextBox ID="a_txtUrlImagen" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="a_lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="a_txtDescripcion" TextMode="MultiLine" CssClass="form-control" Rows="3" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="a_lblTalles" runat="server" Text="Talles"></asp:Label>
            </div>
        </div>

        <div class="mb-3 row">
            <table class="table table-borderless table-responsive">
                <tr>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaXS" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaXS">XS</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaS" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaS">S</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaM" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaM">M</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaL">L</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaXL">XL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaXXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaXXL">XXL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTallaXXXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTallaXXXL">XXXL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla30" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla30">30</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla31" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla31">31</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla32" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla32">32</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla33" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla33">33</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla34" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla34">34</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla35" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla35">35</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla36" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla36">36</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla37" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla37">37</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla38" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla38">38</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla39" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla39">39</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla40" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla40">40</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla41" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla41">41</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla42" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla42">42</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla43" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla43">43</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla44" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla44">44</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla45" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla45">45</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="a_txtStockTalla46" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="a_txtStockTalla46">46</label>
                        </div>
                    </td>
                </tr>
            </table>


        </div>
        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="a_btnAtrás" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="a_btnAtrás_Click" />
                <asp:Button ID="a_btnCrear" CssClass="btn btn-primary" runat="server" Text="Crear Articulo" OnClick="a_btnCrear_Click" />
            </div>
        </div>
    </div>
        
        <%} %>
    <%else if(tipo=="e") { %>

    <div class="form-control">
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="e_lblNombre" runat="server" Text="Nombre"></asp:Label>
                <asp:TextBox ID="e_txtNombre" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="e_lblMarca" runat="server" Text="Marcas"></asp:Label>
                <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:Label ID="e_lblCategoria" runat="server" Text="Categorias"></asp:Label>
                <asp:DropDownList ID="ddlCategorias" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>
            <div class="col">
                <asp:Label ID="e_lblGenero" runat="server" Text="Generos"></asp:Label>
                <asp:DropDownList ID="ddlGeneros" CssClass="form-select" runat="server"></asp:DropDownList>
            </div>

        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="e_lblPrecio" runat="server" Text="Precio"></asp:Label>
                <asp:TextBox ID="e_txtPrecio" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
            <div class="col">
                <asp:Label ID="e_lblurlImagen" runat="server" Text="URL de Imagen"></asp:Label>
                <asp:TextBox ID="e_txtURLImagen" CssClass="form-control" runat="server"></asp:TextBox>
            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="e_lblDescripcion" runat="server" Text="Descripcion"></asp:Label>
                <asp:TextBox ID="e_txtDescripcion" TextMode="MultiLine" CssClass="form-control" Rows="3" runat="server"></asp:TextBox>

            </div>
        </div>
        <div class="mb-3 row">
            <div class="col">
                <asp:Label ID="lblTalles" runat="server" Text="Talles"></asp:Label>
            </div>
        </div>

        <div class="mb-3 row">
            <table class="table table-borderless table-responsive">
                <tr>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaXS" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaXS">XS</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaS" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaS">S</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaM" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaM">M</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaL">L</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaXL">XL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaXXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaXXL">XXL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTallaXXXL" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTallaXXXL">XXXL</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla30" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla30">30</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla31" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla31">31</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla32" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla32">32</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla33" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla33">33</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla34" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla34">34</label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla35" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla35">35</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla36" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla36">36</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla37" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla37">37</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla38" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla38">38</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla39" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla39">39</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla40" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla40">40</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla41" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla41">41</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla42" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla42">42</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla43" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla43">43</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla44" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla44">44</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla45" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla45">45</label>
                        </div>
                    </td>
                    <td>
                        <div class="form-floating mb-3">
                            <asp:TextBox ID="e_txtStockTalla46" CssClass="form-control" runat="server"></asp:TextBox>
                            <label for="e_txtStockTalla46">46</label>
                        </div>
                    </td>
                </tr>
            </table>


        </div>
        <div class="mb-3 row">
            <div class="d-grid gap-2 d-md-block">
                <asp:Button ID="btnAtrás" CssClass="btn btn-primary" runat="server" Text="Atrás" OnClick="btnAtrás_Click" />
                <asp:Button ID="btnEditar" CssClass="btn btn-primary" runat="server" Text="Editar Articulo" OnClick="btnEditar_Click" />
            </div>
        </div>
    </div>
        
        
        
        
        <%} %>

</asp:Content>
