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
    public class MovimientosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.MovimientosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly OperadoresDataAccess _operadoresDataAccess;

        public MovimientosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _operadoresDataAccess = new OperadoresDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar MovimientosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo movimiento en la base de datos
        /// </summary>
        /// <param name="movimiento">Objeto Movimiento con la información a insertar</param>
        /// <returns>El ID generado si fue exitoso, -1 en caso de error</returns>
        public int InsertarMovimiento(Movimiento movimiento)
        {
            try
            {
                string query = "INSERT INTO Movimientos (tipo, estatus, fecha, id_operador) " +
                              "VALUES (@Tipo, @Estatus, @Fecha, @IdOperador) " +
                              "RETURNING id_movimiento";

                // Crea parámetros para la consulta
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@Tipo", movimiento.Tipo);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", movimiento.Estatus);
                NpgsqlParameter paramFecha = _dbAccess.CreateParameter("@Fecha", movimiento.Fecha);
                NpgsqlParameter paramIdOperador = _dbAccess.CreateParameter("@IdOperador", movimiento.IdOperador);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramTipo, paramEstatus, paramFecha, paramIdOperador);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Movimiento insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el movimiento de tipo {movimiento.Tipo}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza los datos de un movimiento existente
        /// </summary>
        /// <param name="movimiento">Objeto Movimiento con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarMovimiento(Movimiento movimiento)
        {
            try
            {
                string query = "UPDATE Movimientos " +
                              "SET tipo = @Tipo, " +
                              "    estatus = @Estatus, " +
                              "    fecha = @Fecha, " +
                              "    id_operador = @IdOperador " +
                              "WHERE id_movimiento = @IdMovimiento";

                // Crea los parámetros
                NpgsqlParameter paramIdMovimiento = _dbAccess.CreateParameter("@IdMovimiento", movimiento.IdMovimiento);
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@Tipo", movimiento.Tipo);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", movimiento.Estatus);
                NpgsqlParameter paramFecha = _dbAccess.CreateParameter("@Fecha", movimiento.Fecha);
                NpgsqlParameter paramIdOperador = _dbAccess.CreateParameter("@IdOperador", movimiento.IdOperador);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdMovimiento, paramTipo,
                                                             paramEstatus, paramFecha, paramIdOperador);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento con ID {movimiento.IdMovimiento} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el movimiento con ID {movimiento.IdMovimiento}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el movimiento con ID {movimiento.IdMovimiento}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un movimiento de la base de datos
        /// </summary>
        /// <param name="idMovimiento">ID del movimiento a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarMovimiento(int idMovimiento)
        {
            try
            {
                string query = "DELETE FROM Movimientos WHERE id_movimiento = @IdMovimiento";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdMovimiento", idMovimiento);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento con ID {idMovimiento} eliminado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el movimiento con ID {idMovimiento}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el movimiento con ID {idMovimiento}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un movimiento por su ID, incluyendo los datos del operador asociado
        /// </summary>
        /// <param name="idMovimiento">ID del movimiento a buscar</param>
        /// <returns>Objeto Movimiento si se encuentra, null si no existe</returns>
        public Movimiento? ObtenerMovimientoPorId(int idMovimiento)
        {
            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador " +
                              "FROM Movimientos WHERE id_movimiento = @IdMovimiento";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdMovimiento", idMovimiento);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún movimiento con ID {idMovimiento}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear objeto Movimiento
                Movimiento movimiento = new Movimiento(
                    Convert.ToInt32(row["id_movimiento"]),
                    row["tipo"].ToString() ?? "",
                    Convert.ToInt32(row["estatus"]),
                    Convert.ToDateTime(row["fecha"]),
                    Convert.ToInt32(row["id_operador"])
                );

                // Obtener datos del operador asociado
                Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(movimiento.IdOperador);
                if (operador != null)
                {
                    movimiento.Operador = operador;
                }

                return movimiento;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el movimiento con ID {idMovimiento}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los movimientos de la base de datos, incluyendo los datos de operadores
        /// </summary>
        /// <returns>Lista de objetos Movimiento</returns>
        public List<Movimiento> ObtenerTodosLosMovimientos()
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador FROM Movimientos";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Movimiento movimiento = new Movimiento(
                        Convert.ToInt32(row["id_movimiento"]),
                        row["tipo"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"]),
                        Convert.ToDateTime(row["fecha"]),
                        Convert.ToInt32(row["id_operador"])
                    );

                    // Obtener datos del operador asociado
                    Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(movimiento.IdOperador);
                    if (operador != null)
                    {
                        movimiento.Operador = operador;
                    }

                    movimientos.Add(movimiento);
                }

                _logger.Info($"Se obtuvieron {movimientos.Count} movimientos de la base de datos");
                return movimientos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los movimientos");
                return movimientos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene los movimientos con un estatus específico
        /// </summary>
        /// <param name="estatus">Estatus de los movimientos a buscar</param>
        /// <returns>Lista de movimientos con el estatus especificado</returns>
        public List<Movimiento> ObtenerMovimientosPorEstatus(int estatus)
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador " +
                               "FROM Movimientos WHERE estatus = @Estatus";

                // Crea el parámetro
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramEstatus);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Movimiento movimiento = new Movimiento(
                        Convert.ToInt32(row["id_movimiento"]),
                        row["tipo"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"]),
                        Convert.ToDateTime(row["fecha"]),
                        Convert.ToInt32(row["id_operador"])
                    );

                    // Obtener datos del operador asociado
                    Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(movimiento.IdOperador);
                    if (operador != null)
                    {
                        movimiento.Operador = operador;
                    }

                    movimientos.Add(movimiento);
                }

                _logger.Info($"Se obtuvieron {movimientos.Count} movimientos con estatus {estatus}");
                return movimientos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos con estatus {estatus}");
                return movimientos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene movimientos por tipo (búsqueda exacta)
        /// </summary>
        /// <param name="tipo">Tipo de movimiento a buscar</param>
        /// <returns>Lista de movimientos del tipo especificado</returns>
        public List<Movimiento> ObtenerMovimientosPorTipo(string tipo)
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador " +
                              "FROM Movimientos WHERE tipo = @Tipo";

                // Crea el parámetro
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@Tipo", tipo);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramTipo);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Movimiento movimiento = new Movimiento(
                        Convert.ToInt32(row["id_movimiento"]),
                        row["tipo"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"]),
                        Convert.ToDateTime(row["fecha"]),
                        Convert.ToInt32(row["id_operador"])
                    );

                    // Obtener datos del operador asociado
                    Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(movimiento.IdOperador);
                    if (operador != null)
                    {
                        movimiento.Operador = operador;
                    }

                    movimientos.Add(movimiento);
                }

                _logger.Info($"Se encontraron {movimientos.Count} movimientos del tipo '{tipo}'");
                return movimientos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al buscar movimientos del tipo '{tipo}'");
                return movimientos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene movimientos realizados por un operador específico
        /// </summary>
        /// <param name="idOperador">ID del operador</param>
        /// <returns>Lista de movimientos asociados al operador</returns>
        public List<Movimiento> ObtenerMovimientosPorOperador(int idOperador)
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador " +
                               "FROM Movimientos WHERE id_operador = @IdOperador";

                // Crea el parámetro
                NpgsqlParameter paramIdOperador = _dbAccess.CreateParameter("@IdOperador", idOperador);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdOperador);

                // Obtener el operador una sola vez
                Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(idOperador);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Movimiento movimiento = new Movimiento(
                        Convert.ToInt32(row["id_movimiento"]),
                        row["tipo"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"]),
                        Convert.ToDateTime(row["fecha"]),
                        Convert.ToInt32(row["id_operador"])
                    );

                    // Asignar el operador si existe
                    if (operador != null)
                    {
                        movimiento.Operador = operador;
                    }

                    movimientos.Add(movimiento);
                }

                _logger.Info($"Se encontraron {movimientos.Count} movimientos para el operador con ID {idOperador}");
                return movimientos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos para el operador con ID {idOperador}");
                return movimientos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene movimientos realizados en un rango de fechas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango</param>
        /// <param name="fechaFin">Fecha de fin del rango</param>
        /// <returns>Lista de movimientos realizados en el rango de fechas</returns>
        public List<Movimiento> ObtenerMovimientosPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Movimiento> movimientos = new List<Movimiento>();

            try
            {
                string query = "SELECT id_movimiento, tipo, estatus, fecha, id_operador " +
                              "FROM Movimientos WHERE fecha BETWEEN @FechaInicio AND @FechaFin";

                // Crea los parámetros
                NpgsqlParameter paramFechaInicio = _dbAccess.CreateParameter("@FechaInicio", fechaInicio);
                NpgsqlParameter paramFechaFin = _dbAccess.CreateParameter("@FechaFin", fechaFin);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramFechaInicio, paramFechaFin);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Movimiento movimiento = new Movimiento(
                        Convert.ToInt32(row["id_movimiento"]),
                        row["tipo"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"]),
                        Convert.ToDateTime(row["fecha"]),
                        Convert.ToInt32(row["id_operador"])
                    );

                    // Obtener datos del operador asociado
                    Operador? operador = _operadoresDataAccess.ObtenerOperadorPorId(movimiento.IdOperador);
                    if (operador != null)
                    {
                        movimiento.Operador = operador;
                    }

                    movimientos.Add(movimiento);
                }

                _logger.Info($"Se encontraron {movimientos.Count} movimientos entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()}");
                return movimientos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos por rango de fechas");
                return movimientos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Cambia el estatus de un movimiento
        /// </summary>
        /// <param name="idMovimiento">ID del movimiento</param>
        /// <param name="nuevoEstatus">Nuevo valor de estatus</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool CambiarEstatusMovimiento(int idMovimiento, int nuevoEstatus)
        {
            try
            {
                string query = "UPDATE Movimientos SET estatus = @Estatus WHERE id_movimiento = @IdMovimiento";

                // Crea los parámetros
                NpgsqlParameter paramIdMovimiento = _dbAccess.CreateParameter("@IdMovimiento", idMovimiento);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", nuevoEstatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdMovimiento, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento con ID {idMovimiento} cambió su estatus a {nuevoEstatus}");
                }
                else
                {
                    _logger.Warn($"No se pudo cambiar el estatus del movimiento con ID {idMovimiento}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al cambiar el estatus del movimiento con ID {idMovimiento}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }
    }
}