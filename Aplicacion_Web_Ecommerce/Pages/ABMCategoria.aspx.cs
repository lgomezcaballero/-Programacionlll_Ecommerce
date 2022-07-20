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
    public partial class ABMCategoria : System.Web.UI.Page
    {
        public Int16 id;
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
                    Categoria categoria = new Categoria();

                    if (!IsPostBack)
                    {
                        if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                        {
                            tipo = Request.QueryString["Type"];
                            id = Int16.Parse(Request.QueryString["ID"]);
                        }
                        if (Request.QueryString["Type"] == "a")
                            tipo = Request.QueryString["Type"];
                        if (tipo == "e")
                        {
                            //Con esta funciom obtine el articulo que se busca
                            categoria = obtenerCategoria(id);
                            //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                            setearCamposModificarCategoria(categoria);
                        }

                        if (Request.QueryString["Type"] == "d")
                        {
                            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                            categoriaNegocio.eliminarCategoria(id);
                            Response.Redirect("ListarCategorias.aspx", false);
                        }
                    }
                }
            }
        }


        //Con esta funcion obtengo lo datos de la categoria seleccionada para editar
        protected Categoria obtenerCategoria(Int16 idCategoria)
        {
            List<Categoria> lista = new List<Categoria>();
            Categoria aux = new Categoria();
            lista = (List<Categoria>)Session["listacategoria"];

            aux = lista.Find(x => x.ID == idCategoria);

            return aux;
        }


        protected void setearCamposModificarCategoria(Categoria categoria)
        {

            TxtCategoriaNombre.Text = categoria.Nombre;
        }


        //De aca para abajo todo esto es para la funcionalidad de agregar una categoria
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

            //Esto captura los datos de la categoria que se quiere cargar
            Categoria categoria = new Categoria();

            categoria.Nombre = TextBoxNombreCategoria.Text;


            //Esto carga el pais a la base 
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            if(!existeCategoria(categoria.Nombre, categoriaNegocio))
                categoriaNegocio.agregarCategoria(categoria);

            Response.Redirect("ListarCategorias.aspx", false);

        }

        protected bool existeCategoria(string categoria, CategoriaNegocio categoriaNegocio)
        {
            foreach (var item in categoriaNegocio.listar(true))
            {
                if (item.Nombre.Equals(categoria))
                {
                    categoriaNegocio.RestaurarCategoria(item);
                    return true;
                }
            }
            return false;
        }

        //Esta funcion edita la categoria
        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            Categoria categoria = new Categoria();

            categoria.ID = Int16.Parse(Request.QueryString["ID"]);
            categoria.Nombre = TxtCategoriaNombre.Text;
            categoriaNegocio.modificarCategoria(categoria);
            Response.Redirect("ListarCategorias.aspx", false);

        }

        protected void btnAtrás_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarCategorias.aspx", false);
        }
    }
}