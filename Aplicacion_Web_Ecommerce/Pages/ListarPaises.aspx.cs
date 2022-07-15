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
    public partial class ListarPaises : System.Web.UI.Page
    {

        //Esto es para el abm de paises
        public List<Pais> listaPaises = new List<Pais>(); //ok
        PaisNegocio paisNegocio = new PaisNegocio();
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
                    //Esto lo hago para guardar el pais en session 
                    listaPaises = paisNegocio.listar();
                    if (!IsPostBack)
                        Session.Add("listapaises", listaPaises);
                }
            }

        }

        protected void btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx", false);
        }
    }
}