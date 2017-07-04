using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApuestasCliente
{
    public partial class SWApuestaCliente : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            BL_Cliente blCliente = new BL_Cliente();

            String nroDoc = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc);
            if (!String.IsNullOrEmpty(nroDoc) && !nroDoc.Equals(""))
            {
                EN_Cliente enCliente = new EN_Cliente();
                enCliente.NroDocumento = nroDoc;
                dt = blCliente.BL_ObtenerNombreUsuario(enCliente);

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.linkNombreUsuario.Visible = true;
                    this.linkNombreUsuario.Text = dt.Rows[0]["nombreapellido"].ToString();
                }
                else
                {
                    this.linkNombreUsuario.Visible = false;
                }
            }
        }

        protected void CerrarSession_Click(object sender, EventArgs e)
        {
            Session.Abandon();
            //if (Request.Cookies["SR_Usuario"] != null)
            //{
            //    HttpCookie myCooKies = new HttpCookie("SR_Usuario");
            //    myCooKies.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCooKies);
            //}

            //if (Request.Cookies["SR_Password"] != null)
            //{
            //    HttpCookie myCooKies = new HttpCookie("SR_Password");
            //    myCooKies.Expires = DateTime.Now.AddDays(-1d);
            //    Response.Cookies.Add(myCooKies);
            //}

            HttpCookie aCookie;
            string cookieName;
            int limit = Request.Cookies.Count;
            for (int i = 0; i < limit; i++)
            {
                cookieName = Request.Cookies[i].Name;
                aCookie = new HttpCookie(cookieName);
                aCookie.Expires = DateTime.Now.AddDays(-1);
                Response.Cookies.Add(aCookie);
            }
            HttpContext.Current.Response.Redirect("~/LoginAG.aspx");
        }
    }
}