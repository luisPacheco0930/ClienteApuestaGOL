using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApuestasCliente.ResultadoGanadores
{
    public partial class PollaSemanalRG : System.Web.UI.Page
    {
        int p_orden_prog = 0;
        String ls_codTipoApuesta = EN_Constante.laPollaSemanal;

        DataTable dt_datosApuesta = new DataTable();
        BL_ApuestaUsuario blApuesta = new BL_ApuestaUsuario();

        int p_idprogSelected; string p_param_idProg;
        protected void Page_Load(object sender, EventArgs e)
        {
            string p_inicioResul = Request.QueryString["InicioResul"];

            p_param_idProg = Request.QueryString["px_idProg"];

            this.lblTituloResultado.InnerText = "Resultados LA POLLA SEMANAL";
            this.lblFechasApuesta.InnerText = "Fecha: ";

            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioResultadoPolla);

            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            enCodAleatorio.NroCodigoAleatorio = "";
            dt_datosApuesta = blApuesta.BL_ObtenerDatosApuesta(enCodAleatorio, ls_codTipoApuesta);

           // Response.Write("<script> alert('p_inicioResul: "+ p_param_idProg + " Rows:" + dt_datosApuesta.Rows.Count +"') </script>");

            
            pintarListaProgramaciones();
            pintarDatosApuesta();
            pintarResultadoPartidos(p_idprogSelected);
            pintarGanadores(p_idprogSelected);
            //if (!String.IsNullOrEmpty(p_inicioResul))
            //{
            //    pintarDatosApuesta(enCodAleatorio, p_orden_prog);
            //    pintarResultadoPartidos(p_idprogSelected);
            //    pintarGanadores(enCodAleatorio);
            //}
            //else
            //{
            //    if (!String.IsNullOrEmpty(codeFrom))
            //    {
            //        //EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            //        enCodAleatorio.NroCodigoAleatorio = codeFrom;
            //        pintarDatosApuesta(enCodAleatorio, p_orden_prog);
            //        pintarResultadoPartidos(p_idprogSelected);
            //        pintarGanadores(enCodAleatorio);
            //    }
            //    else
            //    {
            //        pintarCabeceraResultadoPartidos();
            //    }
            //}
        }

        public void pintarDatosApuesta()
        {
            
            if (String.IsNullOrEmpty(p_param_idProg))
            {
                p_idprogSelected = int.Parse(dt_datosApuesta.Rows[0]["IdProgramaApuesta"].ToString());
            }
            else
                p_idprogSelected = int.Parse(p_param_idProg);

            txtNroProgramacion2.Text = "Resultados de Programación N° " + p_idprogSelected;

            DataTable dt = new DataTable();
            dt = blApuesta.BL_ObtenerDatosApuesta_XPROG(p_idprogSelected);

            //Fecha: 26 de Marzo 2017 al 01 de Abril 2017
            this.lblFechasApuesta.InnerText = this.lblFechasApuesta.InnerText + ((DateTime)dt.Rows[0]["fechaInicial"]).ToLongDateString()
                + " al " + ((DateTime)dt.Rows[0]["fechaFinal"]).ToLongDateString();

            this.lblJugadores.InnerText = dt.Rows[0]["cantidadJugada"].ToString();
            this.lblGanadores.InnerText = dt.Rows[0]["ganadores"].ToString();
            this.lblPozo.InnerText = dt.Rows[0]["montoPozo"].ToString();

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

        public void pintarListaProgramaciones()
        {
            TableRow row0 = new TableHeaderRow();
            row0.TableSection = TableRowSection.TableHeader;
            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Text = "Prog";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Fecha";
            row0.Cells.Add(cell1);

            tableListProg.Rows.Add(row0);

            if (dt_datosApuesta.Rows.Count > 0)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < dt_datosApuesta.Rows.Count; i++)
                {
                    row2 = new TableRow();
                    
                    TableCell cell2 = new TableCell();

                    HyperLink h1 = new HyperLink();
                    h1.Text = dt_datosApuesta.Rows[i]["IdProgramaApuesta"].ToString();
                    h1.NavigateUrl = "~/ResultadoGanadores/PollaSemanalRG.aspx?px_idProg="+ dt_datosApuesta.Rows[i]["IdProgramaApuesta"].ToString();
                    cell2.Controls.Add(h1);
                    //cell2.Text = dt_datosApuesta.Rows[i]["IdProgramaApuesta"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = ((DateTime)dt_datosApuesta.Rows[i]["fechaFinal"]).ToShortDateString();
                    row2.Cells.Add(cell2);

                    tableListProg.Rows.Add(row2);
                }
            }
          }

                public void pintarDetalleResultadoPartidos(int p_idProgramacion)
        {

            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();

            dt = blpartidosProgramados.BL_ListarResultadoPartidos_XPROG(p_idProgramacion);
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
                cell2.Text = dt.Rows[i]["resultado"].ToString();
                row2.Cells.Add(cell2);

                tablePartResul.Rows.Add(row2);
            }
            }
        }

        public void pintarResultadoPartidos(int p_idProgramacion)
        {
            pintarCabeceraResultadoPartidos();
            pintarDetalleResultadoPartidos(p_idProgramacion);
        }

        public void pintarGanadores(int p_idProgramacion)
        {

            TableRow row0 = new TableHeaderRow();
            row0.TableSection = TableRowSection.TableHeader;
            TableHeaderCell cell1 = new TableHeaderCell();
            cell1.Text = "Categoría de Premios";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Número de Ganadores";
            row0.Cells.Add(cell1);

            cell1 = new TableHeaderCell();
            cell1.Text = "Premio c/u";
            row0.Cells.Add(cell1);

            tableGanadores.Rows.Add(row0);

            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarResumenGanadores_XPROG(p_idProgramacion);

            if (dt.Rows.Count > 0)
            {
                TableRow row2 = new TableRow();

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    row2 = new TableRow();
                    TableCell cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["descPozo"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["cantGanadores"].ToString();
                    row2.Cells.Add(cell2);

                    cell2 = new TableCell();
                    cell2.Text = dt.Rows[i]["descPremio"].ToString();
                    row2.Cells.Add(cell2);

                    tableGanadores.Rows.Add(row2);
                }
            }
            }

    }
}