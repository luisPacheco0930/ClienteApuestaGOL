using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestaCliente.Entity
{
    public class EN_ProgramacionApuesta
    {
        public int IdProgramaApuesta { get; set; }

        public DateTime FechaInicial { get; set; }

        public DateTime FechaFinal { get; set; }

        public Char Vigencia { get; set; }

        public Char CodigoTipoApuesta { get; set; }
        
    }
}
