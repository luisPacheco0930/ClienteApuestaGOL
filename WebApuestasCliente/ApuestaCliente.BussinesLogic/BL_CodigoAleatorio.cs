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
    public class BL_CodigoAleatorio
    {
        public DataTable BL_ValidarCodigoAlearorio(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

        //Registrar o Actualizar
        //public void BL_Registrar(EN_Deporte enDeporte)
        //{
        //    DA_Deporte daDeporte = new DA_Deporte();
        //    using (ContextoDB contexto = ContextoDB.InicializarContexto())
        //    {
        //        contexto.IniciarTransaccion();
        //        daDeporte.DA_RegistrarDeporte(contexto, enDeporte);
        //        contexto.ConfirmarTransaccion();
        //    }
        //}
    }
}
