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

        public EN_ProgramacionApuesta BL_codAleatorio_fechaTope(EN_CodigoAleatorio enCodAleatorio)
        {
            EN_ProgramacionApuesta apuesta=null;

            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_CodAleatorio_FechaTope(dbContexto, enCodAleatorio);
            }

            if(dtLista != null && dtLista.Rows.Count > 0)
            {
                apuesta = new EN_ProgramacionApuesta();
                apuesta.IdProgramaApuesta= dtLista.Rows[0].Field<int>(0);
                apuesta.FechaInicial = dtLista.Rows[0].Field<DateTime>(1);
                apuesta.FechaFinal = dtLista.Rows[0].Field<DateTime>(2);
                //apuesta.Vigencia = dtLista.Rows[0].Field<Char>(3);
                //apuesta.CodigoTipoApuesta = dtLista.Rows[0].Field<Char>(4);
            }
            return apuesta;
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
