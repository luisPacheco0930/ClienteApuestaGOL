using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestaCliente.Entity
{
   
    public class EN_ApuestaUsuario
    {
        public int IdDetGenCod { get; set; }

        public int IdProgApuesta { get; set; }

        public String Estado { get; set; }

        public String CodAleatorio { get; set; }

        public String Usuario { get; set; }

    }
}
