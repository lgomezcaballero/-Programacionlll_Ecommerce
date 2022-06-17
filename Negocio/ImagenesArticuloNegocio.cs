using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class ImagenesArticuloNegocio
    {
        public List<ImagenesArticulo> listar(long idArticulo)
        {
            List<ImagenesArticulo> lista = new List<ImagenesArticulo>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select IDImagen, URLImagen, Estado From Imagenes Where IDArticulo = " + idArticulo);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ImagenesArticulo auxiliar = new ImagenesArticulo();
                    if (!(datos.Lector["IDImagen"] is DBNull))
                        auxiliar.ID = (long)datos.Lector["IDImagen"];
                    if (!(datos.Lector["URLImagen"] is DBNull))
                        auxiliar.URLImagen = (string)datos.Lector["URLImagen"];
                    if (!(datos.Lector["Estado"] is DBNull))
                        auxiliar.Estado = (bool)datos.Lector["Estado"];
                    lista.Add(auxiliar);
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
