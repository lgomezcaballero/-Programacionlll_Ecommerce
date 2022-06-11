using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Contacto
    {
        public int ID { get; set; }
        public Usuario Usuario { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
    }
}
