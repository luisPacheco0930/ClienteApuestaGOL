<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="ApuestaGoles.aspx.cs" Inherits="WebApuestasCliente.Juego.ApuestaGoles" %>
<asp:Content ID="contenidoCabecera" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="contenidoPagina" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
							<div class="row">
								<div class="col-md-9">
									<h1 class="page-header">Apuesta Gol</h1>
									<p><strong>Ingrese su código promocional antes de empezar a jugar, recuede que es un único código por juego.</strong></p>
									<p>Ingrese su pronostico de marcado para los siguientes partidos, recuerde que solo puede ingresar una sola vez el resultado</p>
									<form id="juego01" class="form-horizontal">
										<div class="validation-code">
											<div class="form-group">
											    <div class="col-sm-6">
											    	<label>Ingrese su código</label>
											   	   <input type="text" class="form-control" id="code" placeholder="Ejemplo : DC0003532-552332">
											    </div>
											    <div class="col-sm-6">
											    	<div class="alert alert-success" role="alert">
											    		<i class="fa fa-check" aria-hidden="true"></i>
											    		Su código es valido
											    	</div>
											    </div>
											</div>
										</div>
										<div class="description">
											<div class="row">
												<div class="col-md-6">
													<div class="programation">N° de programación: 5545</div>
												</div>
												<div class="col-md-6">
													<div class="date">Juegalo hasta: 01:00pm del SAB 10 ABR</div>
												</div>
											</div>
										</div>
                                        <div class="table-game apuesta">
                                        <div class="panel-group" id="accordion" role="tablist" aria-multiselectable="true">
                                          <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingOne">
                                              <h4 class="panel-title">
                                                <a role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseOne" aria-expanded="true" aria-controls="collapseOne">
                                                  <img src="<%= ResolveClientUrl("~/recursos/images/balon.png") %>" />Torneo Peruano
                                                </a>
                                              </h4>
                                            </div>
                                            <div id="collapseOne" class="panel-collapse collapse in" role="tabpanel" aria-labelledby="headingOne">
                                              <div class="panel-body">
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">1.</span> <span class="list-title">Universitario - Sporting Cristal</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/universitario.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/sporting.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">2.</span> <span class="list-title">Cienciano - Alianza Lima</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cienciano.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/alianza.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">3.</span> <span class="list-title">Universidad Cesar Vallejo - Pacifico</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cesar-vallejo.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/pacifico.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">4.</span> <span class="list-title">Juan Aurich - León de Huanuco</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/aurich.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/leon.png">
                                                		</div>
                                                	</div>
                                                </div>
                                              </div>
                                            </div>
                                          </div>
                                          <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingTwo">
                                              <h4 class="panel-title">
                                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseTwo" aria-expanded="false" aria-controls="collapseTwo">
                                                  <img src="<%= ResolveClientUrl("~/recursos/images/balon.png") %>" />Partidos Amistosos
                                                </a>
                                              </h4>
                                            </div>
                                            <div id="collapseTwo" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingTwo">
                                                <div class="panel-body">
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">1.</span> <span class="list-title">Universitario - Sporting Cristal</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/universitario.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/sporting.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">2.</span> <span class="list-title">Cienciano - Alianza Lima</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cienciano.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/alianza.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">3.</span> <span class="list-title">Universidad Cesar Vallejo - Pacifico</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cesar-vallejo.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/pacifico.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">4.</span> <span class="list-title">Juan Aurich - León de Huanuco</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/aurich.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/leon.png">
                                                		</div>
                                                	</div>
                                                </div>
                                              </div>
                                            </div>
                                          </div>
                                          <div class="panel panel-default">
                                            <div class="panel-heading" role="tab" id="headingThree">
                                              <h4 class="panel-title">
                                                <a class="collapsed" role="button" data-toggle="collapse" data-parent="#accordion" href="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                                                  <img src="<%= ResolveClientUrl("~/recursos/images/balon.png") %>" />Futbol Extranjero
                                                </a>
                                              </h4>
                                            </div>
                                            <div id="collapseThree" class="panel-collapse collapse" role="tabpanel" aria-labelledby="headingThree">
                                                <div class="panel-body">
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">1.</span> <span class="list-title">Universitario - Sporting Cristal</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/universitario.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/sporting.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">2.</span> <span class="list-title">Cienciano - Alianza Lima</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cienciano.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/alianza.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-one">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">3.</span> <span class="list-title">Universidad Cesar Vallejo - Pacifico</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/cesar-vallejo.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/pacifico.png">
                                                		</div>
                                                	</div>
                                                </div>
                                                <div class="form-group list-two">
                                                	<div class="col-sm-7">
                                                		<div class="versus">
                                                			<span class="list-item">4.</span> <span class="list-title">Juan Aurich - León de Huanuco</span>
                                                		</div>
                                                	</div>
                                                	<div class="col-sm-5">
                                                		<div class="option-games">
                                        	        		<img src="images/equipos/aurich.png">
                                        	        		<input type="text" class="form-option">
                                        	        		<input type="text" class="form-option">
                                        	        		<img src="images/equipos/leon.png">
                                                		</div>
                                                	</div>
                                                </div>
                                              </div>
                                            </div>
                                          </div>
                                        </div>
                                        </div>

                                        <div class="form-group">
                                        	<input class="btn btn-default btn-primary btn-lg btn-block" type="submit" value="Guardar partida">
                                        </div>
									</form>
								</div>
								<div class="col-md-3">
								
								</div>
							</div>
						</div>
</asp:Content>
