using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //datos.setConsulta("select a.IDArticulo, a.Nombre Articulo, a.Descripcion, a.Precio, a.Stock, a.FechaRegistro," +
                //    " a.Estado EstadoArticulo, m.IDMarca, m.Nombre Marca, m.FechaRegistro FechaRegistroMarca, m.Estado EstadoMarca," +
                //    " c.IDCategoria, c.Nombre Categoria, c.FechaRegistro FechaRegistroCategoria, c.Estado EstadoCategoria, g.IDGenero," +
                //    " g.Nombre Genero, g.Estado EstadoGenero From Articulos a Inner Join Marcas m on a.IDMarca = m.IDMarca " +
                //    "Inner Join Categorias c on a.IDCategoria = c.IDCategoria Inner Join Generos g on a.IDGenero = g.IDGenero");
                datos.setConsultaSP("SP_ListarArticulos");
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

                    if (!(datos.Lector["Stock"] is DBNull))
                        aux.Stock = (long)datos.Lector["Stock"];
                    
                    if (!(datos.Lector["FechaRegistro"] is DBNull))
                        aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];

                    if (!(datos.Lector["EstadoArticulo"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoArticulo"];

                    aux.Imagenes = new List<ImagenesArticulo>();
                    ImagenesArticuloNegocio ImagenesNegocio = new ImagenesArticuloNegocio();
                    aux.Imagenes = ImagenesNegocio.listar(aux.ID);
                    //string url = aux.Imagenes[0].URLImagen;
                    //aux.Marca = new Marca();
                    //if (!(datos.Lector["IDMarca"] is DBNull))
                    //    aux.Marca.ID = (int)datos.Lector["IDMarca"];

                    //if (!(datos.Lector["Marca"] is DBNull))
                    //    aux.Marca.Nombre = (string)datos.Lector["Marca"];

                    //if (!(datos.Lector["FechaRegistroMarca"] is DBNull))
                    //    aux.Marca.FechaRegistro = (DateTime)datos.Lector["FechaRegistroMarca"];

                    //if (!(datos.Lector["EstadoMarca"] is DBNull))
                    //    aux.Marca.Estado = (bool)datos.Lector["EstadoMarca"];

                    //aux.Categoria = new Categoria();
                    //if (!(datos.Lector["IDCategoria"] is DBNull))
                    //    aux.Categoria.ID = (int)datos.Lector["IDCategoria"];

                    //if (!(datos.Lector["Categoria"] is DBNull))
                    //    aux.Categoria.Nombre = (string)datos.Lector["Categoria"];

                    //if (!(datos.Lector["FechaRegistroCategoria"] is DBNull))
                    //    aux.Categoria.FechaRegistro = (DateTime)datos.Lector["FechaRegistroCategoria"];

                    //if (!(datos.Lector["EstadoCategoria"] is DBNull))
                    //    aux.Categoria.Estado = (bool)datos.Lector["EstadoCategoria"];

                    //aux.Genero = new Genero();
                    //if (!(datos.Lector["IDGenero"] is DBNull))
                    //    aux.Genero.ID = (int)datos.Lector["IDGenero"];

                    //if (!(datos.Lector["Genero"] is DBNull))
                    //    aux.Genero.Nombre = (string)datos.Lector["Genero"];

                    //if (!(datos.Lector["EstadoGenero"] is DBNull))
                    //    aux.Genero.Estado = (bool)datos.Lector["EstadoGenero"];

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
    }
}
