using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class FacturaNegocio
    {
        public Factura obtenerFactura(long idFactura)
        {
            //Factura factura = new Factura();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_MostrarFactura");
                datos.ejecutarLectura();

                Factura aux = new Factura();
                aux.Carrito.ArticulosCarrito = new List<ArticuloCarrito>();
                while (datos.Lector.Read())
                {
                    aux = new Factura();
                    if (!(datos.Lector["IDFactura"] is DBNull))
                        aux.ID = (long)datos.Lector["IDFactura"];

                    aux.FormaPago = new FormaPago();
                    if (!(datos.Lector["IDFormaPago"] is DBNull))
                        aux.FormaPago.ID = (byte)datos.Lector["IDFormaPago"];

                    if (!(datos.Lector["EstadoFactura"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoFactura"];

                    aux.Carrito = new Carrito();
                    if (!(datos.Lector["IDUsuario"] is DBNull))
                        aux.Carrito.ID = (long)datos.Lector["IDUsuario"];

                    ArticuloCarrito ac = new ArticuloCarrito();
                    ac.Articulo = new Articulo();
                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        ac.Articulo.ID = (long)datos.Lector["IDArticulo"];

                    if (!(datos.Lector["IDTalle"] is DBNull))
                        ac.IDTalle = (byte)datos.Lector["IDTalle"];

                    if (!(datos.Lector["PrecioTotal"] is DBNull))
                        aux.PrecioTotal = (decimal)datos.Lector["PrecioTotal"];

                    if (!(datos.Lector["EstadoCompra"] is DBNull))
                        aux.Carrito.Estado = (bool)datos.Lector["EstadoCompra"];
                        
                    aux.Carrito.ArticulosCarrito.Add(ac);

                }
                return aux;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void comprar(Factura factura)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarFactura");
                datos.setParametros("@idFormaPago", factura.FormaPago.ID);
                datos.ejecutarAccion();

                long idFactura = this.obtenerIDFacturaNueva();
                agregarCompra(idFactura, factura.Carrito);
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void agregarCompra(long idFactura, Carrito carrito)
        {
            foreach (var item in carrito.ArticulosCarrito)
            {
                AccesoDatos datos = new AccesoDatos();
                CarritoNegocio cNegocio = new CarritoNegocio();
                datos.setConsultaSP("SP_AgregarCompra");
                datos.setParametros("@idFactura", idFactura);
                datos.setParametros("@idUsuario", carrito.ID);
                datos.setParametros("@idArticulo", item.Articulo.ID);
                datos.setParametros("@idTalle", item.IDTalle);
                datos.setParametros("@cantidad", item.Cantidad);
                datos.setParametros("@PrecioTotal", item.Cantidad * item.Articulo.Precio);
                datos.ejecutarAccion();
                cNegocio.eliminarArticuloCarrito(carrito.ID, item.Articulo.ID, item.IDTalle);
            }
        }

        /*public void modificarArticulo(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
            ImagenesArticuloNegocio imgNegocio = new ImagenesArticuloNegocio();
            try
            {
                datos.setConsultaSP("SP_ModificarArticulo");
                datos.setParametros("@idArticulo", articulo.ID);
                datos.setParametros("@idMarca", articulo.Marca.ID);
                datos.setParametros("@idCategoria", articulo.Categoria.ID);
                datos.setParametros("@idGenero", articulo.Genero.ID);

                //Aca me pide id talla para que funcione 

                //datos.setParametros("@idTalla", articulo.Talla.IDTalla);
                datos.setParametros("@nombre", articulo.Nombre);
                datos.setParametros("@descripcion", articulo.Descripcion);
                datos.setParametros("@precio", articulo.Precio);
                //datos.setParametros("@urlImagen", urlImagen);
                //datos.setParametros("@stock", articulo.Stock);
                datos.ejecutarAccion();
                foreach (var item in articulo.Talles)
                {
                    atNegocio.modificarTallaArticulo(item);
                }
                foreach (var item in articulo.Imagenes)
                {
                    imgNegocio.modificarImagen(item);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        /*public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca, " +
                    "c.Descripcion Categoria, a.ImagenUrl, a.Precio, m.Id as IdMarca, c.Id as IdCategoria From ARTICULOS a " +
                    "Inner Join MARCAS m on a.IdMarca = m.Id Inner Join CATEGORIAS c on a.IdCategoria = c.Id " +
                    "Where ";
                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "a.Codigo like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "a.Codigo like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "a.Codigo like '%" + filtro + "%'";
                                break;

                            default:
                                consulta += "a.Codigo like '%%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "a.Nombre like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "a.Nombre like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "a.Nombre like '%" + filtro + "%'";
                                break;

                            default:
                                consulta += "a.Nombre like '%%'";
                                break;
                        }
                        break;

                    case "Precio":
                        switch (criterio)
                        {
                            case "Menor a":
                                consulta += "a.Precio < " + filtro;
                                break;

                            case "Mayor a":
                                consulta += "a.Precio > " + filtro;
                                break;

                            case "Igual a":
                                consulta += "a.Precio = " + filtro;
                                break;
                            default:
                                consulta = "Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca, " +
                                "c.Descripcion Categoria, a.ImagenUrl, a.Precio, m.Id as IdMarca, c.Id as IdCategoria From ARTICULOS a " +
                                "Inner Join MARCAS m on a.IdMarca = m.Id Inner Join CATEGORIAS c on a.IdCategoria = c.Id " +
                                "Where a.Activo = 1";
                                break;
                        }
                        break;
                }
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.ID = (int)datos.Lector["IdCategoria"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/

        /*public void eliminarArticulo(long id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarArticulo");
                datos.setParametros("@idArticulo", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }*/
        public long obtenerIDFacturaNueva()
        {
            long idFactura = -1;
            AccesoDatos datos = new AccesoDatos();
            ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
            ImagenesArticuloNegocio imgNegocio = new ImagenesArticuloNegocio();
            try
            {
                datos.setConsultaSP("SP_ObtenerIDFacturaNueva");
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["IDFactura"] is DBNull))
                    {
                        idFactura = (long)datos.Lector["IDFactura"];
                    }
                }
                return idFactura;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

        }

        public List<Estadisticas> listar()
        {
            List<Estadisticas> lista = new List<Estadisticas>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarFacturas");
                datos.ejecutarLectura();

                Estadisticas aux = new Estadisticas();
                while (datos.Lector.Read())
                {
                    aux = new Estadisticas();

                    if (!(datos.Lector["IDFactura"] is DBNull))
                        aux.IDFactura= (long)datos.Lector["IDFactura"];

                    if (!(datos.Lector["IDFormaPago"] is DBNull))
                        aux.IDFormaPago = (byte)datos.Lector["IDFormaPago"];

                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        aux.IDArticulo = (long)datos.Lector["IDArticulo"];

                    if (!(datos.Lector["Cantidad"] is DBNull))
                        aux.cantidad = (int)datos.Lector["Cantidad"];

                    if (!(datos.Lector["PrecioTotal"] is DBNull))
                        aux.precioTotal = (decimal)datos.Lector["PrecioTotal"];

                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }

        public long listarArticuloMasVendido()
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarFacturas");
                datos.ejecutarLectura();

                long idArticulo = -1;
                if (datos.Lector.Read())
                { 
                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        idArticulo = (long)datos.Lector["IDArticulo"];
                }
                return idArticulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
