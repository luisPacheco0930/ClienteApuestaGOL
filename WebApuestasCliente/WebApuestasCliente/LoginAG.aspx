<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SWApuestaCliente.Master" CodeBehind="LoginAG.aspx.cs" Inherits="WebApuestasCliente.LoginAG" %>

<asp:Content ID="contentHeadLogin" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var loginCheck = jQuery('#masterPage_checkBoxLogin');
            if (loginCheck.is(':checked')) {
                $(".login-advanced").show();
            } else {
                $(".login-advanced").hide();
            }
        });
    </script>
</asp:Content>
<asp:Content ID="cabeceraLogin" ContentPlaceHolderID="masterHeader" runat="server">
    <header id="header-top">
        <div class="logo">
			<img class="img-responsive" src="recursos/images/logo-apuestagol.png" />
		</div>
	</header>
    <div class="register">
		¿Ingresas por primera vez?
		<a href="#" data-toggle="modal" data-target="#myModal">
			<i class="fa fa-sign-in" aria-hidden="true"></i> Registrate aquí
		</a>
	</div>
</asp:Content>
<asp:Content ID="menu" ContentPlaceHolderID="masterMenu" runat="server">
    <!-- contenido vacio -->
</asp:Content>
<asp:Content ID="contentPageInicio" ContentPlaceHolderID="masterPage" runat="server">
    <div class="row">
        <div class="col-md-3">
			
		</div>
		<div class="col-md-6">
			<div id="login-user">
				<div class="panel panel-primary">
					<div class="panel-heading">
						<h4>Ingresar</h4>
					</div>
					<div class="panel-body">
						<%--<form id="login" runat="server" class="form-horizontal">--%>
							<div class="form-group">
								<div class="input-group">
									<div class="input-group-addon">
									<i class="fa fa-tag fa-lg" aria-hidden="true"></i>
									</div>
									<%--<input type="text" class="form-control" id="txtNroPromocional" name="txtNroPromocional" placeholder="Escribe tu codigo promocional" />--%>
                                    <asp:TextBox ID="txtNroPromocional" CssClass="form-control" placeholder="Ingrese código promocional" runat="server"></asp:TextBox>
								</div>
							</div>
							<div class="checkbox">
								<label>
                                <asp:CheckBox id="checkBoxLogin" 
                                     AutoPostBack="True"
                                     Text="Si es usted cliente marque la siguiente opción"
                                     TextAlign="Right"
                                     Checked="False"
                                     runat="server"/>
								<%--<input type="checkbox" id="login-more" value="" />--%>
								</label>
							</div>
							<div class="login-advanced" >
								<div class="form-group">
									<div class="input-group">
										<div class="input-group-addon">
										<i class="fa fa-user fa-lg" aria-hidden="true"></i>
										</div>
                                        <asp:TextBox ID="textNroDocumento" CssClass="form-control" placeholder="N° de documento de identidad" runat="server"></asp:TextBox>
									</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTextNroDocumento" runat="server"
                                        ControlToValidate="textNroDocumento"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
								</div>
								<div class="form-group">
									<div class="input-group">
										<div class="input-group-addon">
										<i class="fa fa-lock fa-lg" aria-hidden="true"></i>
										</div>
                                        <asp:TextBox ID="textContrasenha" TextMode="Password" CssClass="form-control" placeholder="Contraseña" runat="server"></asp:TextBox>
									</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTextContrasenha" runat="server"
                                        ControlToValidate="textContrasenha"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red">
                                    </asp:RequiredFieldValidator>--%>
								</div>
							</div>
							    <div class="form-group">
                                    <asp:Button ID="btnLoguear" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Iniciar Sesión" OnClick="btnLoguear_Click"/>
                                </div>
						<%--</form>--%>
					</div>
				</div>
			</div>
		</div>
		<div class="col-md-3">
			Anuncio Lateral
		</div>
    </div>

</asp:Content>
<asp:Content ID="ModalRegister" ContentPlaceHolderID="contentModal" runat="server">
    <!-- Modal -->
<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Registro de usuario</h4>
      </div>
      <div class="modal-body">
      	<div class="form-body">
      		<%--<form id="register" class="form-horizontal">--%>
        	<div class="form-group">
                <asp:TextBox ID="txtdni" CssClass="form-control" placeholder="N° de documento de identidad" runat="server"></asp:TextBox>
			</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTxtdni" runat="server"
                                        ControlToValidate="txtdni"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
			<div class="form-group">
                <asp:TextBox ID="txtNombres" CssClass="form-control" placeholder="Ingrese Nombres" runat="server"></asp:TextBox>
			</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTxtNombres" runat="server"
                                        ControlToValidate="txtNombres"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
			<div class="form-group">
			    <asp:TextBox ID="txtApellidos" CssClass="form-control" placeholder="Ingrese Apellidos" runat="server"></asp:TextBox>
			</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTxtApellidos" runat="server"
                                        ControlToValidate="txtApellidos"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
			<div class="form-group">
			    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Ingrese Correo Electrónico" runat="server"></asp:TextBox>
			</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTxtEmail" runat="server"
                                        ControlToValidate="txtEmail"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
			<div class="form-group">

                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Contraseña" runat="server"></asp:TextBox>
			</div>
                                    <%--<asp:RequiredFieldValidator id="requiredFieldValidatorTxtPassword" runat="server"
                                        ControlToValidate="txtPassword"
                                        ErrorMessage="Ingrese este campo."
                                        ForeColor="Red" >
                                    </asp:RequiredFieldValidator>--%>
			<div class="form-group btn-register">
				<%--<button type="button" class="btn btn-success btn-lg btn-block">Registrarse</button>--%>
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Registrar Usuario" OnClick="btnRegistrar_Click"/>
			</div>
            <%--</form>--%>
      	</div>
      </div>
    </div>
  </div>
</div>
    
</asp:Content>