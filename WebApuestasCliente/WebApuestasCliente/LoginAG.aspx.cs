using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApuestasCliente
{
    public partial class LoginAG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            Session.RemoveAll(); 
        }

        protected void btnLoguear_Click(object sender, EventArgs e)
        {
            Response.Redirect("InicioAG.aspx");
        }
    }
}