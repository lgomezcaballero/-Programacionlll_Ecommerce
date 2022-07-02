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
        //public List<ArticuloTalla> articuloTallas;

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
                    ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
                    //Con esta funciom obtine el articulo que se busca
                    articulo = obtenerArticulo(id);
                    articulo.Talles = new List<ArticuloTalla>();
                    articulo.Talles = atNegocio.listar(id);
                    Session.Add("tallesArticulo", articulo.Talles);
                    //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                    setearCamposModificar(articulo);
                }

                if(Request.QueryString["Type"] == "d") 
                {
                ArticuloNegocio articuloNegocio = new ArticuloNegocio();    
                articuloNegocio.eliminarArticulo(id);
                Response.Redirect("HomeAdmin.aspx", false);
                
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
            e_txtStockTallaXS.Text = articulo.Talles[0].Stock.ToString();
            e_txtStockTallaS.Text = articulo.Talles[1].Stock.ToString();
            e_txtStockTallaM.Text = articulo.Talles[2].Stock.ToString();
            e_txtStockTallaL.Text = articulo.Talles[3].Stock.ToString();
            e_txtStockTallaXL.Text = articulo.Talles[4].Stock.ToString();
            e_txtStockTallaXXL.Text = articulo.Talles[5].Stock.ToString();
            e_txtStockTallaXXXL.Text = articulo.Talles[6].Stock.ToString();
            e_txtStockTalla30.Text = articulo.Talles[7].Stock.ToString();
            e_txtStockTalla31.Text = articulo.Talles[8].Stock.ToString();
            e_txtStockTalla32.Text = articulo.Talles[9].Stock.ToString();
            e_txtStockTalla33.Text = articulo.Talles[10].Stock.ToString();
            e_txtStockTalla34.Text = articulo.Talles[11].Stock.ToString();
            e_txtStockTalla35.Text = articulo.Talles[12].Stock.ToString();
            e_txtStockTalla36.Text = articulo.Talles[13].Stock.ToString();
            e_txtStockTalla37.Text = articulo.Talles[14].Stock.ToString();
            e_txtStockTalla38.Text = articulo.Talles[15].Stock.ToString();
            e_txtStockTalla39.Text = articulo.Talles[16].Stock.ToString();
            e_txtStockTalla40.Text = articulo.Talles[17].Stock.ToString();
            e_txtStockTalla41.Text = articulo.Talles[18].Stock.ToString();
            e_txtStockTalla42.Text = articulo.Talles[19].Stock.ToString();
            e_txtStockTalla43.Text = articulo.Talles[20].Stock.ToString();
            e_txtStockTalla44.Text = articulo.Talles[21].Stock.ToString();
            e_txtStockTalla45.Text = articulo.Talles[22].Stock.ToString();
            e_txtStockTalla46.Text = articulo.Talles[23].Stock.ToString();

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
            articulo.Talles = new List<ArticuloTalla>();
            articulo.Talles = (List<ArticuloTalla>)Session["tallesArticulo"];
            articulo.Talles[0].Stock = long.Parse(e_txtStockTallaXS.Text);
            articulo.Talles[1].Stock = long.Parse(e_txtStockTallaS.Text);
            articulo.Talles[2].Stock = long.Parse(e_txtStockTallaM.Text);
            articulo.Talles[3].Stock = long.Parse(e_txtStockTallaL.Text);
            articulo.Talles[4].Stock = long.Parse(e_txtStockTallaXL.Text);
            articulo.Talles[5].Stock = long.Parse(e_txtStockTallaXXL.Text);
            articulo.Talles[6].Stock = long.Parse(e_txtStockTallaXXXL.Text);
            articulo.Talles[7].Stock = long.Parse(e_txtStockTalla30.Text);
            articulo.Talles[8].Stock = long.Parse(e_txtStockTalla31.Text);
            articulo.Talles[9].Stock = long.Parse(e_txtStockTalla32.Text);
            articulo.Talles[10].Stock = long.Parse(e_txtStockTalla33.Text);
            articulo.Talles[11].Stock = long.Parse(e_txtStockTalla34.Text);
            articulo.Talles[12].Stock = long.Parse(e_txtStockTalla35.Text);
            articulo.Talles[13].Stock = long.Parse(e_txtStockTalla36.Text);
            articulo.Talles[14].Stock = long.Parse(e_txtStockTalla37.Text);
            articulo.Talles[15].Stock = long.Parse(e_txtStockTalla38.Text);
            articulo.Talles[16].Stock = long.Parse(e_txtStockTalla39.Text);
            articulo.Talles[17].Stock = long.Parse(e_txtStockTalla40.Text);
            articulo.Talles[18].Stock = long.Parse(e_txtStockTalla41.Text);
            articulo.Talles[19].Stock = long.Parse(e_txtStockTalla42.Text);
            articulo.Talles[20].Stock = long.Parse(e_txtStockTalla43.Text);
            articulo.Talles[21].Stock = long.Parse(e_txtStockTalla44.Text);
            articulo.Talles[22].Stock = long.Parse(e_txtStockTalla45.Text);
            articulo.Talles[23].Stock = long.Parse(e_txtStockTalla46.Text);

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
            //articulo.Talla = new List<Talla>();
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