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
                    Usuario usuario = new Usuario();

                    //TP lean

                    if (!IsPostBack)
                    {
                        if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                        {
                            tipo = Request.QueryString["Type"];
                            id = long.Parse(Request.QueryString["ID"]);
                        }
                        if (Request.QueryString["Type"] == "a")
                            tipo = Request.QueryString["Type"];
                        if (tipo == "e")
                        {
                            /*
                            //Con esta funciom obtine el articulo que se busca
                            provincia = obtenerProvincia(id);
                            //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                             setearCamposModificarPais(pais);*/
                        }

                        if (Request.QueryString["Type"] == "d")
                        {
                            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
                            usuarioNegocio.eliminarUsuario(id);
                            Response.Redirect("ListarUsuarios.aspx", false);
                        }
                    }
                }
            }
        }
    }
}