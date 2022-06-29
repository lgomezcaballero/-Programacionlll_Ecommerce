using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos = new List<Articulo>();
        ArticuloNegocio negocio = new ArticuloNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            //if(!IsPostBack)
            listaArticulos = negocio.listar();
            //if(Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
            //{
            //    string id = Request.QueryString["ID"];
            //    string type = Request.QueryString["Type"];

            //}
        }

        protected void ModificarArticulo_Click(object sender, EventArgs e)
        {
            long idArticulo = long.Parse(((LinkButton)sender).CommandArgument);
            Articulo aux = new Articulo();

        }
    }
}