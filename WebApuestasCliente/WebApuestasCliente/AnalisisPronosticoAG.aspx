<%@ Page Title="" Language="C#" MasterPageFile="~/SWApuestaCliente.Master" AutoEventWireup="true" CodeBehind="AnalisisPronosticoAG.aspx.cs" Inherits="WebApuestasCliente.AnalisisPronosticoAG" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit"   TagPrefix="asp" %>  
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <div class="row">
            <div class="page-header"><h2>Análisis y Pronostico</h2></div>
            <br />
        </div>
        <div>
			<div class="panel panel-default">
				<asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">  </asp:ToolkitScriptManager>  
                <div class="row">
			        <asp:Panel ID="MyContent" runat="server">  </asp:Panel>
                </div>
            </div> 
        </div>
    </div>
</asp:Content>
