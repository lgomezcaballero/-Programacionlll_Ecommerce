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
                datos.setConsulta("select c.IDCategoria, c.Nombre, c.FechaRegistro, c.Estado from Categorias as C");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.ID = (Int16)datos.Lector["IDCategoria"];
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


        }
    }
}