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

        public DataTable BL_ListarPartidosJugados(EN_CodigoAleatorio enCodAleatorio, String codigoTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetPartidosJugados(dbContexto, enCodAleatorio, codigoTipoApuesta);
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

        public DataTable BL_ListarResultadoPartidos(EN_CodigoAleatorio enCodAleatorio, String codTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetResultadoPartidos(dbContexto, enCodAleatorio,codTipoApuesta);
            }
            return dtLista;
        }

        public DataTable BL_ListarGanadores(EN_CodigoAleatorio enCodAleatorio, String codTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daPartidosProgramados = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daPartidosProgramados.DA_GetListadoGanadores(dbContexto, enCodAleatorio,codTipoApuesta);
            }
            return dtLista;
        }

        public DataTable BL_ObtenerPozoMayorxApuesta(EN_ProgramacionApuesta enProgramacionApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daProgApuesta = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daProgApuesta.DA_ObtenerPozoMayorxApuesta(dbContexto, enProgramacionApuesta);
            }
            return dtLista;
        }

        public DataTable BL_ObtenerJugadaCliente(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_PartidosProgramados daJugada = new DA_PartidosProgramados();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daJugada.DA_ObtenerJugadaCliente(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

    }
}
