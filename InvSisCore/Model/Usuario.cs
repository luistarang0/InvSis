using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Usuario
    {
        /// <summary>
        /// Identificador único del usuario
        /// </summary>
        public int IdUsuario { get; set; }

        /// <summary>
        /// Identificador del rol asociado
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Identificador de la persona asociada
        /// </summary>
        public int IdPersona { get; set; }

        /// <summary>
        /// Nombre de usuario (nickname)
        /// </summary>
        public string Nickname { get; set; }

        /// <summary>
        /// Contraseña del usuario
        /// </summary>
        public string Contraseña { get; set; }

        /// <summary>
        /// Estado del usuario (1=activo, 2=inactivo)
        /// </summary>
        public int Estatus { get; set; }

        /// <summary>
        /// Referencia a la persona
        /// </summary>
        public Persona Persona { get; set; }

        /// <summary>
        /// Referencia al rol
        /// </summary>
        public Rol Rol { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Usuario()
        {
            Nickname = string.Empty;
            Contraseña = string.Empty;
            Estatus = 1; // Activo por defecto
            Persona = new Persona();
            Rol = new Rol();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Usuario(string nickname, string contrasena, int idRol, int idPersona)
        {
            Nickname = nickname;
            Contraseña = contrasena;
            IdRol = idRol;
            IdPersona = idPersona;
            Estatus = 1; // Activo por defecto
            Persona = new Persona();
            Rol = new Rol();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Usuario(int idUsuario, int idRol, int idPersona, string nickname, string contrasena, int estatus)
        {
            IdUsuario = idUsuario;
            IdRol = idRol;
            IdPersona = idPersona;
            Nickname = nickname;
            Contraseña = contrasena;
            Estatus = estatus;
            Persona = new Persona();
            Rol = new Rol();
        }

    }
}
