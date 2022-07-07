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
    public partial class Carrito : System.Web.UI.Page
    {
        public Dominio.Carrito carrito { get; set; }

        public float PrecioTotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {
                CarritoNegocio negocio = new CarritoNegocio();
                if(Request.QueryString["IDArt"] != null && Request.QueryString["IDT"] != null)
                {
                    long idUsuario = (long)Session["IDUsuarioLogueado"];
                    long idArticulo = long.Parse(Request.QueryString["IDArt"]);
                    byte idTalle = byte.Parse(Request.QueryString["IDT"]);
                    negocio.eliminarArticuloCarrito(idUsuario, idArticulo, idTalle);
                }
                carrito = new Dominio.Carrito();
                carrito.ArticulosCarrito = new List<ArticuloCarrito>();
                carrito = (Dominio.Carrito)Session["CarritoUsuario"];
                carrito = negocio.mostrarCarrito(carrito.ID);
                Session.Add("CarritoUsuario", carrito);
            }
        }
    }
}