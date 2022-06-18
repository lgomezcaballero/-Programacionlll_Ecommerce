using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
namespace Negocio
{
    public class MarcaNegocio
    {
        public List<Marca> listar()
        {
            List<Marca> lista = new List<Marca>();      
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("select m.IDMarca, m.Nombre, m.FechaRegistro, m.Estado from Marcas as M ");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca aux = new Marca();
                    if (!(datos.Lector["IDMarca"] is DBNull))
                        aux.ID =  (Int16)datos.Lector["IDMarca"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["FechaRegistro"] is DBNull))
                        aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
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

    }
}
