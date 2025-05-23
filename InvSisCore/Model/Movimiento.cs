using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Movimiento
    {
        /// <summary>
        /// Identificador único del movimiento
        /// </summary>
        public int IdMovimiento { get; set; }

        /// <summary>
        /// Tipo de movimiento
        /// </summary>
        public string Tipo { get; set; }

        /// <summary>
        /// Estado del movimiento (múltiples valores según diccionario)
        /// </summary>
        public int Estatus { get; set; }

        /// <summary>
        /// Fecha del movimiento
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Identificador del operador responsable
        /// </summary>
        public int IdOperador { get; set; }

        /// <summary>
        /// Referencia al operador
        /// </summary>
        public Operador Operador { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Movimiento()
        {
            Tipo = string.Empty;
            Fecha = DateTime.Now;
            Estatus = 1; // Activo por defecto
            Operador = new Operador();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Movimiento(string tipo, int idOperador)
        {
            Tipo = tipo;
            IdOperador = idOperador;
            Fecha = DateTime.Now;
            Estatus = 1; // Activo por defecto
            Operador = new Operador();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Movimiento(int idMovimiento, string tipo, int estatus, DateTime fecha, int idOperador)
        {
            IdMovimiento = idMovimiento;
            Tipo = tipo;
            Estatus = estatus;
            Fecha = fecha;
            IdOperador = idOperador;
            Operador = new Operador();
        }
    }

}
