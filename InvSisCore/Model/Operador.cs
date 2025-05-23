using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Operador
    {
        /// <summary>
        /// Identificador único del operador
        /// </summary>
        public int IdOperador { get; set; }

        /// <summary>
        /// Identificador de la persona asociada
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Puesto del operador
        /// </summary>
        public string Puesto { get; set; }

        /// <summary>
        /// Estado del operador (1=activo, 2=inactivo)
        /// </summary>
        public int Estatus { get; set; }

        /// <summary>
        /// Referencia a la persona
        /// </summary>
        public Persona Persona { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Operador()
        {
            Puesto = string.Empty;
            Estatus = 1; // Activo por defecto
            Persona = new Persona();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Operador(int idPersona, string puesto)
        {
            IdPersona = idPersona;
            Puesto = puesto;
            Estatus = 1; // Activo por defecto
            Persona = new Persona();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Operador(int idOperador, int idPersona, string puesto, int estatus)
        {
            IdOperador = idOperador;
            IdPersona = idPersona;
            Puesto = puesto;
            Estatus = estatus;
            Persona = new Persona();
        }
    }

}
