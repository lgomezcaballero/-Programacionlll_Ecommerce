using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public long ID { get; set; }
        public FormaPago FormaPago { get; set; }
        public Carrito Carrito { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Estado { get; set; }

    }
}
