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
            Pais pais = new Pais();

            if (!IsPostBack)
            {
                if (Request.QueryString["ID"] != null && Request.QueryString["Type"] != null)
                {
                    tipo = Request.QueryString["Type"];
                    id = int.Parse(Request.QueryString["ID"]);
                }
                if (Request.QueryString["Type"] == "a")
                    tipo = Request.QueryString["Type"];
                if (tipo == "e")
                {
                    //Con esta funciom obtine el articulo que se busca
                   //pais = obtenerPais(id);
                    //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                    //setearCamposModificarPais(pais);
                }
            }
        }




        //De aca para abajo todo esto es para la funcionalidad de agregar una provincia
        protected void BtnAgregar_Click(object sender, EventArgs e)
        {
            //Esto captura los datos del pais que se quiere cargar
            Provincia provincia = new Provincia();

            //Capturo los datos del front 
            provincia.Pais = new Pais();
            provincia.Pais.NombrePais = txtNombrePais.Text;
            provincia.NombreProvincia = TxtNombreProvincia.Text;

            //Esto lo hago para que el usuario puede ingresar el nombre del pais y no el id
            Pais pais = new Pais();
            pais = BuscarPaisPorNombre(provincia.Pais.NombrePais);
            //Aca le pongo el id del pais que encuentra la funcion
            provincia.Pais.ID = pais.ID;

            
            //Esto carga la provincia a la base 
            ProvinciaNegocio provinciaNegocio = new ProvinciaNegocio();
            provinciaNegocio.agregarProvincia(provincia);
            Response.Redirect("HomeAdmin.aspx", false);
            

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
    }
}