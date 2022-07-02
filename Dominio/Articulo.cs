using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public long ID { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public Genero Genero { get; set; }
        public List<ImagenesArticulo> Imagenes { get; set; }
        public List<ArticuloTalla> Talles { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }
}
