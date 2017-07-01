using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestaCliente.Entity
{
   
    public class EN_ApuestaUsuario
    {

        public int idApuestaUsuario { get; set; }

        public int IdProgApuesta { get; set; }

        public Char Estado { get; set; }

        public String CodAleatorio { get; set; }

        public String Usuario { get; set; }

        public DateTime fecha { get; set; }
        
        public List<EN_ApuestaUsuarioDet> listaitem { get; set; }
    }
}
