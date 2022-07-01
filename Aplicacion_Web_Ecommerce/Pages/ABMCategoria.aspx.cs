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
            Articulo articulo = new Articulo();

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
                    // articulo = obtenerArticulo(id);
                    //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                    // setearCamposModificar(articulo);
                }
            }
        }

        //De aca para abajo todo esto es para la funcionalidad de agregar una categoria
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

            //Esto captura los datos de la categoria que se quiere cargar
            Categoria categoria = new Categoria();

            categoria.Nombre = TextBoxNombreCategoria.Text;


            //Esto carga el pais a la base 
            CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
            categoriaNegocio.agregarCategoria(categoria);
            Response.Redirect("HomeAdmin.aspx", false);

        }
    }
}