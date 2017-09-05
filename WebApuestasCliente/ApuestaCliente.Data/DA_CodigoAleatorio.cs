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
    public class DA_CodigoAleatorio
    {
        //Para actaulizar o insertar los registros.....
        //public void DA_RegistrarDeporte(ContextoDB contexto, EN_Deporte enDeporte)
        //{
        //    Dictionary<string, object> dicParametros = new Dictionary<string, object>();
        //    Dictionary<string, object> dicOutPut = new Dictionary<string, object>();
        //    dicParametros.Add("@descripcion", Convert.ToString(enDeporte.descripcion));
        //    dicParametros.Add("@usuario", Convert.ToString(enDeporte.UsuarioCreacion));
        //    contexto.EjecutarTransaccion("SP_InsertarDeporte", dicParametros);
        //}

        //Para listar datatable o reader...
        public DataTable DA_validarCodigoXprograma(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String TipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@TipoApuesta", TipoApuesta);
            dtLista = contexto.RetornarDataTable("SP_Validar_CodAleatorioXPrograma", dicParametros);
            return dtLista;
        }

        public DataTable DA_obtenerCodigoXprograma(ContextoDB contexto, EN_CodigoAleatorio enCodigo, String TipoApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@TipoApuesta", TipoApuesta);
            dtLista = contexto.RetornarDataTable("SP_Obtener_CodAleatorioXPrograma", dicParametros);
            return dtLista;
        }

        public DataTable DA_ValidarCodigoAleatorio_EstaVigente(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dtLista = contexto.RetornarDataTable("SP_ValidarAcceso_CodAleatorio_EstaVigente", dicParametros);
            return dtLista;
        }

        public DataTable DA_ValidarCodigoAleatorio_YaJugado(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dtLista = contexto.RetornarDataTable("SP_ValidarAcceso_CodAleatorio_YaJugado", dicParametros);
            return dtLista;
        }

        public DataTable DA_ValidarCodigoAleatorio_UsadoxUsuario(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dtLista = contexto.RetornarDataTable("SP_ValidarAcceso_CodAleatorio_UsadoxUsuario", dicParametros);
            return dtLista;
        }

        public DataTable DA_CodAleatorio_FechaTope(ContextoDB contexto, EN_CodigoAleatorio enCodigo, string codApuesta)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dicParametros.Add("@CodApuesta", codApuesta);
            dtLista = contexto.RetornarDataTable("SP_ObtenerPrograma", dicParametros);
            return dtLista;
        }

        public DataTable DA_ValidarCodigoAleatorio_ResultadoListo(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroCodAleatorio", Convert.ToString(enCodigo.NroCodigoAleatorio));
            dtLista = contexto.RetornarDataTable("SP_ValidarAcceso_CodAleatorio_ResultadoListo", dicParametros);
            return dtLista;
        }

    }
}
