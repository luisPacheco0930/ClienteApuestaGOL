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
    public partial class CartillaSuerteRG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            //codeFrom = "5SWH2A9R";
            //Response.Write("<script> alert('"+ codeFrom+"') </script>");
            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            enCodAleatorio.NroCodigoAleatorio = codeFrom;
            pintarResultadoPartidos(enCodAleatorio);

            DataTable dt = new DataTable();
            BL_ApuestaUsuario blApuesta = new BL_ApuestaUsuario();
            dt = blApuesta.BL_ObtenerDatosApuesta(enCodAleatorio);

            this.lblTituloResultado.InnerText = "Resultados "+ dt.Rows[0]["tipoApuesta"].ToString(); 

            //Fecha: 26 de Marzo 2017 al 01 de Abril 2017
            this.lblFechasApuesta.InnerText = "Fecha: " + ((DateTime)dt.Rows[0]["fechaInicial"]).ToLongDateString()
                + " al " + ((DateTime)dt.Rows[0]["fechaFinal"]).ToLongDateString();

            this.lblJugadores.InnerText = dt.Rows[0]["cantidadJugada"].ToString();
            this.lblGanadores.InnerText = dt.Rows[0]["ganadores"].ToString();
        }

        public void pintarResultadoPartidos(EN_CodigoAleatorio enCodAleatorio)
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
            
            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarResultadoPartidos(enCodAleatorio);


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
}