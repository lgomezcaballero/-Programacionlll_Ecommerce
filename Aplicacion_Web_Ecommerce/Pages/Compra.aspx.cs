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
        public string fechaHoy { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            precargarCompra();
            obtenerUsuario(factura.Carrito.ID);
            fechaHoy = DateTime.Now.ToString("dd-MM-yyyy");
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
                if (item.IDTalla == idTalle)
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

        protected void btnCompra_Click(object sender, EventArgs e)
        {
            Dominio.Carrito carro = new Dominio.Carrito();
            carro = (Dominio.Carrito)Session["CarritoUsuario"];
            //foreach (var item in carro.ArticulosCarrito)
            //{
            //    //if ((obtenerStock(item.Articulo.ID, item.IDTalle) - item.Cantidad) < 0)
            //}
            //Response.Redirect("Compra.aspx", false);


            CarritoNegocio cNegocio = new CarritoNegocio();
            FacturaNegocio fNegocio = new FacturaNegocio();
            Factura factura = new Factura();
            factura.FormaPago = new FormaPago();
            factura.FormaPago.ID = obtenerIDFormaPago();
            factura.Carrito = new Dominio.Carrito();
            factura.Carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            factura.Carrito = (Dominio.Carrito)Session["CarritoUsuario"];
            factura.PrecioTotal = calcularPrecioTotal(factura.Carrito.ArticulosCarrito);
            fNegocio.comprar(factura);
            actualizarCarrito();

            OutlookAutomation mail = new OutlookAutomation();
            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>Este es el body del correo</h1></br>
                            <h2>Este es el segundo párrafo</h2>";
            mail.enviarMail("leandrogomez343@gmail.com", "Este correo fue enviado via C-sharp", body);

            Response.Redirect("WebForm1.aspx", false);
        }

        protected byte obtenerIDFormaPago()
        {
            byte idFormaPago = 0;
            FormaPagoNegocio negocio = new FormaPagoNegocio();
            List<FormaPago> aux = new List<FormaPago>();
            aux = negocio.listar();
            if (rdbEfectivo.Checked)
            {
                foreach (var item in aux)
                {
                    if (item.Nombre.Equals("Efectivo"))
                    {
                        idFormaPago = item.ID;
                        break;
                    }
                }
            }
            else if (rdbMP.Checked)
            {
                foreach (var item in aux)
                {
                    if (item.Nombre.Equals("MercadoPago"))
                    {
                        idFormaPago = item.ID;
                        break;
                    }
                }
            }
            return idFormaPago;
        }
    }
}