using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Data;
using MSCaptcha;
//using BotDetect.Web.;

namespace WebApuestasCliente
{
    public partial class LoginAG : System.Web.UI.Page
    {
        Boolean validaCaptcha = true;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack) return;
            Session.RemoveAll(); 
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
          
            BL_Cliente blCliente = new BL_Cliente();
            EN_Cliente enCliente = new EN_Cliente();

            Boolean valido = true;
            if (this.txtdni != null && !String.IsNullOrEmpty(this.txtdni.Text))
                enCliente.NroDocumento = this.txtdni.Text.Trim();
            else
                valido = false;
            if (this.txtNombres != null && !String.IsNullOrEmpty(this.txtNombres.Text))
                enCliente.Nombres = this.txtNombres.Text.Trim();
            if (this.txtApellidos != null && !String.IsNullOrEmpty(this.txtApellidos.Text))
                enCliente.Apellidos = this.txtApellidos.Text.Trim();
            if (this.txtEmail != null && !String.IsNullOrEmpty(this.txtEmail.Text))
                enCliente.Email = this.txtEmail.Text.Trim();
            if (this.txtPassword != null && !String.IsNullOrEmpty(this.txtPassword.Text))
                enCliente.Contrasena = this.txtPassword.Text.Trim();

            if (!valido)
            {
                String textError = "Datos Incompletos";
                Response.Write("<script> alert('" + textError + "') </script>");
            }
            else
            {
                String textError = blCliente.BL_validaExistenciaUsuario(enCliente);
                if (!String.IsNullOrEmpty(textError))
                {
                    Response.Write("<script> alert('" + textError + "') </script>");
                }
                else
                {
                    //Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());

                    if (validaCaptcha)
                    {
                        blCliente.BL_registrarUsuario(enCliente);
                        textError = "Usuario registrado satisfactoriamente";

                        Response.Write("<script> alert('" + textError + "') </script>");
                        LimpiarCampos();
                    }
                    else {
                        
                    }
                    //else {
                    //    textError = "Texto Aleatorio Incorrecto.";
                    //    Response.Write("<script> alert('" + textError + "') </script>");
                    //}

                }
            }
            
        }

        public void LimpiarCampos() {
            this.txtdni.Text = null;
            this.txtNombres.Text = null;
            this.txtApellidos.Text = null;
            this.txtEmail.Text = null;
            this.txtPassword.Text = null;
            this.txtCaptcha.Text = null;
        }

        protected void btnLoguear_Click(object sender, EventArgs e)
        {
            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            BL_Cliente blCliente = new BL_Cliente();

            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            EN_Cliente enCliente = new EN_Cliente();
            try
            {
                    if (!this.checkBoxLogin.Checked)
                    {
                        if(this.txtNroPromocional!=null && !String.IsNullOrEmpty(this.txtNroPromocional.Text))
                        {
                            enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text;
                            String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                            if (!String.IsNullOrEmpty(textError))
                            {
                                Response.Write("<script> alert('" + textError + "') </script>");
                            }
                            else
                            {
                                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, enCodAleatorio.NroCodigoAleatorio);
                                //String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                                Response.Redirect("InicioAG.aspx");
                            }
                        }
                        else
                        {
                            Response.Write("<script> alert('Ingresar Codigo Promocional') </script>");
                        }   
                    }
                    else
                    {
                        enCliente.NroDocumento = this.textNroDocumento.Text.ToString();
                        enCliente.Contrasena = this.textContrasenha.Text.ToString();
                        String textError = blCliente.BL_validarUsuarioIngresado(enCliente);
                        if (!String.IsNullOrEmpty(textError))
                        {
                            Response.Write("<script> alert('" + textError + "') </script>");
                        }
                        else {
                            if (this.txtNroPromocional != null && !String.IsNullOrEmpty(this.txtNroPromocional.Text))
                            {
                                enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text;
                                textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                                if (!String.IsNullOrEmpty(textError))
                                {
                                    Response.Write("<script> alert('" + textError + "') </script>");
                                }
                                else
                                {
                                    BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, enCodAleatorio.NroCodigoAleatorio);
                                    BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc, enCliente.NroDocumento);
                                    //String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                                    Response.Redirect("InicioAG.aspx");
                                }
                            }
                            else
                            {
                                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc, enCliente.NroDocumento);
                                //String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                                Response.Redirect("InicioAG.aspx");
                            }
                        }
                    }
            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Hubo problemas...') </script>");
            }
            finally { 
                
            }

            
        }

        protected void ValidateCaptcha(object sender, ServerValidateEventArgs e)
        {
            if (this.txtdni != null && !String.IsNullOrEmpty(this.txtdni.Text))
            { 
                Captcha1.ValidateCaptcha(txtCaptcha.Text.Trim());
            e.IsValid = Captcha1.UserValidated;
            if (e.IsValid)
            {
                    //Response.Write("<script> alert('validateCaptchaTrue ...') </script>");
                    //ClientScript.RegisterStartupScript(this.GetType(), "alert", "alert('Valid Captcha!');", true);

                }
                else {
                    validaCaptcha = false;
                    this.txtCaptcha.Text = null;
                    Response.Write("<script> alert('Código de seguridad incorrecto! Vuelva a intentarlo...') </script>");
                   
                }
            }
        }
    }
}