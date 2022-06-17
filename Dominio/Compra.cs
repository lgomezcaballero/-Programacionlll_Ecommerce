using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Compra
    {
        public long ID { get; set; }
        public Usuario Usuario { get; set; }
        public Carrito Carrito { get; set; }
        public FormaPago FormaPago { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioTotal { get; set; }
        public bool Estado { get; set; }

    }
}
