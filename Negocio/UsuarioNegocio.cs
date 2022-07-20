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
        public List<Usuario> listar(bool b = false)
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

                    //Esto valida que se cargue a la lista un usuario que este con estado false

                    if (!b)
                    {
                        if (aux.Estado)
                        {
                            lista.Add(aux);
                        }
                    }
                    else
                    {
                        lista.Add(aux);
                    }
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
        public void agregarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_AgregarUsuario");
                datos.setParametros("@apellidos", usuario.Apellidos);
                datos.setParametros("@nombres", usuario.Nombres);
                datos.setParametros("@dni", usuario.DNI);
                datos.setParametros("@nombreUsuario", usuario.NombreUsuario);
                datos.setParametros("@contraseña", usuario.Contraseña);
                datos.setParametros("@idTipoUsuario", usuario.TipoUsuario.ID);
                datos.setParametros("@idLocalidad", usuario.Localidad.ID);
                datos.setParametros("@email", usuario.Contacto.Email);
                datos.setParametros("@telefono", usuario.Contacto.Telefono);
                datos.ejecutarAccion();
                //agregarContacto(usuario);
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

        public void modificarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_ModificarUsuario");
                datos.setParametros("@idUsuario", usuario.ID);
                datos.setParametros("@apellidos", usuario.Apellidos);
                datos.setParametros("@nombres", usuario.Nombres);
                datos.setParametros("@dni", usuario.DNI);
                datos.setParametros("@nombreUsuario", usuario.NombreUsuario);
                datos.setParametros("@contraseña", usuario.Contraseña);
                datos.setParametros("@idTipoUsuario", usuario.TipoUsuario.ID);
                datos.setParametros("@idLocalidad", usuario.Localidad.ID);
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

        /*public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca, " +
                    "c.Descripcion Categoria, a.ImagenUrl, a.Precio, m.Id as IdMarca, c.Id as IdCategoria From ARTICULOS a " +
                    "Inner Join MARCAS m on a.IdMarca = m.Id Inner Join CATEGORIAS c on a.IdCategoria = c.Id " +
                    "Where ";
                switch (campo)
                {
                    case "Código":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "a.Codigo like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "a.Codigo like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "a.Codigo like '%" + filtro + "%'";
                                break;

                            default:
                                consulta += "a.Codigo like '%%'";
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Empieza con":
                                consulta += "a.Nombre like '" + filtro + "%'";
                                break;

                            case "Termina con":
                                consulta += "a.Nombre like '%" + filtro + "'";
                                break;

                            case "Contiene":
                                consulta += "a.Nombre like '%" + filtro + "%'";
                                break;

                            default:
                                consulta += "a.Nombre like '%%'";
                                break;
                        }
                        break;

                    case "Precio":
                        switch (criterio)
                        {
                            case "Menor a":
                                consulta += "a.Precio < " + filtro;
                                break;

                            case "Mayor a":
                                consulta += "a.Precio > " + filtro;
                                break;

                            case "Igual a":
                                consulta += "a.Precio = " + filtro;
                                break;
                            default:
                                consulta = "Select a.ID, a.Codigo, a.Nombre, a.Descripcion, m.Descripcion Marca, " +
                                "c.Descripcion Categoria, a.ImagenUrl, a.Precio, m.Id as IdMarca, c.Id as IdCategoria From ARTICULOS a " +
                                "Inner Join MARCAS m on a.IdMarca = m.Id Inner Join CATEGORIAS c on a.IdCategoria = c.Id " +
                                "Where a.Activo = 1";
                                break;
                        }
                        break;
                }
                datos.setConsulta(consulta);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.ID = (int)datos.Lector["Id"];
                    if (!(datos.Lector["Codigo"] is DBNull))
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    if (!(datos.Lector["Nombre"] is DBNull))
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    if (!(datos.Lector["Descripcion"] is DBNull))
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    if (!(datos.Lector["Marca"] is DBNull))
                        aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    if (!(datos.Lector["Categoria"] is DBNull))
                        aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    if (!(datos.Lector["ImagenUrl"] is DBNull))
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    if (!(datos.Lector["Precio"] is DBNull))
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    if (!(datos.Lector["IdMarca"] is DBNull))
                        aux.Marca.ID = (int)datos.Lector["IdMarca"];
                    if (!(datos.Lector["IdCategoria"] is DBNull))
                        aux.Categoria.ID = (int)datos.Lector["IdCategoria"];

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
        }*/

        public void eliminarUsuario(long id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_EliminarUsuario");
                datos.setParametros("@idUsuario", id);
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


        public bool Loguear(Usuario usuariologin)
        {
            //AccesoDatos datos = new AccesoDatos();
            try
            {

                //Voy hacer la consulta enbebida por ahora, pero esto tiene que estar en procedimiento  
                //datos.setConsulta("select u.IDUsuario, u.NombreUsuario, u.Contraseña from Usuarios U where u.NombreUsuario = @NombreUsuario and u.Contraseña = @Contraseña");
                //datos.setParametros("@NombreUsuario", NombreUsuario);
                //datos.setParametros("@Contraseña", Contraseña);



                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                List<Usuario> listausuarios = new List<Usuario>();
                Usuario usuario = new Usuario();
                listausuarios = usuarioNegocio.listar();

                foreach (var item in listausuarios)
                {
                    if (item.NombreUsuario == usuariologin.NombreUsuario && item.Contraseña == usuariologin.Contraseña)
                    {

                        return true;
                    }

                }

                return false;

                //datos.ejecutarLectura();        

                /*
                while(datos.Lector.Read() == true) 
                {

                    if()
                    return true;
                }*/

            }
            catch (Exception ex)
            {

                throw ex;
            }

        }

        public void RestaurarUsuario(Usuario usuario)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsultaSP("SP_RestaurarUsuario");
                datos.setParametros("@idUsuario", obtenerUsuario(usuario.NombreUsuario));
                datos.setParametros("@apellidos", usuario.Apellidos);
                datos.setParametros("@nombres", usuario.Nombres);
                datos.setParametros("@dni", usuario.DNI);
                datos.setParametros("@nombreUsuario", usuario.NombreUsuario);
                datos.setParametros("@contraseña", usuario.Contraseña);
                datos.setParametros("@idTipoUsuario", usuario.TipoUsuario.ID);
                datos.setParametros("@idLocalidad", usuario.Localidad.ID);
                datos.setParametros("@email", usuario.Contacto.Email);
                datos.setParametros("@telefono", usuario.Contacto.Telefono);
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

        protected long obtenerUsuario(string nombre)
        {
            foreach (var item in listar(true))
            {
                if (item.NombreUsuario.Equals(nombre))
                    return item.ID;
            }
            return -1;
        }

        //public void agregarContacto(Usuario usuario)
        //{
        //    ContactoNegocio negocio = new ContactoNegocio();
        //    usuario.Contacto.ID = this.obtenerIDUsuarioNuevo(usuario.Contacto);
        //    negocio.agregarContacto(usuario.Contacto);
        //}

        //public long obtenerIDUsuarioNuevo(Contacto contacto)
        //{
        //    AccesoDatos datos = new AccesoDatos();
        //    try
        //    {
        //        datos.setConsultaSP("SP_ObtenerIDUsuarioNuevo");
        //        datos.ejecutarLectura();
        //        if (datos.Lector.Read())
        //        {
        //            if (!(datos.Lector["IDUsuario"] is DBNull))
        //                contacto.ID = (long)datos.Lector["IDUsuario"]; //ok

        //        }
        //        return contacto.ID;
        //    }
        //    catch (Exception ex)
        //    {

        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.cerrarConexion();
        //    }
        //}
    }
}
