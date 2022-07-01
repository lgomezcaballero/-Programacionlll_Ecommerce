using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Aplicacion_Web_Ecommerce.Pages
{
    public partial class ModificarArticulo : System.Web.UI.Page
    {
        public long id;
        public string tipo;

        protected void Page_Load(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();

            if (!IsPostBack)
            {
                MarcaNegocio mNegocio = new MarcaNegocio();
                ddlMarcas.DataSource = mNegocio.listar();
                ddlMarcas.DataValueField = "ID";
                ddlMarcas.DataTextField = "Nombre";
                ddlMarcas.DataBind();
                CategoriaNegocio cNegocio = new CategoriaNegocio();
                ddlCategorias.DataSource = cNegocio.listar();
                ddlCategorias.DataValueField = "ID";
                ddlCategorias.DataTextField = "Nombre";
                ddlCategorias.DataBind();
                GeneroNegocio gNegocio = new GeneroNegocio();
                ddlGeneros.DataSource = gNegocio.listar();
                ddlGeneros.DataValueField = "ID";
                ddlGeneros.DataTextField = "Nombre";
                ddlGeneros.DataBind();
                Session.Add("listaMarcas", mNegocio.listar());
                Session.Add("listaCategorias", cNegocio.listar());
                Session.Add("listaGeneros", gNegocio.listar());
                if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                {
                    tipo = Request.QueryString["Type"];
                    id = long.Parse(Request.QueryString["ID"]);
                }
                if (Request.QueryString["Type"] == "a")
                    tipo = Request.QueryString["Type"];
                if (tipo == "e")
                {
                    //Con esta funciom obtine el articulo que se busca
                    articulo = obtenerArticulo(id);
                    //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                    setearCamposModificar(articulo);
                }
            }
        }
        protected Articulo obtenerArticulo(long idArticulo)
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux = new Articulo();
            lista = (List<Articulo>)Session["listaArticulos"];

            aux = lista.Find(x => x.ID == idArticulo);

            return aux;
        }

        protected void setearCamposModificar(Articulo articulo)
        {
            e_txtNombre.Text = articulo.Nombre;
            ddlMarcas.SelectedValue = articulo.Marca.ID.ToString();
            ddlCategorias.SelectedValue = articulo.Categoria.ID.ToString();
            ddlGeneros.SelectedValue = articulo.Genero.ID.ToString();
            e_txtPrecio.Text = articulo.Precio.ToString();
            e_txtDescripcion.Text = articulo.Descripcion;
        }
        protected void btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();
            articulo.ID = long.Parse(Request.QueryString["ID"]);
            articulo.Marca = new Marca();
            articulo.Marca.ID = short.Parse(ddlMarcas.SelectedItem.Value);
            articulo.Categoria = new Categoria();
            articulo.Categoria.ID = short.Parse(ddlCategorias.SelectedItem.Value);
            articulo.Genero = new Genero();
            articulo.Genero.ID = byte.Parse(ddlGeneros.SelectedItem.Value);
            articulo.Nombre = e_txtNombre.Text;
            articulo.Descripcion = e_txtDescripcion.Text;
            articulo.Precio = decimal.Parse(e_txtPrecio.Text);

            negocio.modificarArticulo(articulo);
            Response.Redirect("HomeAdmin.aspx");
        }



        protected void BtbAgregarArticulo_Click(object sender, EventArgs e)
        {
            Articulo articulo = new Articulo();
            articulo.Nombre = TextBoxNombreArticulo.Text;
            articulo.Marca = new Marca();
            //Aca capturo el nombre de la marca que se ingresa por teclado
            articulo.Marca.Nombre = (TextBoxNombreMarcaArticulo.Text);
            articulo.Categoria = new Categoria();
            //Aca capturo el nombre de la categoria que se ingresa por teclado
            articulo.Categoria.Nombre = TextBoxNombreCategoria.Text;
            articulo.Genero = new Genero();
            //Aca capturo el nombre del genero que se ingresa por teclado
            articulo.Genero.Nombre = TextBoxGenero.Text;
            articulo.Descripcion = TextBoxDescripcion.Text;
            //articulo.Precio = decimal.Parse(TextBoxPrecio.Text);
            //Esto es temporal, hasta que vea como usar el datos de la textbox
            articulo.Precio = 2;
            articulo.Talla = new List<Talla>();
            List<Talla> lista = new List<Talla>();
            //Todo esto es temporal, lo uso para cargar el articulo
            //Talla talla = new Talla();
            //Esto se lo dejo asi por ahora

            //talla.IDTalla = 1;
            //talla.Nombre = "XS";
            //talla.Stock = 4;
            //lista.Add(talla);



            //Esto esta ok
            Marca marca = new Marca();
            marca = BuscarMarcaPorNombre(articulo.Marca.Nombre);
            //Aca le pongo el id de la marca que encuentra la funcion
            articulo.Marca.ID = marca.ID;

            //Esto esta ok
            Genero genero = new Genero();
            genero = BuscarGeneroPorNombre(articulo.Genero.Nombre);
            //Aca le pongo el id del Genero que encuentra la funcion
            articulo.Genero.ID = genero.ID;


            //Esto esta ok
            Categoria categoria = new Categoria();
            categoria = BuscarCategoriaPorNombre(articulo.Categoria.Nombre);
            //Aca le pongo el id de la categoria que encuentra la funcion
            articulo.Categoria.ID = categoria.ID;


            //Esto lo hice asi de manera temporal
            Talla talla = new Talla();
            talla = BuscarTallaPorNombre(TextBoxNombreTalla.Text);
            lista.Add(talla);



            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            articuloNegocio.agregarArticulo(articulo);
            Response.Redirect("HomeAdmin.aspx", false);



        }

        // Estas funciones son para poder ingresar el nombre de las entidades y no ingresar sis ID

        protected Categoria BuscarCategoriaPorNombre(string NombreCategoria)
        {

            Categoria categoria = new Categoria();
            List<Categoria> lista = new List<Categoria>();
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            lista = categoriaNegocio.listar();

            categoria = lista.Find(c => c.Nombre == NombreCategoria);


            return categoria;
        }


        protected Marca BuscarMarcaPorNombre(string NombreMarca)
        {

            Marca marca = new Marca();
            List<Marca> lista = new List<Marca>();
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            lista = marcaNegocio.listar();

            marca = lista.Find(c => c.Nombre == NombreMarca);


            return marca;
        }


        protected Genero BuscarGeneroPorNombre(string NombreGenero)
        {

            Genero genero = new Genero();
            List<Genero> lista = new List<Genero>();
            GeneroNegocio generoNegocio = new GeneroNegocio();
            lista = generoNegocio.listar();

            genero = lista.Find(c => c.Nombre == NombreGenero);


            return genero;
        }


        protected Talla BuscarTallaPorNombre(string NombreTalla)
        {

            Talla talla = new Talla();
            List<Talla> lista = new List<Talla>();
            TallaNegocio tallaNegocio = new TallaNegocio();
            lista = tallaNegocio.listar();

            talla = lista.Find(c => c.Nombre == NombreTalla);


            return talla;
        }

    }
}