using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Text;
using System.Data;
using System.Web.UI.HtmlControls;

namespace WebApuestasCliente.ResultadoGanadores
{
    public partial class ApuestaGolesRG : System.Web.UI.Page
    {
        String ls_codTipoApuesta = EN_Constante.apuestaGoles;
        protected void Page_Load(object sender, EventArgs e)
        {
            string p_inicioResul = Request.QueryString["InicioResul"];

            this.lblTituloResultado.InnerText = "Resultados APUESTA GOLES";
            this.lblFechasApuesta.InnerText = "Fecha: ";

            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioResultadoApuesta);

            if (!String.IsNullOrEmpty(p_inicioResul))
            {
                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = "";
                pintarDatosApuesta(enCodAleatorio);
                pintarResultadoPartidos(enCodAleatorio);
                pintarGanadores(enCodAleatorio);
            }
            else
            {
                if (!String.IsNullOrEmpty(codeFrom))
                {
                    EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                    enCodAleatorio.NroCodigoAleatorio = codeFrom;
                    pintarDatosApuesta(enCodAleatorio);
                    pintarResultadoPartidos(enCodAleatorio);
                    pintarGanadores(enCodAleatorio);
                }
                else
                {
                    pintarCabeceraResultadoPartidos();
                }
            }
            
        }

        public void pintarDatosApuesta(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dt = new DataTable();
            BL_ApuestaUsuario blApuesta = new BL_ApuestaUsuario();
            dt = blApuesta.BL_ObtenerDatosApuesta(enCodAleatorio,ls_codTipoApuesta);

            //Fecha: 26 de Marzo 2017 al 01 de Abril 2017
            if (dt.Rows.Count > 0)
            {
                this.lblFechasApuesta.InnerText = this.lblFechasApuesta.InnerText + ((DateTime)dt.Rows[0]["fechaInicial"]).ToLongDateString()
                    + " al " + ((DateTime)dt.Rows[0]["fechaFinal"]).ToLongDateString();

                this.lblJugadores.InnerText = dt.Rows[0]["cantidadJugada"].ToString();
                this.lblGanadores.InnerText = dt.Rows[0]["ganadores"].ToString();
                this.lblPozo.InnerText = dt.Rows[0]["montoPozo"].ToString();
            }
        }

        public void pintarCabeceraResultadoPartidos()
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
            tablePartResul.Rows.Add(row0);
        }

        public void pintarDetalleResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarResultadoPartidos(enCodAleatorio,ls_codTipoApuesta);

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

                    if (dt.Rows[i]["resultado"].ToString().Contains("V"))
                    {
                        cell2.CssClass = "result-v";
                    }
                    else
                    {
                        if (dt.Rows[i]["resultado"].ToString().Contains("L"))
                        {
                            cell2.CssClass = "result-l";
                        }
                        else
                            cell2.CssClass = "result-e";
                    }
                    cell2.Text = dt.Rows[i]["resultado"].ToString();
                    row2.Cells.Add(cell2);

                    tablePartResul.Rows.Add(row2);
                }

            }
        }

        public void pintarResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            pintarCabeceraResultadoPartidos();
            pintarDetalleResultadoPartidos(enCodAleatorio);            
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
            dt = blpartidosProgramados.BL_ListarGanadores(enCodAleatorio,ls_codTipoApuesta);

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

    }
}