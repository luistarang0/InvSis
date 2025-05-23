using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InvSis.Utilities;

namespace InvSis.Business
{
    public class UsuarioNegocio
    {
        public static bool EsFormatoValido(string correo)
        {
            return Validaciones.EsCorreoValido(correo);
        }


    }
}
