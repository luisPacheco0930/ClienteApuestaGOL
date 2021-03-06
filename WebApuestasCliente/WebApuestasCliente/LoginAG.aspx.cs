﻿using System;
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

        protected void btnVerJugada_Click(object sender, EventArgs e)
        {
            String textError = "Datos Incompletos";
          //  Response.Write("<script> alert('" + textError + "') </script>");

            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            BL_Cliente blCliente = new BL_Cliente();

            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            EN_Cliente enCliente = new EN_Cliente();

            textError = "";
            if (this.txtNroPromocionalJugado != null && !String.IsNullOrEmpty(this.txtNroPromocionalJugado.Text))
            {       enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text;
                    //String codTipoApuesta = blCodAleatorio.BL_validarCodigoJugadoResultadoListo(enCodAleatorio);
                    //if (String.IsNullOrEmpty(codTipoApuesta))
                    //{
                    textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);

                    if (String.IsNullOrEmpty(textError))
                    {
                        Response.Write("<script> alert('" + textError + "') </script>");
                    }
                    else
                    {
                        BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioVerJugada,this.txtNroPromocionalJugado.Text);
                        //String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                        this.txtNroPromocionalJugado.Text = "";
                        Response.Redirect("/Visualizar/VisualizarJugada.aspx", false);
                    }
                   
            }
            else
            {
                Response.Write("<script> alert('Ingresar Codigo Promocional') </script>");
            }

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
                    else
                    {

                    }
                    //else {
                    //    textError = "Texto Aleatorio Incorrecto.";
                    //    Response.Write("<script> alert('" + textError + "') </script>");
                    //}

                }
            }

        }

        public void LimpiarCampos()
        {
            this.txtdni.Text = null;
            this.txtNombres.Text = null;
            this.txtApellidos.Text = null;
            this.txtEmail.Text = null;
            this.txtPassword.Text = null;
            this.txtCaptcha.Text = null;
        }

        public void irAResultados(String codTipoApuesta, EN_CodigoAleatorio enCodAleatorio)
        {
            Response.Write("<script> alert('Los resultados ya están listos!') </script>");

            if (codTipoApuesta.Equals(EN_Constante.cartillaDeLaSuerte))
            {
                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioResultadoCartilla, enCodAleatorio.NroCodigoAleatorio);
                HttpContext.Current.Response.Redirect("~/ResultadoGanadores/CartillaSuerteRG.aspx");
            } else
            if (codTipoApuesta.Equals(EN_Constante.laPollaSemanal))
            {
                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioResultadoPolla, enCodAleatorio.NroCodigoAleatorio);
                HttpContext.Current.Response.Redirect("~/ResultadoGanadores/PollaSemanalRG.aspx");
            } else
            if (codTipoApuesta.Equals(EN_Constante.apuestaGoles))
            {
                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorioResultadoApuesta, enCodAleatorio.NroCodigoAleatorio);
                HttpContext.Current.Response.Redirect("~/ResultadoGanadores/ApuestaGolesRG.aspx");
            }
        }

        protected void btnLoguear_Click(object sender, EventArgs e)
        {
            BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
            BL_Cliente blCliente = new BL_Cliente();

            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            EN_Cliente enCliente = new EN_Cliente();
            try
            {
                //String recaptchaResponse = Request.Form.Get("g-recaptcha-response");
                //Response.Write("<script> alert('Iniicio') </script>");
                Captcha2.ValidateCaptcha(txtCaptcha2.Text.Trim());
                
                Boolean b = Captcha2.UserValidated;
                
                //Response.Write("<script> alert('" + recaptchaResponse + "') </script>");
                if (!this.checkBoxLogin.Checked)
                {
                    if (this.txtNroPromocional != null && !String.IsNullOrEmpty(this.txtNroPromocional.Text))
                    {
                        if (b) //recaptchaResponse != null && !recaptchaResponse.Equals(""))
                        {
                            enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text;
                            //String codTipoApuesta = blCodAleatorio.BL_validarCodigoJugadoResultadoListo(enCodAleatorio);
                            //if (String.IsNullOrEmpty(codTipoApuesta))
                            //{
                                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                                if (!String.IsNullOrEmpty(textError))
                                {
                                    Response.Write("<script> alert('" + textError + "') </script>");
                                }
                                else
                                {
                                    BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, enCodAleatorio.NroCodigoAleatorio);
                                    //String valor = HttpContext.Current.Session[EN_Constante.nombreCookieCodAleatorio].ToString();
                                    Response.Redirect("InicioAG.aspx", false);
                                }
                            //}
                            //else
                            //    irAResultados(codTipoApuesta, enCodAleatorio);
                        }
                        else
                        {
                            Response.Write("<script> alert('Ingrese Código de Seguridad Correcto') </script>");
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
                    else
                    {
                        if (this.txtNroPromocional != null && !String.IsNullOrEmpty(this.txtNroPromocional.Text))
                        {
                            enCodAleatorio.NroCodigoAleatorio = this.txtNroPromocional.Text;
                            textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                            //String codTipoApuesta = blCodAleatorio.BL_validarCodigoJugadoResultadoListo(enCodAleatorio);
                            //if (String.IsNullOrEmpty(codTipoApuesta))
                            //{
                                if (!String.IsNullOrEmpty(textError))
                                {
                                    Response.Write("<script> alert('" + textError + "') </script>");
                                }
                                else
                                {
                                    if (b) //recaptchaResponse != null && !recaptchaResponse.Equals(""))
                                    {
                                        BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, enCodAleatorio.NroCodigoAleatorio);
                                        BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc, enCliente.NroDocumento);
                                        Response.Redirect("InicioAG.aspx", false);
                                    }
                                    else
                                    {
                                        Response.Write("<script> alert('Ingrese Código de Seguridad Correcto') </script>");
                                    }
                                }
                            //}
                            //else
                            //    irAResultados(codTipoApuesta, enCodAleatorio);

                        }
                        else
                        {
                            if (b) //recaptchaResponse != null && !recaptchaResponse.Equals(""))
                            {
                                BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc, enCliente.NroDocumento);
                                Response.Redirect("InicioAG.aspx",false);
                            }
                            else
                            {
                                Response.Write("<script> alert('Ingrese Código de Seguridad Correcto') </script>");
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Response.Write("<script> alert('Hubo problemas...') </script>");
            }
            finally
            {

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
                else
                {
                    validaCaptcha = false;
                    this.txtCaptcha.Text = null;
                    Response.Write("<script> alert('Código de seguridad incorrecto! Vuelva a intentarlo...') </script>");
                }
            }
        }
    }
}