using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloTalla
    {
        public long IDArticulo { get; set; }
        public byte IDTalla { get; set; }
        public string Talle { get; set; }
        public long Stock { get; set; }
        public bool Estado { get; set; }
    }
}
