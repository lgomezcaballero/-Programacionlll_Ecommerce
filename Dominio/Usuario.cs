using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int ID { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int DNI { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public int Contacto { get; set; }
        public int IDLocalidad { get; set; }
        public bool Estado { get; set; }
    }
}
