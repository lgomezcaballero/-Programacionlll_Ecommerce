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
    public partial class LoginSinMaster : System.Web.UI.Page
    {

        public bool SeLogueo = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TxtNombreUsuario.Text = "Admin";
                TxtContraseña.Text = "123";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

            if(TxtNombreUsuario.Text == "" ||
                TxtContraseña.Text == "")
            {
                LabelError.Text = "Debe llenar los campos";
            }


            else
            {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuariologin = new Usuario();



            //Esto es temporal hasta que pueda hacerlo por una consulta
            List<Usuario> listaUsuarios;
            listaUsuarios = usuarioNegocio.listar();


            usuariologin.NombreUsuario = TxtNombreUsuario.Text;
            usuariologin.Contraseña = TxtContraseña.Text;
            string TipoUsuario;
            byte TipousuarioNumero = 0; //Con esta variable obtengo el numero del tipo de usuario que se haya logueado

            foreach (var item in listaUsuarios)
            {
                if (item.NombreUsuario == usuariologin.NombreUsuario && item.Contraseña == usuariologin.Contraseña)
                {
                    TipousuarioNumero = (byte)item.TipoUsuario.ID; //Aca lo guardo
                    TipoUsuario = item.TipoUsuario.NombreTipo;
                    usuariologin.TipoUsuario = new TipoUsuario();
                    usuariologin.TipoUsuario.NombreTipo = TipoUsuario;
                    Session.Add("IDUsuarioLogueado", item.ID);
                    Session.Add("CarritoUsuario", obtenerCarritoUsuario(item.ID));
                    continue;
                }
            }

            if (usuarioNegocio.Loguear(usuariologin) == true)
            {
                SeLogueo = true;
                Session.Add("TeLogueaste", usuariologin);
                if(TipousuarioNumero == 1)
                    {
                        Response.Redirect("HomeAdmin.aspx", false);
                        Session.Add("Admin", TipousuarioNumero);
                    }
                    else
                    {
                        Response.Redirect("Home.aspx", false);
                    }
            }
            else
            {
                SeLogueo = false;
                Session.Add("error", "Usuario o contraseña incorrectos");
                //LabelDatosIncorrectos.Text = "Usuario o contraseña incorrectos";
                //Response.Redirect("Login", false);
                LabelError.Text = "Usuario o contraseña incorrectos";
                //Response.Redirect("ErrorLogin.aspx", false);
                //Response.Redirect("ErrorLogin.aspx", false);
            }

            }

        }

        protected Dominio.Carrito obtenerCarritoUsuario(long idUsuario)
        {
            Dominio.Carrito carrito = new Dominio.Carrito();
            carrito.ArticulosCarrito = new List<ArticuloCarrito>();
            CarritoNegocio negocio = new CarritoNegocio();
            carrito = negocio.mostrarCarrito(idUsuario);
            return carrito;
        }
    }
}