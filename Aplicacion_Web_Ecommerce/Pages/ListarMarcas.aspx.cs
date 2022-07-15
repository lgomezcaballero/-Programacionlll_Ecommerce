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
    public partial class ListarMarcas : System.Web.UI.Page
    {

        //Esto lo hago para el abm de provincias
        public List<Marca> listademarcas = new List<Marca>(); //ok
        MarcaNegocio marcaNegocio = new MarcaNegocio();
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
                    listademarcas = marcaNegocio.listar();
                    if (!IsPostBack)
                        Session.Add("listademarcas", listademarcas);

                }

            }

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx", false);
        }
    }
}