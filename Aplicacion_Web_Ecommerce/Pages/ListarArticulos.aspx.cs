using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce.Pages
{
    public partial class ListarArticulos : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos = new List<Articulo>();
        ArticuloNegocio negocio = new ArticuloNegocio(); //ok

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
                    listaArticulos = negocio.listar();
                    if (!IsPostBack)
                        Session.Add("listaArticulos", listaArticulos);
                }

            }
        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx", false);
        }
    }
}