using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApuestaCliente.Data;
using ApuestaCliente.Entity;
using System.Data;
using System.Data.SqlClient;


namespace ApuestaCliente.BussinesLogic
{
    public class BL_ApuestaUsuario
    {

        public int BL_registrarApuestaUsuario(EN_ApuestaUsuario enApuestaUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                id = daObject.DA_registrarApuestaUsuario(dbContexto, enApuestaUsuario);
            }
            return id;
        }
    }
}
