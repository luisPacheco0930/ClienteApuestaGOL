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
    public class BL_Cliente
    {
        /*public DataTable BL_ValidarCodigoAlearorio_EstaVigente(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_EstaVigente(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }*/

        public String BL_validarUsuarioIngresado(EN_Cliente enCliente)
        {
            String textError = "";
            DataTable dtCliente = new DataTable();
            dtCliente = BL_Login(enCliente);
            if (dtCliente == null || dtCliente.Rows.Count == 0)
            {
                textError = EN_Constante.textUsuarioNoValido;
            }
            return textError;
        }

        public DataTable BL_Login(EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            DA_Cliente daCliente = new DA_Cliente();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCliente.DA_Login(dbContexto, enCliente);
            }
            return dtLista;
        }

        public void BL_registrarUsuario(EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            DA_Cliente daCliente = new DA_Cliente();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                daCliente.DA_registrarUsuario(dbContexto, enCliente);
            }
        }

        public String BL_validaExistenciaUsuario(EN_Cliente enCliente)
        {
            String textError = "";
            DataTable dtCliente = new DataTable();
            dtCliente = BL_ValidarUsuario_ExisteDNIEmail(enCliente);
            if (dtCliente != null && dtCliente.Rows.Count > 0)
            {
                textError = EN_Constante.textUsuarioYaExiste;
            }
            return textError;
        }
        
        public DataTable BL_ValidarUsuario_ExisteDNIEmail(EN_Cliente enCliente)
        {
            DataTable dtLista = new DataTable();
            DA_Cliente daCliente = new DA_Cliente();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCliente.DA_validaExistenciaUsuario(dbContexto, enCliente);
            }
            return dtLista;
        }        
        /*public DataTable BL_ValidarCodigoAlearorio_UsadoxUsuario(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_UsadoxUsuario(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }*/
    }
}
