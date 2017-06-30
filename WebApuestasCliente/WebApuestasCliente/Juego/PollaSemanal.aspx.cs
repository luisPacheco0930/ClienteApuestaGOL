﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Web.UI.HtmlControls;
using AjaxControlToolkit;
using System.Data;


namespace WebApuestasCliente.Juego
{
    public partial class PollaSemanal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals(""))
            {
                this.txtCode.Text = codeFrom;

                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();

                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = codeFrom;
                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                if (!String.IsNullOrEmpty(textError))
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoNoValido;
                    this.pnlValidator.CssClass = "alert alert-danger";
                    this.txtCode.Enabled = false;
                }
                else
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                    this.pnlValidator.CssClass = "alert alert-success";
                    this.txtCode.Enabled = false;

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio);
                    this.lblCodFecTope.Text = d.FechaFinal.ToShortTimeString() + " del " + d.FechaFinal.ToShortDateString(); // d.ToLongDateString();
                    this.txtNroProgramacion.Text = d.IdProgramaApuesta.ToString();
                    pintarPartidos(enCodAleatorio);
                }
            }
            else
            {
                this.lblStatusCode.Text = EN_Constante.textCodigoNoIngresado;
                this.pnlValidator.CssClass = "alert alert-info";
                this.txtCode.Enabled = true;
            }
        }
        protected void txtCodigoAleatorio_TextChanged(object sender, System.EventArgs e)
        {
            if (this.txtCode != null && !String.IsNullOrEmpty(this.txtCode.Text))
            {
                //En caso si se ingrese a esta sección con un código promocional
                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();

                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = this.txtCode.Text;
                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);
                if (!String.IsNullOrEmpty(textError))
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoNoValido;
                    this.pnlValidator.CssClass = "alert alert-danger";
                    this.txtCode.Enabled = false;
                }
                else
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                    this.pnlValidator.CssClass = "alert alert-success";
                    this.txtCode.Enabled = false;
                    BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, this.txtCode.Text);


                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio);
                    this.lblCodFecTope.Text = d.FechaFinal.ToShortTimeString() + " del " + d.FechaFinal.ToShortDateString(); // d.ToLongDateString();
                    this.txtNroProgramacion.Text = d.IdProgramaApuesta.ToString();
                    pintarPartidos(enCodAleatorio);
                }
            }
            else
            {
                this.lblStatusCode.Text = EN_Constante.textCodigoNoIngresado;
                this.pnlValidator.CssClass = "alert alert-info";
                this.txtCode.Enabled = true;
            }
        }

        private void pintarPartidos(EN_CodigoAleatorio enCodAleatorio)
        {

            // pintando partidos
            Accordion acrDynamic = new Accordion();
            acrDynamic.ID = "MyAccordion";
            acrDynamic.SelectedIndex = -1;//No default selection  
            acrDynamic.RequireOpenedPane = false;//no open pane  
            acrDynamic.HeaderCssClass = "panel-heading";//Header class  
            acrDynamic.HeaderSelectedCssClass = "panel-heading";//Selected herder class  
            acrDynamic.ContentCssClass = "form-group list-one";//Content class  

            Label lbTitle;
            Label lbContent;
            AccordionPane pane;
            string Content = "";
            Image img;
            List<String> listaEquipos = new List<string>();


            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.laPollaSemanal);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string BranchName = dt.Rows[i]["descTorneo"].ToString();
                string Next_Branch = "";
                if ((i + 1) < dt.Rows.Count)
                    Next_Branch = dt.Rows[i + 1]["descTorneo"].ToString();
                else
                    Next_Branch = "";

                //if (i != dt.Rows.Count - 1)
                //    Next_Branch = dt.Rows[i + 1]["descTorneo"].ToString();

                listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString() + "/" + dt.Rows[i]["icoLoc"].ToString() + "/" + dt.Rows[i]["icoVis"].ToString()+"/"+ dt.Rows[i]["IdDetallePrograma"].ToString());

                Content += dt.Rows[i]["equiDescLoc"].ToString() + "<br/>";

                if (BranchName != Next_Branch) //if last row of branch  
                {
                    pane = new AccordionPane();
                    lbTitle = new Label();
                    lbContent = new Label();
                    pane.ID = "Pane_" + BranchName.ToString();
                    pane.CssClass = "panel-title";
                    pane.HeaderCssClass = "panel-heading";

                    lbTitle.Text = BranchName;
                    lbTitle.ForeColor = System.Drawing.Color.White;
                    lbTitle.Font.Bold = true;
                    lbTitle.Font.Size = 12;

                    //<img src="../recursos/images/balon.png" />
                    img = new Image();
                    img.ImageUrl = "../recursos/images/balon.png";


                    pane.HeaderContainer.Controls.Add(img);
                    pane.HeaderContainer.Controls.Add(lbTitle);

                    //pane.HeaderCssClass = "panel-title";
                    Panel panPartido; //= new Panel();
                    Panel panJ; //= new Panel();
                    Panel panJugada; //= new Panel();
                    Panel panO;
                    for (int j = 0; j < listaEquipos.Count; j++)
                    {
                        String[] datos = listaEquipos.ElementAt(j).Split('/');
                        String encuentro = datos[0];
                        String iconoLoc = datos[1];
                        String iconoVis = datos[2];
                        String idDetallePrograma = datos[3];

                        panPartido = new Panel();
                        panPartido.CssClass = "col-sm-7";

                        panJ = new Panel();
                        panJ.CssClass = "versus";

                        Label lx;
                        lx = new Label();
                        lx.Text = "" + j + ".";
                        lx.CssClass = "list-item";
                        panJ.Controls.Add(lx);

                        lx = new Label();
                        lx.Text = encuentro;
                        lx.CssClass = "list-title";
                        panJ.Controls.Add(lx);
                        panPartido.Controls.Add(panJ);


                        panJugada = new Panel();
                        panJugada.CssClass = "col-sm-5";

                        panO = new Panel();
                        panO.CssClass = "option-games";


                        Image imagLV;
                        imagLV = new Image();
                        imagLV.ImageUrl = EN_Constante.rutaIconosEquipos + iconoLoc;
                        panO.Controls.Add(imagLV);

                        TextBox cbx;
                        cbx = new TextBox();
                        //cbx.Text = "L";
                        cbx.ID = idDetallePrograma + "L";
                        cbx.CssClass = "form-option";
                        cbx.Attributes.Add("style", "margin: 0px 5px 0px 5px");
                        panO.Controls.Add(cbx);

                        cbx = new TextBox();
                        //cbx.Text = "E";
                        cbx.ID = idDetallePrograma + "V";
                        cbx.CssClass = "form-option";
                        cbx.Attributes.Add("style", "margin: 0px 5px 0px 5px");
                        panO.Controls.Add(cbx);

                        imagLV = new Image();
                        imagLV.ImageUrl = EN_Constante.rutaIconosEquipos + iconoVis;
                        panO.Controls.Add(imagLV);

                        panJugada.Controls.Add(panO);

                        pane.ContentContainer.Controls.Add(panPartido);
                        pane.ContentContainer.Controls.Add(panJugada);
                    }


                    //lbContent.Text = Content;
                    //pane.ContentContainer.Controls.Add(lbContent);

                    acrDynamic.Panes.Add(pane);
                    Content = "";
                    listaEquipos = new List<string>();
                }
            }

            this.MyContent.Controls.Add(acrDynamic);
        }

        protected void btnGuardarPollaSemanal_Click(object sender, EventArgs e)
        {/*
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals(""))
            {
                this.txtCode.Text = codeFrom;

                BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = codeFrom;
                DataTable dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.laPollaSemanal);

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    String IdDetallePrograma = dt.Rows[i]["IdDetallePrograma"].ToString()+"L";
                    String mpid = "masterPage_" + dt.Rows[i]["IdDetallePrograma"].ToString() + "L";
                    Control tb1 = this.MyContent.FindControl(IdDetallePrograma);
                    Control tb2 = this.MyContent.FindControl(mpid);
                    
                }
            }
        */}
    }
}