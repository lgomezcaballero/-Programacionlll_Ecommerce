using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class Login : System.Web.UI.Page
    {
        //Este atributo lo puse para para que aparezca un mensaje en caso de no estar logueado
        public bool SeLogueo = true;
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
            Usuario usuariologin = new Usuario();



            //Esto es temporal hasta que pueda hacerlo por una consulta
            List<Usuario> listaUsuarios;
            listaUsuarios = usuarioNegocio.listar();


            usuariologin.NombreUsuario = TxtNombreUsuario.Text;
            usuariologin.Contraseña = TxtContraseña.Text;
            string TipoUsuario;

            foreach (var item in listaUsuarios)
            {
                if (item.NombreUsuario == usuariologin.NombreUsuario && item.Contraseña == usuariologin.Contraseña)
                {
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
                Response.Redirect("Home.aspx", false);
            }
            else
            {
                SeLogueo = false;
                Session.Add("error", "Usuario o contraseña incorrectos");
                //LabelDatosIncorrectos.Text = "Usuario o contraseña incorrectos";
                //Response.Redirect("Login", false);
                Response.Redirect("ErrorLogin.aspx", false);
                //Response.Redirect("ErrorLogin.aspx", false);
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