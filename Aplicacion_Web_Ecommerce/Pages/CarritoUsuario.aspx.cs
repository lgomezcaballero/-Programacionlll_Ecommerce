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
    public partial class Carrito : System.Web.UI.Page
    {
        public Dominio.Carrito carrito { get; set; }

        public decimal PrecioTotal { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {
                //if (!IsPostBack)
                //{
                    CarritoNegocio negocio = new CarritoNegocio();
                    if(Request.QueryString["IDArt"] != null && Request.QueryString["IDT"] != null)
                    {
                        long idUsuario = (long)Session["IDUsuarioLogueado"];
                        long idArticulo = long.Parse(Request.QueryString["IDArt"]);
                        byte idTalle = byte.Parse(Request.QueryString["IDT"]);
                        negocio.eliminarArticuloCarrito(idUsuario, idArticulo, idTalle);
                    }
                    carrito = new Dominio.Carrito();
                    carrito.ArticulosCarrito = new List<ArticuloCarrito>();
                    carrito = (Dominio.Carrito)Session["CarritoUsuario"];
                    carrito = negocio.mostrarCarrito(carrito.ID);
                    Session.Add("CarritoUsuario", carrito);
                //}
            }
        }

        protected string obtenerTalle(byte idTalle)
        {
            //string talle;
            TallaNegocio negocio = new TallaNegocio();
            Talla aux = new Talla();
            aux = negocio.listar().Find(x => x.IDTalla.Equals(idTalle));


            return aux.Nombre;
        }

        protected long obtenerStock(long idArticulo, byte idTalla)
        {
            ArticuloTallaNegocio negocio = new ArticuloTallaNegocio();
            ArticuloTalla aux = new ArticuloTalla();
            aux = negocio.listar(idArticulo).Find(x => x.IDArticulo.Equals(idArticulo) && x.IDTalla.Equals(idTalla));
            return aux.Stock;
        }
    }
}