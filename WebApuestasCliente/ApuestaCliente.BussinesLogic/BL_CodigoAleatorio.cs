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
        public DataTable BL_ValidarCodigoAlearorio_EstaVigente(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_EstaVigente(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

        public DataTable BL_ValidarCodigoAlearorio_YaJugado(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_YaJugado(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

        public DataTable BL_ValidarCodigoAlearorio_UsadoxUsuario(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_UsadoxUsuario(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

        public String BL_validarCodigoIngresado(EN_CodigoAleatorio enCodAleatorio)
        {
            String textError = "";
            DataTable dtClientwDetCodigoAleatorio = new DataTable();
            DataTable dtGeneraCodigo = new DataTable();
            DataTable dtApuestaCodigoAleatorio = new DataTable();
            dtGeneraCodigo = BL_ValidarCodigoAlearorio_EstaVigente(enCodAleatorio);
            if (dtGeneraCodigo != null && dtGeneraCodigo.Rows.Count > 0)
            {
                dtApuestaCodigoAleatorio = BL_ValidarCodigoAlearorio_YaJugado(enCodAleatorio);
                if (dtApuestaCodigoAleatorio == null || dtApuestaCodigoAleatorio.Rows.Count == 0)
                {
                    dtClientwDetCodigoAleatorio = BL_ValidarCodigoAlearorio_UsadoxUsuario(enCodAleatorio);

                    if (dtClientwDetCodigoAleatorio != null && dtClientwDetCodigoAleatorio.Rows.Count > 0)
                    {
                        textError = EN_Constante.textCodigoYaUsado;
                        //Response.Write("<script> alert('El código ya ha sido usado') </script>");
                    }
                }
                else
                {
                    textError = EN_Constante.textCodigoYaUsado;
                    //Response.Write("<script> alert('El código ya ha sido usado') </script>");
                }
            }
            else
            {
                textError = EN_Constante.textCodigoNoVigente;
                //Response.Write("<script> alert('El código no está vigente') </script>");
            }

            return textError;
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
