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
    public class DA_ApuestaUsuario
    {

        public int DA_registrarApuestaUsuario(ContextoDB contexto, EN_ApuestaUsuario enApuestaUsuario)
        {
            String idd = "";
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@IdProgApuesta", Convert.ToString(enApuestaUsuario.IdProgApuesta));
            dicParametros.Add("@Estado", Convert.ToChar(enApuestaUsuario.Estado));
            dicParametros.Add("@CodAleatorio", Convert.ToString(enApuestaUsuario.CodAleatorio));
            dicParametros.Add("@Usuario", Convert.ToString(enApuestaUsuario.Usuario));
            dicParametros.Add("@INT_SALIDA", idd);
            idd=contexto.RetornarUnValor("SP_RegistrarApuestaUsuario", dicParametros);
            return Convert.ToInt32(idd);

        }

        public void DA_registrarApuestaDetalleUsuario(ContextoDB contexto, EN_ApuestaUsuarioDet enApuestaDetalleUsuario)
        {
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@MarcLocal", Convert.ToString(enApuestaDetalleUsuario.MarcadorLocal));
            dicParametros.Add("@MarVisitante", Convert.ToString(enApuestaDetalleUsuario.MarcadorVisitante));
            dicParametros.Add("@Resultado", Convert.ToString(enApuestaDetalleUsuario.Resultado));
            dicParametros.Add("@Secuencia", Convert.ToString(enApuestaDetalleUsuario.Secuencia));
            dicParametros.Add("@Vigencia", Convert.ToString(enApuestaDetalleUsuario.Vigencia));
            dicParametros.Add("@IdApuestaCab", Convert.ToInt32(enApuestaDetalleUsuario.idApuestaUsuario));
            dicParametros.Add("@ValidaResultado", Convert.ToInt32(enApuestaDetalleUsuario.ValidaResultado));
            contexto.EjecutarTransaccion("SP_RegistrarApuestaUsuarioDet", dicParametros);
        }

    }
}
