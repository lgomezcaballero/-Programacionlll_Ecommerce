using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Provincia
    {
        public int ID { get; set; }
        public Pais Pais { get; set; }
        public string NombreProvincia { get; set; }
        public bool Estado { get; set; }
    }
}
