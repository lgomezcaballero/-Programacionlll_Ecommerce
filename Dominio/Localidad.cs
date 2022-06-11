using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Localidad
    {
        public int ID { get; set; }
        public int CodigoPostal { get; set; }
        public string Provincia { get; set; }
        public string NombreLocalidad { get; set; }
        public bool Estado { get; set; }
    }
}
