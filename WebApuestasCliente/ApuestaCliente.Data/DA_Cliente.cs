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
    public class DA_Cliente
    {

        public DataTable DA_Login(ContextoDB contexto, EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroDoc", Convert.ToString(enCliente.NroDocumento));
            dicParametros.Add("@Contrasena", Convert.ToString(enCliente.Contrasena));
            dtLista = contexto.RetornarDataTable("SP_Login", dicParametros);
            return dtLista;
        }
        
        public DataTable DA_validaExistenciaUsuario(ContextoDB contexto, EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroDocumento", Convert.ToString(enCliente.NroDocumento));
            dicParametros.Add("@CorreoElectronico", Convert.ToString(enCliente.Email));
            dtLista = contexto.RetornarDataTable("SP_ValidaExistencia_Usuario", dicParametros);
            return dtLista;
        }

        public DataTable DA_ObtenerNombreUsuario(ContextoDB contexto, EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroDocumento", Convert.ToString(enCliente.NroDocumento));
            dtLista = contexto.RetornarDataTable("SP_ObtenerNombreUsuario", dicParametros);
            return dtLista;
        }

        public void DA_registrarUsuario(ContextoDB contexto, EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@NroDocumento", Convert.ToString(enCliente.NroDocumento));
            dicParametros.Add("@Nombres", Convert.ToString(enCliente.Nombres));
            dicParametros.Add("@Apellidos", Convert.ToString(enCliente.Apellidos));
            dicParametros.Add("@Contrasenha", Convert.ToString(enCliente.Contrasena));
            dicParametros.Add("@CorreoElectronico", Convert.ToString(enCliente.Email));
            contexto.EjecutarTransaccion("SP_RegistrarUsuario", dicParametros);
        }


        /*public DataTable DA_ValidarCodigoAleatorio_YaJugado(ContextoDB contexto, EN_CodigoAleatorio enCodigo)
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
    }*/

        public DataTable DA_ObtenerDatosUsuario(ContextoDB contexto, EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@nroDoc", Convert.ToString(enCliente.NroDocumento));
            dtLista = contexto.RetornarDataTable("SP_ObtenerDatosUsuario", dicParametros);
            return dtLista;
        }

    }
}
