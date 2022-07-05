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
        public List<Articulo> ListaCarrito { get; set; }

        public float PrecioTotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeLogueaste"] == null)
            {
                Response.Redirect("ErrorLogin.aspx", false);
            }

            ListaCarrito = (List<Articulo>)Session["Carrito"];

            foreach (var item in ListaCarrito)
            {
                PrecioTotal += (float)item.Precio;
            }

            /*
            GrillaArticulos.DataSource = Session["Carrito"];
            GrillaArticulos.DataBind();     
            */
        }
    }
}