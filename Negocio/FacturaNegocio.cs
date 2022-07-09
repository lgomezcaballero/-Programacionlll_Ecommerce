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
        public Factura mostrar(long idFactura)
        {
            Factura factura = new Factura();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_MostrarFactura");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        aux.ID = (long)datos.Lector["IDArticulo"];

                    if (!(datos.Lector["Articulo"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Articulo"];

                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];

                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];

                    //if (!(datos.Lector["Stock"] is DBNull))
                    //    aux.Stock = (long)datos.Lector["Stock"];

                    /*
                    if (!(datos.Lector["FechaRegistroArticulo"] is DBNull))
                        aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistroArticulo"];
                    */

                    if (!(datos.Lector["EstadoArticulo"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoArticulo"];

                    aux.Imagenes = new List<ImagenesArticulo>();
                    ImagenesArticuloNegocio ImagenesNegocio = new ImagenesArticuloNegocio();
                    aux.Imagenes = ImagenesNegocio.listar(aux.ID);

                    aux.Marca = new Marca();
                    if (!(datos.Lector["IDMarca"] is DBNull))
                        aux.Marca.ID = (Int16)datos.Lector["IDMarca"];

                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    /*
                    if (!(datos.Lector["FechaRegistroMarca"] is DBNull))
                        aux.Marca.FechaRegistro = (DateTime)datos.Lector["FechaRegistroMarca"];
                    */

                    if (!(datos.Lector["EstadoMarca"] is DBNull))
                        aux.Marca.Estado = (bool)datos.Lector["EstadoMarca"];

                    aux.Categoria = new Categoria();
                    if (!(datos.Lector["IDCategoria"] is DBNull))
                        aux.Categoria.ID = (Int16)datos.Lector["IDCategoria"];

                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria.Nombre = (string)datos.Lector["Categoria"];

                    /*
                    if (!(datos.Lector["FechaRegistroCategoria"] is DBNull))
                        aux.Categoria.FechaRegistro = (DateTime)datos.Lector["FechaRegistroCategoria"];
                    */

                    if (!(datos.Lector["EstadoCategoria"] is DBNull))
                        aux.Categoria.Estado = (bool)datos.Lector["EstadoCategoria"];

                    aux.Genero = new Genero();
                    if (!(datos.Lector["IDGenero"] is DBNull))
                        aux.Genero.ID = (byte)datos.Lector["IDGenero"];

                    if (!(datos.Lector["Genero"] is DBNull))
                        aux.Genero.Nombre = (string)datos.Lector["Genero"];

                    if (!(datos.Lector["EstadoGenero"] is DBNull))
                        aux.Genero.Estado = (bool)datos.Lector["EstadoGenero"];

                    //aux.Talla = new Talla();
                    //if (!(datos.Lector["IDTalla"] is DBNull))
                    //    aux.Talla.IDTalla = (byte)datos.Lector["IDTalla"];

                    //if (!(datos.Lector["Talla"] is DBNull))
                    //    aux.Talla.Nombre= (string)datos.Lector["Talla"];

                    //if (!(datos.Lector["EstadoTalla"] is DBNull))
                    //    aux.Talla.Estado = (bool)datos.Lector["EstadoTalla"];

                    if (aux.Estado == true)
                    {
                        lista.Add(aux);

                    }


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
        public void comprar(Factura factura)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_AgregarFactura");
                datos.setParametros("@idFormaPago", factura.FormaPago.ID);
                datos.ejecutarAccion();

                long idFactura = this.obtenerIDFacturaNueva();
                foreach (var item in factura.Carrito.ArticulosCarrito)
                {
                    datos.setConsultaSP("SP_AgregarCompra");
                    datos.setParametros("@idFactura", idFactura);
                    datos.setParametros("@idUsuario", factura.Carrito.ID);
                    datos.setParametros("@idArticulo", item.Articulo.ID);
                    datos.setParametros("@idTalle", item.IDTalle);
                    datos.setParametros("@cantidad", item.Cantidad);
                    datos.setParametros("@PrecioTotal", item.Cantidad * item.Articulo.Precio);
                    datos.ejecutarAccion();
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

        public void modificarArticulo(Articulo articulo)
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

        public void eliminarArticulo(long id)
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
        }
        public long obtenerIDFacturaNueva()
        {
            long idFactura = -1;
            AccesoDatos datos = new AccesoDatos();
            ArticuloTallaNegocio atNegocio = new ArticuloTallaNegocio();
            ImagenesArticuloNegocio imgNegocio = new ImagenesArticuloNegocio();
            try
            {
                datos.setConsultaSP("SP_ObtenerFacturaNueva");
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
    }
}
