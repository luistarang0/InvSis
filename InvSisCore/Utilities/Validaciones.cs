using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace InvSis.Utilities
{
    public class Validaciones
    {
        public static bool EsCorreoValido(string correo)
        {
            string patron = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";
            return Regex.IsMatch(correo, patron);
        }
    }
}
