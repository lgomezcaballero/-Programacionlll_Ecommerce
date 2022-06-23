using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticulosCarrito
    {
        public Articulo Articulo { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
