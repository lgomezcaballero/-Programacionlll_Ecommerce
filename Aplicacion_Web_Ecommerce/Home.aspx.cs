using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaDeArticulos { get; set; }   

        public List<Articulo> Carrito { get; set; }
         
        protected void Page_Load(object sender, EventArgs e)
        {
            
            ArticuloNegocio Negocio = new ArticuloNegocio();
            ListaDeArticulos = Negocio.listar();

            if (!IsPostBack) { 
                if(Session["Carrito"] == null) { 
                Carrito = new List<Articulo>();
                Session.Add("Carrito", Carrito);
                }
            }

            if (Request.QueryString["ID"] != null) { 
   
            int ID = Int32.Parse(Request.QueryString["ID"].ToString());

            Carrito = (List<Articulo>)Session["Carrito"];
            Carrito.Add(ListaDeArticulos.Find(x => x.ID == ID));
            Session.Add("Carrito", Carrito);
            
            grillaArticulos.DataSource = ListaDeArticulos;
            grillaArticulos.DataBind();

            }

            

        }
    }
}