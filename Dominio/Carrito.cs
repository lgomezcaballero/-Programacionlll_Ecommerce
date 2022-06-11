using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }
        public List<Articulo> ListaArticulos { get; set; }
        public bool Estado { get; set; }
    }
}
