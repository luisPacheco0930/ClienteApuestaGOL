using System;
using System.Collections.Generic;
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