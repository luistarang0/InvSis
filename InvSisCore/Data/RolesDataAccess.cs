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
    public class RolesDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.RolesDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public RolesDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar RolesDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo rol en la base de datos
        /// </summary>
        /// <param name="rol">Objeto Rol con la información a insertar</param>
        /// <returns>ID del rol insertado o -1 en caso de error</returns>
        public int InsertarRol(Rol rol)
        {
            try
            {
                string query = "INSERT INTO Roles (nombre_rol, estatus) " +
                              "VALUES (@NombreRol, @Estatus) " +
                              "RETURNING id_rol";

                // Crea parámetros para la consulta
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreRol", rol.NombreRol);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", rol.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramEstatus);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Rol insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el rol {rol.NombreRol}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza un rol existente en la base de datos
        /// </summary>
        /// <param name="rol">Objeto Rol con la información actualizada</param>
        /// <returns>True si se actualizó correctamente, False en caso contrario</returns>
        public bool ActualizarRol(Rol rol)
        {
            try
            {
                string query = "UPDATE Roles " +
                              "SET nombre_rol = @NombreRol, " +
                              "    estatus = @Estatus " +
                              "WHERE id_rol = @IdRol";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdRol", rol.IdRol);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreRol", rol.NombreRol);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", rol.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Rol con ID {rol.IdRol} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el rol con ID {rol.IdRol}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el rol con ID {rol.IdRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina lógicamente un rol cambiando su estatus a inactivo (2)
        /// </summary>
        /// <param name="idRol">ID del rol a eliminar</param>
        /// <returns>True si se eliminó correctamente, False en caso contrario</returns>
        public bool EliminarRol(int idRol)
        {
            try
            {
                string query = "UPDATE Roles SET estatus = 2 WHERE id_rol = @IdRol";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdRol", idRol);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Rol con ID {idRol} desactivado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo desactivar el rol con ID {idRol}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al desactivar el rol con ID {idRol}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un rol con el nombre especificado
        /// </summary>
        /// <param name="nombreRol">Nombre del rol a verificar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool ExisteNombreRol(string nombreRol)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Roles WHERE nombre_rol = @NombreRol";
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreRol", nombreRol);

                _dbAccess.Connect();

                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre);
                int count = Convert.ToInt32(resultado);

                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del rol: {nombreRol}");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un rol por su ID
        /// </summary>
        /// <param name="idRol">ID del rol a buscar</param>
        /// <returns>Objeto Rol si se encuentra, null si no existe</returns>
        public Rol? ObtenerRolPorId(int idRol)
        {
            try
            {
                string query = @"
                    SELECT id_rol, nombre_rol, estatus
                    FROM Roles
                    WHERE id_rol = @IdRol";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdRol", idRol);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta con el parámetro
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún rol con ID {idRol}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear el objeto Rol
                Rol rol = new Rol(
                    Convert.ToInt32(row["id_rol"]),
                    row["nombre_rol"].ToString() ?? "",
                    Convert.ToInt32(row["estatus"])
                );

                return rol;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el rol con ID {idRol}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los roles de la base de datos
        /// </summary>
        /// <param name="soloActivos">Indica si solo se deben obtener los roles activos</param>
        /// <returns>Lista de objetos Rol</returns>
        public List<Rol> ObtenerTodosLosRoles(bool soloActivos = true)
        {
            List<Rol> roles = new List<Rol>();

            try
            {
                string query = @"
                    SELECT id_rol, nombre_rol, estatus
                    FROM Roles
                    WHERE 1=1";

                // Si solo se quieren los activos, añade la condición
                if (soloActivos)
                {
                    query += " AND estatus = 1";
                }

                // Ordena por nombre
                query += " ORDER BY nombre_rol";

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
                        Convert.ToInt32(row["estatus"])
                    );

                    roles.Add(rol);
                }

                _logger.Info($"Se obtuvieron {roles.Count} roles de la base de datos");
                return roles;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener los roles de la base de datos");
                return roles; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        public bool AsignarPermisoARol(int idRol, int idPermiso)
        {
            try
            {
                string query = "INSERT INTO Roles_Permisos (id_rol, id_permiso) VALUES (@IdRol, @IdPermiso)";

                var paramRol = _dbAccess.CreateParameter("@IdRol", idRol);
                var paramPermiso = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                _dbAccess.Connect();
                int filas = _dbAccess.ExecuteNonQuery(query, paramRol, paramPermiso);

                return filas > 0;
            }
            catch (PostgresException ex) when (ex.SqlState == "23505") // Unique violation
            {
                _logger.Warn($"Permiso ya asignado al rol: {idRol}-{idPermiso}");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al asignar permiso al rol");
                return false;
            }
            finally
            {
                _dbAccess.Disconnect();
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