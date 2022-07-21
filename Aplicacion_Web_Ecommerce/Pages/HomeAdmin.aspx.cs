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

        public long cantidadVentas { get; set; }
        public decimal recaudado { get; set; }
        public string articulo { get; set; }
        public string FormaPago { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {

            //No me convence del todo esto
            if (Session["TeLogueaste"] == null/*&& ((Usuario)Session["TeLogueaste"]).TipoUsuario.NombreTipo != "Administrador"*/)
            {
                Session.Add("error", "Solo lo los administradores pueden acceder a esta pagina");
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
                    if (!IsPostBack)
                    {
                        listaArticulos = negocio.listar();
                        Session.Add("listaArticulos", listaArticulos);

                        //Esto lo hago para guardar el pais en session 
                        listaPaises = paisNegocio.listar();
                        Session.Add("listapaises", listaPaises);

                        //Esto lo hago para guardar el las provincias en session 
                        listaProvincias = provincianegocio.listar();
                        Session.Add("listaProvincias", listaProvincias);

                        //Esto lo hago para guardar las categorias en la session 
                        listacategoria = categoriaNegocio.listar();
                        Session.Add("listacategoria", listacategoria);


                        listademarcas = marcaNegocio.listar();
                        Session.Add("listademarcas", listademarcas);

                        //Esto lo hago para guardar las localidades en la session //ok
                        Session.Add("listalocalidades", listalocalidades);

                        //Esto lo hago para guardar los Usuarios en la session //ok
                        listausuarios = usuarioNegocio.listar();
                        Session.Add("listausuarios", listausuarios);

                        obtenerEstadisticas();
                    }
                }
            }
        }

        protected void obtenerEstadisticas()
        {
            FacturaNegocio negocio = new FacturaNegocio();
            obtenerCantidadVentas(negocio);
            obtenerTotalRecaudado(negocio);
            obtenerArticuloMasVendido(negocio);
            obtenerFormaPago(negocio);
        }
        protected void obtenerCantidadVentas(FacturaNegocio negocio)
        {
            cantidadVentas = negocio.listar().Count;
        }

        protected void obtenerTotalRecaudado(FacturaNegocio negocio)
        {
            foreach (var item in negocio.listar())
            {
                recaudado += item.precioTotal;
            }
        }

        protected void obtenerArticuloMasVendido(FacturaNegocio negocio)
        {
            ArticuloNegocio artNegocio = new ArticuloNegocio();
            long idArticulo = negocio.listarArticuloMasVendido();
            articulo = (artNegocio.obtenerArticulo(idArticulo)).Nombre;
        }

        protected void obtenerFormaPago(FacturaNegocio negocio)
        {
            int e = 0, mp = 0;
            foreach (var item in negocio.listar())
            {
                if (item.IDFormaPago == 1)
                    e++;
                else if (item.IDFormaPago == 2)
                    mp++;
            }
            if (e > mp)
                FormaPago = "Efectivo";
            else if (mp > e)
                FormaPago = "Mercado Pago";
        }
    }
}