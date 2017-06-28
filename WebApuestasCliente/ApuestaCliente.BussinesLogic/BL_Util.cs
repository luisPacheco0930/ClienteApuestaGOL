using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;
using System.Web;

namespace ApuestaCliente.BussinesLogic
{
    public static class BL_Util
    {
        public static void guardarCookie(HttpContext Context, String nombreCookie, String valorCookie)
        {
            Context.Session[nombreCookie] = valorCookie;
        }

        public static String obtenerCookie(HttpContext Context, String nombreCookie)
        {
           String valorCookie="";
            
            // Get the cookie.
            if(Context.Session[nombreCookie]!=null)
                valorCookie = Context.Session[nombreCookie].ToString();
            // Response.Cookies.Add(myCookie);
            return valorCookie;

            //HttpContext.Current.Session[nombreCookie] = valorCookie;
        }
    }
}
