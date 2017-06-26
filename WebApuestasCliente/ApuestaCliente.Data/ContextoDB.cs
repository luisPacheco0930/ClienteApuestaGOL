using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using ApuestaCliente.Entity;

namespace ApuestaCliente.Data
{
    public class ContextoDB:IDisposable
    {
        //public static ContextoDB InicializarContexto(string CadenaDeConexion)
        //{
        //    ContextoDB contexto = new ContextoDB();
        //    contexto.Abrir(CadenaDeConexion);
        //    return contexto;
        //}
        private static ContextoDB contexto = null;
        private ContextoDB() { }

        public static ContextoDB InicializarContexto()
        {
            if (contexto == null)
            {
                //ContextoDB contexto = new ContextoDB();
                contexto = new ContextoDB();
            }
            contexto.Abrir(EN_Constante.conexion);
            return contexto;
        }

        private SqlConnection conexion;
        private SqlTransaction transaccion;

        public SqlTransaction ObtenerTransaccion()
        {
            return transaccion;
        }

        public SqlConnection ObtenerConexion()
        {
            return conexion;
        }

        public void Abrir(string CadenaDeConexion)
        {
            string parametrosDeConexion = System.Configuration.ConfigurationManager.ConnectionStrings[CadenaDeConexion].ConnectionString;

            conexion = new SqlConnection(parametrosDeConexion);
            conexion.Open();
        }

        public void Cerrar()
        {
            conexion.Close();
        }

        public void IniciarTransaccion()
        {
            transaccion = conexion.BeginTransaction();
        }

        public void ConfirmarTransaccion()
        {
            transaccion.Commit();
            transaccion = null;
        }

        public void RechazarTransaccion()
        {
            transaccion.Rollback();
            transaccion = null;
        }

        public void Dispose()
        {
            if (transaccion != null)
            {
                transaccion.Rollback();
            }

            this.Cerrar();
        }

        public DataTable RetornarDataTable(string sNombreStoredProcedure, Dictionary<string, object> dicParametros)
        {
            SqlCommand cmd = new SqlCommand(sNombreStoredProcedure, ObtenerConexion(), ObtenerTransaccion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 90000;
            foreach (KeyValuePair<string, object> parametro in dicParametros)
            {
                cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
            DataTable dtDatos = new DataTable();
            dtDatos.Load(cmd.ExecuteReader());

            return dtDatos;
        }

        public string RetornarUnValor(string sNombreStoredProcedure, Dictionary<string, object> dicParametros)
        {
            object valor;
            SqlCommand cmd = new SqlCommand(sNombreStoredProcedure, ObtenerConexion(), ObtenerTransaccion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.CommandTimeout = 90000;
            foreach (KeyValuePair<string, object> parametro in dicParametros)
            {
                cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
            DataTable dtDatos = new DataTable();
            valor = cmd.ExecuteScalar();

            if (valor == null)
            {
                valor = string.Empty;
            }
            return valor.ToString();
        }

        public int EjecutarTransaccion(string sNombreStoredProcedure, Dictionary<string, object> dicParametros)
        {
            SqlCommand cmd = new SqlCommand(sNombreStoredProcedure, ObtenerConexion(), ObtenerTransaccion());
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> parametro in dicParametros)
            {
                cmd.Parameters.AddWithValue(parametro.Key, parametro.Value);
            }
            return cmd.ExecuteNonQuery();
        }
    }
}
