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

        public List<Articulo> ListaDeArticulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            ArticuloNegocio ArticuloNegocio = new ArticuloNegocio();
            ListaDeArticulos = ArticuloNegocio.listar();

            //Eliminacion de articulos

            /*
           if (Request.QueryString["ID"] != null)
            {
                //Captura el numero del articulo que se quiere eliminar 
                int ID = int.Parse(Request.QueryString["ID"]);
                
                //Elimina el articulo seleccionado
                ArticuloNegocio.eliminarArticulo(ID);
                //Recarga la pagina cuando se elimina el articulo
                Response.Redirect("HomeAdmin.aspx", false);

                
            }
            */


            if (Request.QueryString["ID"] != null)
            {
                //Captura el numero del articulo que se quiere eliminar 
                int ID = int.Parse(Request.QueryString["ID"]);


                Articulo Articulin = new Articulo();
                Articulin.ID = ID;
                Articulin.Marca = new Marca();
                Articulin.Marca.ID = 1;
                Articulin.Nombre = "Articulon";
                Articulin.Categoria = new Categoria();
                Articulin.Categoria.ID = 1;
                Articulin.Genero = new Genero();
                Articulin.Genero.ID = 1;
                Articulin.Descripcion = "LuisMiguel";
                Articulin.Precio = 22;
                //Le comente stock porque en tu codigo ya no lo usa
                //Articulin.Stock = 200;
                Articulin.FechaRegistro = new DateTime(2020, 02, 02);
                Articulin.Estado = true;
                //Le comente talla porque en tu codigo ya no lo usa
                //Articulin.Talla = new Talla();
                //Articulin.Talla.IDTalla = 1;

                //Modifica el articulo seleccionado
                ArticuloNegocio.modificarArticulo(Articulin);
                //Recarga la pagina cuando se modifica el articulo
                Response.Redirect("HomeAdmin.aspx", false);

            }



        }

        //Esto es temporal aca tiene que pedir cada dato en la aplicacion
        protected void AgregarArticulo_Click(object sender, EventArgs e)
        {
            /*
            ArticuloNegocio ArticuloNegocio = new ArticuloNegocio();
            Articulo Articulin = new Articulo();
            Articulin.Marca = new Marca();
            Articulin.Marca.ID = 1;
            Articulin.Nombre = "Articulon";
            Articulin.Categoria = new Categoria();
            Articulin.Categoria.ID = 1;
            Articulin.Genero = new Genero();    
            Articulin.Genero.ID = 1;
            Articulin.Descripcion = "El pupu que hacia pipi";
            Articulin.Precio = 22;
            Articulin.Stock = 200;
            Articulin.FechaRegistro = new DateTime(2020,02, 02);
            Articulin.Estado = true;
            Articulin.Talla = new Talla();  
            Articulin.Talla.IDTalla = 1;
            ArticuloNegocio.agregarArticulo(Articulin);
            */

        }

        /*
        protected void Button1_Click(object sender, EventArgs e)
        {

        }*/

        //Este evento toma todos los datos que se ingresan del articulo
        //y luego agrega ese articulo a la base
        protected void Entendido_Click(object sender, EventArgs e)
        {

            //Creo estos dos objetos porque los voy a necesitar
            Articulo ArticuloAgregado = new Articulo();

            ArticuloNegocio articulonegocio = new ArticuloNegocio();

            //Validar cuando los datos son nulos

            ArticuloAgregado.Marca = new Marca();
            ArticuloAgregado.Marca.ID = Int16.Parse(TxtIDMarca.Text);
            ArticuloAgregado.Categoria = new Categoria();
            ArticuloAgregado.Categoria.ID = Int16.Parse(TxtIDCategoria.Text);
            ArticuloAgregado.Genero = new Genero();
            ArticuloAgregado.Genero.ID = byte.Parse(TxtIDGenero.Text);
            //Le comente talla porque en tu codigo ya no lo usa 
            //ArticuloAgregado.Talla = new Talla();
            //ArticuloAgregado.Talla.IDTalla = byte.Parse(TxtIDTalla.Text);
            ArticuloAgregado.Nombre = TxtNombreArticulo.Text;
            ArticuloAgregado.Descripcion = TxtDescripcionArticulo.Text;
            ArticuloAgregado.Precio = decimal.Parse(TxtPrecio.Text);
            //Le comente el stock porque en tu codigo ya no lo usa
            //ArticuloAgregado.Stock = long.Parse(TxtStock.Text);


            //Se cargan los datos a la base 
            articulonegocio.agregarArticulo(ArticuloAgregado);

        }
    }
}