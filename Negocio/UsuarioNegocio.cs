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
                datos.setConsulta("select u.IDUsuario, u.Apellidos, u.Nombres,u.DNI," + 
                    "u.NombreUsuario, u.Contraseña, u.IDTipoUsuario, u.IDLocalidad," +
                    "u.Estado, tu.IDTipoUsuario, tu.Nombre NombreTipo, tu.Estado EstadoTipo" + 
                    "l.IDLocalidad, l.CP, l.IDProvincia, l.Nombre NombreLocalidad, l.Estado EstadoLocalidad," + 
                    "p.IDProvincia, p.IDPais, p.Nombre, p.Estado, pa.IDPais, pa.Nombre, " +
                    "pa.Estado EstadoPais from Usuarios as U inner join TiposUsuarios as TU " + 
                    "on u.IDTipoUsuario = tu.IDTipoUsuario inner join Localidad as L" +
                    "on u.IDLocalidad = l.IDLocalidad inner join Provincias as P " + 
                    "on l.IDProvincia = p.IDProvincia inner join Pais as PA " + 
                    "on p.IDPais = pa.IDPais");
                    datos.ejecutarLectura();
                while (datos.Lector.Read()) 
                {
                    Usuario aux = new Usuario();    

                    aux.ID = (long)datos.Lector["IDUsuario"]; //ok
                    aux.Apellidos = (string)datos.Lector["Apellidos"]; //ok
                    aux.Nombres = (string)datos.Lector["Nombres"]; //ok
                    aux.DNI = (string)datos.Lector["DNI"]; //ok
                    aux.NombreUsuario = (string)datos.Lector["NombreUsuario"]; //ok
                    aux.Contraseña = (string)datos.Lector["Contraseña"]; //ok

                    aux.TipoUsuario = new TipoUsuario();
                    //No me convence esto
                    aux.TipoUsuario.ID = (byte)datos.Lector["IDTipoUsuario"]; //ok
                    aux.TipoUsuario.NombreTipo = (string)datos.Lector["NombreTipo"]; //ok
                    aux.TipoUsuario.Estado = (bool)datos.Lector["EstadoTipo"]; //ok

                    /*
                    //Falta hacer el join a contactos
                    aux.Contacto = new Contacto();
                    aux.Contacto.ID = (long)datos.Lector["ID"];
                    aux.Contacto.Email = (string)datos.Lector["Email"];
                    aux.Contacto.Telefono = (string)datos.Lector["Telefono"];
                    */
                   
                    aux.Localidad = new Localidad();
                    aux.Localidad.ID = (int)datos.Lector["IDLocalidad"]; // ok
                    aux.Localidad.CodigoPostal = (string)datos.Lector["CP"]; //ok
                    aux.Localidad.NombreLocalidad = (string)datos.Lector["NombreLocalidad"]; //ok
                    aux.Localidad.Estado = (bool)datos.Lector["EstadoLocalidad"]; //ok 
                    
                    
                    aux.Localidad.Provincia.Pais = new Pais();
                    aux.Localidad.Provincia.ID = (int)datos.Lector["IDProvincia"]; //ok
                    aux.Localidad.Provincia.Pais.ID = (byte)datos.Lector["IDPais"]; //ok
                    aux.Localidad.Provincia.Pais.NombrePais = (string)datos.Lector["Nombre"]; //ok
                    aux.Localidad.Provincia.Pais.Estado = (bool)datos.Lector["EstadoPais"];
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
