using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarCategorias");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    if(!(datos.Lector["IDCategoria"] is DBNull))
                    aux.ID = (Int16)datos.Lector["IDCategoria"];
                    if(!(datos.Lector["Nombre"] is DBNull))
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    if(!(datos.Lector["FechaRegistro"] is DBNull))
                    aux.FechaRegistro = (DateTime)datos.Lector["FechaRegistro"];
                    if(!(datos.Lector["Estado"] is DBNull))
                    aux.Estado = (bool)datos.Lector["Estado"];

                    lista.Add(aux);
                }

                return lista;

            }
            catch (Exception ex)
            {

                throw ex;
            }


        }
    }
}