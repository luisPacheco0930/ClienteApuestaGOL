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
        String ls_codTipoApuesta = EN_Constante.laPollaSemanal;
        String flagResListos = "NO";
        protected void Page_Load(object sender, EventArgs e)
        {
            //if (Page.IsPostBack) return;
            /*
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioVerJugada);

            
            if (!String.IsNullOrEmpty(codeFrom))
            {
                pintarDatosJugada(codeFrom, sender, e);
            }
            else {
                divResulTitulo.Visible = false;
                divTableResultados.Visible = false;
                divResulResumen.Visible = false;
                divResulGanadores.Visible = false;
                divtablePartJugado.Visible = false;
                divNumProgTitulo.Visible = false;
            }

            if (!String.IsNullOrEmpty(codeFrom))
            {
                this.txtCode.Text = codeFrom;
                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, "");
            }
            */
        }

        public void pintarDatosJugada(String p_codeFrom, object sender, EventArgs e) {
            this.txtCode.Text = p_codeFrom;
            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            enCodAleatorio.NroCodigoAleatorio = this.txtCode.Text;

            BL_ApuestaUsuario blApuestaUsuario = new BL_ApuestaUsuario();
            DataTable dt = blApuestaUsuario.BL_ObtenerDatosApuesta(enCodAleatorio, "");

            this.lblTituloResultado.InnerText = dt.Rows[0]["tipoApuesta"].ToString();
            this.ls_codTipoApuesta = dt.Rows[0]["codTipoApuesta"].ToString();

            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            DataTable dt2 = blCodAleatorio.BL_ValidarCodigoAlearorio_ResultadoListo(enCodAleatorio);


            if (dt2.Rows.Count > 0)
            {
                flagResListos = "SI";
                pintarResultadoPartidos(enCodAleatorio);
                pintarGanadores(enCodAleatorio);
            }
            else
            {
                // divResulTitulo.Visible = false;
                divTableResultados.Visible = false;
                divResulResumen.Visible = false;
                divResulGanadores.Visible = false;
                this.txtNroProgramacion2.Text = "No existe resultado aún de la programación.";
                this.txtNroProgramacion2.ForeColor = System.Drawing.Color.Red;

            }

            //txtCodigoAleatorio_TextChanged(sender, e);
            pintarDatosApuesta(enCodAleatorio);
            pintarPartidoJugado(enCodAleatorio);

        }
        protected void txtCodigoAleatorio_TextChanged(object sender, System.EventArgs e)
        {
            // Response.Write("<script> alert('changed:"+ this.txtCode.Text +"') </script>");
            if (this.txtCode != null && !String.IsNullOrEmpty(this.txtCode.Text))
            {
                //En caso si se ingrese a esta sección con un código promocional
                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();
                BL_PartidosProgramados blProgApuesta = new BL_PartidosProgramados();
                DataTable dt = new DataTable();

                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = this.txtCode.Text;
                String textError = blCodAleatorio.BL_validarCodigoJugado(enCodAleatorio);
              //  Response.Write("<script> alert('EE-" + textError + "') </script>");
                if (!String.IsNullOrEmpty(textError))
                {
                    this.lblStatusCode.Text = textError; //EN_Constante.textCodigoNoValido;
                    this.pnlValidator.CssClass = "alert alert-danger";
                    //this.txtCode.Enabled = false;
                    //this.btnGuardarPollaSemanal.Enabled = false;
                }
                else
                {
                    EN_ProgramacionApuesta enProgXCodAleatorio = null; //blCodAleatorio.BL_obtenerCodigoXprograma(enCodAleatorio, EN_Constante.laPollaSemanal);

                    if (enProgXCodAleatorio == null)
                    {
                        this.lblStatusCode.Text = EN_Constante.textCodigoValido; //EN_Constante.textNohayProgramaParaCodigo; //EN_Constante.textCodigoNoValido;
                        this.pnlValidator.CssClass = "alert alert-success"; //"alert alert-danger";
                      //  this.txtCode.Enabled = false;
                        //  this.btnGuardarPollaSemanal.Enabled = false;
                        // pintarPartidos(enCodAleatorio);
                        pintarDatosJugada(this.txtCode.Text, sender, e);
                    }
                    else
                    {
                        this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                        this.pnlValidator.CssClass = "alert alert-success";
                        // this.txtCode.Enabled = false;
                        pintarDatosJugada(this.txtCode.Text, sender, e);
                        BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, this.txtCode.Text);

                        //this.lblCodFecTope.Text = enProgXCodAleatorio.FechaFinal.ToShortTimeString() + " del " + enProgXCodAleatorio.FechaFinal.ToShortDateString(); // d.ToLongDateString();
                        //this.txtNroProgramacion.Text = enProgXCodAleatorio.IdProgramaApuesta.ToString();
                        //dt = blProgApuesta.BL_ObtenerPozoMayorxApuesta(enProgXCodAleatorio);
                        //this.lblPozoPrograma.Text = "S/. " + dt.Rows[0]["montoPozoMayor"].ToString();

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

        public void pintarCabeceraResultadoPartidos( String flagTable )
        {
            TableRow row0 = new TableHeaderRow();
            row0.TableSection = TableRowSection.TableHeader;
            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Text = "N°";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Fecha";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Local";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "VS";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Visitante";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Torneo";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Resultado";
            row0.Cells.Add(cell1);

            if (flagTable.Equals("R"))
            tablePartResul.Rows.Add(row0);
            else
              tablePartJugado.Rows.Add(row0);
        }

        public void pintarDatosApuesta(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dt = new DataTable();
            BL_ApuestaUsuario blApuesta = new BL_ApuestaUsuario();
            dt = blApuesta.BL_ObtenerDatosApuesta(enCodAleatorio, ls_codTipoApuesta);

            //Fecha: 26 de Marzo 2017 al 01 de Abril 2017
            // this.lblFechasApuesta.InnerText = this.lblFechasApuesta.InnerText + ((DateTime)dt.Rows[0]["fechaInicial"]).ToLongDateString()
            //   + " al " + ((DateTime)dt.Rows[0]["fechaFinal"]).ToLongDateString();

            this.txtNroProgramacion.Text = dt.Rows[0]["IdProgramaApuesta"].ToString();

            this.lblJugadores.InnerText = dt.Rows[0]["cantidadJugada"].ToString();
            this.lblGanadores.InnerText = dt.Rows[0]["ganadores"].ToString();
            this.lblPozo.InnerText = dt.Rows[0]["montoPozo"].ToString();

            if (flagResListos.Equals("SI")) { 
            this.txtNroProgramacion2.Text = "Resultado de la programación N°: " + dt.Rows[0]["IdProgramaApuesta"].ToString();
            }
        }

        public void pintarResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            pintarCabeceraResultadoPartidos("R");
            pintarDetalleResultadoPartidos(enCodAleatorio);
        }

        public void pintarPartidoJugado(EN_CodigoAleatorio enCodAleatorio)
        {
            pintarCabeceraResultadoPartidos("J");
            pintarDetallePartidoJugado(enCodAleatorio);
        }

        public void pintarGanadores(EN_CodigoAleatorio enCodAleatorio)
        {

            TableRow row0 = new TableHeaderRow();
            row0.TableSection = TableRowSection.TableHeader;
            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Text = "CÓDIGO GANADOR";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "DOCUMENTO DE IDENTIDAD";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "APELLIDOS Y NOMBRES";
            row0.Cells.Add(cell1);

            tableGanadores.Rows.Add(row0);

            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarGanadores(enCodAleatorio, ls_codTipoApuesta);

            if (dt.Rows.Count > 0)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row2 = new TableRow();
                    TableCell cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["codigoAleatorio"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["numdocid"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["nombresApellidos"].ToString();
                    row2.Cells.Add(cell2);

                    tableGanadores.Rows.Add(row2);
                }
            }
        }

        public void pintarDetalleResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarResultadoPartidos(enCodAleatorio, ls_codTipoApuesta);

            if (dt.Rows.Count > 0)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row2 = new TableRow();
                    TableCell cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["secuencia"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = ((DateTime)dt.Rows[i]["fechamodificacion"]).ToShortDateString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["equiDescLoc"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    Image img1 = new Image();
                    img1.ID = "Image" + i + "11";
                    img1.ImageUrl = "~/recursos/images/equipos/" + dt.Rows[i]["icoLoc"].ToString();
                    cell2.Controls.Add(img1);
                    img1 = new Image();
                    img1.ID = "Image" + i + "12";
                    img1.ImageUrl = "~/recursos/images/equipos/" + dt.Rows[i]["icoVis"].ToString();
                    cell2.Controls.Add(img1);
                    cell2.CssClass = "equipment";
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["equiDescVis"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["descTorneo"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();

                    if (dt.Rows[i]["resultado"].ToString().Equals("V"))
                    {
                        cell2.CssClass = "result-v";
                    }
                    else
                    {
                        if (dt.Rows[i]["resultado"].ToString().Equals("L"))
                        {
                            cell2.CssClass = "result-l";
                        }
                        else
                            cell2.CssClass = "result-e";
                    }
                    cell2.Text = dt.Rows[i]["resultadoMarcador"].ToString();
                    row2.Cells.Add(cell2);

                    tablePartResul.Rows.Add(row2);
                }
            }
        }

        public void pintarDetallePartidoJugado(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarPartidosJugados(enCodAleatorio, ls_codTipoApuesta);
            //Response.Write("<script> alert('Jugadoos') </script>");
            if (dt.Rows.Count > 0)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row2 = new TableRow();
                    TableCell cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["secuencia"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = ((DateTime)dt.Rows[i]["fechamodificacion"]).ToShortDateString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["equiDescLoc"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    Image img1 = new Image();
                    img1.ID = "JImage" + i + "11";
                    img1.ImageUrl = "~/recursos/images/equipos/" + dt.Rows[i]["icoLoc"].ToString();
                    cell2.Controls.Add(img1);
                    img1 = new Image();
                    img1.ID = "JImage" + i + "12";
                    img1.ImageUrl = "~/recursos/images/equipos/" + dt.Rows[i]["icoVis"].ToString();
                    cell2.Controls.Add(img1);
                    cell2.CssClass = "equipment";
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["equiDescVis"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["descTorneo"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();

                    if (dt.Rows[i]["resultado"].ToString().Equals("V"))
                    {
                        cell2.CssClass = "result-v";
                    }
                    else
                    {
                        if (dt.Rows[i]["resultado"].ToString().Equals("L"))
                        {
                            cell2.CssClass = "result-l";
                        }
                        else
                            cell2.CssClass = "result-e";
                    }

                    if (dt.Rows[i]["codigotipoapuesta"].ToString().Equals(EN_Constante.cartillaDeLaSuerte))
                        cell2.Text = dt.Rows[i]["MarcadorLocal"].ToString() + " - " + dt.Rows[i]["MarcadorVisitante"].ToString();
                    else
                        cell2.Text = dt.Rows[i]["Resultado"].ToString();
                    row2.Cells.Add(cell2);

                    tablePartJugado.Rows.Add(row2);
                }
            }
        }

    }

}