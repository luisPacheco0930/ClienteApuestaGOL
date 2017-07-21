<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="InicioAG.aspx.cs" Inherits="WebApuestasCliente.InicioAG" %>
<asp:Content ID="contentHeadInicio" ContentPlaceHolderID="head" runat="server">
    
</asp:Content>
<asp:Content ID="cabeceraInicio" ContentPlaceHolderID="masterHeader" runat="server">
    <header id="header-top" class="inside">			
	    <div class="row">
		    <div class="col-md-3">
			    <div class="logo-inside">
				    <img class="img-responsive" src="recursos/images/logo-apuestagol.png"/>
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
	    <h1 class="page-header">Selección de Juegos</h1>
	    <p>Bienvenido a apuestagol, a continuación selecciona uno de los juegos con el cual puedes usar tu código promocional, recuerda que puedes usar un único código por cada jugada</p>
	    <div id="games-selection">
		    <div class="row">
			    <div class="col-md-4">
				    <div class="item-game">
					    <%--<a href="#"><img class="img-thumbnail" src="recursos/images/juego01.png"/></a>--%>
                        <%--<asp:ImageButton ID="ImgCartillaSuerte" runat="server" CssClass="img-thumbnail" ImageUrl="recursos/images/juego01.png" OnClick="ImgCartillaSuerte_Click" />--%>

                        <asp:HyperLink id="ImgCartillaSuerte" 
                            NavigateUrl="~/Juego/CartillaSuerte.aspx"
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
                            NavigateUrl="~/Juego/PollaSemanal.aspx"
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
                            NavigateUrl="~/Juego/ApuestaGoles.aspx"
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
