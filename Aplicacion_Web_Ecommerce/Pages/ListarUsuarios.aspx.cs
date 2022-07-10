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
    public partial class ListarUsuarios : System.Web.UI.Page
    {

        //Esto lo hago para el abm de Usuarios
        public List<Usuario> listausuarios = new List<Usuario>(); //ok
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();
        protected void Page_Load(object sender, EventArgs e)
        {
            //Esto lo hago para guardar los Usuarios en la session //ok
            listausuarios = usuarioNegocio.listar();
            if (!IsPostBack)
                Session.Add("listausuarios", listausuarios);
        }
    }
}