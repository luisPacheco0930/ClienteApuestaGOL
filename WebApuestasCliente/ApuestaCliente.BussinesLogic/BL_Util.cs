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
        public static void guardarCookie(HttpResponse Response, String nombreCookie, String valorCookie)
        {
            HttpCookie myCookie = new HttpCookie(nombreCookie);
            DateTime now = DateTime.Now;

            // Set the cookie value.
            myCookie.Value = valorCookie;
            // Set the cookie expiration date.
            //myCookie.Expires = now.AddMinutes(1);

            // Add the cookie.
            Response.Cookies.Add(myCookie);


            HttpContext.Current.Session[nombreCookie] = valorCookie;
        }
    }
}
