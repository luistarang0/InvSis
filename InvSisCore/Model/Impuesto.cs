using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Impuesto
    {
        /// <summary>
        /// Identificador único del impuesto
        /// </summary>
        public int IdImpuesto { get; set; }

        /// <summary>
        /// Tipo de impuesto
        /// </summary>
        public string TipoImpuesto { get; set; }

        /// <summary>
        /// Cantidad o porcentaje de impuesto
        /// </summary>
        public decimal CantidadImpuesto { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Impuesto()
        {
            TipoImpuesto = string.Empty;
            CantidadImpuesto = 0;
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Impuesto(string tipoImpuesto, decimal cantidadImpuesto)
        {
            TipoImpuesto = tipoImpuesto;
            CantidadImpuesto = cantidadImpuesto;
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Impuesto(int idImpuesto, string tipoImpuesto, decimal cantidadImpuesto)
        {
            IdImpuesto = idImpuesto;
            TipoImpuesto = tipoImpuesto;
            CantidadImpuesto = cantidadImpuesto;
        }
    }

}
