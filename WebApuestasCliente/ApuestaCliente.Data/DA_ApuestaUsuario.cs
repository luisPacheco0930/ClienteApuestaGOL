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
            int idd = 10;
            DataTable dtLista = new DataTable();
            Dictionary<string, object> dicParametros = new Dictionary<string, object>();
            dicParametros.Add("@IdDetGenCod", Convert.ToString(enApuestaUsuario.IdDetGenCod));
            dicParametros.Add("@IdProgApuesta", Convert.ToString(enApuestaUsuario.IdProgApuesta));
            dicParametros.Add("@Estado", Convert.ToString(enApuestaUsuario.Estado));
            dicParametros.Add("@CodAleatorio", Convert.ToString(enApuestaUsuario.CodAleatorio));
            dicParametros.Add("@Usuario", Convert.ToString(enApuestaUsuario.Usuario));
            dicParametros.Add("@INT_SALIDA", idd);
            contexto.EjecutarTransaccion("SP_RegistrarApuestaUsuario", dicParametros);
            return idd;

        }

    }
}
