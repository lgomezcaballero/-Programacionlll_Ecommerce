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
                if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                {
                    tipo = Request.QueryString["Type"];
                    id = long.Parse(Request.QueryString["ID"]);
                }
                if (Request.QueryString["Type"] == "a")
                    tipo = Request.QueryString["Type"];
                if (tipo == "e")
                {
                    articulo = obtenerArticulo(id);
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
            txtNombre.Text = articulo.Nombre;
            txtMarca.Text = articulo.Marca.Nombre;
            txtCategoria.Text = articulo.Categoria.Nombre;
            txtGenero.Text = articulo.Genero.Nombre;
            txtPrecio.Text = articulo.Precio.ToString();
            txtDescripcion.Text = articulo.Descripcion;
        }
        protected void btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx");
        }

        protected void btnEditar_Click(object sender, EventArgs e)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            Articulo articulo = new Articulo();

            articulo.Nombre = txtNombre.Text;
            articulo.Marca = new Marca();
            articulo.Marca.Nombre = txtMarca.Text;
            articulo.Categoria = new Categoria();
            articulo.Categoria.Nombre = txtCategoria.Text;
            articulo.Genero = new Genero();
            articulo.Genero.Nombre = txtGenero.Text;
            articulo.Precio = decimal.Parse(txtPrecio.Text);
            articulo.Descripcion = txtDescripcion.Text;

            negocio.modificarArticulo(articulo);
            Response.Redirect("HomeAdmin.aspx");
        }
    }
}