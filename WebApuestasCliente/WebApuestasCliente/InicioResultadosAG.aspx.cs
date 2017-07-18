using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApuestasCliente
{
    public partial class InicioResultadosAG : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ImgCartillaSuerte_Click(object sender, ImageClickEventArgs e)
        {
            HttpContext.Current.Response.Redirect("~/Juego/CartillaSuerte.aspx");
        }
    }
}