using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Valoracion
    {
        public long IDCompra { get; set; }
        public long IDArticulo { get; set; }
        public int Puntaje { get; set; }
        public bool Estado { get; set; }
    }
}
