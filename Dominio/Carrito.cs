using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Carrito
    {
        public long ID { get; set; }
        public List<ArticuloCarrito> ArticulosCarrito { get; set; }
        public bool Estado { get; set; }
    }
}
