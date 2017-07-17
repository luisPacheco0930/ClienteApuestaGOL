<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="CartillaSuerteRG.aspx.cs" Inherits="WebApuestasCliente.ResultadoGanadores.CartillaSuerteRG" %>
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
		<div class="row">
			<div class="col-md-12">
				<h1 class="page-header">
                    <label id="lblTituloResultado" runat="server"></label></h1>
				<p>Recuerde que estos resultados son de acuerdo a fechas programadas.</p>	
				<div class="date"><label id="lblFechasApuesta" runat="server"></label>
                    </div>
                <div class="result-goal">	
                     <div class="table-responsive">
                    <%--asp:Literal ID="partidosResultadoTable" runat="server" /--%>
                      <asp:Table ID ="tablePartResul" class="table table-striped" runat="server">

                      </asp:Table>
                         </div>
              
			</div>
            <div class="source">
                <p><strong>Total de participantes :</strong><label id="lblJugadores" runat="server"></label></p>
                <p><strong>Total de ganadores :</strong><label id="lblGanadores" runat="server"></label></p>
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
