<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="VisualizarJugada.aspx.cs" Inherits="WebApuestasCliente.VisualizarJugada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"   TagPrefix="asp" %>  
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server" >
    <div class="page-content">
        <div class="row">
		    <div class="col-md-9">
			    <div class="page-header">
                    <h2 id="lblTituloResultado" runat="server"></h2></div>
				<p>Para visualizar su jugada deberá colocar el código correcto con el que participó</p>
	
				<div class="validation-code">
				    <div class="form-group">
					    <div class="col-sm-6">
						    <label>Ingrese su código jugado</label>
                            <asp:TextBox ID="txtCode" CssClass="form-control" AutoPostBack="true" runat="server" 
                            placeholder="Ejemplo : DC0003532-552332" OnTextChanged="txtCodigoAleatorio_TextChanged"></asp:TextBox>
							
                        </div>
						<div class="col-sm-6">
						    <asp:Panel ID="pnlValidator" runat="server" rol="alert">
							    <i class="fa fa-check" aria-hidden="true"></i>
							    <asp:Label ID="lblStatusCode" runat="server"></asp:Label>
							</asp:Panel>
                        </div>
					</div>
				</div>
				<div id="divNumProgTitulo" class="description" runat="server">
				    <div class="row">
					    <div class="col-md-6">
						    <div class="programation">N° de programación: <asp:Label ID="txtNroProgramacion" Text="....." runat="server"></asp:Label></div>
						</div>						
					</div>
				</div>
                <div id="divtablePartJugado" class="result-goal" runat="server">	
                    <div class="table-responsive">
                        <asp:Table ID ="tablePartJugado" class="table table-striped" runat="server">
                        </asp:Table>
                    </div>          
			    </div>
                <div id="divResulTitulo" class="description" runat="server">
				    <div class="row">
					    <div class="col-md-6">
						    <div class="programation"><asp:Label ID="txtNroProgramacion2" Text="....." runat="server"></asp:Label></div>
						</div>						
					</div>
				</div>
                <div id="divTableResultados" class="result-goal" runat="server">	
                    <div class="table-responsive">
                        <asp:Table ID ="tablePartResul" class="table table-striped" runat="server">
                        </asp:Table>
                    </div>          
			    </div>
                <div id="divResulResumen" class="source" runat="server">
                    <p><strong>Total de participantes :</strong><label id="lblJugadores" runat="server"></label></p>
                    <p><strong>Total de ganadores :</strong><label id="lblGanadores" runat="server"></label></p>
                    <p><strong>Monto del pozo :</strong><label id="lblPozo" runat="server"></label></p>
                </div>
                <div id="divResulGanadores" class="panel winners" runat="server">
                    <div class="panel-body">
                    <h3>Ganadores</h3>
                    <div class="table-responsive">
                         <asp:Table ID ="tableGanadores" class="table" runat="server">
                          </asp:Table>
                           </div>
                    </div>
                </div>	
			</div>
			
        </div>
    </div>
</asp:Content>
