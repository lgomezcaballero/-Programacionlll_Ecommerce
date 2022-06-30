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
        public byte id;
        public string tipo;

        protected void Page_Load(object sender, EventArgs e)
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
                   // pais = obtenerPais(id);
                    //Esto lo que hace es precargar los datos con el articulo que se quiere modificar
                   // setearCamposModificarPais(pais);
                }
            }
        }
    }
}