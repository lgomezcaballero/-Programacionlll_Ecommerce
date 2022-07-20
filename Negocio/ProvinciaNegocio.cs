using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class ProvinciaNegocio
    {
        public List<Provincia> listar(bool b = false)
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_listarProvincias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();

                    if (!(datos.Lector["IDProvincia"] is DBNull))
                        aux.ID = (int)datos.Lector["IDProvincia"];

                    if (!(datos.Lector["Provincia"] is DBNull))
                        aux.NombreProvincia = (string)datos.Lector["Provincia"];

                    if (!(datos.Lector["EstadoProvincia"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoProvincia"];

                    aux.Pais = new Pais();
                    if (!(datos.Lector["IDPais"] is DBNull))
                        aux.Pais.ID = (byte)datos.Lector["IDPais"];

                    if (!(datos.Lector["Pais"] is DBNull))
                        aux.Pais.NombrePais = (string)datos.Lector["Pais"];

                    if (!(datos.Lector["EstadoPais"] is DBNull))
                        aux.Pais.Estado = (bool)datos.Lector["EstadoPais"];

                    if (!b)
                    {
                        if (aux.Estado == true)
                        {
                            lista.Add(aux);
                        }
                    }
                    else
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

        public void agregarProvincia(Provincia provincia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarProvincia");
                datos.setParametros("@idPais", provincia.Pais.ID);
                datos.setParametros("@nombre", provincia.NombreProvincia);
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

        public void modificarProvincia(Provincia provincia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarProvincia");
                datos.setParametros("@idProvincia", provincia.ID);
                datos.setParametros("@idPais", provincia.Pais.ID);
                datos.setParametros("@nombre", provincia.NombreProvincia);
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

        public void eliminarProvincia(int idProvincia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarProvincia");
                datos.setParametros("@idProvincia", idProvincia);
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

        public void restaurarProvincia(Provincia provincia)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_RestaurarProvincia");
                datos.setParametros("@idProvincia", provincia.ID);
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
