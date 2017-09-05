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

        public DataTable DA_GetPartidosJugados(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String codigoTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
         //   dicParametros.Add("@CodigoTipoApuesta", Convert.ToString(codigoTipoApuesta));
            dtLista = contexto.RetornarDataTable("SP_ListarDetProgramaJugado", dicParametros);
            return dtLista;
        }

        public DataTable DA_GetPartidosxTorneo(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String codigoTipoApuesta, String nroTorneo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@CodigoTipoApuesta", Convert.ToString(codigoTipoApuesta));
            dicParametros.Add("@NroTorneo", Convert.ToInt32(nroTorneo));
            dtLista = contexto.RetornarDataTable("SP_LISTAR_PARTIDOS_TORNEO", dicParametros);
            return dtLista;
        }

        public DataTable DA_GetResultadoPartidos(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String codTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@CodTipoAPuesta", codTipoApuesta);
            dtLista = contexto.RetornarDataTable("SP_LISTAR_PARTIDOS_RESULTADOS", dicParametros);
            return dtLista;
        }

        public DataTable DA_GetListadoGanadores(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String codTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@CodTipoAPuesta", codTipoApuesta);
            dtLista = contexto.RetornarDataTable("SP_LISTAR_GANADORES", dicParametros);
            return dtLista;
        }

        public DataTable DA_ObtenerPozoMayorxApuesta(ContextoDB contexto, EN_ProgramacionApuesta enProgramacionApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroProgApuesta", Convert.ToInt32(enProgramacionApuesta.IdProgramaApuesta));
            dtLista = contexto.RetornarDataTable("SP_ObtenerPozoMayorxApuesta", dicParametros);
            return dtLista;
        }

        public DataTable DA_ObtenerJugadaCliente(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dtLista = contexto.RetornarDataTable("SP_ObtenerJugadaCliente", dicParametros);
            return dtLista;
        }
    }
}
