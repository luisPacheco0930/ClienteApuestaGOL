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
        public const String nombreCookieNroDoc = "cookieNroDoc";

        public const String textCodigoYaUsado = "El código ya ha sido usado";
        public const String textCodigoNoVigente = "El código no está vigente";
        public const String textUsuarioNoValido = "Usuario o contraseña errados";
        public const String textUsuarioYaExiste = "Nro Documento y correo electrónico ya registrados";
    }
}
