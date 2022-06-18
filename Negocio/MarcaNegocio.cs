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
                    aux.ID =  (Int16)datos.Lector["IDMarca"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
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
