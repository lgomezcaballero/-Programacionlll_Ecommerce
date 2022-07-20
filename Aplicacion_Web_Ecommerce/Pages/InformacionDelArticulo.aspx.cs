using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class InformacioDelArticulo : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {
                if (IsPostBack && Session["articuloAux"] != null)
                    articulo = (Articulo)Session["articuloAux"];

                if (!IsPostBack)
                {
                    TallaNegocio tNegocio = new TallaNegocio();
                    Session.Add("Talles", tNegocio.listar());
                    if (Request.QueryString["IDinfoArt"] != null)
                    {
                        articulo = new Articulo();
                        long idArticulo = long.Parse(Request.QueryString["IDinfoArt"]);
                        articulo = obtenerArticulo(idArticulo);
                        Session.Add("articuloAux", articulo);
                        ddlTalles.DataSource = tNegocio.listarTallasDisponibles(articulo);
                        ddlTalles.DataTextField = "Nombre";
                        ddlTalles.DataValueField = "IDTalla";
                        ddlTalles.DataBind();
                    }
                }
            }
        }

        protected Articulo obtenerArticulo(long idArticulo)
        {
            Articulo articulo = new Articulo();
            List<Articulo> lista = new List<Articulo>();
            lista = (List<Articulo>)Session["listaArticulos"];
            foreach (var item in lista)
            {
                if (item.ID == idArticulo)
                    return item;
            }
            return articulo;
        }

        protected void btnComprar_Click(object sender, EventArgs e)
        {
            CarritoNegocio carritoNegocio = new CarritoNegocio();
            ArticuloCarrito artCarrito = new ArticuloCarrito();
            artCarrito.Articulo = new Articulo();
            artCarrito.Articulo = articulo;
            artCarrito.Cantidad = 1;
            artCarrito.IDTalle = byte.Parse(ddlTalles.SelectedItem.Value);
            //artCarrito.Estado = true;
            carritoNegocio.agregarArticuloCarrito(artCarrito, (long)Session["IDUsuarioLogueado"]);
            List<Articulo> lista = new List<Articulo>();
            lista = (List<Articulo>)Session["Carrito"];
            lista.Add(articulo);
            Session.Add("Carrito", lista);
            //lblAgregado.Visible = true;
            //Response.Redirect("Carrito.aspx", false);
        }
    }
}