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
    public partial class ABMMarcas : System.Web.UI.Page
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

                else { 
                Marca marca = new Marca();

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
                        marca = obtenerMarca(id);
                        //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                        setearCamposModificarMarca(marca);


                    }

                    if (Request.QueryString["Type"] == "d")
                    {
                        MarcaNegocio marcaNegocio = new MarcaNegocio();
                        marcaNegocio.eliminarMarca(id);
                        Response.Redirect("ListarMarcas.aspx", false);
                    }
                }
              }
            }
        }

        //De aca para abajo todo esto es para la funcionalidad de agregar una marca
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {

            //Esto captura los datos de la marca que se quiere cargar
            Marca marca = new Marca();

            marca.Nombre = TextBoxNombreMarca.Text;


            //Esto carga el pais a la base 
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            if(!existeMarca(marca.Nombre, marcaNegocio))
                marcaNegocio.agregarMarca(marca);
            Response.Redirect("ListarMarcas.aspx", false);
        }

        protected bool existeMarca(string marca, MarcaNegocio marcaNegocio)
        {
            foreach (var item in marcaNegocio.listar(true))
            {
                if (item.Nombre.Equals(marca))
                {
                    marcaNegocio.RestaurarMarca(item);
                    return true;
                }
            }
            return false;
        }

        //Esto modifica la marca
        protected void BtnEditar_Click(object sender, EventArgs e)
        {
            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca marca = new Marca();

            marca.ID = Int16.Parse(Request.QueryString["ID"]);
            marca.Nombre = TxtNombreMarca.Text;
            marcaNegocio.modificarMarca(marca);
            Response.Redirect("ListarMarcas.aspx", false);

        }


        //Esta funcion obtiene la marca
        protected Marca obtenerMarca(Int16 IdMarca)
        {
            List<Marca> lista = new List<Marca>();
            Marca aux = new Marca();
            lista = (List<Marca>)Session["listademarcas"];

            aux = lista.Find(x => x.ID == IdMarca);

            return aux;
        }

        //Esto setea la marca que se quiere modificar
        protected void setearCamposModificarMarca(Marca marca)
        {

            TxtNombreMarca.Text = marca.Nombre;
        }

        protected void ButtonAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarMarcas.aspx", false);
        }
    }
}