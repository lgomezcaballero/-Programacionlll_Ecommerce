﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class TallaNegocio
    {


        public List<Talla> listar()
        {
            List<Talla> lista = new List<Talla>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarTallas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Talla aux = new Talla();
                    if (!(datos.Lector["IDTalla"] is DBNull))
                        aux.IDTalla = (byte)datos.Lector["IDTalla"];
                    if (!(datos.Lector["Talla"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Talla"];
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
