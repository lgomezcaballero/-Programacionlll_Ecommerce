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
    public partial class ListarCategorias : System.Web.UI.Page
    {
        //Esto lo hago para el abm de provincias
        public List<Categoria> listacategoria = new List<Categoria>(); //ok
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            listacategoria = categoriaNegocio.listar();
            if (!IsPostBack)
                Session.Add("listacategoria", listacategoria);

        }
    }
}