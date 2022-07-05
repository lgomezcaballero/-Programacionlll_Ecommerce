using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos = new List<Articulo>();
        ArticuloNegocio negocio = new ArticuloNegocio(); //ok

        //Esto es para el abm de paises
        public List<Pais> listaPaises = new List<Pais>(); //ok
        PaisNegocio paisNegocio = new PaisNegocio();

        //Esto lo hago para el abm de provincias
        public List<Provincia> listaProvincias = new List<Provincia>(); //ok
        ProvinciaNegocio provincianegocio = new ProvinciaNegocio();

        //Esto lo hago para el abm de provincias
        public List<Categoria> listacategoria = new List<Categoria>(); //ok
        CategoriaNegocio categoriaNegocio = new CategoriaNegocio();

        //Esto lo hago para el abm de provincias
        public List<Marca> listademarcas = new List<Marca>(); //ok
        MarcaNegocio marcaNegocio = new MarcaNegocio();

        //Esto lo hago para el abm de localidades
        public List<Localidad> listalocalidades = new List<Localidad>(); //ok
        LocalidadNegocio localidadNegocio = new LocalidadNegocio();

        //Esto lo hago para el abm de Usuarios
        public List<Usuario> listausuarios = new List<Usuario>(); //ok
        UsuarioNegocio usuarioNegocio = new UsuarioNegocio();



        protected void Page_Load(object sender, EventArgs e)
        {

            //No me convence del todo esto
            if (Session["TeLogueaste"] == null && ((Usuario)Session["TeLogueaste"]).TipoUsuario.NombreTipo != "Administrador")
            {
                Session.Add("error", "Solo lo los administradores pueden acceder a la pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }


            listaArticulos = negocio.listar();
            if (!IsPostBack)
                Session.Add("listaArticulos", listaArticulos);

            //Esto lo hago para guardar el pais en session 
            listaPaises = paisNegocio.listar();
            if (!IsPostBack)
                Session.Add("listapaises", listaPaises);

            //Esto lo hago para guardar el las provincias en session 
            listaProvincias = provincianegocio.listar();
            if (!IsPostBack)
                Session.Add("listaProvincias", listaProvincias);

            //Esto lo hago para guardar las categorias en la session 
            listacategoria = categoriaNegocio.listar();
            if (!IsPostBack)
                Session.Add("listacategoria", listacategoria);


            listademarcas = marcaNegocio.listar();
            if (!IsPostBack)
                Session.Add("listademarcas", listademarcas);

            //Esto lo hago para guardar las localidades en la session //ok
            if (!IsPostBack)
                Session.Add("listalocalidades", listalocalidades);

            //Esto lo hago para guardar los Usuarios en la session //ok
            listausuarios = usuarioNegocio.listar();
            if (!IsPostBack)
                Session.Add("listausuarios", listausuarios);
        }


    }
}