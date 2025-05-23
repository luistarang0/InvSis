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
    public class OperadoresDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.OperadoresDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly PersonasDataAccess _personasDataAccess;

        public OperadoresDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _personasDataAccess = new PersonasDataAccess();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar OperadoresDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo operador en la base de datos
        /// </summary>
        /// <param name="operador">Objeto Operador con la información a insertar</param>
        /// <returns>El ID generado si fue exitoso, -1 en caso de error</returns>
        public int InsertarOperador(Operador operador)
        {
            try
            {
                string query = "INSERT INTO Operadores (id_persona, puesto, estatus) " +
                              "VALUES (@IdPersona, @Puesto, @Estatus) " +
                              "RETURNING id_operador";

                // Crea parámetros para la consulta
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", operador.IdPersona);
                NpgsqlParameter paramPuesto = _dbAccess.CreateParameter("@Puesto", operador.Puesto);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", operador.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdPersona, paramPuesto, paramEstatus);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Operador insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el operador con IdPersona {operador.IdPersona}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza los datos de un operador existente
        /// </summary>
        /// <param name="operador">Objeto Operador con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarOperador(Operador operador)
        {
            try
            {
                string query = "UPDATE Operadores " +
                              "SET id_persona = @IdPersona, " +
                              "    puesto = @Puesto, " +
                              "    estatus = @Estatus " +
                              "WHERE id_operador = @IdOperador";

                // Crea los parámetros
                NpgsqlParameter paramIdOperador = _dbAccess.CreateParameter("@IdOperador", operador.IdOperador);
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", operador.IdPersona);
                NpgsqlParameter paramPuesto = _dbAccess.CreateParameter("@Puesto", operador.Puesto);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", operador.Estatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdOperador, paramIdPersona,
                                                             paramPuesto, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Operador con ID {operador.IdOperador} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el operador con ID {operador.IdOperador}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el operador con ID {operador.IdOperador}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un operador de la base de datos
        /// </summary>
        /// <param name="idOperador">ID del operador a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarOperador(int idOperador)
        {
            try
            {
                string query = "DELETE FROM Operadores WHERE id_operador = @IdOperador";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdOperador", idOperador);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Operador con ID {idOperador} eliminado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el operador con ID {idOperador}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el operador con ID {idOperador}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un operador por su ID, incluyendo los datos de la persona asociada
        /// </summary>
        /// <param name="idOperador">ID del operador a buscar</param>
        /// <returns>Objeto Operador si se encuentra, null si no existe</returns>
        public Operador? ObtenerOperadorPorId(int idOperador)
        {
            try
            {
                string query = "SELECT id_operador, id_persona, puesto, estatus " +
                              "FROM Operadores WHERE id_operador = @IdOperador";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdOperador", idOperador);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún operador con ID {idOperador}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear objeto Operador
                Operador operador = new Operador(
                    Convert.ToInt32(row["id_operador"]),
                    Convert.ToInt32(row["id_persona"]),
                    row["puesto"].ToString() ?? "",
                    Convert.ToInt32(row["estatus"])
                );

                // Obtener datos de la persona asociada
                Persona? persona = _personasDataAccess.ObtenerPersonaPorId(operador.IdPersona);
                if (persona != null)
                {
                    operador.Persona = persona;
                }

                return operador;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el operador con ID {idOperador}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los operadores de la base de datos, incluyendo los datos de personas
        /// </summary>
        /// <returns>Lista de objetos Operador</returns>
        public List<Operador> ObtenerTodosLosOperadores()
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                string query = "SELECT id_operador, id_persona, puesto, estatus FROM Operadores";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Operador operador = new Operador(
                        Convert.ToInt32(row["id_operador"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["puesto"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    );

                    // Obtener datos de la persona asociada
                    Persona? persona = _personasDataAccess.ObtenerPersonaPorId(operador.IdPersona);
                    if (persona != null)
                    {
                        operador.Persona = persona;
                    }

                    operadores.Add(operador);
                }

                _logger.Info($"Se obtuvieron {operadores.Count} operadores de la base de datos");
                return operadores;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los operadores");
                return operadores; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene los operadores con estatus activo (1)
        /// </summary>
        /// <returns>Lista de operadores activos</returns>
        public List<Operador> ObtenerOperadoresActivos()
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                string query = "SELECT id_operador, id_persona, puesto, estatus " +
                               "FROM Operadores WHERE estatus = 1";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Operador operador = new Operador(
                        Convert.ToInt32(row["id_operador"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["puesto"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    );

                    // Obtener datos de la persona asociada
                    Persona? persona = _personasDataAccess.ObtenerPersonaPorId(operador.IdPersona);
                    if (persona != null)
                    {
                        operador.Persona = persona;
                    }

                    operadores.Add(operador);
                }

                _logger.Info($"Se obtuvieron {operadores.Count} operadores activos");
                return operadores;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener operadores activos");
                return operadores; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Busca operadores por puesto (búsqueda parcial)
        /// </summary>
        /// <param name="puestoBusqueda">Texto a buscar en el puesto</param>
        /// <returns>Lista de operadores que coinciden con la búsqueda</returns>
        public List<Operador> BuscarOperadoresPorPuesto(string puestoBusqueda)
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                string query = "SELECT id_operador, id_persona, puesto, estatus " +
                              "FROM Operadores WHERE puesto ILIKE @PuestoBusqueda";

                // Crea el parámetro (con comodines para búsqueda parcial)
                NpgsqlParameter paramPuesto = _dbAccess.CreateParameter("@PuestoBusqueda", $"%{puestoBusqueda}%");

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramPuesto);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Operador operador = new Operador(
                        Convert.ToInt32(row["id_operador"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["puesto"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    );

                    // Obtener datos de la persona asociada
                    Persona? persona = _personasDataAccess.ObtenerPersonaPorId(operador.IdPersona);
                    if (persona != null)
                    {
                        operador.Persona = persona;
                    }

                    operadores.Add(operador);
                }

                _logger.Info($"Se encontraron {operadores.Count} operadores con el puesto '{puestoBusqueda}'");
                return operadores;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al buscar operadores con el puesto '{puestoBusqueda}'");
                return operadores; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene operadores por ID de persona
        /// </summary>
        /// <param name="idPersona">ID de la persona asociada</param>
        /// <returns>Lista de operadores asociados a la persona</returns>
        public List<Operador> ObtenerOperadoresPorIdPersona(int idPersona)
        {
            List<Operador> operadores = new List<Operador>();

            try
            {
                string query = "SELECT id_operador, id_persona, puesto, estatus " +
                               "FROM Operadores WHERE id_persona = @IdPersona";

                // Crea el parámetro
                NpgsqlParameter paramIdPersona = _dbAccess.CreateParameter("@IdPersona", idPersona);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdPersona);

                // Obtener la persona una sola vez
                Persona? persona = _personasDataAccess.ObtenerPersonaPorId(idPersona);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Operador operador = new Operador(
                        Convert.ToInt32(row["id_operador"]),
                        Convert.ToInt32(row["id_persona"]),
                        row["puesto"].ToString() ?? "",
                        Convert.ToInt32(row["estatus"])
                    );

                    // Asignar la persona si existe
                    if (persona != null)
                    {
                        operador.Persona = persona;
                    }

                    operadores.Add(operador);
                }

                _logger.Info($"Se encontraron {operadores.Count} operadores para la persona con ID {idPersona}");
                return operadores;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener operadores para la persona con ID {idPersona}");
                return operadores; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Cambia el estatus de un operador
        /// </summary>
        /// <param name="idOperador">ID del operador</param>
        /// <param name="nuevoEstatus">Nuevo valor de estatus (1=activo, 2=inactivo)</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool CambiarEstatusOperador(int idOperador, int nuevoEstatus)
        {
            try
            {
                string query = "UPDATE Operadores SET estatus = @Estatus WHERE id_operador = @IdOperador";

                // Crea los parámetros
                NpgsqlParameter paramIdOperador = _dbAccess.CreateParameter("@IdOperador", idOperador);
                NpgsqlParameter paramEstatus = _dbAccess.CreateParameter("@Estatus", nuevoEstatus);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdOperador, paramEstatus);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Operador con ID {idOperador} cambió su estatus a {nuevoEstatus}");
                }
                else
                {
                    _logger.Warn($"No se pudo cambiar el estatus del operador con ID {idOperador}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al cambiar el estatus del operador con ID {idOperador}");
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