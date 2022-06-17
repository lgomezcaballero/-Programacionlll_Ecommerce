using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Factura
    {
        public int ID { get; set; }
        //todo:  lista de compras
        public Compra Compra { get; set; }
        public FormaPago FormaPago { get; set; }
        public bool Estado { get; set; }
    }
}
