using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CarritoNegocio
    {
        public Carrito mostrarCarrito(long idUsuario)
        {
            Carrito carrito = new Carrito();
            AccesoDatos datos = new AccesoDatos();
            ArticuloNegocio articuloNegocio = new ArticuloNegocio();

            try
            {
                datos.setConsultaSP("SP_ListarCarrito");
                datos.setParametros("@idUsuario", idUsuario);
                datos.ejecutarLectura();

                //Marca aux = new Marca();
                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["IDCarrito"] is DBNull))
                        carrito.ID = (long)datos.Lector["IDCarrito"];

                    if (!(datos.Lector["EstadoCarrito"] is DBNull))
                        carrito.Estado = (bool)datos.Lector["EstadoCarrito"];

                    carrito.ArticulosCarrito = new List<ArticuloCarrito>();
                }

                do
                {
                    ArticuloCarrito aux = new ArticuloCarrito();
                    aux.Articulo = new Articulo();
                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        aux.Articulo = articuloNegocio.obtenerArticulo((long)datos.Lector["IDArticulo"]);

                    if (!(datos.Lector["Cantidad"] is DBNull))
                        aux.Cantidad = (int)datos.Lector["Cantidad"];

                    if (!(datos.Lector["IDTalle"] is DBNull))
                        aux.IDTalle = (byte)datos.Lector["IDTalle"];

                    if (!(datos.Lector["EstadoArticuloCarrito"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoArticuloCarrito"];

                    if(aux.Articulo != null && aux.Estado && aux.Cantidad != 0)
                        carrito.ArticulosCarrito.Add(aux);
                } while (datos.Lector.Read());

                return carrito;

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
        public void agregarArticuloCarrito(ArticuloCarrito articuloCarrito, long IDUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarArticuloCarrito");
                datos.setParametros("@idCarrito", IDUsuario);
                datos.setParametros("@idArticulo", articuloCarrito.Articulo.ID);
                datos.setParametros("@idTalle", articuloCarrito.IDTalle);
                datos.setParametros("@cantidad", articuloCarrito.Cantidad);
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

        public void modificarArticuloCarrito(ArticuloCarrito articuloCarrito, long idUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarArticuloCarrito");
                datos.setParametros("@idCarrito", idUsuario);
                datos.setParametros("@idArticulo", articuloCarrito.Articulo.ID);
                datos.setParametros("@idTalle", articuloCarrito.IDTalle);
                datos.setParametros("@cantidad", articuloCarrito.Cantidad);
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

        public void eliminarArticuloCarrito(long idUsuario, long idArticulo, byte idTalle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarArticuloCarrito");
                datos.setParametros("@idCarrito", idUsuario);
                datos.setParametros("@idArticulo", idArticulo);
                datos.setParametros("@idTalle", idTalle);
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
    }
}
