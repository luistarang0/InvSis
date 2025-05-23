using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Business
{
    public class ClaveProducto
    {
        /// <summary>
        /// Valida que el código de producto cumpla con el formato EAN-13
        /// </summary>
        /// <param name="codigo">Código de producto a validar</param>
        /// <returns>True si el código es válido, False en caso contrario</returns>
        public static bool ValidarCodigoProducto(string codigo)
        {            
            // Eliminar espacios y guiones que pudieran estar en el código
            codigo = codigo.Replace(" ", "").Replace("-", "");

            // Comprobar que sean exactamente 13 dígitos
            if (codigo.Length != 13 || !codigo.All(char.IsDigit))
            {                
                return false;
            }
            
            // Verificar que comience con el prefijo de México (750)
            if (!codigo.StartsWith("750"))
            {                
                return false;
            }            

            return true;
        }
    }
}
