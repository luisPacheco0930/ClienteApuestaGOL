<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="ApuestaGolesRG.aspx.cs" Inherits="WebApuestasCliente.ResultadoGanadores.ApuestaGolesRG" %>
<asp:Content ID="contenidoHead" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
		<div class="row">
			<div class="col-md-12">
				<h1 class="page-header">Resultados Apuesta Gol</h1>
				<p>Recuerde que estos resultados son de acuerdo a fechas programadas.</p>	
				<div class="date">Fecha: 26 de Marzo 2017 al 01 de Abril 2017</div>
                <div class="result-goal">					
                <div class="table-responsive">
                    <table class="table table-striped">
                        <thead>
                            <tr>
                                <th>N°</th>
                                <th>Fecha</th>
                                <th>Local</th>
                                <th>VS</th>
                                <th>Visitante</th>
                                <th>Torneo</th>
                                <th>Resulato</th>
                            </tr>
                        </thead>
                        <tbody>
                            <tr>
                                <td>1</td>
                                <td>26/03/2017</td>
                                <td>Universitario</td>
                                <td>
                                    <div class="equipment">
                                        <asp:image runat="server" id="Image1" ImageUrl="~/recursos/images/equipos/universitario.png" />
                                        <asp:image runat="server" id="Image2" ImageUrl="~/recursos/images/equipos/sporting.png" />
                                    </div>
                                </td>
                                <td>Sporting Cristal</td>
                                <td>Copa Perú</td>
                                <td>
                                    <div class="result-v">
                                        V
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>2</td>
                                <td>26/03/2017</td>
                                <td>Cienciano</td>
                                <td>
                                    <div class="equipment">
                                        <asp:image runat="server" id="Image3" ImageUrl="~/recursos/images/equipos/universitario.png" />
                                        <asp:image runat="server" id="Image4" ImageUrl="~/recursos/images/equipos/sporting.png" />
                                    </div>
                                </td>
                                <td>Alianza Lima</td>
                                <td>Copa Perú</td>
                                <td>
                                    <div class="result-l">
                                        L
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>3</td>
                                <td>26/03/2017</td>
                                <td>Cienciano</td>
                                <td>
                                    <div class="equipment">
                                        <asp:image runat="server" id="Image5" ImageUrl="~/recursos/images/equipos/universitario.png" />
                                        <asp:image runat="server" id="Image6" ImageUrl="~/recursos/images/equipos/sporting.png" />
                                    </div>
                                </td>
                                <td>Alianza Lima</td>
                                <td>Copa Perú</td>
                                <td>
                                    <div class="result-l">
                                        L
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>4</td>
                                <td>26/03/2017</td>
                                <td>Cienciano</td>
                                <td>
                                    <div class="equipment">
                                        <asp:image runat="server" id="Image7" ImageUrl="~/recursos/images/equipos/universitario.png" />
                                        <asp:image runat="server" id="Image8" ImageUrl="~/recursos/images/equipos/sporting.png" />
                                    </div>
                                </td>
                                <td>Alianza Lima</td>
                                <td>Copa Perú</td>
                                <td>
                                    <div class="result-v">
                                       V
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>5</td>
                                <td>26/03/2017</td>
                                <td>Cienciano</td>
                                <td>
                                    <div class="equipment">
                                        <asp:image runat="server" id="Image9" ImageUrl="~/recursos/images/equipos/universitario.png" />
                                        <asp:image runat="server" id="Image10" ImageUrl="~/recursos/images/equipos/sporting.png" />
                                    </div>
                                </td>
                                <td>Alianza Lima</td>
                                <td>Copa Perú</td>
                                <td>
                                    <div class="result-v">
                                       V
                                    </div>
                                </td>
                            </tr>
                        </tbody>
                    </table>
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
