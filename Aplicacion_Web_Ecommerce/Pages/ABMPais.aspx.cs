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
    public partial class ABMPais : System.Web.UI.Page
    {
        public byte id;
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

                    Pais pais = new Pais();

                    if (!IsPostBack)
                    {
                        if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                        {
                            tipo = Request.QueryString["Type"];
                            id = byte.Parse(Request.QueryString["ID"]);
                        }
                        if (Request.QueryString["Type"] == "a")
                            tipo = Request.QueryString["Type"];
                        if (tipo == "e")
                        {
                            //Con esta funciom obtine el articulo que se busca
                            pais = obtenerPais(id);
                            //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                            setearCamposModificarPais(pais);
                        }

                        //Esto elimina de manera logica el pais
                        if (Request.QueryString["Type"] == "d")
                        {
                            PaisNegocio paisNegocio = new PaisNegocio();
                            paisNegocio.EliminarPais(id);
                            Response.Redirect("ListarPaises.aspx", false);


                        }
                    }
                }
            }
        }

        //De aca para abajo esto es para poder modificar el pais 
        protected Pais obtenerPais(byte IDPais)
        {
            List<Pais> lista = new List<Pais>();
            Pais aux = new Pais();
            //a donde se agrega este session?
            lista = (List<Pais>)Session["listapaises"];

            aux = lista.Find(x => x.ID == IDPais);

            return aux;
        }

        protected void setearCamposModificarPais(Pais pais)
        {
            txtPais.Text = pais.NombrePais;
        }

        protected void BtnModificar_Click(object sender, EventArgs e)
        {
            PaisNegocio paisnegocio = new PaisNegocio();
            Pais pais = new Pais();

            //Esto lo hice asi para probar, pero aun asi no funciona 
            pais.ID = byte.Parse(Request.QueryString["ID"]);
            pais.NombrePais = txtPais.Text;
            pais.Estado = true;


            paisnegocio.ModificarPais(pais);
            Response.Redirect("ListarPaises.aspx");
        }

        //--------------------------------------------------------------------------------------------


        //De aca para abajo todo esto es para la funcionalidad de agregar un pais
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Esto captura los datos del pais que se quiere cargar
            Pais pais = new Pais();

            pais.NombrePais = txtNombrePais.Text;


            //Esto carga el pais a la base 
            PaisNegocio paisNegocio = new PaisNegocio();

            if (!existePais(pais.NombrePais, paisNegocio))
                paisNegocio.AgregarPais(pais);
            Response.Redirect("ListarPaises.aspx", false);
        }

        protected bool existePais(string nombre, PaisNegocio paisNegocio)
        {
            foreach (var item in paisNegocio.listar(true))
            {
                if (item.NombrePais.Equals(nombre))
                {
                    paisNegocio.RestaurarPais(item);
                    return true;
                }
            }
            return false;
        }

        protected void BtnAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarPaises.aspx", false);
        }
    }
}