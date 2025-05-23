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
    public class PersonasDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.PersonasDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public PersonasDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar PersonasDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta una nueva persona en la base de datos
        /// </summary>
        /// <param name="persona">Objeto Persona con la información a insertar</param>
        /// <returns>El ID generado si fue exitoso, -1 en caso de error</returns>
        public int InsertarPersona(Persona persona)
        {
            try
            {
                string query = "INSERT INTO Personas (nombre_completo, edad, sexo, nacionalidad) " +
                              "VALUES (@NombreCompleto, @Edad, @Sexo, @Nacionalidad) " +
                              "RETURNING id_persona";

                // Crea parámetros para la consulta
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramEdad = _dbAccess.CreateParameter("@Edad", persona.Edad ?? (object)DBNull.Value);
                NpgsqlParameter paramSexo = _dbAccess.CreateParameter("@Sexo", persona.Sexo);
                NpgsqlParameter paramNacionalidad = _dbAccess.CreateParameter("@Nacionalidad", persona.Nacionalidad);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramNombre, paramEdad, paramSexo, paramNacionalidad);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Persona insertada correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar la persona {persona.NombreCompleto}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza los datos de una persona existente
        /// </summary>
        /// <param name="persona">Objeto Persona con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarPersona(Persona persona)
        {
            try
            {
                string query = "UPDATE Personas " +
                              "SET nombre_completo = @NombreCompleto, " +
                              "    edad = @Edad, " +
                              "    sexo = @Sexo, " +
                              "    nacionalidad = @Nacionalidad " +
                              "WHERE id_persona = @IdPersona";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPersona", persona.IdPersona);
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreCompleto", persona.NombreCompleto);
                NpgsqlParameter paramEdad = _dbAccess.CreateParameter("@Edad", persona.Edad ?? (object)DBNull.Value);
                NpgsqlParameter paramSexo = _dbAccess.CreateParameter("@Sexo", persona.Sexo);
                NpgsqlParameter paramNacionalidad = _dbAccess.CreateParameter("@Nacionalidad", persona.Nacionalidad);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramNombre, paramEdad,
                                                             paramSexo, paramNacionalidad);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona con ID {persona.IdPersona} actualizada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar la persona con ID {persona.IdPersona}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar la persona con ID {persona.IdPersona}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina una persona de la base de datos
        /// </summary>
        /// <param name="idPersona">ID de la persona a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarPersona(int idPersona)
        {
            try
            {
                string query = "DELETE FROM Personas WHERE id_persona = @IdPersona";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPersona", idPersona);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Persona con ID {idPersona} eliminada correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar la persona con ID {idPersona}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar la persona con ID {idPersona}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene una persona por su ID
        /// </summary>
        /// <param name="idPersona">ID de la persona a buscar</param>
        /// <returns>Objeto Persona si se encuentra, null si no existe</returns>
        public Persona? ObtenerPersonaPorId(int idPersona)
        {
            try
            {
                string query = "SELECT id_persona, nombre_completo, edad, sexo, nacionalidad " +
                              "FROM Personas WHERE id_persona = @IdPersona";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdPersona", idPersona);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ninguna persona con ID {idPersona}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear y devolver el objeto Persona
                return new Persona(
                    Convert.ToInt32(row["id_persona"]),
                    row["nombre_completo"].ToString() ?? "",
                    row["edad"] != DBNull.Value ? (int?)Convert.ToInt32(row["edad"]) : null,
                    row["sexo"].ToString() ?? "",
                    row["nacionalidad"].ToString() ?? ""
                );
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener la persona con ID {idPersona}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todas las personas de la base de datos
        /// </summary>
        /// <returns>Lista de objetos Persona</returns>
        public List<Persona> ObtenerTodasLasPersonas()
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                string query = "SELECT id_persona, nombre_completo, edad, sexo, nacionalidad FROM Personas";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Persona persona = new Persona(
                        Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["edad"] != DBNull.Value ? (int?)Convert.ToInt32(row["edad"]) : null,
                        row["sexo"].ToString() ?? "",
                        row["nacionalidad"].ToString() ?? ""
                    );

                    personas.Add(persona);
                }

                _logger.Info($"Se obtuvieron {personas.Count} personas de la base de datos");
                return personas;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todas las personas");
                return personas; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Busca personas por nombre completo (búsqueda parcial)
        /// </summary>
        /// <param name="nombreBusqueda">Texto a buscar en el nombre</param>
        /// <returns>Lista de personas que coinciden con la búsqueda</returns>
        public List<Persona> BuscarPersonasPorNombre(string nombreBusqueda)
        {
            List<Persona> personas = new List<Persona>();

            try
            {
                string query = "SELECT id_persona, nombre_completo, edad, sexo, nacionalidad " +
                              "FROM Personas WHERE nombre_completo ILIKE @NombreBusqueda";

                // Crea el parámetro (con comodines para búsqueda parcial)
                NpgsqlParameter paramNombre = _dbAccess.CreateParameter("@NombreBusqueda", $"%{nombreBusqueda}%");

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramNombre);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    Persona persona = new Persona(
                        Convert.ToInt32(row["id_persona"]),
                        row["nombre_completo"].ToString() ?? "",
                        row["edad"] != DBNull.Value ? (int?)Convert.ToInt32(row["edad"]) : null,
                        row["sexo"].ToString() ?? "",
                        row["nacionalidad"].ToString() ?? ""
                    );

                    personas.Add(persona);
                }

                _logger.Info($"Se encontraron {personas.Count} personas con el nombre '{nombreBusqueda}'");
                return personas;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al buscar personas con el nombre '{nombreBusqueda}'");
                return personas; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }
    }
}