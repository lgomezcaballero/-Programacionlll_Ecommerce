﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Dominio;

namespace Aplicacion_Web_Ecommerce
{
    public partial class _Default : Page
    {
        public List<Articulo> ListaDeArticulos { get; set; }   
         
        public List<Usuario> Usuarios { get; set; } 
        protected void Page_Load(object sender, EventArgs e)
        {

            ArticuloNegocio Negocio = new ArticuloNegocio();
            ListaDeArticulos = Negocio.listar();


            grillaArticulos.DataSource = ListaDeArticulos;
            grillaArticulos.DataBind();

            UsuarioNegocio marca = new UsuarioNegocio();
            Usuarios = marca.listar();        

           
        }
    }
}