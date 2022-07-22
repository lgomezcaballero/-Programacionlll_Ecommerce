using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce.Pages
{
    public partial class Registrarse : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Estam parte es para cargar las dropdowns
            //Pais dropdownlist
            List<Pais> listapaises = new List<Pais>();
            PaisNegocio paisNegocio = new PaisNegocio();

            try
            {
                if (!IsPostBack)
                {
                    List<Provincia> listaprovincia = new List<Provincia>();
                    ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                    listaprovincia = provinciaNegocio.listar();
                    Session.Add("listaprovincia", listaprovincia);

                    //Esto es para el dropdownlist de localidad
                    List<Localidad> listalocalidad = new List<Localidad>();
                    LocalidadNegocio localidadNegocio = new LocalidadNegocio();
                    listalocalidad = localidadNegocio.listar();
                    Session.Add("listalocalidad", listalocalidad);


                    listapaises = paisNegocio.listar();
                    DropDownListPaises.DataSource = listapaises;
                    DropDownListPaises.DataTextField = "NombrePais";
                    DropDownListPaises.DataValueField = "ID";
                    DropDownListPaises.DataBind();

                    //Esto precarga las provincias solo por primera vez
                    int id = int.Parse(DropDownListPaises.SelectedItem.Value);
                    DropDownListProvincia.DataSource = ((List<Provincia>)Session["listaprovincia"]).FindAll(x => x.Pais.ID == id);
                    DropDownListProvincia.DataValueField = "ID";
                    DropDownListProvincia.DataTextField = "NombreProvincia";
                    DropDownListProvincia.DataBind();

                    //Esto precarga las localidades solo por primera vez
                    int idLocalidad = int.Parse(DropDownListProvincia.SelectedItem.Value);

                    DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listalocalidad"]).FindAll(x => x.Provincia.ID == idLocalidad);
                    DropDownListLocalidad.DataValueField = "ID";
                    DropDownListLocalidad.DataTextField = "NombreLocalidad";
                    DropDownListLocalidad.DataBind();

                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        protected void DropDownListPaises_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(DropDownListPaises.SelectedItem.Value);

            DropDownListProvincia.DataSource = ((List<Provincia>)Session["listaprovincia"]).FindAll(x => x.Pais.ID == id);
            DropDownListProvincia.DataBind();
            if (DropDownListProvincia.Items.Count > 0)
            {
                DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listalocalidad"]).FindAll
                    (x => x.Provincia.ID == int.Parse(DropDownListProvincia.SelectedItem.Value));
                DropDownListLocalidad.DataBind();
            }


        }


        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(DropDownListProvincia.SelectedItem.Value);

            DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listalocalidad"]).FindAll(x => x.Provincia.ID == id);
            DropDownListLocalidad.DataBind();
        }



        protected void BtnAgregarUsuario_Click(object sender, EventArgs e)
        {


            if (CompletarCampos() == false)
            {
                LabelErrorCampos.Text = "Complete todos los campos";
            }

            else
            {
                if (ValidarDni() == true)
                {
                    LabelErrorCampos.Text = "El dni que ingreso ya existe";
                }


                else
                {
                    //Esto valida que usuario el usuario que se ingresar no este repetido en la base
                    if (validarUsuario(TxtNombreUsuario.Text) == true)
                    {
                        LabelErrorCampos.Text = "Ese nombre de usuario ya esta en uso, intente con otro nombre";
                    }

                    else
                    {

                        if (ValidaEmail() == true)
                        {
                            LabelErrorCampos.Text = "El mail que ingresso ya esta en uso, intente con otro mail";
                        }


                        else
                        {
                            //Valido que la contraseña se escriba bien las dos veces
                            if (validarContraseña(TxtContraseña.Text, TxtRepetirContraseña.Text) == true)
                            {

                                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                                Usuario usuario = new Usuario();


                                ContactoNegocio contactoNegocio = new ContactoNegocio();


                                //Datos Usuario
                                usuario.Apellidos = TxtApellidos.Text;
                                usuario.Nombres = TxtNombres.Text;
                                usuario.DNI = TxtDNI.Text;
                                usuario.NombreUsuario = TxtNombreUsuario.Text;
                                usuario.Contraseña = TxtContraseña.Text;


                                //Tipo Usuario
                                //Esto se carga de manera automatica
                                usuario.TipoUsuario = new TipoUsuario();
                                usuario.TipoUsuario.ID = 2; // 2 = Normal 1 = Admin


                                //Datos Contacto falta que de alguna forma guarde esto
                                usuario.Contacto = new Contacto();
                                //usuario.Contacto.ID = como hago para obtener el id del usuario?

                                usuario.Contacto.Email = TxtEmail.Text;
                                usuario.Contacto.Telefono = TxtTelefono.Text;

                                //contactoNegocio.agregarContacto(usuario.Contacto);

                                //Localidad
                                usuario.Localidad = new Localidad();
                                usuario.Localidad.ID = int.Parse(DropDownListLocalidad.SelectedItem.Value);


                                //Localidad > Provincia
                                //usuario.Localidad.Provincia = new Provincia();
                                //usuario.Localidad.Provincia.ID = int.Parse(DropDownListProvincia.SelectedItem.Value);
                                //Localidad > Provincia > Pais
                                // usuario.Localidad.Provincia.Pais = new Pais();
                                //usuario.Localidad.Provincia.Pais.ID = byte.Parse(DropDownListProvincia.SelectedItem.Value);


                                //Agrego el usuario a la base
                                if (!existeUsuario(usuario, usuarioNegocio))
                                    usuarioNegocio.agregarUsuario(usuario);

                                Response.Redirect("LoginSinMaster.aspx", false);


                            }

                            else
                            {
                                LabelErrorCampos.Text = "Las contraseñas ingresadas no coinciden";
                            }


                        }



                    }
                }

            }


        }

        protected bool existeUsuario(Usuario usuario, UsuarioNegocio usuarioNegocio)
        {
            foreach (var item in usuarioNegocio.listar(true))
            {
                if (item.NombreUsuario.Equals(usuario.NombreUsuario))
                {
                    usuarioNegocio.RestaurarUsuario(usuario);
                    return true;
                }
            }
            return false;
        }

        protected bool CompletarCampos()
        {
            if (TxtApellidos.Text == "" ||
                TxtNombres.Text == "" ||
                TxtDNI.Text == "" ||
                TxtNombreUsuario.Text == "" ||
                TxtContraseña.Text == "" ||
                TxtRepetirContraseña.Text == "" ||
                TxtEmail.Text == "" ||
                TxtTelefono.Text == "")
            {
                return false;
            }

            else
            {
                return true;
            }
        }

        //Este metodo valida que la contraseña este escrita bien las dos veces
        protected bool validarContraseña(string Contraseña, string ConstraseñaRepetida)
        {
            if (Contraseña == ConstraseñaRepetida)
            { return true; }

            return false;
        }

        //esto lo dejo para despues 
        //protected bool MailExiste(string Email)
        //{
        //   List<Usuario> usuarioList = new List<Usuario>();     
        //   UsuarioNegocio usuarioNegocio = new UsuarioNegocio();



        //}

        protected bool validarUsuario(string NombreDeUsuario)
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            usuarios = usuarioNegocio.listar();
            foreach (Usuario usuario in usuarios)
            {
                if (usuario.NombreUsuario == NombreDeUsuario)
                {
                    return true;
                }
            }

            return false;
        }


        protected bool ValidarDni()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarios = usuarioNegocio.listar();

            foreach (Usuario usuario in usuarios)
            {
                if (TxtDNI.Text == usuario.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        protected bool ValidaEmail()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarios = usuarioNegocio.listar();

            foreach (Usuario usuario in usuarios)
            {
                if (TxtEmail.Text == usuario.Contacto.Email)
                {
                    return true;
                }
            }

            return false;
        }
    }
}