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
            /*
            List<Articulo> articuloList = new List<Articulo>();
            ArticuloNegocio negocios = new ArticuloNegocio();

            articuloList = negocios.listar();



            List<Articulo> listaFiltrada = new List<Articulo>();
            string Filtro = BarraBuscadora.Text;
            if (Filtro.Length > 2)
            {
                listaFiltrada = articuloList.FindAll(x => x.Nombre.ToLower().Contains(Filtro.ToLower()));
            }
            */
            
        }
    }
}