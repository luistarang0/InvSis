using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;
using NLog;
using InvSis.Utilities;
using InvSis.Model;
using System.Data;
using NpgsqlTypes;

namespace InvSis.Data
{
    public class RolesPermisosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.RolesPermisosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly RolesDataAccess _rolesData;
        private readonly PermisosDataAccess _permisosData;

        public RolesPermisosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _rolesData = new RolesDataAccess();
                _permisosData = new PermisosDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar RolesPermisosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Asigna un permiso a un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idPermiso">ID del permiso</param>
        /// <returns>True si la asignación fue exitosa, False en caso contrario</returns>
        public bool AsignarPermisoARol(int idRol, int idPermiso)
        {
            try
            {
                // Verificar si el rol y el permiso existen
                Rol? rol = _rolesData.ObtenerRolPorId(idRol);
                Permiso? permiso = _permisosData.ObtenerPermisoPorId(idPermiso);

                if (rol == null)
                {
                    _logger.Warn($"No se pudo asignar el permiso porque el rol con ID {idRol} no existe");
                    return false;
                }

                if (permiso == null)
                {
                    _logger.Warn($"No se pudo asignar el permiso porque el permiso con ID {idPermiso} no existe");
                    return false;
                }

                // Verificar si la asignación ya existe
                if (ExisteAsignacion(idRol, idPermiso))
                {
                    _logger.Info($"El permiso con ID {idPermiso} ya está asignado al rol con ID {idRol}");
                    return true; // Consideramos que es exitoso si ya existe
                }

                string query = "INSERT INTO Roles_Permisos (id_rol, id_permiso) VALUES (@IdRol, @IdPermiso)";

                // Crea los parámetros
                NpgsqlParameter paramIdRol = _dbAccess.CreateParameter("@IdRol", idRol);
                NpgsqlParameter paramIdPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdRol, paramIdPermiso);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Permiso con ID {idPermiso} asignado correctamente al rol con ID {idRol}");
                }
                else
                {
                    _logger.Warn($"No se pudo asignar el permiso con ID {idPermiso} al rol con ID {idRol}");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al asignar el permiso con ID {idPermiso} al rol con ID {idRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si ya existe una asignación de un permiso a un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idPermiso">ID del permiso</param>
        /// <returns>True si existe la asignación, False en caso contrario</returns>
        public bool ExisteAsignacion(int idRol, int idPermiso)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Roles_Permisos WHERE id_rol = @IdRol AND id_permiso = @IdPermiso";

                // Crea los parámetros
                NpgsqlParameter paramIdRol = _dbAccess.CreateParameter("@IdRol", idRol);
                NpgsqlParameter paramIdPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdRol, paramIdPermiso);

                int count = Convert.ToInt32(resultado);
                bool existe = count > 0;

                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia de la asignación del permiso {idPermiso} al rol {idRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina la asignación de un permiso a un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idPermiso">ID del permiso</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarAsignacion(int idRol, int idPermiso)
        {
            try
            {
                string query = "DELETE FROM Roles_Permisos WHERE id_rol = @IdRol AND id_permiso = @IdPermiso";

                // Crea los parámetros
                NpgsqlParameter paramIdRol = _dbAccess.CreateParameter("@IdRol", idRol);
                NpgsqlParameter paramIdPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdRol, paramIdPermiso);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Asignación del permiso con ID {idPermiso} al rol con ID {idRol} eliminada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar la asignación porque no existe una relación entre el rol {idRol} y el permiso {idPermiso}");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar la asignación del permiso {idPermiso} al rol {idRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina todas las asignaciones de permisos para un rol específico
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarPermisosDeRol(int idRol)
        {
            try
            {
                string query = "DELETE FROM Roles_Permisos WHERE id_rol = @IdRol";

                // Crea el parámetro
                NpgsqlParameter paramIdRol = _dbAccess.CreateParameter("@IdRol", idRol);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdRol);

                _logger.Info($"Se eliminaron {filasAfectadas} asignaciones de permisos para el rol con ID {idRol}");
                return true; // Consideramos exitoso aunque no haya asignaciones que eliminar
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar las asignaciones de permisos para el rol {idRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los permisos asignados a un rol específico
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <returns>Lista de objetos RolPermiso</returns>
        public List<RolPermiso> ObtenerPermisosPorRol(int idRol)
        {
            List<RolPermiso> rolesPermisos = new List<RolPermiso>();

            try
            {
                string query = @"
                    SELECT rp.id_rol, rp.id_permiso, 
                           r.nombre_rol, r.estatus AS estatus_rol,
                           p.descripcion, p.estatus AS estatus_permiso
                    FROM Roles_Permisos rp
                    INNER JOIN Roles r ON rp.id_rol = r.id_rol
                    INNER JOIN Permisos p ON rp.id_permiso = p.id_permiso
                    WHERE rp.id_rol = @IdRol";

                // Crea el parámetro
                NpgsqlParameter paramIdRol = _dbAccess.CreateParameter("@IdRol", idRol);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdRol);

                // Procesa los resultados
                foreach (DataRow row in resultado.Rows)
                {
                    Rol rol = new Rol(
                        Convert.ToInt32(row["id_rol"]),
                        row["nombre_rol"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_rol"])
                    );

                    Permiso permiso = new Permiso(
                        Convert.ToInt32(row["id_permiso"]),
                        row["descripcion"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_permiso"])
                    );

                    RolPermiso rolPermiso = new RolPermiso(
                        Convert.ToInt32(row["id_rol"]),
                        Convert.ToInt32(row["id_permiso"]),
                        rol,
                        permiso
                    );

                    rolesPermisos.Add(rolPermiso);
                }

                _logger.Info($"Se obtuvieron {rolesPermisos.Count} permisos para el rol con ID {idRol}");
                return rolesPermisos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener los permisos para el rol con ID {idRol}");
                return rolesPermisos; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los roles a los que está asignado un permiso específico
        /// </summary>
        /// <param name="idPermiso">ID del permiso</param>
        /// <returns>Lista de objetos RolPermiso</returns>
        public List<RolPermiso> ObtenerRolesPorPermiso(int idPermiso)
        {
            List<RolPermiso> rolesPermisos = new List<RolPermiso>();

            try
            {
                string query = @"
                    SELECT rp.id_rol, rp.id_permiso, 
                           r.nombre_rol, r.estatus AS estatus_rol,
                           p.descripcion, p.estatus AS estatus_permiso
                    FROM Roles_Permisos rp
                    INNER JOIN Roles r ON rp.id_rol = r.id_rol
                    INNER JOIN Permisos p ON rp.id_permiso = p.id_permiso
                    WHERE rp.id_permiso = @IdPermiso";

                // Crea el parámetro
                NpgsqlParameter paramIdPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdPermiso);

                // Procesa los resultados
                foreach (DataRow row in resultado.Rows)
                {
                    Rol rol = new Rol(
                        Convert.ToInt32(row["id_rol"]),
                        row["nombre_rol"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_rol"])
                    );

                    Permiso permiso = new Permiso(
                        Convert.ToInt32(row["id_permiso"]),
                        row["descripcion"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_permiso"])
                    );

                    RolPermiso rolPermiso = new RolPermiso(
                        Convert.ToInt32(row["id_rol"]),
                        Convert.ToInt32(row["id_permiso"]),
                        rol,
                        permiso
                    );

                    rolesPermisos.Add(rolPermiso);
                }

                _logger.Info($"Se obtuvieron {rolesPermisos.Count} roles para el permiso con ID {idPermiso}");
                return rolesPermisos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener los roles para el permiso con ID {idPermiso}");
                return rolesPermisos; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todas las asignaciones de roles y permisos
        /// </summary>
        /// <returns>Lista de objetos RolPermiso</returns>
        public List<RolPermiso> ObtenerTodasLasAsignaciones()
        {
            List<RolPermiso> rolesPermisos = new List<RolPermiso>();

            try
            {
                string query = @"
                    SELECT rp.id_rol, rp.id_permiso, 
                           r.nombre_rol, r.estatus AS estatus_rol,
                           p.descripcion, p.estatus AS estatus_permiso
                    FROM Roles_Permisos rp
                    INNER JOIN Roles r ON rp.id_rol = r.id_rol
                    INNER JOIN Permisos p ON rp.id_permiso = p.id_permiso
                    ORDER BY r.nombre_rol, p.descripcion";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa los resultados
                foreach (DataRow row in resultado.Rows)
                {
                    Rol rol = new Rol(
                        Convert.ToInt32(row["id_rol"]),
                        row["nombre_rol"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_rol"])
                    );

                    Permiso permiso = new Permiso(
                        Convert.ToInt32(row["id_permiso"]),
                        row["descripcion"].ToString() ?? "",
                        Convert.ToInt32(row["estatus_permiso"])
                    );

                    RolPermiso rolPermiso = new RolPermiso(
                        Convert.ToInt32(row["id_rol"]),
                        Convert.ToInt32(row["id_permiso"]),
                        rol,
                        permiso
                    );

                    rolesPermisos.Add(rolPermiso);
                }

                _logger.Info($"Se obtuvieron {rolesPermisos.Count} asignaciones de roles y permisos");
                return rolesPermisos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todas las asignaciones de roles y permisos");
                return rolesPermisos; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si un rol tiene un permiso específico
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idPermiso">ID del permiso</param>
        /// <returns>True si el rol tiene el permiso, False en caso contrario</returns>
        public bool RolTienePermiso(int idRol, int idPermiso)
        {
            return ExisteAsignacion(idRol, idPermiso);
        }

        /// <summary>
        /// Asigna múltiples permisos a un rol
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idsPermisos">Lista de IDs de permisos</param>
        /// <returns>True si todas las asignaciones fueron exitosas, False si alguna falló</returns>
        public bool AsignarPermisosARol(int idRol, List<int> idsPermisos)
        {
            try
            {
                // Verificar si el rol existe
                Rol? rol = _rolesData.ObtenerRolPorId(idRol);
                if (rol == null)
                {
                    _logger.Warn($"No se pudieron asignar los permisos porque el rol con ID {idRol} no existe");
                    return false;
                }

                bool todoExitoso = true;

                // Asignar cada permiso
                foreach (int idPermiso in idsPermisos)
                {
                    bool resultado = AsignarPermisoARol(idRol, idPermiso);
                    if (!resultado)
                    {
                        todoExitoso = false;
                        _logger.Warn($"No se pudo asignar el permiso con ID {idPermiso} al rol con ID {idRol}");
                    }
                }

                return todoExitoso;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al asignar múltiples permisos al rol con ID {idRol}");
                return false;
            }
        }

        /// <summary>
        /// Actualiza los permisos de un rol, eliminando los existentes y asignando los nuevos
        /// </summary>
        /// <param name="idRol">ID del rol</param>
        /// <param name="idsPermisos">Lista de IDs de permisos a asignar</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarPermisosDeRol(int idRol, List<int> idsPermisos)
        {
            try
            {
                // Verificar si el rol existe
                Rol? rol = _rolesData.ObtenerRolPorId(idRol);
                if (rol == null)
                {
                    _logger.Warn($"No se pudieron actualizar los permisos porque el rol con ID {idRol} no existe");
                    return false;
                }

                // Eliminar todos los permisos actuales
                bool eliminacionExitosa = EliminarPermisosDeRol(idRol);
                if (!eliminacionExitosa)
                {
                    _logger.Warn($"No se pudieron eliminar los permisos existentes para el rol con ID {idRol}");
                    return false;
                }

                // Si no hay nuevos permisos para asignar, terminamos
                if (idsPermisos == null || idsPermisos.Count == 0)
                {
                    _logger.Info($"No hay nuevos permisos para asignar al rol con ID {idRol}");
                    return true;
                }

                // Asignar los nuevos permisos
                bool asignacionExitosa = AsignarPermisosARol(idRol, idsPermisos);
                if (!asignacionExitosa)
                {
                    _logger.Warn($"Hubo problemas al asignar los nuevos permisos al rol con ID {idRol}");
                    return false;
                }

                _logger.Info($"Se actualizaron correctamente los permisos para el rol con ID {idRol}");
                return true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar los permisos del rol con ID {idRol}");
                return false;
            }
        }

        public List<Permiso> ObtenerPermisosDeRol(int idRol)
        {
            var permisos = new List<Permiso>();
            try
            {
                string query = @"SELECT p.id_permiso, p.descripcion, p.estatus 
                         FROM Permisos p
                         INNER JOIN Roles_Permisos rp ON p.id_permiso = rp.id_permiso
                         WHERE rp.id_rol = @IdRol";

                var param = _dbAccess.CreateParameter("@IdRol", idRol);

                _dbAccess.Connect();
                var tabla = _dbAccess.ExecuteQuery_Reader(query, param);

                foreach (DataRow row in tabla.Rows)
                {
                    permisos.Add(new Permiso(
                        Convert.ToInt32(row["id_permiso"]),
                        row["descripcion"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    ));
                }

                return permisos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener permisos del rol.");
                return permisos;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public bool RemoverPermisoDeRol(int idRol, int idPermiso)
        {
            try
            {
                string query = "DELETE FROM Roles_Permisos WHERE id_rol = @IdRol AND id_permiso = @IdPermiso";

                var paramRol = _dbAccess.CreateParameter("@IdRol", idRol);
                var paramPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                _dbAccess.Connect();
                int filas = _dbAccess.ExecuteNonQuery(query, paramRol, paramPermiso);

                return filas > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al remover permiso del rol");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

    }
}