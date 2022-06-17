using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public long ID { get; set; }
        public string Apellidos { get; set; }
        public string Nombres { get; set; }
        public string DNI { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public TipoUsuario TipoUsuario { get; set; }
        public Contacto Contacto { get; set; }
        public Localidad Localidad { get; set; }
        public bool Estado { get; set; }
    }
}
