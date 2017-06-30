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
        protected void Page_Load(object sender, EventArgs e)
        {
            String codeFrom = BL_Util.obtenerCookie(HttpContext.Current, EN_Constante.nombreCookieCodAleatorio);
            //codeFrom = "5SWH2A9R";
            if (!String.IsNullOrEmpty(codeFrom) && !codeFrom.Equals("")) {
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

                    EN_ProgramacionApuesta d = blCodAleatorio.BL_codAleatorio_fechaTope(enCodAleatorio);
                    this.lblCodFecTope.Text = d.FechaFinal.ToShortTimeString() + " del " + d.FechaFinal.ToShortDateString(); // d.ToLongDateString();

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

                listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString() + "/" + dt.Rows[i]["icoLoc"].ToString() + "/" + dt.Rows[i]["icoVis"].ToString());

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
                        /*
                        RadioButton cbx;
                        cbx = new RadioButton();
                        cbx.Text = "L";
                        cbx.CssClass = "radio-inline";
                        panO.Controls.Add(cbx);

                        cbx = new RadioButton();
                        cbx.Text = "E";
                        cbx.CssClass = "radio-inline";
                        panO.Controls.Add(cbx);

                        cbx = new RadioButton();
                        cbx.Text = "V";
                        cbx.CssClass = "radio-inline";
                        panO.Controls.Add(cbx);
                        */
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
    }
}