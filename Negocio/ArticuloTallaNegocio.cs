using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloTallaNegocio
    {
        public List<ArticuloTalla> listar(long idArticulo)
        {
            List<ArticuloTalla> lista = new List<ArticuloTalla>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarTallasArticulo");
                datos.setParametros("@idArticulo", idArticulo);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    ArticuloTalla aux = new ArticuloTalla();
                    if (!(datos.Lector["IDArticulo"] is DBNull))
                        aux.IDArticulo = (long)datos.Lector["IDArticulo"];
                    if (!(datos.Lector["IDTalla"] is DBNull))
                        aux.IDTalla = (byte)datos.Lector["IDTalla"];
                    if (!(datos.Lector["Stock"] is DBNull))
                        aux.Stock = (long)datos.Lector["Stock"];
                    if (!(datos.Lector["Talle"] is DBNull))
                        aux.Talle = (string)datos.Lector["Talle"];
                    if (!(datos.Lector["EstadoArticuloTalla"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoArticuloTalla"];

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
        public void agregarTallaArticulo(ArticuloTalla articuloTalla)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarTallaArticulo");
                datos.setParametros("@idArticulo", articuloTalla.IDArticulo);
                datos.setParametros("@idTalla", articuloTalla.IDTalla);
                datos.setParametros("@stock", articuloTalla.Stock);
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

        public void modificarTallaArticulo(ArticuloTalla articuloTalla)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarTallaArticulo");
                datos.setParametros("@idArticulo", articuloTalla.IDArticulo);
                datos.setParametros("@idTalla", articuloTalla.IDTalla);
                datos.setParametros("@stock", articuloTalla.Stock);
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

        public void eliminarTallaArticulo(ArticuloTalla articuloTalla)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarTallaArticulo");
                datos.setParametros("@idArticulo", articuloTalla.IDArticulo);
                datos.setParametros("@idTalla", articuloTalla.IDTalla);
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

        public ArticuloTalla obtenerArticuloTalla(long idArticulo, byte idTalla)
        {
            ArticuloTalla articuloTalla = new ArticuloTalla();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ObtenerArticuloTalla");
                datos.setParametros("@idArticulo", idArticulo);
                datos.setParametros("@idTalla", idTalla);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    if (!(datos.Lector["Stock"] is DBNull))
                        articuloTalla.Stock = (long)datos.Lector["Stock"];
                }

                return articuloTalla;

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
