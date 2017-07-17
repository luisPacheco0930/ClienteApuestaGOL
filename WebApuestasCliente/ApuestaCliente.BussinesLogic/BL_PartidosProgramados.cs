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
    public class BL_PartidosProgramados
    {

        public DataTable BL_ListarPartidos(EN_CodigoAleatorio enCodAleatorio, String codigoTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetPartidos(dbContexto, enCodAleatorio,codigoTipoApuesta);
            }
            return dtLista;
        }

        public DataTable BL_ListarPartidosxTorneo(EN_CodigoAleatorio enCodAleatorio, String codigoTipoApuesta, String nroTorneo)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetPartidosxTorneo(dbContexto, enCodAleatorio, codigoTipoApuesta, nroTorneo);
            }
            return dtLista;
        }

        public DataTable BL_ListarResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetResultadoPartidos(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }
    }
}
