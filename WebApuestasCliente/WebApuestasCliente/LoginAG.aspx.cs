using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Data;


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
            DataTable dtGeneraCodigo = new DataTable();
            DataTable dtApuestaCodigoAleatorio = new DataTable();
            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();

            try
            {
                if (!this.checkBoxLogin.Checked)
                {
                    enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text.ToString();
                    dtGeneraCodigo = blCodAleatorio.BL_ValidarCodigoAlearorio_EstaVigente(enCodAleatorio);

                    if (dtGeneraCodigo!=null && dtGeneraCodigo.Rows.Count > 0)
                    {
                        dtApuestaCodigoAleatorio = blCodAleatorio.BL_ValidarCodigoAlearorio_YaJugado(enCodAleatorio);
                        if (dtApuestaCodigoAleatorio == null || dtApuestaCodigoAleatorio.Rows.Count == 0)
                        {
                            BL_Util.guardarCookie(Response,EN_Constante.nombreCookieCodAleatorio,enCodAleatorio.NroCodigoAleatorio);
                            String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                            Response.Redirect("InicioAG.aspx");
                        }
                        else
                        {
                            Response.Write("<script> alert('El código ya ha sido usado') </script>");
                        }

                    }
                    else
                    {
                        Response.Write("<script> alert('El código no está vigente') </script>");
                    }
                }
                else
                {
                    
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Hubo problemas...') </script>");
            }
            finally { 
                
            }

            
        }
    }
}