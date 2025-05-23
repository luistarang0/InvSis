using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Business
{
    public class Sesion
    {
        public static bool EsAdministrador { get; set; }
        public static string UsuarioActual { get; set; }

        public static void IniciarSesion(string usuario)
        {
            // Verificar si es administrador
            if (usuario.ToLower() == "admin")
            {
                EsAdministrador = true;
            }
            else
            {
                EsAdministrador = false; // O verificar en la base de datos
            }

            UsuarioActual = usuario;
        }
        public static void CerrarSesion()
        {
            EsAdministrador = false;
            UsuarioActual = null;
        }
    }
}
