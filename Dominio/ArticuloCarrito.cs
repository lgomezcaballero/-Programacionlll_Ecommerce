using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ArticuloCarrito
    {
        public Articulo Articulo { get; set; }
        public byte IDTalle { get; set; }
        public int Cantidad { get; set; }
        public bool Estado { get; set; }
    }
}
