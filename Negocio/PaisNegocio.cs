using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Negocio;
using Dominio;

namespace Negocio
{
    public class PaisNegocio
    {
        public List<Pais> listar() //Tengo que probarlo
        {
            List<Pais> lista = new List<Pais>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarPais");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Pais aux = new Pais();

                    if (!(datos.Lector["ID"] is DBNull))
                        aux.ID = (byte)datos.Lector["ID"];
                    if (!(datos.Lector["NombrePais"] is DBNull))
                        aux.NombrePais = (string)datos.Lector["NombrePais"];
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

        public void AgregarPais(Pais pais) //Tengo que probarlo, creo que tengo que ponerle el estado 
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Creo que aca va el estado
                datos.setConsultaSP("SP_AgregarPais");
                datos.setParametros("@NombrePais", pais.NombrePais);
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

        public void ModificarPais(Pais pais)  //Falta probar
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarPais");
                datos.setParametros("@ID", pais.ID);
                datos.setParametros("@NombrePais", pais.NombrePais);
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

        public void EliminarPais(byte ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarPais");
                datos.setParametros("@ID", ID);
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
        }//Falta probar 
    }
}
