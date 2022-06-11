using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio listaArticulos = new ArticuloNegocio();
            grillaArticulos.DataSource = listaArticulos.listar();
            grillaArticulos.DataBind();
        }
    }
}