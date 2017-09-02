using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApuestaCliente.Entity;
using System.Data;
using System.Data.SqlClient;

namespace ApuestaCliente.Data
{
    public class DA_Documento
    {

        public DataTable DA_ObtenerDocumentosActivos(ContextoDB contexto)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@estadoDocumento", Convert.ToInt32(1));
            dtLista = contexto.RetornarDataTable("SP_ObtenerDocumentosActivos", dicParametros);
            return dtLista;
        }
        
    }
}
