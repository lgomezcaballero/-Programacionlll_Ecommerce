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
            listademarcas = marcaNegocio.listar();
            if (!IsPostBack)
                Session.Add("listademarcas", listademarcas);
        }
    }
}