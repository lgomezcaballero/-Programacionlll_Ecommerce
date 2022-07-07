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
                carrito = new Dominio.Carrito();
                carrito.ArticulosCarrito = new List<ArticuloCarrito>();
                carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            }
        }
    }
}