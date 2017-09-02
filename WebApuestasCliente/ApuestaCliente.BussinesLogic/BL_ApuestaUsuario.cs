using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApuestaCliente.Data;
using ApuestaCliente.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Net.Mail;
using System.Net;

namespace ApuestaCliente.BussinesLogic
{
    public class BL_ApuestaUsuario
    {

        public void BL_registrarApuestaUsuario(ref EN_ApuestaUsuario enApuestaUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id= enApuestaUsuario.idApuestaUsuario;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();

            if (enApuestaUsuario.idApuestaUsuario == null || enApuestaUsuario.idApuestaUsuario == 0) {
                using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
                {
                    id = daObject.DA_registrarApuestaUsuario(dbContexto, enApuestaUsuario);
                    enApuestaUsuario.idApuestaUsuario = id;
                }
            }
            if(enApuestaUsuario.listaitem!=null && enApuestaUsuario.listaitem.Count > 0)
            {
                foreach (EN_ApuestaUsuarioDet detalle in enApuestaUsuario.listaitem)
                {
                    detalle.idApuestaUsuario = id;
                    BL_registrarApuestaDetalleUsuario(detalle);
                }
            }

            if (!String.IsNullOrEmpty(enApuestaUsuario.Usuario))
            {
                   BL_RegistraClienteCodigoAleatorio(enApuestaUsuario);
                   enviarMail(enApuestaUsuario);
            }

        }

        public void enviarMail(EN_ApuestaUsuario apuestaCodigoAleatorio)
        {
            EN_Cliente enCliente = new EN_Cliente();
            DataTable dtLista = new DataTable();
            BL_Cliente blCliente = new BL_Cliente();
            EN_CodigoAleatorio enCodigoAleatorio = new EN_CodigoAleatorio();

            enCliente.NroDocumento = apuestaCodigoAleatorio.Usuario;

            dtLista = blCliente.BL_ObtenerDatosUsuario(enCliente);
            String body = armarBody(apuestaCodigoAleatorio.CodAleatorio);


            MailMessage email = new MailMessage();
            email.To.Add(new MailAddress(dtLista.Rows[0]["Correo"].ToString()));
            email.From = new MailAddress("no-reply@apuestagol.pe");
            email.Subject = "[APUESTA GOL] "+ dtLista.Rows[0]["Nombres"].ToString() + ", GRACIAS POR JUGAR";
            email.Body = body;
            email.IsBodyHtml = true;
            email.Priority = MailPriority.Normal;

            SmtpClient smtp = new SmtpClient();
            smtp.Host = "mail.apuestagol.pe";
            smtp.Port = 25;
            smtp.EnableSsl = false;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential("no-reply@apuestagol.pe", "apuestagol.pe");

            string output = null;

            try
            {
                smtp.Send(email);
                email.Dispose();
                //output = "Corre electrónico fue enviado satisfactoriamente.";
            }
            catch (Exception ex)
            {
                output = "Error enviando correo electrónico: " + ex.Message;
            }
        }

        public String armarBody(String codigoAleatorio)
        {
            String body = "<HTML><HEAD><H1>Jugada Realizada</H1></HEAD><BODY><table><tr><td><strong>Partido</strong></td><td><strong>Jugada</strong></td></tr>";
            EN_CodigoAleatorio enCodigoAleatorio = new EN_CodigoAleatorio();
            BL_PartidosProgramados blPartidosProgramados = new BL_PartidosProgramados();

            enCodigoAleatorio.NroCodigoAleatorio = codigoAleatorio;
            DataTable dt = blPartidosProgramados.BL_ObtenerJugadaCliente(enCodigoAleatorio);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                body += "<tr><td>" + dt.Rows[i]["secuencia"].ToString() + ". " + dt.Rows[i]["descLocal"].ToString() + " - " + dt.Rows[i]["descVisita"].ToString()+ "</td>";

                if (dt.Rows[i]["codigotipoapuesta"].ToString().Equals(EN_Constante.cartillaDeLaSuerte))
                {
                    body += "<td>" + dt.Rows[i]["marcadorLocal"].ToString() + " - " + dt.Rows[i]["marcadorvisitante"].ToString()+ "</td></tr>";
                }
                else
                {
                    body += "<td>" + dt.Rows[i]["resultado"].ToString() + "</td></tr>";
                }
            }

            body += "</table></BODY></HTML> ";
            return body;
        }
        public void BL_RegistraClienteCodigoAleatorio(EN_ApuestaUsuario apuestaUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                daObject.DA_RegistraClienteCodigoAleatorio(dbContexto, apuestaUsuario);
            }
        }

        public void BL_registrarApuestaDetalleUsuario(EN_ApuestaUsuarioDet enApuestaDetalleUsuario)
        {
            //DataTable dtLista = new DataTable();
            int id;
            DA_ApuestaUsuario daObject = new DA_ApuestaUsuario();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                daObject.DA_registrarApuestaDetalleUsuario(dbContexto, enApuestaDetalleUsuario);
            }
        }

        public DataTable BL_ObtenerDatosApuesta(EN_CodigoAleatorio enCodAleatorio, String codTipoApuesta)
        {
            DataTable dtLista = new DataTable();
            DA_ApuestaUsuario daApuestaUsuario = new DA_ApuestaUsuario();
            using (ContextoDB dbContexto = ContextoDB.InicializarContexto())
            {
                dtLista = daApuestaUsuario.DA_Obtener_DatosApuesta(dbContexto, enCodAleatorio, codTipoApuesta);
            }
            return dtLista;
        }
    }
}
