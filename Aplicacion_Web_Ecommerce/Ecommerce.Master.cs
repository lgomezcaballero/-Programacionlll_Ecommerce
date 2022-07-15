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
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BarraBuscadora_TextChanged(object sender, EventArgs e)
        {

            string Busqueda = BarraBuscadora.Text;
            Session.Add("Busqueda", Busqueda);
            Response.Redirect("Busqueda.aspx", false);

            /*
            List<Articulo> articuloList = new List<Articulo>();
            ArticuloNegocio negocios = new ArticuloNegocio();

            articuloList = negocios.listar();

            List<Articulo> listaFiltrada = new List<Articulo>();
            string Filtro = BarraBuscadora.Text;
            if (Filtro.Length > 2)
            {
                listaFiltrada = articuloList.FindAll(x => x.Nombre.ToLower().Contains(Filtro.ToLower()));
                Response.Redirect("Busqueda.aspx", false);
            }*/


        }

        protected void BtnBuscar_Click(object sender, EventArgs e)
        {
            string Busqueda = BarraBuscadora.Text;
            Session.Add("Busqueda", Busqueda);
            Response.Redirect("Busqueda.aspx", false);
        }

        protected void BtnCerrarSession_Click(object sender, EventArgs e)
        {
            Session["TeLogueaste"] = null;
            Session["Admin"] = null;
            Response.Redirect("LoginSinMaster.aspx", false);
        }
    }
}