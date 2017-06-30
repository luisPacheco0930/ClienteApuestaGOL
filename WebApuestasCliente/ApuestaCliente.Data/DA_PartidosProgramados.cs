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
    public class DA_PartidosProgramados
    {
        public DataTable DA_GetPartidos(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String codigoTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@CodigoTipoApuesta", Convert.ToString(codigoTipoApuesta));
            dtLista = contexto.RetornarDataTable("SP_LISTAR_PARTIDOS", dicParametros);
            return dtLista;
        }
    }
}
