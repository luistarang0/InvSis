using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class RolPermiso
    {
        /// <summary>
        /// Identificador del rol
        /// </summary>
        public int IdRol { get; set; }

        /// <summary>
        /// Identificador del permiso
        /// </summary>
        public int IdPermiso { get; set; }

        /// <summary>
        /// Referencia al rol
        /// </summary>
        public Rol Rol { get; set; }

        /// <summary>
        /// Referencia al permiso
        /// </summary>
        public Permiso Permiso { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public RolPermiso()
        {
            Rol = new Rol();
            Permiso = new Permiso();
        }

        /// <summary>
        /// Constructor con IDs
        /// </summary>
        public RolPermiso(int idRol, int idPermiso)
        {
            IdRol = idRol;
            IdPermiso = idPermiso;
            Rol = new Rol();
            Permiso = new Permiso();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public RolPermiso(int idRol, int idPermiso, Rol rol, Permiso permiso)
        {
            IdRol = idRol;
            IdPermiso = idPermiso;
            Rol = rol;
            Permiso = permiso;
        }
    }

}
