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

            //Esto lo hago para guardar el pais en session 
            listaPaises = paisNegocio.listar();
            if (!IsPostBack)
                Session.Add("listapaises", listaPaises);
        }
    }
}