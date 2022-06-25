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
                datos.setConsultaSP("SP_ListarTipoUsuario");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    TipoUsuario aux = new TipoUsuario();
                    if (!(datos.Lector["IDTipoUsuario"] is DBNull))
                        aux.ID = (byte)datos.Lector["IDTipoUsuario"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.NombreTipo = (string)datos.Lector["Nombre"];
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

        public void agregarTipoUsuario(TipoUsuario tipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarTipoUsuario");
                datos.setParametros("@nombreTipo", tipoUsuario.NombreTipo);
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

        public void modificarTipoUsuario(TipoUsuario tipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarTipoUsuario");
                datos.setParametros("@idTipoUsuario", tipoUsuario.ID);
                datos.setParametros("@nombreTipo", tipoUsuario.NombreTipo);
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

        public void eliminarTipoUsuario(byte idTipoUsuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarTipoUsuario");
                datos.setParametros("@idTipoUsuario", idTipoUsuario);
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
