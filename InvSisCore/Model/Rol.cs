using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Rol
    {
        /// <summary>
        /// Identificador único del rol
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Nombre del rol
        /// </summary>
        public string NombreRol { get; set; }

        /// <summary>
        /// Estado del rol (1=activo, 2=inactivo)
        /// </summary>
        public int Estatus { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Rol()
        {
            NombreRol = string.Empty;
            Estatus = 1; // Activo por defecto
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Rol(string nombreRol)
        {
            NombreRol = nombreRol;
            Estatus = 1; // Activo por defecto
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Rol(int idRol, string nombreRol, int estatus)
        {
            IdRol = idRol;
            NombreRol = nombreRol;
            Estatus = estatus;
        }
    }

}
