﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestaCliente.Entity
{
    public class EN_ApuestaUsuarioDet
    {
        public int MarcadorLocal { get; set; }

        public int MarcadorVisitante { get; set; }

        public String Resultado { get; set; }

        public int Secuencia { get; set; }

        public Char Vigencia { get; set; }

        public int ValidaResultado { get; set; }

        public int idApuestaUsuario { get; set; }

        public int IdDetalleProgApuesta { get; set; }
    }
}
