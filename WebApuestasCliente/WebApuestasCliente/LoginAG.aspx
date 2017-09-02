<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/SWApuestaCliente.Master" CodeBehind="LoginAG.aspx.cs" Inherits="WebApuestasCliente.LoginAG" %>
<%@ Register Assembly="MSCaptcha" Namespace="MSCaptcha" TagPrefix="cc1" %>

<asp:Content ID="contentHeadLogin" ContentPlaceHolderID="head" runat="server">
    <script src="https://www.google.com/recaptcha/api.js" async defer></script>
  
    <script type="text/javascript">
        $(document).ready(function () {
            var loginCheck = jQuery('#masterPage_checkBoxLogin');
            if (loginCheck.is(':checked')) {
                $(".login-advanced").show(300);
                $("#NroPromocional").hide();
            } else {
                $(".login-advanced").hide();
                $("#NroPromocional").show(300);
            }
        });
    </script>

    <script type="text/javascript" >  
        function validarNumeros(e) {
            //  var charCode = (evt.which) ? evt.which : event.keyCode
            // alert("charCode: " + e.keyCode);
            // if (/^\d+$/.test(this.value + String.fromCharCode(event.keyCode))) {  
            //$.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 ||
            if (e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 46 || e.keyCode == 27 || e.keyCode == 13 || e.keyCode == 110
                || e.keyCode == 190) {
                return true;
            }
            if (
                // Allow: Ctrl/cmd+A
                (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: Ctrl/cmd+C
                (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: Ctrl/cmd+X
                (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                // let it happen, don't do anything
                // alert("charCode 1: " + e.keyCode);
                return true;
            }
            // Ensure that it is a number and stop the keypress
            if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
                // alert("charCode 2: " + e.keyCode);
                e.preventDefault();
            }
            //alert("charCode 3: " + e.keyCode);
            return true;
        }

        function validarLetras(e) {
            e = (e) ? e : event;
            var charCode = (e.which) ? e.which : event.keyCode

            console.log("charCode: " + charCode);

            if (e.keyCode == 32 || e.keyCode == 8 || e.keyCode == 9 || e.keyCode == 46 || e.keyCode == 27 || e.keyCode == 13 || e.keyCode == 110
                || e.keyCode == 190) {
                return true;
            }
            if (
                // Allow: Ctrl/cmd+A
                (e.keyCode == 65 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: Ctrl/cmd+C
                (e.keyCode == 67 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: Ctrl/cmd+X
                (e.keyCode == 88 && (e.ctrlKey === true || e.metaKey === true)) ||
                // Allow: home, end, left, right
                (e.keyCode >= 35 && e.keyCode <= 39)) {
                // let it happen, don't do anything
                // alert("charCode 1: " + e.keyCode);
                return true;
            }

            if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                (charCode < 97 || charCode > 122)) {
                return false;
            }


            return true;
        }

        function validarNoEspeciales(evt) {
            evt = (evt) ? evt : event;
            var charCode = (evt.which) ? evt.which : event.keyCode

            //console.log("charCode: " + charCode);
            /*  if (charCode > 31 && (charCode < 65 || charCode > 90) &&
                  (charCode < 97 || charCode > 122)) {
                  return false;
              }*/
            return true;
        }

        function validarCampos() {

            var txtdni = document.getElementById("contentModal_txtdni").value;
            var txtNombres = document.getElementById("contentModal_txtNombres").value;
            var txtApellidos = document.getElementById("contentModal_txtApellidos").value;
            var txtEmail = document.getElementById("contentModal_txtEmail").value;
            var txtPassword = document.getElementById("contentModal_txtPassword").value;
            var txtPassword2 = document.getElementById("contentModal_txtPassword2").value;
            var txtCaptcha = document.getElementById("contentModal_txtCaptcha").value;

            console.log("txtdni: " + txtdni);
            console.log("txtNombres: " + txtNombres);
            console.log("txtApellidos: " + txtApellidos);
            console.log("txtEmail: " + txtEmail);
            console.log("txtPassword: " + txtPassword);
            // alert("txtCaptcha: " + txtCaptcha);
            if (!txtdni) {
                alert("Ingresar Nro Documento Identidad");
                return false;
            } else if (!txtNombres) {
                alert("Ingresar Nombres");
                return false;
            } else if (!txtApellidos) {
                alert("Ingresar Apellidos");
                return false;
            } else if (!txtEmail) {
                alert("Ingresar Email");
                return false;
            } else if (!txtPassword) {
                alert("Ingresar Contraseña");
                return false;
            } else if (!txtPassword2) {
                alert("Debe reingresar la contraseña");
                return false;
            } else if (!txtCaptcha) {
                alert("Debe ingresar el texto aleatorio");
                return false;
            }
            else {

                var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
                if (re.test(txtEmail)) {
                    if (txtPassword != txtPassword2) {
                        alert("Las contraseñas no coinciden");
                        document.getElementById("contentModal_txtPassword").focus;
                        return false;
                    }
                    else return true;
                }
                else {
                    alert("Ingresar un Email correcto.");
                    return false;
                }
            }
        }
        function validarCodigoPromocional() {

            var txtdni = document.getElementById("contentModal_txtNroPromocionalJugado").value;
            if (!txtdni) {
                alert("Ingresar Código Promocional");
                return false;
            } 
        }
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
</asp:Content>
<asp:Content ID="contentPageInicio" ContentPlaceHolderID="masterPage" runat="server">
    <div class="row">
        <div class="col-md-3">
			<%--Anuncio Lateral--%>
		</div>
		<div class="col-md-6">
			<div id="login-user">
				<div class="panel panel-primary">
					<div class="panel-heading">
						<h4>Ingresar</h4>
					</div>
					<div class="panel-body">
						<div id="NroPromocional" class="form-group">
							<div class="input-group">
								<div class="input-group-addon">
								<i class="fa fa-tag fa-lg" aria-hidden="true"></i>
								</div>
                                <asp:TextBox ID="txtNroPromocional" CssClass="form-control" placeholder="Ingrese código promocional" runat="server"></asp:TextBox>
							</div>
						</div>
                        <div class="form-group">
						    <div class="checkbox">
							    <div class="item">
                                <asp:CheckBox id="checkBoxLogin" 
                                        AutoPostBack="True"
                                        Text="Si es usted cliente marque la siguiente opción"
                                        TextAlign="Right"
                                        Checked="False"
                                        runat="server"/>
							    </div>
						    </div>
                        </div>
						<div class="login-advanced" >
							<div class="form-group">
								<div class="input-group">
									<div class="input-group-addon">
									    <i class="fa fa-user fa-lg" aria-hidden="true"></i>
									</div>
                                    <asp:TextBox ID="textNroDocumento" CssClass="form-control" placeholder="N° de documento de identidad" runat="server" onkeydown="return validarNumeros(event)" MaxLength="8"></asp:TextBox>
								</div>
							</div>
							<div class="form-group">
								<div class="input-group">
									<div class="input-group-addon">
									    <i class="fa fa-lock fa-lg" aria-hidden="true"></i>
									</div>
                                    <asp:TextBox ID="textContrasenha" TextMode="Password" CssClass="form-control" placeholder="Contraseña" runat="server"></asp:TextBox>
								</div>
							</div>
						</div>

                        <%--<div class="form-captcha">
                            <%--<div class="g-recaptcha" data-sitekey="6LeIxAcTAAAAAJcZVRqyHh71UMIEGNQ_MXjiZKhI"></div>--%>
                            <%--<div class="g-recaptcha" data-sitekey="6LeUuygUAAAAACOhCKFLY-fRvDX3WMD_XNrd6elw"></div> <%-- Produccion ----%>
                        <%--</div>---%>

                  <div class="form-group">
                   <asp:ScriptManager ID="sm" runat="server"></asp:ScriptManager>
                 <label class="label-captcha">Ingrese código de seguridad:</label>
                 <div class="row">
                     <div class="col-md-5">
                         <asp:TextBox ID="txtCaptcha2" runat="server" placeholder="Código Captcha" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-7">
                         <div class="panel-captcha">
                             <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                <ContentTemplate>
                                    <cc1:CaptchaControl CssClass="img-captcha" ID="Captcha2" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                    CaptchaHeight="60" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                    FontColor="#D20B0C" NoiseColor="#B1B1B1" />
                                    <asp:ImageButton CssClass="btn-refresh" ImageUrl="recursos/images/blue-refresh.png" runat="server" CausesValidation="false" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                         </div>
                     </div>
                 </div> 
            </div>

                        <div class="form-group form-btnsummit">
                            <asp:Button ID="btnLoguear" runat="server" CssClass="btn btn-success btn-lg btn-block" Text="Ingresar" OnClick="btnLoguear_Click"/>
					    </div>
                        <div style="align-content:center">
		                    ¿Deseas ver tu jugada?
		                    <a href="#" data-toggle="modal" data-target="#myJugada">
			                    <i class="fa fa-sign-in" aria-hidden="true"></i> Visualizalo aquí
		                    </a>
	                    </div>
				    </div>
			    </div>
		    </div>
        </div>
		<div class="col-md-3">
			<%--Anuncio Lateral--%>
		</div>
    </div>

</asp:Content>
<asp:Content ID="ModalRegister" ContentPlaceHolderID="contentModal" runat="server">

<div class="modal fade" id="myJugada" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalJugada">Ver jugada por código</h4>
      </div>
      <div class="modal-body">
            <div class="form-group">
                <div class="input-group">
                <div class="input-group-addon">
				    <i class="fa fa-tag fa-lg" aria-hidden="true"></i>
				</div>
                    <asp:TextBox ID="txtNroPromocionalJugado" CssClass="form-control" placeholder="Ingrese código promocional jugado" runat="server"></asp:TextBox>
                </div>
		    </div>
      </div>
        <div class="modal-footer">
            <asp:Button ID="btnVerJugada" runat="server" CssClass="btn btn-lg btn-block" Text="Ver Jugada" OnClientClick="return validarCodigoPromocional();" OnClick="btnVerJugada_Click"/>
        </div>
   </div>
  </div>
</div>

<div class="modal fade" id="myModal" tabindex="-1" role="dialog" aria-labelledby="myModalLabel">
  <div class="modal-dialog" role="document">
    <div class="modal-content">
      <div class="modal-header">
        <button type="button" class="close" data-dismiss="modal" aria-label="Close"><span aria-hidden="true">&times;</span></button>
        <h4 class="modal-title" id="myModalLabel">Registro de usuario</h4>
      </div>
      <div class="modal-body">
      	<div class="form-body">
      		
        	<div class="form-group">
                <asp:TextBox ID="txtdni" CssClass="form-control" placeholder="N° de documento de identidad"
                    onkeydown="return validarNumeros(event)" runat="server" MaxLength="8"></asp:TextBox>
			</div>
                                    
			<div class="form-group">
                <asp:TextBox ID="txtNombres" CssClass="form-control" placeholder="Ingrese Nombres" 
                    onkeydown="return validarLetras(event)" runat="server"></asp:TextBox>
			</div>
                                   
			<div class="form-group">
			    <asp:TextBox ID="txtApellidos" CssClass="form-control" placeholder="Ingrese Apellidos" 
                    onkeydown="return validarLetras(event)" runat="server"></asp:TextBox>
			</div>
                                    
			<div class="form-group">
			    <asp:TextBox ID="txtEmail" CssClass="form-control" placeholder="Ingrese Correo Electrónico" 
                    onkeydown="return validarNoEspeciales(event)" runat="server"></asp:TextBox>
			</div>
                 
			<div class="form-group">
                <asp:TextBox ID="txtPassword" TextMode="Password" CssClass="form-control" placeholder="Contraseña" runat="server"></asp:TextBox>
			</div>

            <div class="form-group">
                <asp:TextBox ID="txtPassword2" TextMode="Password" CssClass="form-control" placeholder="Reingresar Contraseña" runat="server"></asp:TextBox>
			</div>

             <div class="form-group">
                 
                 <label class="label-captcha">Ingrese código de seguridad:</label>
                 <div class="row">
                     <div class="col-md-5">
                         <asp:TextBox ID="txtCaptcha" runat="server" placeholder="Código Captcha" CssClass="form-control"></asp:TextBox>
                     </div>
                     <div class="col-md-7">
                         <div class="panel-captcha">
                             <asp:UpdatePanel ID="up1" runat="server">
                                <ContentTemplate>
                                    <cc1:CaptchaControl CssClass="img-captcha" ID="Captcha1" runat="server" CaptchaBackgroundNoise="Low" CaptchaLength="5"
                                    CaptchaHeight="60" CaptchaWidth="200" CaptchaMinTimeout="5" CaptchaMaxTimeout="240"
                                    FontColor="#D20B0C" NoiseColor="#B1B1B1" />
                                    <asp:ImageButton CssClass="btn-refresh" ImageUrl="recursos/images/blue-refresh.png" runat="server" CausesValidation="false" />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                         </div>
                     </div>
                 </div> 
            </div>
			<div class="form-group btn-register">
                </div>
				<asp:CustomValidator ErrorMessage="" OnServerValidate="ValidateCaptcha" runat="server" />
                <asp:Button ID="btnRegistrarse" CssClass="btn btn-success btn-lg btn-block" runat="server" Text="Registrar Usuario"  OnClientClick="return validarCampos();" OnClick="btnRegistrar_Click"/>
			</div>
      	</div>
      </div>
    </div>
  </div>

</asp:Content>