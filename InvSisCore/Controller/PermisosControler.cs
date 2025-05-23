using System;
using System.Collections.Generic;
using InvSis.Utilities;
using NLog;
using InvSis.Data;
using InvSis.Model;

namespace InvSis.Controller
{
    public class PermisosController
    {
        private static readonly Logger _Logger = LoggingManager.GetLogger("InvSis.Controller.RolesController");
        private readonly RolesDataAccess _rolesData;
        private readonly PermisosDataAccess _permisosData;

        public  PermisosController()
        {
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

        public List<Permiso> ObtenerTodosPermisos(bool soloActivos = true)
        {
            try
            {
                return _permisosData.ObtenerTodosLosPermisos();
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
                    // Obtener el último ID e incrementarlo
                    int ultimoId = _permisosData.ObtenerUltimoIdPermiso();
                    permiso.IdPermiso = ultimoId + 1;

                    return _permisosData.InsertarPermiso(permiso) > 0;
                }
                else
                {
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

        public Permiso? ObtenerPermisoPorDescripcion(string descripcion)
        {
            return _permisosData.ObtenerPermisoPorDescripcion(descripcion);
        }
    }
}

