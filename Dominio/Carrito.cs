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
        public List<ArticulosCarrito> ArticulosCarrito { get; set; }
        public bool Estado { get; set; }
    }
}
