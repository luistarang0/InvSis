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
    public class PermisosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.PermisosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public PermisosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar PermisosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo permiso en la base de datos
        /// </summary>
        /// <param name="permiso">Objeto Permiso con la información a insertar</param>
        /// <returns>ID del permiso insertado o -1 si ocurre un error</returns>
        public int InsertarPermiso(Permiso permiso)
        {
            try
            {
                string query = "INSERT INTO Permisos (descripcion, estatus) " +
                              "VALUES (@Descripcion, @Estatus) " +
                              "RETURNING id_permiso";

                // Crea parámetros para la consulta
                NpgsqlParameter paramDescripcion = _dbAccess.CreateParameter("@Descripcion", permiso.Descripcion);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", permiso.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramDescripcion, paramEstatus);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Permiso insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el permiso {permiso.Descripcion}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza un permiso existente en la base de datos
        /// </summary>
        /// <param name="permiso">Objeto Permiso con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarPermiso(Permiso permiso)
        {
            try
            {
                string query = "UPDATE Permisos " +
                              "SET descripcion = @Descripcion, " +
                              "    estatus = @Estatus " +
                              "WHERE id_permiso = @IdPermiso";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPermiso", permiso.IdPermiso);
                NpgsqlParameter paramDescripcion = _dbAccess.CreateParameter("@Descripcion", permiso.Descripcion);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", permiso.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramDescripcion, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Permiso con ID {permiso.IdPermiso} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el permiso con ID {permiso.IdPermiso}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el permiso con ID {permiso.IdPermiso}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina lógicamente un permiso cambiando su estatus a inactivo (2)
        /// </summary>
        /// <param name="idPermiso">ID del permiso a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarPermiso(int idPermiso)
        {
            try
            {
                string query = "UPDATE Permisos SET estatus = 2 WHERE id_permiso = @IdPermiso";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Permiso con ID {idPermiso} eliminado lógicamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el permiso con ID {idPermiso}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el permiso con ID {idPermiso}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un permiso por su ID
        /// </summary>
        /// <param name="idPermiso">ID del permiso a buscar</param>
        /// <returns>Objeto Permiso si se encuentra, null si no existe</returns>
        public Permiso? ObtenerPermisoPorId(int idPermiso)
        {
            try
            {
                string query = "SELECT id_permiso, descripcion, estatus FROM Permisos WHERE id_permiso = @IdPermiso";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPermiso", idPermiso);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún permiso con ID {idPermiso}");
                    return null;
                }

                // Obtiene la primera fila
                DataRow row = resultado.Rows[0];

                // Crea el objeto Permiso
                Permiso permiso = new Permiso(
                    Convert.ToInt32(row["id_permiso"]),
                    row["descripcion"].ToString() ?? "",
                    Convert.ToInt32(row["estatus"])
                );

                return permiso;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el permiso con ID {idPermiso}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los permisos registrados en la base de datos
        /// </summary>
        /// <param name="soloActivos">Indica si solo se deben retornar los permisos activos</param>
        /// <returns>Lista de permisos</returns>
        public List<Permiso> ObtenerTodosLosPermisos(bool soloActivos = true)
        {
            List<Permiso> permisos = new List<Permiso>();

            try
            {
                string query = "SELECT id_permiso, descripcion, estatus FROM Permisos";

                if (soloActivos)
                {
                    query += " WHERE estatus = 1";
                }

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa los resultados
                foreach (DataRow row in resultado.Rows)
                {
                    Permiso permiso = new Permiso(
                        Convert.ToInt32(row["id_permiso"]),
                        row["descripcion"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    );

                    permisos.Add(permiso);
                }

                _logger.Info($"Se obtuvieron {permisos.Count} permisos de la base de datos");
                return permisos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener los permisos de la base de datos");
                return permisos; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un permiso con la descripción proporcionada
        /// </summary>
        /// <param name="descripcion">Descripción a verificar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool ExistePermisoPorDescripcion(string descripcion)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Permisos WHERE descripcion = @Descripcion";

                // Crea el parámetro
                NpgsqlParameter paramDescripcion = _dbAccess.CreateParameter("@Descripcion", descripcion);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramDescripcion);

                int cantidad = Convert.ToInt32(resultado);
                bool existe = cantidad > 0;

                return existe;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del permiso con descripción '{descripcion}'");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        public Permiso? ObtenerPermisoPorDescripcion(string descripcion)
        {
            try
            {
                string query = "SELECT id_permiso, descripcion, estatus FROM Permisos WHERE descripcion = @Descripcion";

                var paramDescripcion = _dbAccess.CreateParameter("@Descripcion", descripcion);

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramDescripcion);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Info($"No se encontró ningún permiso con la descripción '{descripcion}'.");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                return new Permiso(
                    Convert.ToInt32(row["id_permiso"]),
                    row["descripcion"].ToString() ?? "",
                    Convert.ToInt32(row["estatus"])
                );
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el permiso con descripción '{descripcion}'");
                return null;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        public int ObtenerUltimoIdPermiso()
        {
            try
            {
                string query = "SELECT COALESCE(MAX(id_permiso), 0) FROM Permisos";

                _dbAccess.Connect();
                object? resultado = _dbAccess.ExecuteScalar(query);

                return Convert.ToInt32(resultado);
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener el último ID de permiso");
                return 0;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }



    }
}