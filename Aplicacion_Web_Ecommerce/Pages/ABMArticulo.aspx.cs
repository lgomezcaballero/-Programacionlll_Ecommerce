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
            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {

                if (Session["Admin"] == null)
                {
                    Session.Add("error", "solo los administradores pueden acceder a esta pagina");
                    Response.Redirect("ErrorAcceso.aspx", false);
                }

                else
                {

                    Articulo articulo = new Articulo();

                    if (!IsPostBack)
                    {

                        MarcaNegocio mNegocio = new MarcaNegocio();

                        CategoriaNegocio cNegocio = new CategoriaNegocio();

                        GeneroNegocio gNegocio = new GeneroNegocio();


                        Session.Add("listaMarcas", mNegocio.listar());
                        Session.Add("listaCategorias", cNegocio.listar());
                        Session.Add("listaGeneros", gNegocio.listar());
                        if (Request.QueryString["Type"] != null)
                        {
                            tipo = Request.QueryString["Type"];
                            if (Request.QueryString["ID"] != null)
                                id = long.Parse(Request.QueryString["ID"]);

                            ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
                            articulo.Talles = new List<ArticuloTalla>();
                            articulo.Talles = atNegocio.listar(id);
                            Session.Add("tallesArticulo", articulo.Talles);
                            if (tipo == "a")
                            {
                                a_ddlMarcas.DataSource = mNegocio.listar();
                                a_ddlMarcas.DataValueField = "ID";
                                a_ddlMarcas.DataTextField = "Nombre";
                                a_ddlMarcas.DataBind();
                                a_ddlCategorias.DataSource = cNegocio.listar();
                                a_ddlCategorias.DataValueField = "ID";
                                a_ddlCategorias.DataTextField = "Nombre";
                                a_ddlCategorias.DataBind();
                                a_ddlGeneros.DataSource = gNegocio.listar();
                                a_ddlGeneros.DataValueField = "ID";
                                a_ddlGeneros.DataTextField = "Nombre";
                                a_ddlGeneros.DataBind();
                            }
                            if (tipo == "e")
                            {
                                ddlMarcas.DataSource = mNegocio.listar();
                                ddlMarcas.DataValueField = "ID";
                                ddlMarcas.DataTextField = "Nombre";
                                ddlMarcas.DataBind();
                                ddlCategorias.DataSource = cNegocio.listar();
                                ddlCategorias.DataValueField = "ID";
                                ddlCategorias.DataTextField = "Nombre";
                                ddlCategorias.DataBind();
                                ddlGeneros.DataSource = gNegocio.listar();
                                ddlGeneros.DataValueField = "ID";
                                ddlGeneros.DataTextField = "Nombre";
                                ddlGeneros.DataBind();
                                //Con esta funciom obtine el articulo que se busca
                                articulo = obtenerArticulo(id);
                                //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                                setearCamposModificar(articulo);
                            }
                            if (tipo == "d")
                            {
                                ArticuloNegocio aNegocio = new ArticuloNegocio();
                                aNegocio.eliminarArticulo(id);
                                Response.Redirect("ListarArticulos", false);
                            }
                        }
                    }
                }
            }
        }
        protected Articulo obtenerArticulo(long idArticulo)
        {
            List<Articulo> lista = new List<Articulo>();
            Articulo aux = new Articulo();
            lista = (List<Articulo>)Session["listaArticulos"];

            ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
            ImagenesArticuloNegocio imgNegocio = new ImagenesArticuloNegocio();
            Session.Add("imgsArticulo", imgNegocio.listar(id));
            aux = lista.Find(x => x.ID == idArticulo);
            aux.Talles = new List<ArticuloTalla>();
            aux.Talles = atNegocio.listar(idArticulo);
            aux.Imagenes = new List<ImagenesArticulo>();
            aux.Imagenes = imgNegocio.listar(id);

            return aux;
        }

        protected void setearCamposModificar(Articulo articulo)
        {
            e_txtNombre.Text = articulo.Nombre;
            ddlMarcas.SelectedValue = articulo.Marca.ID.ToString();
            ddlCategorias.SelectedValue = articulo.Categoria.ID.ToString();
            ddlGeneros.SelectedValue = articulo.Genero.ID.ToString();
            e_txtPrecio.Text = articulo.Precio.ToString();
            e_txtURLImagen.Text = articulo.Imagenes[0].URLImagen;
            e_txtDescripcion.Text = articulo.Descripcion;

            //articulo.Talles = new List<ArticuloTalla>();
            //articulo.Talles = (List<ArticuloTalla>)Session["tallesArticulo"];
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
            Response.Redirect("ListarArticulos.aspx", false);
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
            articulo.Imagenes = new List<ImagenesArticulo>();
            articulo.Imagenes = (List<ImagenesArticulo>)Session["imgsArticulo"];
            articulo.Imagenes[0].URLImagen = e_txtURLImagen.Text;
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
            Response.Redirect("ListarArticulos.aspx");
        }

        protected void a_btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarArticulos.aspx", false);
        }

        protected void a_btnCrear_Click(object sender, EventArgs e)
        {
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            articulo.Marca = new Marca();
            articulo.Marca.ID = short.Parse(a_ddlMarcas.SelectedItem.Value);
            articulo.Categoria = new Categoria();
            articulo.Categoria.ID = short.Parse(a_ddlCategorias.SelectedItem.Value);
            articulo.Genero = new Genero();
            articulo.Genero.ID = byte.Parse(a_ddlGeneros.SelectedItem.Value);
            articulo.Nombre = a_txtNombre.Text;
            articulo.Imagenes = new List<ImagenesArticulo>();
            ImagenesArticulo img = new ImagenesArticulo();
            img.URLImagen = a_txtUrlImagen.Text;
            articulo.Imagenes.Add(img);
            articulo.Descripcion = a_txtDescripcion.Text;
            articulo.Precio = decimal.Parse(a_txtPrecio.Text);
            articulo.Talles = new List<ArticuloTalla>();
            articulo.Talles = setTallesArticulo();
            articulo.Talles[0].Stock = a_txtStockTallaXS.Text != "" ? long.Parse(a_txtStockTallaXS.Text) : 0;
            articulo.Talles[1].Stock = a_txtStockTallaS.Text != "" ? long.Parse(a_txtStockTallaS.Text) : 0;
            articulo.Talles[2].Stock = a_txtStockTallaM.Text != "" ? long.Parse(a_txtStockTallaM.Text) : 0;
            articulo.Talles[3].Stock = a_txtStockTallaL.Text != "" ? long.Parse(a_txtStockTallaL.Text) : 0;
            articulo.Talles[4].Stock = a_txtStockTallaXL.Text != "" ? long.Parse(a_txtStockTallaXL.Text) : 0;
            articulo.Talles[5].Stock = a_txtStockTallaXXL.Text != "" ? long.Parse(a_txtStockTallaXXL.Text) : 0;
            articulo.Talles[6].Stock = a_txtStockTallaXXXL.Text != "" ? long.Parse(a_txtStockTallaXXXL.Text) : 0;
            articulo.Talles[7].Stock = a_txtStockTalla30.Text != "" ? long.Parse(a_txtStockTalla30.Text) : 0;
            articulo.Talles[8].Stock = a_txtStockTalla31.Text != "" ? long.Parse(a_txtStockTalla31.Text) : 0;
            articulo.Talles[9].Stock = a_txtStockTalla32.Text != "" ? long.Parse(a_txtStockTalla32.Text) : 0;
            articulo.Talles[10].Stock = a_txtStockTalla33.Text != "" ? long.Parse(a_txtStockTalla33.Text) : 0;
            articulo.Talles[11].Stock = a_txtStockTalla34.Text != "" ? long.Parse(a_txtStockTalla34.Text) : 0;
            articulo.Talles[12].Stock = a_txtStockTalla35.Text != "" ? long.Parse(a_txtStockTalla35.Text) : 0;
            articulo.Talles[13].Stock = a_txtStockTalla36.Text != "" ? long.Parse(a_txtStockTalla36.Text) : 0;
            articulo.Talles[14].Stock = a_txtStockTalla37.Text != "" ? long.Parse(a_txtStockTalla37.Text) : 0;
            articulo.Talles[15].Stock = a_txtStockTalla38.Text != "" ? long.Parse(a_txtStockTalla38.Text) : 0;
            articulo.Talles[16].Stock = a_txtStockTalla39.Text != "" ? long.Parse(a_txtStockTalla39.Text) : 0;
            articulo.Talles[17].Stock = a_txtStockTalla40.Text != "" ? long.Parse(a_txtStockTalla40.Text) : 0;
            articulo.Talles[18].Stock = a_txtStockTalla41.Text != "" ? long.Parse(a_txtStockTalla41.Text) : 0;
            articulo.Talles[19].Stock = a_txtStockTalla42.Text != "" ? long.Parse(a_txtStockTalla42.Text) : 0;
            articulo.Talles[20].Stock = a_txtStockTalla43.Text != "" ? long.Parse(a_txtStockTalla43.Text) : 0;
            articulo.Talles[21].Stock = a_txtStockTalla44.Text != "" ? long.Parse(a_txtStockTalla44.Text) : 0;
            articulo.Talles[22].Stock = a_txtStockTalla45.Text != "" ? long.Parse(a_txtStockTalla45.Text) : 0;
            articulo.Talles[23].Stock = a_txtStockTalla46.Text != "" ? long.Parse(a_txtStockTalla46.Text) : 0;

            articuloNegocio.agregarArticulo(articulo);
            Response.Redirect("ListarArticulos.aspx", false);
        }

        protected List<ArticuloTalla> setTallesArticulo()
        {
            List<ArticuloTalla> lista = new List<ArticuloTalla>();
            //ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
            //long idart = idArticulo;
            for (int i = 0; i < 24; i++)
            {
                ArticuloTalla aux = new ArticuloTalla();
                //aux.IDArticulo = idArticulo;
                aux.IDTalla = (byte)(i + 1);
                lista.Add(aux);
            }
            return lista;
        }
    }
}