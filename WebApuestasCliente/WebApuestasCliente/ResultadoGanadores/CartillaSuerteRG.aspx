﻿<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="CartillaSuerteRG.aspx.cs" Inherits="WebApuestasCliente.ResultadoGanadores.CartillaSuerteRG" %>
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
		<div class="row">
			<div class="col-md-12">
				<div class="page-header">
                    <h2 id="lblTituloResultado" runat="server"></h2>
				</div>
				<p>Recuerde que estos resultados son de acuerdo a fechas programadas.</p>	
				<div class="date">
                    <label id="lblFechasApuesta" runat="server"></label>
                </div>
                <div id="divResulTitulo" class="description" runat="server">
				    <div class="row">
					    <div class="col-md-6">
						    <div class="programation"><asp:Label ID="txtNroProgramacion2" Text="....." runat="server"></asp:Label></div>
						</div>						
					</div>
				</div>
                <div class="result-goal">	
                    <div class="table-responsive">
                        <asp:Table ID ="tablePartResul" class="table table-striped" runat="server">
                        </asp:Table>
                    </div>          
			    </div>
                <div class="source">
                    <p><strong>Total de participantes :</strong><label id="lblJugadores" runat="server"></label></p>
                    <p><strong>Total de ganadores :</strong><label id="lblGanadores" runat="server"></label></p>
                    <p><strong>Monto del pozo :</strong><label id="lblPozo" runat="server"></label></p>
                </div>
                <div>
                <div class="panel winners">
                    <div class="panel-body">
                    <h3>Ganadores</h3>
                    <div class="table-responsive">
                         <asp:Table ID ="tableGanadores" class="table" runat="server">
                          </asp:Table>
                           </div>
                    </div>
                </div>	
                    <div class="result-goal">	
                    <div class="table-responsive">
                        <asp:Table ID ="tableListProg" class="table table-striped" runat="server">
                        </asp:Table>
                    </div>          
			    </div>
                </div>
			</div>
		</div>
	</div>
</asp:Content>
