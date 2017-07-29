using System;
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
using System.Text.RegularExpressions;

namespace WebApuestasCliente.Juego
{
    public partial class ApuestaGoles : System.Web.UI.Page
    {
        Accordion acrDynamic;
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
                    this.btnGuardarApuestaGoles.Enabled = false;
                }
                else
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                    this.pnlValidator.CssClass = "alert alert-success";
                    this.txtCode.Enabled = false;
                    this.btnGuardarApuestaGoles.Enabled = true;

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio, EN_Constante.apuestaGoles);
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
                this.btnGuardarApuestaGoles.Enabled = false;
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
                    this.btnGuardarApuestaGoles.Enabled = false;
                }
                else
                {
                    this.lblStatusCode.Text = EN_Constante.textCodigoValido;
                    this.pnlValidator.CssClass = "alert alert-success";
                    this.txtCode.Enabled = false;
                    this.btnGuardarApuestaGoles.Enabled = true;
                    BL_Util.guardarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio, this.txtCode.Text);

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio,EN_Constante.apuestaGoles);
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
                this.btnGuardarApuestaGoles.Enabled = false;
            }
        }

        private void pintarPartidos(EN_CodigoAleatorio enCodAleatorio)
        {

            acrDynamic = new Accordion();
            acrDynamic.ID = "accordion-juego";
            acrDynamic.SelectedIndex = -1;//No default selection  
            acrDynamic.RequireOpenedPane = false;//no open pane  
            acrDynamic.HeaderCssClass = "panel-heading";//Header class  
            acrDynamic.HeaderSelectedCssClass = "panel-heading";//Selected herder class  
            acrDynamic.ContentCssClass = "panel-body";//Content class  

            Label lbTitle;
            Label lbContent;
            AccordionPane pane;
            string Content = "";
            Image img;
            List<String> listaEquipos = new List<string>();


            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.apuestaGoles);
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

                listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString() + "/" + dt.Rows[i]["icoLoc"].ToString() + "/" + dt.Rows[i]["icoVis"].ToString() + "/" + dt.Rows[i]["IdDetallePrograma"].ToString() + "/" + dt.Rows[i]["IdProgramaApuesta"].ToString() + "/" + dt.Rows[i]["Secuencia"].ToString());

                Content += dt.Rows[i]["equiDescLoc"].ToString() + "<br/>";

                if (BranchName != Next_Branch) //if last row of branch  
                {
                    pane = new AccordionPane();
                    lbTitle = new Label();
                    lbContent = new Label();
                    pane.ID = "Pane_" + dt.Rows[i]["IdProgramaApuesta"].ToString() + "_" + dt.Rows[i]["NumeroTorneo"].ToString() + "_" + BranchName.ToString();

                    pane.CssClass = "panel-title";
                    pane.HeaderCssClass = "panel-heading";

                    lbTitle.Text = BranchName;
                    lbTitle.CssClass = "title-white";

                    //<img src="../recursos/images/balon.png" />
                    img = new Image();
                    img.ImageUrl = "../recursos/images/balon.png";


                    pane.HeaderContainer.Controls.Add(img);
                    pane.HeaderContainer.Controls.Add(lbTitle);

                    //pane.HeaderCssClass = "panel-title";
                    Panel fila;
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
                        String idPrograma = datos[4];
                        String secuencia = datos[5];

                        fila = new Panel();
                        fila.CssClass = "form-group list-one";
                        panPartido = new Panel();
                        panPartido.CssClass = "col-sm-7";

                        panJ = new Panel();
                        panJ.CssClass = "versus";

                        Label lx;
                        lx = new Label();
                        lx.Text = "" + secuencia + ".";
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

                        RadioButtonList rbl = new RadioButtonList();
                        rbl.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
                        rbl.CssClass = "radio-inline";
                        rbl.ID = idPrograma + "_" + idDetallePrograma + "_R";

                        ListItem li = new ListItem();
                        li.Text = "1L";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 0px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "2L";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "NG";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "1V";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "2V";
                        li.Attributes.Add("style", "margin: 0px 0px 0px 15px");
                        rbl.Items.Add(li);

                        panO.Controls.Add(rbl);

                        imagLV = new Image();
                        imagLV.ImageUrl = EN_Constante.rutaIconosEquipos + iconoVis;
                        panO.Controls.Add(imagLV);

                        panJugada.Controls.Add(panO);

                        fila.Controls.Add(panPartido);
                        fila.Controls.Add(panJugada);
                        pane.ContentContainer.Controls.Add(fila);
                        
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

        protected void btnGuardarApuestaGoles_Click(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            BL_ApuestaUsuario bl_apuestaUsuario = new BL_ApuestaUsuario();
            bool rj = true;

            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals(""))
            {
                this.txtCode.Text = codeFrom;

                if (this.acrDynamic != null)
                {
                    EN_ApuestaUsuario apuestaCab = new EN_ApuestaUsuario();

                    for (int i = 0; i < this.acrDynamic.Panes.Count; i++)
                    {
                        AccordionPane pane = this.acrDynamic.Panes.ElementAt(i);
                        String idPanel = pane.ID;
                        String idPrograma = idPanel.Split('_')[1];
                        String nroTorneo = idPanel.Split('_')[2];

                        BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
                        EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                        enCodAleatorio.NroCodigoAleatorio = codeFrom;
                        DataTable dt = blpartidosProgramados.BL_ListarPartidosxTorneo(enCodAleatorio, EN_Constante.apuestaGoles, nroTorneo);


                        apuestaCab.IdProgApuesta = Convert.ToInt32(idPrograma);
                        apuestaCab.CodAleatorio = enCodAleatorio.NroCodigoAleatorio;
                        apuestaCab.Estado = '1';
                        apuestaCab.Usuario = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieNroDoc);
                        apuestaCab.fecha = new DateTime();

                        if (dt != null && dt.Rows.Count > 0)
                        {
                            apuestaCab.listaitem = new List<EN_ApuestaUsuarioDet>();

                            EN_ApuestaUsuarioDet apuestaDet;
                            for (int j = 0; j < dt.Rows.Count; j++)
                            {
                                apuestaDet = new EN_ApuestaUsuarioDet();

                                String idDetallePrograma = dt.Rows[j]["idDetallePrograma"].ToString();
                                String resultado = "";
                                bool r = false;

                                String idBuscar = idPrograma + "_" + idDetallePrograma + "_R";
                                Control control = pane.ContentContainer.FindControl(idBuscar);
                                if (control != null)
                                {
                                    RadioButtonList rbtnList = (RadioButtonList)control;
                                    resultado = rbtnList.SelectedValue;

                                    if (!String.IsNullOrEmpty(resultado.Trim()))
                                        r = true;
                                }

                                if (r == true)
                                {
                                    apuestaDet.Resultado = resultado;
                                    apuestaDet.Vigencia = '1';
                                    apuestaDet.ValidaResultado = 1;
                                    apuestaDet.IdDetalleProgApuesta = Convert.ToInt32(idDetallePrograma);
                                    apuestaCab.listaitem.Add(apuestaDet);
                                }
                                else
                                {
                                    break;

                                }
                            }

                            if (apuestaCab.listaitem != null && apuestaCab.listaitem.Count == dt.Rows.Count)
                            {
                                bl_apuestaUsuario.BL_registrarApuestaUsuario(ref apuestaCab);
                                //Response.Write("<script> alert('Se registró la jugada.') </script>");
                            }
                            else
                            {
                                rj = false;
                                break;
                            }
                        }
                    }
                }
            }
            if (rj == true)
            {
                BL_Util.borrarCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
                Response.Write("<script> alert('Jugada Registrada.'); window.location.href='../InicioAG.aspx'; </script>");
                //Response.Redirect("~/InicioAG.aspx");
            }
            else
            {
                Response.Write("<script> alert('Debe ingresar resultado para todos los partidos.') </script>");
            }

            /* *********************************** */

            
        }

        /*
        protected void txtResultado_TextChanged(object sender, System.EventArgs e)
        {
            String ID = ((TextBox)sender).ID;
            String Valor = ((TextBox)sender).Text;
        }
        */
    }
}