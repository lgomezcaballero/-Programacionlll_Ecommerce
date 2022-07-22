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
        public decimal valor { get; set; }
        public int cantidad { get; set; }
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
                if (Request.QueryString["IDArt"] != null && Request.QueryString["IDT"] != null)
                {
                    long idUsuario = (long)Session["IDUsuarioLogueado"];
                    long idArticulo = long.Parse(Request.QueryString["IDArt"]);
                    byte idTalle = byte.Parse(Request.QueryString["IDT"]);
                    negocio.eliminarArticuloCarrito(idUsuario, idArticulo, idTalle);
                }
                if(Request.QueryString["updateArt"] != null && Request.QueryString["idA"] != null 
                    && Request.QueryString["idT"] != null)
                {
                    if(int.Parse(Request.QueryString["updateArt"]) == 1)
                    {
                        cambiarCantidadPedido(long.Parse(Request.QueryString["idA"]), 1, byte.Parse(Request.QueryString["idT"]));
                        //cantidad = 1;
                    }
                    else if(int.Parse(Request.QueryString["updateArt"]) == -1)
                    {
                        cambiarCantidadPedido(long.Parse(Request.QueryString["idA"]), -1, byte.Parse(Request.QueryString["idT"]));
                        //cantidad = -1;
                    }
                }
                actualizarCarrito();

                //}
            }
        }

        protected void cambiarCantidadPedido(long idArticulo, int cantidad, byte idTalle)
        {
            CarritoNegocio negocio = new CarritoNegocio();
            carrito = new Dominio.Carrito();
            carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            long aux = obtenerNuevaCantidad(idArticulo, idTalle);
            foreach (var item in carrito.ArticulosCarrito)
            {
                if(item.Articulo.ID == idArticulo && item.IDTalle == idTalle)
                {
                    if(item.Cantidad > 0 && cantidad == -1)
                    {
                        item.Cantidad += cantidad;
                    }
                    else if((item.Cantidad+cantidad) <= (aux))
                    {
                        item.Cantidad += cantidad;
                    }
                    negocio.modificarArticuloCarrito(item, carrito.ID);
                    return;
                }
            }
        }

        protected long obtenerNuevaCantidad(long idArticulo, byte idTalle)
        {
            ArticuloTallaNegocio negocio = new ArticuloTallaNegocio();
            ArticuloTalla articuloTalla = new ArticuloTalla();
            articuloTalla = negocio.obtenerArticuloTalla(idArticulo, idTalle);
            return articuloTalla.Stock;
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

        //protected void btnCompra_Click(object sender, EventArgs e)
        //{
        //    /*Dominio.Carrito carro = new Dominio.Carrito();
        //    carro = (Dominio.Carrito)Session["CarritoUsuario"];
        //    foreach (var item in carro.ArticulosCarrito)
        //    {
        //        //if ((obtenerStock(item.Articulo.ID, item.IDTalle) - item.Cantidad) < 0)
        //    }*/
        //    Response.Redirect("Compra.aspx", false);


        //    //CarritoNegocio cNegocio = new CarritoNegocio();
        //    //FacturaNegocio fNegocio = new FacturaNegocio();
        //    //Factura factura = new Factura();
        //    //factura.FormaPago = new FormaPago();
        //    ////factura.FormaPago.ID = 1;
        //    //factura.Carrito = new Dominio.Carrito();
        //    //factura.Carrito.ArticulosCarrito = new List<ArticuloCarrito>();
        //    //factura.Carrito = (Dominio.Carrito)Session["CarritoUsuario"];
        //    //factura.PrecioTotal = calcularPrecioTotal(factura.Carrito.ArticulosCarrito);
        //    //fNegocio.comprar(factura);
        //    //actualizarCarrito();
        //}



        protected void actualizarCarrito()
        {
            CarritoNegocio negocio = new CarritoNegocio();
            carrito = new Dominio.Carrito();
            carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            carrito = negocio.mostrarCarrito(carrito.ID);
            Session.Add("CarritoUsuario", carrito);
        }
    }
}