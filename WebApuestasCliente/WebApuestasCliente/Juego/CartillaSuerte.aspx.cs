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
            codeFrom = "5SWH2A9R";
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
                }


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
                dt = blpartidosProgramados.BL_ListarPartidos(enCodAleatorio);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string BranchName = dt.Rows[i]["descTorneo"].ToString();
                    string Next_Branch = "";

                    if (i != dt.Rows.Count - 1)
                        Next_Branch = dt.Rows[i + 1]["descTorneo"].ToString();

                    listaEquipos.Add(dt.Rows[i]["equiDescLoc"].ToString() + " - " + dt.Rows[i]["equiDescVis"].ToString());

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

                        //<img src="../recursos/images/balon.png" />
                        img = new Image();
                        img.ImageUrl = "../recursos/images/balon.png";

                        
                        pane.HeaderContainer.Controls.Add(img);
                        pane.HeaderContainer.Controls.Add(lbTitle);

                        //pane.HeaderCssClass = "panel-title";
                        Panel panJ; //= new Panel();
                        for (int j = 0; j < listaEquipos.Count; j++)
                        {
                            panJ = new Panel();
                            Label lx;
                            lx = new Label();
                            lx.Text = "" + j+ ".";
                            lx.CssClass = "list-item";
                            panJ.Controls.Add(lx);

                            lx = new Label();
                            lx.Text = listaEquipos.ElementAt(j);
                            lx.CssClass = "list-title";
                            panJ.Controls.Add(lx);

                            pane.ContentContainer.Controls.Add(panJ);
                        }


                        //lbContent.Text = Content;
                        //pane.ContentContainer.Controls.Add(lbContent);
                       
                        acrDynamic.Panes.Add(pane);
                        Content = "";
                    }
                }

                this.MyContent.Controls.Add(acrDynamic);


            }
            else
            {
                this.lblStatusCode.Text = EN_Constante.textCodigoNoIngresado;
                this.pnlValidator.CssClass = "alert alert-info";
                this.txtCode.Enabled = true;
            }

        }
    }
}