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
    public partial class ABMProvincia : System.Web.UI.Page
    {
        public int id;
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
                    Provincia provincia = new Provincia();
                    provincia.Pais = new Pais();
                    //TP lean

                    if (!IsPostBack)
                    {
                        PaisNegocio pNegocio = new PaisNegocio();
                        ddlPaises.DataSource = pNegocio.listar();
                        ddlPaises.DataTextField = "NombrePais";
                        ddlPaises.DataValueField = "ID";
                        ddlPaises.DataBind();
                        if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                        {
                            tipo = Request.QueryString["Type"];
                            id = int.Parse(Request.QueryString["ID"]);
                        }
                        if (Request.QueryString["Type"] == "a")
                            tipo = Request.QueryString["Type"];
                        if (tipo == "e")
                        {
                            e_ddlPaises.DataSource = pNegocio.listar();
                            e_ddlPaises.DataTextField = "NombrePais";
                            e_ddlPaises.DataValueField = "ID";
                            e_ddlPaises.DataBind();
                            //Con esta funciom obtine el articulo que se busca
                            provincia = obtenerProvincia(id);
                            e_ddlPaises.SelectedValue = provincia.Pais.ID.ToString();
                            //TxtNombreDelPais.Text = provincia.Pais.NombrePais;
                            TxtNombreDeLaProvincia.Text = provincia.NombreProvincia;
                            //Esto lo que hace es precargar los datos con el articulo que se quiere modificar*/
                             //setearCamposModificarPais(pais);
                        }

                        if (Request.QueryString["Type"] == "d")
                        {
                            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
                            provinciaNegocio.eliminarProvincia(id);
                            Response.Redirect("ListarProvincia.aspx", false);
                        }
                    }
                }
            }
        }

        protected Provincia obtenerProvincia(int id)
        {
            ProvinciaNegocio pNegocio = new ProvinciaNegocio();
            Provincia aux = new Provincia();
            foreach (var item in pNegocio.listar())
            {
                if (item.ID == id)
                    aux = item;
            }
            return aux;
        }


        //De aca para abajo todo esto es para la funcionalidad de agregar una provincia
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Esto captura los datos del pais que se quiere cargar
            Provincia provincia = new Provincia();

            //Capturo los datos del front 
            provincia.Pais = new Pais();
            provincia.Pais.NombrePais = ddlPaises.SelectedItem.Text;
            provincia.NombreProvincia = TxtNombreProvincia.Text;

            //Esto lo hago para que el usuario puede ingresar el nombre del pais y no el id
            Pais pais = new Pais();
            pais = BuscarPaisPorNombre(provincia.Pais.NombrePais);
            //Aca le pongo el id del pais que encuentra la funcion
            provincia.Pais.ID = pais.ID;


            //Esto carga la provincia a la base 
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();

            if(!existeProvincia(provincia.NombreProvincia, provincia.Pais.NombrePais, provinciaNegocio))
                provinciaNegocio.agregarProvincia(provincia);

            Response.Redirect("ListarProvincia.aspx", false);
        }

        protected bool existeProvincia(string provincia, string pais, ProvinciaNegocio provinciaNegocio)
        {
            foreach (var item in provinciaNegocio.listar(true))
            {
                if(item.NombreProvincia.Equals(provincia) && item.Pais.NombrePais.Equals(pais))
                {
                    provinciaNegocio.restaurarProvincia(item);
                    return true;
                }
            }
            return false;
        }

        protected Pais BuscarPaisPorNombre(string NombrePais)
        {

            Pais pais = new Pais();
            List<Pais> lista = new List<Pais>();
            PaisNegocio paisNegocio = new PaisNegocio();
            lista = paisNegocio.listar();

            pais = lista.Find(c => c.NombrePais == NombrePais);


            return pais;
        }

        protected void BtnEditar_Click(object sender, EventArgs e)
        {


            PaisNegocio paisnegocio = new PaisNegocio();
            Pais pais = new Pais();
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            Provincia provincia = new Provincia();


            //Esto lo hice asi para probar, pero aun asi no funciona 

            pais.NombrePais = e_ddlPaises.SelectedItem.Text;
            pais = BuscarPaisPorNombre(pais.NombrePais);

            //Aca seteo el pais 
            provincia.ID = int.Parse(Request.QueryString["ID"]);
            provincia.Pais = new Pais();
            provincia.Pais.ID = pais.ID;
            provincia.Pais.NombrePais = pais.NombrePais;
            provincia.Pais.Estado = pais.Estado;

            provincia.NombreProvincia = TxtNombreDeLaProvincia.Text;

            provinciaNegocio.modificarProvincia(provincia);
            Response.Redirect("ListarProvincia.aspx");
        }

        protected void ButtonAtras_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListarProvincia.aspx", false);
        }
    }
}