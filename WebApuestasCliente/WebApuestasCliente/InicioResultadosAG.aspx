<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="InicioResultadosAG.aspx.cs" Inherits="WebApuestasCliente.InicioResultadosAG" %>
<asp:Content ID="contentHeadInicio" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="cabeceraInicio" ContentPlaceHolderID="masterHeader" runat="server">
    <header id="header-top" class="inside">			
	    <div class="row">
		    <div class="col-md-3">
			    <div class="logo-inside">
				    <img class="img-responsive" src="recursos/images/logo-apuestagol.png">
			    </div>
		    </div>
		    <div class="col-md-9">
			    <div class="banner-top">Banner superior</div>
		    </div>
	    </div>			
    </header>
</asp:Content>
<asp:Content ID="contentPageInicio" ContentPlaceHolderID="masterPage" runat="server">
    <div class="page-content">
	    <h1 class="page-header">Visualización de Resultados</h1>
	    <p>Bienvenido a apuestagol, a continuación selecciona uno de los juegos para visualizar su resultado.</p>
	    <div id="games-selection">
		    <div class="row">
			    <div class="col-md-4">
				    <div class="item-game">
					    <%--<a href="#"><img class="img-thumbnail" src="recursos/images/juego01.png"/></a>--%>
                        <%--<asp:ImageButton ID="ImgCartillaSuerte" runat="server" CssClass="img-thumbnail" ImageUrl="recursos/images/juego01.png" OnClick="ImgCartillaSuerte_Click" />--%>

                        <asp:HyperLink id="ImgCartillaSuerte" 
                            NavigateUrl="~/ResultadoGanadores/CartillaSuerteRG.aspx"
                            Text=""
                            runat="server" 
                            >
                            <img  src="recursos/images/juego01.png"  class="img-thumbnail"/>
                        </asp:HyperLink>
				    </div>
			    </div>
			    <div class="col-md-4">
				    <div class="item-game">
                        <asp:HyperLink id="HyperLink1" 
                            NavigateUrl="~/ResultadoGanadores/PollaSemanalRG.aspx"
                            Text=""
                            runat="server" 
                            >
                            <img  src="recursos/images/juego02.png"  class="img-thumbnail"/>
                        </asp:HyperLink>
				    </div>
			    </div>
			    <div class="col-md-4">
				    <div class="item-game">
                        <asp:HyperLink id="HyperLink2" 
                            NavigateUrl="~/ResultadoGanadores/ApuestaGolesRG.aspx"
                            Text=""
                            runat="server" 
                            >
                            <img  src="recursos/images/juego03.png"  class="img-thumbnail"/>
                        </asp:HyperLink>
				    </div>
			    </div>
		    </div>
	    </div>
    </div>
</asp:Content>
