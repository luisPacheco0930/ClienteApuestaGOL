<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="VisualizarJugada.aspx.cs" Inherits="WebApuestasCliente.VisualizarJugada" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"   TagPrefix="asp" %>  
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server" >
    <div class="page-content">
        <div class="row">
		    <div class="col-md-9">
			    <div class="page-header"><h2>La Polla Semanal</h2></div>
				<p>Ingrese su código promocional antes de empezar a jugar, recuede que es un único código por juego.</p>
				<p>Ingrese su pronostico de marcado para los siguientes partidos, recuerde que solo puede ingresar una sola vez el resultado</p>
	
				<div class="validation-code">
				    <div class="form-group">
					    <div class="col-sm-6">
						    <label>Ingrese su código</label>
                            <asp:TextBox ID="txtCode" CssClass="form-control" AutoPostBack="true"
                            placeholder="Ejemplo : DC0003532-552332" runat="server" OnTextChanged="txtCodigoAleatorio_TextChanged"></asp:TextBox>
							
                        </div>
						<div class="col-sm-6">
						    <asp:Panel ID="pnlValidator" runat="server" rol="alert">
							    <i class="fa fa-check" aria-hidden="true"></i>
							    <asp:Label ID="lblStatusCode" runat="server"></asp:Label>
							</asp:Panel>
                        </div>
					</div>
				</div>
				<div class="description">
				    <div class="row">
					    <div class="col-md-6">
						    <div class="programation">N° de programación: <asp:Label ID="txtNroProgramacion" Text="....." runat="server"></asp:Label></div>
						</div>
						<div class="col-md-6">
                            <div class="date">Juegalo hasta: <asp:Label ID="lblCodFecTope" Text="....." runat="server"></asp:Label></div>
                            <div class="date"> Pozo: <asp:Label ID="lblPozoPrograma" Text="S/ 0.00" runat="server"></asp:Label> </div>
						</div>
					</div>
				</div>
				<div class="table-game apuesta">
				    <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
					    <div class="panel panel-default">
						    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  </asp:ToolkitScriptManager>  
							<asp:Panel ID="MyContent" runat="server">  </asp:Panel>
                        </div> 
                    </div>
				</div>
                
			</div>
			<div class="col-md-3">
								
			</div>
        </div>
    </div>
</asp:Content>
