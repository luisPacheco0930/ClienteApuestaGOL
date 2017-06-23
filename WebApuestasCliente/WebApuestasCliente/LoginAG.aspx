<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SWApuestaCliente.Master" CodeBehind="LoginAG.aspx.cs" Inherits="WebApuestasCliente.LoginAG" %>

<asp:Content ID="contentHeadLogin" ContentPlaceHolderID="head" runat="server">
    <script type="text/javascript">
        $(document).ready(function () {
            var loginCheck = jQuery('#login-more');
            if (loginCheck.is(':checked')) {
                $(".login-advanced").show();
            } else {
                $(".login-advanced").hide();
            }
            $(loginCheck).click(function () {
                if (loginCheck.is(':checked')) {
                    $(".login-advanced").show();
                } else {
                    $(".login-advanced").hide();
                }
            });

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
			Anuncio lateral
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
									<input type="text" class="form-control" id="txtNroPromocional" name="txtNroPromocional" placeholder="Escribe tu codigo promocional" />
                                    <%--<asp:TextBox ID="txtNroPromocional" CssClass="form-control" runat="server"></asp:TextBox>--%>
								</div>
							</div>
							<div class="checkbox">
								<label>
								<input type="checkbox" id="login-more" value="" />
								Si es usted cliente marque la siguiente opción
								</label>
							</div>
							<div class="login-advanced" >
								<div class="form-group">
									<div class="input-group">
										<div class="input-group-addon">
										<i class="fa fa-user fa-lg" aria-hidden="true"></i>
										</div>
										<input type="text" class="form-control" id="exampleInputAmount2" placeholder="N° de documento de identidad" />
									</div>
								</div>
								<div class="form-group">
									<div class="input-group">
										<div class="input-group-addon">
										<i class="fa fa-lock fa-lg" aria-hidden="true"></i>
										</div>
										<input type="password" class="form-control" id="exampleInputAmount3" placeholder="Contraseña"/>
									</div>
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
				<input type="text" class="form-control" id="txtdni" placeholder="N° de documento de identidad"/>
			</div>
			<div class="form-group">
			    <input type="text" class="form-control" id="txtNombres" placeholder="Ingresar Nombres"/>
			</div>
			<div class="form-group">
			    <input type="text" class="form-control" id="txtApellidos" placeholder="Ingresar Apellidos"/>
			</div>
			<div class="form-group">
			    <input type="email" class="form-control" id="txtEmail" placeholder="Correo Electronico"/>
			</div>
			<div class="form-group">
			    <input type="password" class="form-control" id="txtPassword" placeholder="Contraseña"/>
			</div>
			<div class="form-group btn-register">
				<%--<button type="button" class="btn btn-success btn-lg btn-block">Registrarse</button>--%>
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Registrarse" />
			</div>
            <%--</form>--%>
      	</div>
      </div>
    </div>
  </div>
</div>
    
</asp:Content>