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
        public string CodigoPostal { get; set; }
        public Provincia Provincia { get; set; }
        public string NombreLocalidad { get; set; }
        public bool Estado { get; set; }
    }
}
