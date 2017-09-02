using ApuestaCliente.BussinesLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApuestasCliente
{
    public partial class AnalisisPronosticoAG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            pintarDocumentos();
        }

        private void pintarDocumentos()
        {
            HyperLink hyperLinkDocumento;
            Panel pane ;

            DataTable dt = new DataTable();
            BL_Documento blDocumento = new BL_Documento();
            dt = blDocumento.BL_ObtenerDocumentosActivos();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pane = new Panel();
                pane.CssClass = "source";

                hyperLinkDocumento = new HyperLink();
                hyperLinkDocumento.Target = "_blank";
                hyperLinkDocumento.NavigateUrl = dt.Rows[i]["ruta_documento"].ToString();
                hyperLinkDocumento.Text = dt.Rows[i]["nombre_documento"].ToString();

                pane.Controls.Add(hyperLinkDocumento);

                this.MyContent.Controls.Add(pane);
            }
        }
    }
}