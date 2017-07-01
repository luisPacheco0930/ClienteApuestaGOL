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

        public void BL_registrarApuestaUsuario(ref EN_ApuestaUsuario enApuestaUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id= enApuestaUsuario.idApuestaUsuario;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();

            if (enApuestaUsuario.idApuestaUsuario == null || enApuestaUsuario.idApuestaUsuario == 0) {
                using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
                {
                    id = daObject.DA_registrarApuestaUsuario(dbContexto, enApuestaUsuario);
                    enApuestaUsuario.idApuestaUsuario = id;
                }
            }
            if(enApuestaUsuario.listaitem!=null && enApuestaUsuario.listaitem.Count > 0)
            {
                foreach (EN_ApuestaUsuarioDet detalle in enApuestaUsuario.listaitem)
                {
                    detalle.idApuestaUsuario = id;
                    BL_registrarApuestaDetalleUsuario(detalle);
                }
            }
        }

        public void BL_registrarApuestaDetalleUsuario(EN_ApuestaUsuarioDet enApuestaDetalleUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                daObject.DA_registrarApuestaDetalleUsuario(dbContexto, enApuestaDetalleUsuario);
            }
        }
    }
}
