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
            enviarMail(factura);
            recibirMail(factura);
        }

        protected void enviarMail(Factura factura)
        {
            OutlookAutomation mail = new OutlookAutomation();
            string EntregaCompra = "";
            if (rdbRetiro.Checked)
                EntregaCompra = "<h2>Podés pasar a retirar tu compra desde este momento por la sucursal mas cercana</h2>";
            else if (rdbEnvio.Checked)
                EntregaCompra = "<h2>Serás contactado/a a la brevedad por el vendedor para coordinar envío</h2>";
            
            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1>"+obtenerNombreUsuario(factura.Carrito.ID)+", Tu pedido ha sido recibido.</h1>"+
                            EntregaCompra+
                            "<h2>Valor total de la compra: " + string.Format("{0:C}", factura.PrecioTotal) + "</h2></br>"+
                            "<h3>Gracias por elegirnos!</h3>";
            mail.enviarMail(obtenerEmail(factura.Carrito.ID), "Detalle - Compra - Tienda Virtual", body);

            //Response.Redirect("FinalCompra.aspx", false);
        }

        protected void recibirMail(Factura factura)
        {
            OutlookAutomation mail = new OutlookAutomation();
            FacturaNegocio fNegocio = new FacturaNegocio();
            string EntregaCompra = "";
            string FormaPago = "";
            if (rdbRetiro.Checked)
                EntregaCompra = "<h2>El cliente retirará el pedido en la sucursal</h2>";
            else if (rdbEnvio.Checked)
                EntregaCompra = "<h2>El cliente solicita envío de pedido</h2>";

            if (rdbEfectivo.Checked)
                FormaPago = "Efectivo";
            else if (rdbMP.Checked)
                FormaPago = "Mercado Pago";

            string articulo = "";
            foreach (var item in factura.Carrito.ArticulosCarrito)
            {
                articulo += @"<h5>Código Articulo: " + item.Articulo.ID + "</h5>"+
                              "<h5>Articulo: " + item.Articulo.Nombre + "</h5>"+
                              "<h5>Marca: " + item.Articulo.Marca.Nombre + "</h5>"+
                              "<h5>Categoria: " + item.Articulo.Categoria.Nombre + "</h5>"+
                              "<h5>Género: " + item.Articulo.Genero.Nombre + "</h5>"+
                              "<h5>Precio: " + item.Articulo.Precio + "</h5>"+
                              "<h5>Talle: " + obtenerTalla(item.IDTalle) + "</h5>"+
                              "<h5>Cantidad: " + item.Cantidad + "</h5>"+
                              "<h5>---------------------------------------------------------</h5>";
            }

            string body = @"<style>
                            h1{color:dodgerblue;}
                            h2{color:darkorange;}
                            </style>
                            <h1> Se ha registrado un pedido</h1>
                            <h5>Cliente: "+ usuario.Apellidos + ", " + usuario.Nombres +"</h5>"+
                            "<h5>Email: " + usuario.Contacto.Email + "</h5>"+
                            "<h5>Teléfono: " + usuario.Contacto.Telefono + "</h5>"+
                            "<h5>---------------------------------------------------------</h5>" +
                             articulo +
                            "<h5>Forma de pago: " + FormaPago + "</h5>"+
                            "<h5>Tipo de entrega: " + EntregaCompra + "</h5>"+
                            "<h2>Valor total de la compra: " + string.Format("{0:C}", factura.PrecioTotal) + "</h2></br>" +
                            "<h3>Contactar al usuario.</h3>";
            mail.enviarMail("tiendavirtual-frpg2022@hotmail.com", "Correo interno - Nuevo Pedido(#"+fNegocio.obtenerIDFacturaNueva().ToString()+")", body);

            Response.Redirect("FinalCompra.aspx", false);
        }

        protected string obtenerEmail(long idUsuario)
        {
            string email = null;
            UsuarioNegocio negocio = new UsuarioNegocio();
            //List<Usuario> usuario = new List<Usuario>();
            foreach (var item in negocio.listar())
            {
                if (item.ID == idUsuario)
                {
                    email = item.Contacto.Email;
                    continue;
                }
            }
            return email;
        }

        protected string obtenerNombreUsuario(long idUsuario)
        {
            string nombre = null;
            UsuarioNegocio negocio = new UsuarioNegocio();
            //List<Usuario> usuario = new List<Usuario>();
            foreach (var item in negocio.listar())
            {
                if (item.ID == idUsuario)
                {
                    nombre = item.Nombres;
                    continue;
                }
            }
            return nombre;
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