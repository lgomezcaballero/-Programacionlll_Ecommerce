using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Aplicacion_Web_Ecommerce.Pages
{

    public partial class AMBUsuarios : System.Web.UI.Page
    {
        public long id;
        public string tipo;
        protected void Page_Load(object sender, EventArgs e)
        {



            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {

                if (Session["Admin"] == null)
                {
                    Session.Add("error", "solo los administradores pueden acceder a esta pagina");
                    Response.Redirect("ErrorAcceso.aspx", false);
                }

                else
                {

                    //Estam parte es para cargar las dropdowns
                    //Pais dropdownlist
                    List<Pais> listapaises = new List<Pais>();
                    PaisNegocio paisNegocio = new PaisNegocio();
                    Usuario usuario = new Usuario();

                    //TP lean

                    if (!IsPostBack)
                    {
                        List<Provincia> listaprovincia = new List<Provincia>();
                        ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                        listaprovincia = provinciaNegocio.listar();
                        Session.Add("listaDeprovincia", listaprovincia);

                        //Esto es para el dropdownlist de localidad
                        List<Localidad> listalocalidad = new List<Localidad>();
                        LocalidadNegocio localidadNegocio = new LocalidadNegocio();
                        listalocalidad = localidadNegocio.listar();
                        Session.Add("listaDelocalidad", listalocalidad);


                        listapaises = paisNegocio.listar();
                        DropDownListPaises.DataSource = listapaises;
                        DropDownListPaises.DataTextField = "NombrePais";
                        DropDownListPaises.DataValueField = "ID";
                        DropDownListPaises.DataBind();

                        //Esto precarga las provincias solo por primera vez
                        int ID = int.Parse(DropDownListPaises.SelectedItem.Value);
                        DropDownListProvincia.DataSource = ((List<Provincia>)Session["listaDeprovincia"]).FindAll(x => x.Pais.ID == ID);
                        DropDownListProvincia.DataValueField = "ID";
                        DropDownListProvincia.DataTextField = "NombreProvincia";
                        DropDownListProvincia.DataBind();

                        //Esto precarga las localidades solo por primera vez
                        int idLocalidad = int.Parse(DropDownListProvincia.SelectedItem.Value);

                        DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll(x => x.Provincia.ID == idLocalidad);
                        DropDownListLocalidad.DataValueField = "ID";
                        DropDownListLocalidad.DataTextField = "NombreLocalidad";
                        DropDownListLocalidad.DataBind();



                    }
                    if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                    {
                        tipo = Request.QueryString["Type"];
                        id = long.Parse(Request.QueryString["ID"]);
                    }
                    if (Request.QueryString["Type"] == "a")
                        tipo = Request.QueryString["Type"];
                    if (tipo == "e" && !IsPostBack)
                    {
                        //Con esta funciom obtine el articulo que se busca
                        usuario = ObtenerUsuario(id);
                        //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                        setearCamposModificarUsuario(usuario);
                    }

                    if (Request.QueryString["Type"] == "d")
                    {
                        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                        usuarioNegocio.eliminarUsuario(id);
                        Response.Redirect("ListarUsuarios.aspx", false);
                    }
                    //else
                    //{
                    //    DropDownListProvincia.DataSource = ((List<Provincia>)Session["listaDeprovincia"]).FindAll(x => x.Pais.ID == id);
                    //    DropDownListProvincia.DataBind();
                    //}
                }
            }
        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Este es el dropdown de agregar
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

        protected void DropDownListPaises_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(DropDownListPaises.SelectedItem.Value);

            DropDownListProvincia.DataSource = ((List<Provincia>)Session["listaDeprovincia"]).FindAll(x => x.Pais.ID == id);
            DropDownListProvincia.DataBind();
            if (DropDownListProvincia.Items.Count > 0)
            {
                DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll
                    (x => x.Provincia.ID == int.Parse(DropDownListProvincia.SelectedItem.Value));
                DropDownListLocalidad.DataBind();
            }

        }

        /////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        //Este es el dropdown de agregar
        ////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
        protected void DropDownListProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {

            int id = int.Parse(DropDownListProvincia.SelectedItem.Value);

            DropDownListLocalidad.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll(x => x.Provincia.ID == id);
            //DropDownListLocalidad.DataValueField = "ID";
            //DropDownListLocalidad.DataTextField = "NombreLocalidad";
            DropDownListLocalidad.DataBind();
            //string nombre = DropDownListLocalidad.SelectedItem.Value;
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
                    if (validarUsuario(TextBoxNombreUsuario.Text) == true)
                    {
                        LabelErrorCampos.Text = "Ese nombre de usuario ya esta en uso, intente con otro nombre";
                    }

                    else
                    {
                        //Valido que la contraseña se escriba bien las dos veces
                        if (validarContraseña(TextBoxContraseña.Text, TextBoxRepetirContraseña.Text) == true)
                        {
                            if (validarEmail(TextBoxEmail.Text))
                            {
                                UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                                Usuario usuario = new Usuario();


                                ContactoNegocio contactoNegocio = new ContactoNegocio();


                                //Datos Usuario
                                usuario.Apellidos = txtApellidos.Text;
                                usuario.Nombres = TxtNombres.Text;
                                usuario.DNI = TextBoxDni.Text;
                                usuario.NombreUsuario = TextBoxNombreUsuario.Text;
                                usuario.Contraseña = TextBoxContraseña.Text;


                                //Tipo Usuario
                                //Esto se carga de manera automatica
                                usuario.TipoUsuario = new TipoUsuario();
                                usuario.TipoUsuario.ID = 2; // 2 = Normal 1 = Admin


                                //Datos Contacto falta que de alguna forma guarde esto
                                usuario.Contacto = new Contacto();
                                //usuario.Contacto.ID = como hago para obtener el id del usuario?

                                usuario.Contacto.Email = TextBoxEmail.Text;
                                usuario.Contacto.Telefono = TextBoxTelefono.Text;

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
                            }
                            else
                            {
                                LabelErrorCampos.Text = "Error, el correo ingresado ya existe.";
                            }

                        }

                        else
                        {
                            LabelErrorCampos.Text = "Las contraseñas ingresadas no coinciden";
                        }

                    }

                }

            }

            Response.Redirect("ListarUsuarios.aspx", false);
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
            if (txtApellidos.Text == "" ||
                TxtNombres.Text == "" ||
                TextBoxDni.Text == "" ||
                TextBoxNombreUsuario.Text == "" ||
                TextBoxContraseña.Text == "" ||
                TextBoxRepetirContraseña.Text == "" ||
                TextBoxEmail.Text == "" ||
                TextBoxTelefono.Text == "")
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

        protected bool validarEmail(string email)
        {
            UsuarioNegocio negocio = new UsuarioNegocio();

            foreach (var item in negocio.listar())
            {
                if (item.Contacto.Email == email)
                {
                    return false;
                }
            }

            return true;
        }


        protected bool ValidarDni()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarios = usuarioNegocio.listar();

            foreach (Usuario usuario in usuarios)
            {
                if (TextBoxDni.Text == usuario.DNI)
                {
                    return true;
                }
            }

            return false;
        }

        protected Usuario ObtenerUsuario(long id)
        {

            List<Usuario> lista = new List<Usuario>();
            Usuario aux = new Usuario();


            //Aca se agrega en session pero ya no me acuerdo para que 
            lista = (List<Usuario>)Session["listausuarios"];
            aux = lista.Find(x => x.ID == id);
            //Aca me guardo el usuario obtenido en sesion para usarlo en editar de abmUsuario



            return aux;

        }


        protected void setearCamposModificarUsuario(Usuario usuario)
        {
            //Datos Usuario
            TextBoxApellidos.Text = usuario.Apellidos;
            TextBoxNombres.Text = usuario.Nombres;
            txtDni.Text = usuario.DNI;
            txtNombreUsuario.Text = usuario.NombreUsuario;
            txtContraseña.Text = usuario.Contraseña;
            TxtBoxRepetirContraseña.Text = usuario.Contraseña;
            TxtBoxEmail.Text = usuario.Contacto.Email;
            TxtBoxTelefono.Text = usuario.Contacto.Telefono;

            PaisNegocio pNegocio = new PaisNegocio();
            DropDownDePaises.DataSource = pNegocio.listar();
            DropDownDePaises.DataTextField = "NombrePais";
            DropDownDePaises.DataValueField = "ID";
            DropDownDePaises.DataBind();
            DropDownDePaises.SelectedValue = usuario.Localidad.Provincia.Pais.ID.ToString();

            int ID = int.Parse(DropDownDePaises.SelectedItem.Value);
            DropDownDeProvincia.DataSource = ((List<Provincia>)Session["listaDeprovincia"]).FindAll(x => x.Pais.ID == ID);
            DropDownDeProvincia.DataValueField = "ID";
            DropDownDeProvincia.DataTextField = "NombreProvincia";
            DropDownDeProvincia.DataBind();
            DropDownDeProvincia.SelectedValue = usuario.Localidad.Provincia.ID.ToString();

            //Esto precarga las localidades solo por primera vez
            int idLocalidad = int.Parse(DropDownDeProvincia.SelectedItem.Value);

            DropDownLocalidades.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll(x => x.Provincia.ID == idLocalidad);
            DropDownLocalidades.DataValueField = "ID";
            DropDownLocalidades.DataTextField = "NombreLocalidad";
            DropDownLocalidades.DataBind();
            DropDownLocalidades.SelectedValue = usuario.Localidad.ID.ToString();
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            Usuario usuario = new Usuario();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();

            Usuario UsuarioObtenido = new Usuario();

            usuario.ID = int.Parse(Request.QueryString["ID"]);
            usuario.Apellidos = TextBoxApellidos.Text;
            usuario.Nombres = TextBoxNombres.Text;
            usuario.DNI = txtDni.Text;
            usuario.NombreUsuario = txtNombreUsuario.Text;
            usuario.Contraseña = txtContraseña.Text;
            usuario.Contacto = new Contacto();
            usuario.Contacto.Email = TxtBoxEmail.Text;
            usuario.Contacto.Telefono = TxtBoxTelefono.Text;
            usuario.TipoUsuario = new TipoUsuario();
            usuario.Localidad = new Localidad();
            usuario.Localidad.Provincia = new Provincia();
            usuario.Localidad.Provincia.Pais = new Pais();
            usuario.Localidad.Provincia.Pais.ID = byte.Parse(DropDownDePaises.SelectedItem.Value);
            usuario.Localidad.Provincia.ID = int.Parse(DropDownDeProvincia.SelectedItem.Value);
            usuario.Localidad.ID = int.Parse(DropDownLocalidades.SelectedItem.Value);

            //Llamo a esta funcion para obtener el id del Usuario que se esta modificando
            UsuarioObtenido = ObtenerUsuario(usuario.ID);
            //usuario.Localidad.ID = UsuarioObtenido.Localidad.ID;

            usuario.TipoUsuario.ID = UsuarioObtenido.TipoUsuario.ID;
            usuarioNegocio.modificarUsuario(usuario);

            Response.Redirect("ListarUsuarios.aspx", false);

        }

        protected void btnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuarios.aspx", false);
        }

        protected void btnAtras_Click1(object sender, EventArgs e)
        {
            Response.Redirect("ListarUsuarios.aspx", false);
        }

        protected void DropDownDePaises_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownDePaises.SelectedItem.Value);

            DropDownDeProvincia.DataSource = ((List<Provincia>)Session["listaDeprovincia"]).FindAll(x => x.Pais.ID == id);
            DropDownDeProvincia.DataBind();
            if (DropDownDeProvincia.Items.Count > 0)
            {
                DropDownLocalidades.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll
                    (x => x.Provincia.ID == int.Parse(DropDownDeProvincia.SelectedItem.Value));
                DropDownLocalidades.DataBind();
            }
        }

        protected void DropDownDeProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = int.Parse(DropDownDeProvincia.SelectedItem.Value);

            DropDownLocalidades.DataSource = ((List<Localidad>)Session["listaDelocalidad"]).FindAll(x => x.Provincia.ID == id);
            DropDownLocalidades.DataBind();
        }

        /*
        protected bool ValidaEmail()
        {
            List<Usuario> usuarios = new List<Usuario>();
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            usuarios = usuarioNegocio.listar();

            foreach (Usuario usuario in usuarios)
            {
                if (TxtEmail.Text == usuario.)
                {
                    return true;
                }
            }

            return false;
        }*/
    }
}