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
    public partial class Busqueda : System.Web.UI.Page
    {
        public List<Articulo> ListaFiltrada { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //Esto lo hago para validar cuando el usuario quiere ingresar a esta ventana pero no esta logueado

            //Si el usuario no esta logueado entra a este if
            if (Session["TeLogueaste"] == null)
            {
                Session.Add("error", "Debe loguearse para acceder a esta pagina");
                Response.Redirect("ErrorLogin.aspx", false);
            }

            else
            {
                List<Articulo> ListaArticulos = new List<Articulo>();
                ArticuloNegocio ArticulosNegocio = new ArticuloNegocio();
                if (!IsPostBack)
                {
                    ListaArticulos = ArticulosNegocio.listar();
                    Session.Add("listaArticulos", ListaArticulos);

                }
                string Filtro;
                if (Request.QueryString["value"] != null)
                    Filtro = Request.QueryString["value"].ToString();
                else
                    Filtro = Session["Busqueda"].ToString();

                if (Filtro.Length >= 2)
                {
                    ListaArticulos = (List<Articulo>)Session["listaArticulos"];
                    //Con esta condicion de aca se pueden buscar articulos por su nombre, por su marca , por su categoria y por su genero
                    ListaFiltrada = ListaArticulos.FindAll(x => x.Nombre.ToLower().Contains(Filtro.ToLower()) ||
                    x.Marca.Nombre.ToLower().Contains(Filtro.ToLower()) || x.Categoria.Nombre.ToLower().
                    Contains(Filtro.ToLower()) || x.Genero.Nombre.ToLower().Contains(Filtro.ToLower()));

                }

                else
                {
                    ListaFiltrada = new List<Articulo>();
                }
            }
        }
    }
}