using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ApuestaCliente.Data;
using ApuestaCliente.Entity;

namespace ApuestaCliente.BussinesLogic
{
    public class BL_Documento
    {
       
        public DataTable BL_ObtenerDocumentosActivos()
        {
            DataTable dtLista = new DataTable();
            DA_Documento daDocumento = new DA_Documento();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daDocumento.DA_ObtenerDocumentosActivos(dbContexto);
            }
            return dtLista;
        }

    }
}
