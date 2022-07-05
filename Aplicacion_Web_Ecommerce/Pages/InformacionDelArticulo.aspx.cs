using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class InformacioDelArticulo : System.Web.UI.Page
    {
        public Articulo articulo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["IDinfoArt"] != null)
                {
                    articulo = new Articulo();
                    long idArticulo = long.Parse(Request.QueryString["IDinfoArt"]);
                    articulo = obtenerArticulo(idArticulo);
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
    }
}