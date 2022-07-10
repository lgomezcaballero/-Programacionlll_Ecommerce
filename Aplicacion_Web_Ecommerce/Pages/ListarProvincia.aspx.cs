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

            //Esto lo hago para guardar el las provincias en session 
            listaProvincias = provincianegocio.listar();
            if (!IsPostBack)
                Session.Add("listaProvincias", listaProvincias);

        }
    }
}