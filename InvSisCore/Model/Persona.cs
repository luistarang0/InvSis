using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Persona
    {
        /// <summary>
        /// Identificador único de la persona
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Nombre completo de la persona
        /// </summary>
        public string NombreCompleto { get; set; }

        /// <summary>
        /// Edad de la persona
        /// </summary>
        public int? Edad { get; set; }

        /// <summary>
        /// Sexo de la persona
        /// </summary>
        public string Sexo { get; set; }

        /// <summary>
        /// Nacionalidad de la persona
        /// </summary>
        public string Nacionalidad { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Persona()
        {
            NombreCompleto = string.Empty;
            Sexo = string.Empty;
            Nacionalidad = string.Empty;
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Persona(string nombreCompleto, string sexo, string nacionalidad)
        {
            NombreCompleto = nombreCompleto;
            Sexo = sexo;
            Nacionalidad = nacionalidad;
        }

        /// <summary>
        /// Constructor completo con todos los datos
        /// </summary>
        public Persona(int idPersona, string nombreCompleto, int? edad, string sexo, string nacionalidad)
        {
            IdPersona = idPersona;
            NombreCompleto = nombreCompleto;
            Edad = edad;
            Sexo = sexo;
            Nacionalidad = nacionalidad;
        }
    }

}
