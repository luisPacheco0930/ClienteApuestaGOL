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

        public DataTable BL_ValidarCodigoAlearorio_ResultadoListo(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daCodAleatorio.DA_ValidarCodigoAleatorio_ResultadoListo(dbContexto, enCodAleatorio);
            }
            return dtLista;
        }

        //public String BL_validarCodigoXprograma(EN_CodigoAleatorio enCodAleatorio, String TipoApuesta)
        //{
        //    String textError = "";
        //    DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
        //    DataTable dtGeneraCodigo = new DataTable();
        //    using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
        //    {
        //        dtGeneraCodigo = daCodAleatorio.DA_validarCodigoXprograma(dbContexto, enCodAleatorio, TipoApuesta);
        //        if (dtGeneraCodigo == null || dtGeneraCodigo.Rows.Count == 0)
        //        {
        //            textError = EN_Constante.textNohayProgramaParaCodigo;
        //        }
        //    }
        //    return textError;
        //}

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
                    }
                }
                else
                {
                    textError = EN_Constante.textCodigoYaUsado;
                }
            }
            else
            {
                textError = EN_Constante.textCodigoNoVigente;
            }

            return textError;
        }

        public String BL_validarCodigoJugadoResultadoListo(EN_CodigoAleatorio enCodAleatorio)
        {
            String textError = "";
            DataTable dtClientwDetCodigoAleatorio = new DataTable();
            DataTable dtApuestaCodigoAleatorio = new DataTable();
           
            // vacio no jugado
            // codigoTipoApuesta jugado y programación finalizada

            dtApuestaCodigoAleatorio = BL_ValidarCodigoAlearorio_ResultadoListo(enCodAleatorio);
            if (dtApuestaCodigoAleatorio != null && dtApuestaCodigoAleatorio.Rows.Count > 0)
            {
                textError = dtApuestaCodigoAleatorio.Rows[0].Field<String>(0); ;
            }

            return textError;
        }

        public EN_ProgramacionApuesta BL_validarCodigoXprograma(EN_CodigoAleatorio enCodAleatorio, string CodApuesta)
        {
            EN_ProgramacionApuesta apuesta = null;

            DataTable dtLista = new DataTable();
            DA_CodigoAleatorio daCodAleatorio = new DA_CodigoAleatorio();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                //dtLista = daCodAleatorio.DA_CodAleatorio_FechaTope(dbContexto, enCodAleatorio, CodApuesta);
                dtLista = daCodAleatorio.DA_validarCodigoXprograma(dbContexto, enCodAleatorio, CodApuesta);
                if (dtLista != null && dtLista.Rows.Count > 0)
                {
                    apuesta = new EN_ProgramacionApuesta();
                    apuesta.IdProgramaApuesta = Convert.ToInt32(dtLista.Rows[0][0].ToString());
                    apuesta.FechaInicial = dtLista.Rows[0].Field<DateTime>(1);
                    apuesta.FechaFinal = dtLista.Rows[0].Field<DateTime>(2);
                }
            }
            return apuesta;
        }
    }
}
