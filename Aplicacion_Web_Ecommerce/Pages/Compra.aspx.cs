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
    public partial class Compra : System.Web.UI.Page
    {
        public Factura factura { get; set; }
        public Usuario usuario { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            precargarCompra();
            obtenerUsuario(factura.Carrito.ID);
        }

        protected void precargarCompra()
        {
            factura = new Factura();
            factura.FormaPago = new FormaPago();
            //factura.FormaPago.ID = 1;
            factura.Carrito = new Dominio.Carrito();
            factura.Carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            factura.Carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            factura.PrecioTotal = calcularPrecioTotal(factura.Carrito.ArticulosCarrito);
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

        protected void obtenerUsuario(long idUsuario)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();
            List<Usuario> lista = new List<Usuario>();
            lista = negocio.listar();
            foreach (var item in lista)
            {
                if (item.ID == idUsuario)
                {
                    usuario = item;
                    return;
                }
            }
        }

        protected string obtenerTalla(byte idTalle)
        {
            string nombre = null;
            TallaNegocio negocio = new TallaNegocio();
            List<Talla> talla = new List<Talla>();
            talla = negocio.listar();
            foreach (var item in talla)
            {
                if(item.IDTalla == idTalle)
                {
                    nombre = item.Nombre;
                    continue;
                }
            }
            return nombre;
        }

        protected void actualizarCarrito()
        {
            CarritoNegocio negocio = new CarritoNegocio();
            Dominio.Carrito carrito = new Dominio.Carrito();
            carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            carrito = negocio.mostrarCarrito(carrito.ID);
            Session.Add("CarritoUsuario", carrito);
        }
    }
}