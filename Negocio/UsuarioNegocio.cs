using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public List<Usuario> listar()
        {
            List<Usuario> lista = new List<Usuario>();  
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsultaSP("SP_ListarUsuarios");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Usuario aux = new Usuario();
                    if (!(datos.Lector["IDUsuario"] is DBNull))
                        aux.ID = (long)datos.Lector["IDUsuario"]; //ok

                    if (!(datos.Lector["Apellidos"] is DBNull))
                        aux.Apellidos = (string)datos.Lector["Apellidos"]; //ok

                    if (!(datos.Lector["Nombres"] is DBNull))
                        aux.Nombres = (string)datos.Lector["Nombres"]; //ok

                    if (!(datos.Lector["DNI"] is DBNull))
                        aux.DNI = (string)datos.Lector["DNI"]; //ok

                    if (!(datos.Lector["NombreUsuario"] is DBNull))
                        aux.NombreUsuario = (string)datos.Lector["NombreUsuario"]; //ok

                    if (!(datos.Lector["Contraseña"] is DBNull))
                        aux.Contraseña = (string)datos.Lector["Contraseña"]; //ok

                    if (!(datos.Lector["EstadoUsuario"] is DBNull))
                        aux.Estado = (bool)datos.Lector["EstadoUsuario"];
                    
                    aux.TipoUsuario = new TipoUsuario();
                    aux.TipoUsuario.ID = (byte)datos.Lector["IDTipoUsuario"]; //ok

                    if (!(datos.Lector["TipoUsuario"] is DBNull))
                        aux.TipoUsuario.NombreTipo = (string)datos.Lector["TipoUsuario"]; //ok

                    if (!(datos.Lector["EstadoTipoUsuario"] is DBNull))
                        aux.TipoUsuario.Estado = (bool)datos.Lector["EstadoTipoUsuario"]; //ok

                    aux.Contacto = new Contacto();
                    aux.Contacto.ID = (long)datos.Lector["IDUsuario"];

                    if (!(datos.Lector["Email"] is DBNull))
                        aux.Contacto.Email = (string)datos.Lector["Email"];

                    if (!(datos.Lector["Telefono"] is DBNull))
                        aux.Contacto.Telefono = (string)datos.Lector["Telefono"];

                    if (!(datos.Lector["EstadoContacto"] is DBNull))
                        aux.Contacto.Estado = (bool)datos.Lector["EstadoContacto"];

                    aux.Localidad = new Localidad();
                    aux.Localidad.ID = (int)datos.Lector["IDLocalidad"]; // ok

                    if (!(datos.Lector["CodigoPostal"] is DBNull))
                        aux.Localidad.CodigoPostal = (string)datos.Lector["CodigoPostal"]; //ok

                    if (!(datos.Lector["NombreLocalidad"] is DBNull))
                        aux.Localidad.NombreLocalidad = (string)datos.Lector["NombreLocalidad"]; //ok

                    if (!(datos.Lector["EstadoLocalidad"] is DBNull))
                        aux.Localidad.Estado = (bool)datos.Lector["EstadoLocalidad"]; //ok 

                    aux.Localidad.Provincia = new Provincia();
                    aux.Localidad.Provincia.ID = (int)datos.Lector["IDProvincia"]; //ok

                    if (!(datos.Lector["Provincia"] is DBNull))
                        aux.Localidad.Provincia.NombreProvincia = (string)datos.Lector["Provincia"];

                    if (!(datos.Lector["EstadoProvincia"] is DBNull))
                        aux.Localidad.Provincia.Estado = (bool)datos.Lector["EstadoProvincia"];

                    aux.Localidad.Provincia.Pais = new Pais();
                    aux.Localidad.Provincia.Pais.ID = (byte)datos.Lector["IDPais"];

                    if (!(datos.Lector["Pais"] is DBNull))
                        aux.Localidad.Provincia.Pais.NombrePais = (string)datos.Lector["Pais"];

                    if (!(datos.Lector["EstadoPais"] is DBNull))
                        aux.Localidad.Provincia.Pais.Estado = (bool)datos.Lector["EstadoPais"];

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
