using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ApuestaCliente.BussinesLogic;
using ApuestaCliente.Entity;
using System.Configuration;
using AjaxControlToolkit;
using System.Data;

namespace WebApuestasCliente.Juego
{
    public partial class CartillaSuerte : System.Web.UI.Page
    {
        Accordion acrDynamic;

        protected void Page_Load(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            //codeFrom = "5SWH2A9R";
            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals(""))
            {
                this.txtCode.Text = codeFrom;

                //En caso si se ingrese a esta sección con un código promocional
                BL_CodigoAleatorio blCodAleatorio = new BL_CodigoAleatorio();
                BL_Cliente blCliente = new BL_Cliente();

                EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
                enCodAleatorio.NroCodigoAleatorio = codeFrom;
                String textError = blCodAleatorio.BL_validarCodigoIngresado(enCodAleatorio);


                //DateTime d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio);
                //this.codFecTope.Text = d.ToShortTimeString() + " del " + d.ToShortDateString(); // d.ToLongDateString();


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

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio,EN_Constante.cartillaDeLaSuerte);
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

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio, EN_Constante.cartillaDeLaSuerte);
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
        /*

        private void pintarPartidos(EN_CodigoAleatorio enCodAleatorio)
        {

            // pintando partidos
            //Accordion
            acrDynamic = new Accordion();
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
            dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.cartillaDeLaSuerte);
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

                listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString() + "/" + dt.Rows[i]["icoLoc"].ToString() + "/" + dt.Rows[i]["icoVis"].ToString()
                    + "/" + dt.Rows[i]["IdProgramaApuesta"].ToString() + "/" + dt.Rows[i]["IdDetallePrograma"].ToString()
                    );

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
                    lbTitle.ForeColor = System.Drawing.Color.Black;
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

                        RadioButtonList rbl = new RadioButtonList();
                        rbl.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
                        rbl.CssClass = "radio-inline";
                        rbl.ID = "rbl_" + datos[3] + "_" + datos[4];

                        ListItem li = new ListItem();
                        li.Text = "L";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "E";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "V";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        panO.Controls.Add(rbl);
                        imagLV = new Image();
                        imagLV.ImageUrl = EN_Constante.rutaIconosEquipos + iconoVis;
                        panO.Controls.Add(imagLV);

                        panJugada.Controls.Add(panO);

                        pane.ContentContainer.Controls.Add(panPartido);
                        pane.ContentContainer.Controls.Add(panJugada);
                    }


                    acrDynamic.Panes.Add(pane);
                    Content = "";
                    listaEquipos = new List<string>();
                }
            }

            this.MyContent.Controls.Add(acrDynamic);
        }


        */
        private void pintarPartidos(EN_CodigoAleatorio enCodAleatorio)
        {
            acrDynamic = new Accordion();
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
            dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.cartillaDeLaSuerte);
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

                listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString() + "/" + dt.Rows[i]["icoLoc"].ToString() + "/" + dt.Rows[i]["icoVis"].ToString() + "/" + dt.Rows[i]["IdDetallePrograma"].ToString() + "/" + dt.Rows[i]["IdProgramaApuesta"].ToString());

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
                    lbTitle.ForeColor = System.Drawing.Color.Black;
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
                        String idPrograma = datos[4];

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

                        RadioButtonList rbl = new RadioButtonList();
                        rbl.RepeatDirection = System.Web.UI.WebControls.RepeatDirection.Horizontal;
                        rbl.CssClass = "radio-inline";
                        rbl.ID = idPrograma + "_" + idDetallePrograma +"_R";

                        ListItem li = new ListItem();
                        li.Text = "L";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "E";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        li = new ListItem();
                        li.Text = "V";
                        li.Attributes.Add("style", "margin: 0px 15px 0px 15px");
                        rbl.Items.Add(li);

                        panO.Controls.Add(rbl);

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

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            EN_CodigoAleatorio enCodAleatorio = new EN_CodigoAleatorio();
            enCodAleatorio.NroCodigoAleatorio = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio); ;
            DataTable dt = new DataTable();
            BL_PartidosProgramados blpartidosProgramados = new BL_PartidosProgramados();
            dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio, EN_Constante.cartillaDeLaSuerte);

            String textError = "";
            Boolean valido = true;
            //Control c = this.MyContent.FindControl("rbl_2_1");
            //textError = c.Controls("masterPage_rbl_2_1_0");
            int idProgApuesta = 0;
            if (this.acrDynamic != null)
            {
                //  textError = "entroo accordion";

                //   AccordionPane p1 = this.acrDynamic.Panes.ElementAt(0); // Panes.First();
                // validando que todos estén seleccionados

                int accPaneidx = 0;
                int bk_id_torneo = -1;
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    int id_Prog = int.Parse(dt.Rows[i]["IdProgramaApuesta"].ToString());
                    idProgApuesta = id_Prog;
                    int id_detProg = int.Parse(dt.Rows[i]["IdDetallePrograma"].ToString());
                    int nroT = int.Parse(dt.Rows[i]["NumeroTorneo"].ToString());

                    if (bk_id_torneo == -1)
                    {
                        bk_id_torneo = nroT;
                    }

                    if (bk_id_torneo != nroT)
                    {
                        accPaneidx++;
                    }

                    bk_id_torneo = nroT;

                    textError = textError + "-" + accPaneidx + "("+ id_Prog + ")";
                    AccordionPane p1 = this.acrDynamic.Panes.ElementAt(accPaneidx);
                    Control x = p1.ContentContainer.FindControl("rbl_" + id_Prog + "_" + id_detProg);

                    if (x != null)
                    {
                        //textError = textError + "entro a " + "rbl_" + id_Prog + "_" + id_detProg;
                        RadioButtonList rbxx = (RadioButtonList)x;
                        String sv = rbxx.SelectedValue;
                       // textError = textError + "-" + sv;
                        if (sv == null || sv.Equals("")) valido = false;
                    }


                }

            }

            if (!valido)
            {
                textError = "Debe completar todos los partidos.";
                Response.Write("<script> alert('" + textError + "') </script>");
            }
            else {
                //Registrar datos en DB
                EN_ApuestaUsuario au = new EN_ApuestaUsuario();
                au.IdProgApuesta = idProgApuesta;
                BL_ApuestaUsuario bau = new BL_ApuestaUsuario();

                bau.BL_registrarApuestaUsuario( ref au);
                textError = "Registro con id: ";
                Response.Write("<script> alert('" + textError + "') </script>");

            }
        }

        protected void btnGuardarCartillaSuerte_Click(object sender, EventArgs e)
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
                        DataTable dt = blpartidosProgramados.BL_ListarPartidosxTorneo(enCodAleatorio, EN_Constante.cartillaDeLaSuerte, nroTorneo);


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

                                if (r == true) { 
                                    apuestaDet.Resultado = resultado.ElementAt(0);
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
        }


    }

}