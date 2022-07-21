using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Estadisticas
    {
        public long IDFactura { get; set; }
        public byte IDFormaPago { get; set; }
        public long IDArticulo { get; set; }
        public int cantidad { get; set; }
        public decimal precioTotal { get; set; }
    }
}
