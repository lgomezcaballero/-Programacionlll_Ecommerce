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
        public List<Provincia> listar() //Tengo que probarlo
        {
            List<Provincia> lista = new List<Provincia>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarPais");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Provincia aux = new Provincia();

                    if (!(datos.Lector["IDProvincia"] is DBNull))
                        aux.ID = (int)datos.Lector["IDProvincia"];

                    aux.Pais = new Pais();
                    if (!(datos.Lector["IDPais"] is DBNull))
                        aux.Pais.ID = (byte)datos.Lector["IDPais"];

                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Pais.NombrePais = (string)datos.Lector["Nombre"];

                    if (!(datos.Lector["EstadoPais"] is DBNull))
                        aux.Pais.Estado = (bool)datos.Lector["EstadoPais"];

                    if (!(datos.Lector["NombreProvincia"] is DBNull))
                        aux.NombreProvincia = (string)datos.Lector["NombreProvincia"];

                    if (!(datos.Lector["Estado"] is DBNull))
                        aux.Estado = (bool)datos.Lector["Estado"];

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

        public void agregarArticulo(Provincia provincia) //Falta probarlo
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarProvincia");
                datos.setParametros("@IDProvincia", provincia.ID);
                datos.setParametros("@IDPais", provincia.Pais.ID);
                datos.setParametros("@Nombre", provincia.NombreProvincia);
                datos.setParametros("@Estado", provincia.Estado);
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

        public void modificarArticulo(Provincia provincia) //Falta probarlo
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarProvincia");
                datos.setParametros("@IDProvincia", provincia.ID);
                datos.setParametros("@IDPais", provincia.Pais.ID);
                datos.setParametros("@Nombre", provincia.NombreProvincia);
                datos.setParametros("@Estado", provincia.Estado);
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
