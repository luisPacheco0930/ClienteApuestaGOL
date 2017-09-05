using ApuestaCliente.BussinesLogic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
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
            //HyperLink hyperLinkDocumento;
            Panel pane ;
            HtmlIframe iframe;


            DataTable dt = new DataTable();
            BL_Documento blDocumento = new BL_Documento();
            dt = blDocumento.BL_ObtenerDocumentosActivos();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                pane = new Panel();
                pane.CssClass = "source";

                iframe = new HtmlIframe();
                iframe.Attributes["height"] = "750px";
                iframe.Attributes["width"] = "500px";
                iframe.Style["left"] = "50%";
                iframe.Style["margin-left"] = "25%";
                iframe.Src = dt.Rows[i]["ruta_documento"].ToString();
                //iframe.InnerHtml = dt.Rows[i]["ruta_documento"].ToString();
                pane.Controls.Add(iframe);

                /******************************************************************************/
                /*
                hyperLinkDocumento = new HyperLink();
                hyperLinkDocumento.Target = "_blank";
                hyperLinkDocumento.NavigateUrl = dt.Rows[i]["ruta_documento"].ToString();
                hyperLinkDocumento.Text = dt.Rows[i]["nombre_documento"].ToString();

                pane.Controls.Add(hyperLinkDocumento);
                */
                this.MyContent.Controls.Add(pane);
            }
        }
    }
}