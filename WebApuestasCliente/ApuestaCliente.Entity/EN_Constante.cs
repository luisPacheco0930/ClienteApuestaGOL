using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApuestaCliente.Entity
{
    public class EN_Constante
    {
        public const string conexion = "cnxSiApuesta";

        public const String nombreCookieCodAleatorio = "cookieCodAlea";
        public const String nombreCookieCodAleatorioResultadoCartilla = "cookieCodAleaResCartilla";
        public const String nombreCookieCodAleatorioResultadoPolla = "cookieCodAleaResPolla";
        public const String nombreCookieCodAleatorioResultadoApuesta = "cookieCodAleaResApuesta";
        public const String nombreCookieNroDoc = "cookieNroDoc";

        public const String textCodigoYaUsado = "El código ya ha sido usado.";
        public const String textCodigoNoVigente = "El código no está vigente.";
        public const String textCodigoValido = "El código es válido.";
        public const String textCodigoNoValido = "El código no es válido.";
        public const String textCodigoNoIngresado = "Código no ingresado.";
        public const String textUsuarioNoValido = "Usuario o contraseña errados.";
        public const String textUsuarioYaExiste = "Nro Documento y correo electrónico ya registrados.";

        public const String textNohayProgramaParaCodigo = "No hay programación, para el Código Ingresado.";

        public const String cartillaDeLaSuerte = "00001"; // "AW001";
        public const String laPollaSemanal = "00002";
        public const String apuestaGoles = "00003";

        public const String GanadorLocal = "L";
        public const String GanadorVisitante = "V";
        public const String Empate = "E";
        public const String rutaIconosEquipos = "http://apuestagol.pe/recursos/images/equipos/"; //"../recursos/images/equipos/";
        //public const String rutaIconosEquipos = HttpContext.Current.Server.MapPath("/admin/recursos/images/equipos/");
    }
}
