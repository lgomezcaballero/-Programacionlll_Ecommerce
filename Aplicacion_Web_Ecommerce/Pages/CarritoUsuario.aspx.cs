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
        public string aux { get; set; }
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

        protected void Button1_Click(object sender, EventArgs e)
        {
            FacturaNegocio negocio = new FacturaNegocio();
            Factura factura = new Factura();
            factura.FormaPago = new FormaPago();
            factura.FormaPago.ID = 1;
            factura.Carrito = new Dominio.Carrito();
            factura.Carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            factura.Carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            factura.PrecioTotal = calcularPrecioTotal(factura.Carrito.ArticulosCarrito);
            negocio.comprar(factura);
        }

        protected decimal calcularPrecioTotal(List<ArticuloCarrito> carrito)
        {
            decimal precioTotal = 0;
            foreach (var item in carrito)
            {
                precioTotal += item.Cantidad * item.Articulo.Precio;
            }
            return precioTotal;
        }
    }
}