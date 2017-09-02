using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using System.Data;
using System.Text.RegularExpressions;

namespace WebApuestasCliente
{
    public partial class VisualizarJugada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack) return;

            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            this.txtCode.Text = codeFrom;

        }

        protected void txtCodigoAleatorio_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtCode != null && !String.IsNullOrEmpty(this.txtCode.Text))
            {
                //En caso si se ingrese a esta sección con un código promocional
                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();
                BL_PartidosProgramados blProgApuesta = new BL_PartidosProgramados();
                DataTable dt = new DataTable();


                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = this.txtCode.Text;
                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                if (!String.IsNullOrEmpty(textError))
                {
                    this.lblStatusCode.Text = textError; //EN_Constante.textCodigoNoValido;
                    this.pnlValidator.CssClass = "alert alert-danger";
                    this.txtCode.Enabled = false;
                    //this.btnGuardarPollaSemanal.Enabled = false;
                }
                else
                {
                    EN_ProgramacionApuesta enProgXCodAleatorio = blCodAleatorio.BL_validarCodigoXprograma(enCodAleatorio, EN_Constante.laPollaSemanal);

                    if (enProgXCodAleatorio == null)
                    {
                        this.lblStatusCode.Text = EN_Constante.textNohayProgramaParaCodigo; //EN_Constante.textCodigoNoValido;
                        this.pnlValidator.CssClass = "alert alert-danger";
                        this.txtCode.Enabled = false;
                      //  this.btnGuardarPollaSemanal.Enabled = false;
                    }
                    else
                    {
                        this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                        this.pnlValidator.CssClass = "alert alert-success";
                        this.txtCode.Enabled = false;
                      //  this.btnGuardarPollaSemanal.Enabled = true;
                        BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, this.txtCode.Text);

                        //EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio, EN_Constante.laPollaSemanal);
                        this.lblCodFecTope.Text = enProgXCodAleatorio.FechaFinal.ToShortTimeString() + " del " + enProgXCodAleatorio.FechaFinal.ToShortDateString(); // d.ToLongDateString();
                        this.txtNroProgramacion.Text = enProgXCodAleatorio.IdProgramaApuesta.ToString();
                        dt = blProgApuesta.BL_ObtenerPozoMayorxApuesta(enProgXCodAleatorio);
                        this.lblPozoPrograma.Text = "S/. " + dt.Rows[0]["montoPozoMayor"].ToString();

                      //  pintarPartidos(enCodAleatorio);
                    }
                }
            }
            else
            {
                this.lblStatusCode.Text = EN_Constante.textCodigoNoIngresado;
                this.pnlValidator.CssClass = "alert alert-info";
                this.txtCode.Enabled = true;
                //this.btnGuardarPollaSemanal.Enabled = false;
            }
        }

    }

}