using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class ListaDeArticulosFiltrada : System.Web.UI.Page
    {

        public List<Articulo> ListaFiltrada { get; set; }   

        protected void Page_Load(object sender, EventArgs e)
        {
            string Filtro = Session["Busqueda"].ToString();

            List<Articulo> ListaArticulos = new List<Articulo>();
            ArticuloNegocio ArticulosNegocio = new ArticuloNegocio();

            ListaArticulos = ArticulosNegocio.listar();

            ListaFiltrada = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(Filtro.ToLower()));

            /*
            DgvFiltrada.DataSource = ListaFiltrada; 
            DgvFiltrada.DataBind(); 
            */


        }
    }
}