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
            DataTable dtListaCodAleatorio = new DataTable();
            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();

            try
            {
                enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text.ToString();
                dtListaCodAleatorio = blCodAleatorio.BL_ValidarCodigoAlearorio(enCodAleatorio);

                if (dtListaCodAleatorio.Rows.Count > 0) 
                { 
                    if (this.txtNroPromocional.Text.ToString().Equals(dtListaCodAleatorio.Rows[0][0].ToString()))
                    {
                        Response.Redirect("InicioAG.aspx");
                    }
                    else
                    {
                        Response.Write("<script> alert('Codigo NO VALIDO, para el juego.') </script>");
                    }
                }
                else
                {
                    Response.Write("<script> alert('Codigo NO VALIDO, para el juego.') </script>");
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