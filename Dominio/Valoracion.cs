﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Valoracion
    {
        public long ID { get; set; }
        public Articulo Articulo { get; set; }
        public Usuario Usuario { get; set; }
        public int Puntaje { get; set; }
        public bool Estado { get; set; }
    }
}
