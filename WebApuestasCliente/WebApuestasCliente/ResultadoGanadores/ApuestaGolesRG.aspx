<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="ApuestaGolesRG.aspx.cs" Inherits="WebApuestasCliente.ResultadoGanadores.ApuestaGolesRG" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"   TagPrefix="asp" %>  
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
		<div class="row">
			<div class="col-md-12">
				<h1 class="page-header">Resultados Apuesta Gol</h1>
				<p><div class="date"><asp:Label  Text="Recuerde que estos resultados son de acuerdo a fechas programadas." runat="server"/></div></p>	
				<div class="date"><div class="date"><asp:Label  Text="Fecha: 26 de Marzo 2017 al 01 de Abril 2017" runat="server"/></div></div>
                <div class="result-goal">					
                <div class="table-responsive">
                    <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  </asp:ToolkitScriptManager>  
					<asp:Panel ID="MyContent" runat="server">  </asp:Panel>
                </div>
			</div>
            <div class="source">
                <p><strong>Total de participantes :</strong>200</p>
                <p><strong>Total de ganadores :</strong>3</p>
            </div>
            <div class="panel winners">
                <div class="panel-body">
                <h3>Ganadores</h3>
                <div class="table-responsive">
                    <table class="table">
                        <thead>
                            <tr>
                                <th>Código Ganador</th>
                                <th>Documento de Identidad</th>
                                <th>Apellidos y Nombres</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>DFFFSK0001</td>
                                <td>44197172</td>
                                <td>Alex Rubén Aragón Calixto</td>
                            </tr>
                            <tr>
                                <td>DFFFSK0002</td>
                                <td>44597172</td>
                                <td>Fabion Cesar Martinez Caceres</td>
                            </tr>
                            <tr>
                                <td>DFFFSK0003</td>
                                <td>46597172</td>
                                <td>Maria Cordero Fernandez</td>
                            </tr>
                        </tbody>
                    </table>
                </div>
                </div>
            </div>
		</div>					
	</div>
</div>
</asp:Content>
