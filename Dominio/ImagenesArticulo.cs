using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class ImagenesArticulo
    {
        public int ID { get; set; }
        public int IDArticulo { get; set; }
        public string URLImagen { get; set; }
        public bool Estado { get; set; }
    }
}
