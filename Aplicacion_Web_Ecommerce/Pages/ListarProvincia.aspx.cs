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
    public partial class ListarProvincia : System.Web.UI.Page
    {
        //Esto lo hago para el abm de provincias
        public List<Provincia> listaProvincias = new List<Provincia>(); //ok
        ProvinciaNegocio provincianegocio = new ProvinciaNegocio();
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
                    //Esto lo hago para guardar el las provincias en session 
                    listaProvincias = provincianegocio.listar();
                    if (!IsPostBack)
                        Session.Add("listaProvincias", listaProvincias);

                }
            }

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("HomeAdmin.aspx", false);
        }
    }
}