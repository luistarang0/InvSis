
using InvSis.Utilities;
using NLog;
using InvSis.Data;
using InvSis.Model;

namespace InvSis.Controller
{
    public class RolesController
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("InvSis.Controller.RolesController");
        private readonly RolesDataAccess _rolesData;
        private readonly PermisosDataAccess _permisosData;

        public RolesController()
        {
            _rolesData = new RolesDataAccess(); 
            _permisosData = new PermisosDataAccess();
        }

        public List<Permiso> ObtenerPermisos(bool soloActivos = true)
        {
            try
            {
                return _permisosData.ObtenerTodosLosPermisos(soloActivos);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error al obtener permisos");
                return new List<Permiso>();
            }
        }

        public Permiso? ObtenerPermisoPorId(int idPermiso)
        {
            try
            {
                return _permisosData.ObtenerPermisoPorId(idPermiso);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al obtener el permiso con ID {idPermiso}");
                return null;
            }
        }

        public bool GuardarPermiso(Permiso permiso)
        {
            try
            {
                if (permiso.IdPermiso == 0)
                {
                    // Insertar nuevo permiso
                    return _permisosData.InsertarPermiso(permiso) > 0;
                }
                else
                {
                    // Actualizar permiso existente
                    return _permisosData.ActualizarPermiso(permiso);
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error al guardar el permiso");
                return false;
            }
        }

        public bool EliminarPermiso(int idPermiso)
        {
            try
            {
                return _permisosData.EliminarPermiso(idPermiso);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al eliminar el permiso con ID {idPermiso}");
                return false;
            }
        }

        public bool ExistePermiso(string descripcion)
        {
            try
            {
                return _permisosData.ExistePermisoPorDescripcion(descripcion);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al verificar existencia de permiso con descripción: {descripcion}");
                return false;
            }
        }

        public bool AsignarPermisoARol(int idRol, int idPermiso)
        {
            try
            {
                return _rolesData.AsignarPermisoARol(idRol, idPermiso);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error al asignar permiso al rol.");
                return false;
            }
        }


        public List<Rol> ObtenerTodosLosRoles(bool soloActivos = true)
        {
            try
            {
                return _rolesData.ObtenerTodosLosRoles(soloActivos);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error al obtener los roles");
                return new List<Rol>();
            }
        }

        public Rol? ObtenerRolPorId(int idRol)
        {
            try
            {
                return _rolesData.ObtenerRolPorId(idRol);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al obtener el rol con ID {idRol}");
                return null;
            }
        }

        public bool GuardarRol(Rol rol)
        {
            try
            {
                if (rol.IdRol == 0)
                {
                    return _rolesData.InsertarRol(rol) > 0;
                }
                else
                {
                    return _rolesData.ActualizarRol(rol);
                }
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, "Error al guardar el rol");
                return false;
            }
        }

        public bool EliminarRol(int idRol)
        {
            try
            {
                return _rolesData.EliminarRol(idRol);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al eliminar el rol con ID {idRol}");
                return false;
            }
        }

        public bool ExisteRol(string nombre)
        {
            try
            {
                return _rolesData.ExisteNombreRol(nombre);
            }
            catch (Exception ex)
            {
                _Logger.Error(ex, $"Error al verificar existencia del rol con nombre '{nombre}'");
                return false;
            }
        }
        public List<Permiso> ObtenerPermisosDeRol(int idRol)
        {
            return _rolesData.ObtenerPermisosDeRol(idRol);
        }

        public bool RemoverPermisoDeRol(int idRol, int idPermiso)
        {
            return _rolesData.RemoverPermisoDeRol(idRol, idPermiso);
        }

    }
}

