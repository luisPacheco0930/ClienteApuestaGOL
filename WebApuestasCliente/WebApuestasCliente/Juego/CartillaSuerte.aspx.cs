using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;

namespace WebApuestasCliente.Juego
{
    public partial class CartillaSuerte : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals("")) {
                this.code.Text = codeFrom;

                //En caso si se ingrese a esta sección con un código promocional
                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();

                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = codeFrom;
                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                if (!String.IsNullOrEmpty(textError))
                {
                    this.codeStatus.Text = textError;
                }
                else
                    this.codeStatus.Text = EN_Constante.textCodigoValido;
            }

            
        }
    }
}