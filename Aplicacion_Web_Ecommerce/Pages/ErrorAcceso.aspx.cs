using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Aplicacion_Web_Ecommerce.Pages
{
    public partial class ErrorAcceso : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            //else
            //{
            //    if (Session["Admin"] != null)
            //    {
            //        Session.Add("error", "solo los administradores pueden acceder a esta pagina");
            //        Response.Redirect("ErrorAcceso.aspx", false);
            //    }
            //}
        }
    }
}