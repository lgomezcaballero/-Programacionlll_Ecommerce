using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Negocio;

namespace Negocio
{
    public class TipoUsuarioNegocio
    {
        public List<TipoUsuario> listar()
        {
            List<TipoUsuario> lista = new List<TipoUsuario>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarMarcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
                    if (!(datos.Lector["ID"] is DBNull))
                        aux.ID = (byte)datos.Lector["ID"];
                    if (!(datos.Lector["NombreTipo"] is DBNull))
                        aux.NombreTipo = (string)datos.Lector["NombreTipo"];
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

        }//Falta probarlo

        public void agregarTipoUsuario(TipoUsuario Tipo) // Falta probar
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarTipoUsuario");
                datos.setParametros("@NombreTipo", Tipo.NombreTipo);
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

        public void modificarTipoUsuario(TipoUsuario Tipo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarTipoUsuario");
                datos.setParametros("@ID", Tipo.ID);
                datos.setParametros("@NombreTipo", Tipo.NombreTipo);
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

        public void eliminarTipoUsuario(byte ID)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarTipoUsuario");
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
        } //Falta probar

    }
}
