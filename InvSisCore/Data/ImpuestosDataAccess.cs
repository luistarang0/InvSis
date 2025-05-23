using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InvSis.Model;
using InvSis.Utilities;

namespace InvSis.Data
{
    public class ImpuestosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.ImpuestosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;

        public ImpuestosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar ImpuestosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo impuesto en la base de datos
        /// </summary>
        /// <param name="impuesto">Objeto impuesto a insertar</param>
        /// <returns>ID del impuesto generado o -1 en caso de error</returns>
        public int InsertarImpuesto(Impuesto impuesto)
        {
            try
            {
                string query = "INSERT INTO Impuestos (tipo_impuesto, cantidad_impuesto) " +
                              "VALUES (@TipoImpuesto, @CantidadImpuesto) " +
                              "RETURNING id_impuesto";

                // Crea parámetros para la consulta
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@TipoImpuesto", impuesto.TipoImpuesto);
                NpgsqlParameter paramCantidad = _dbAccess.CreateParameter("@CantidadImpuesto", impuesto.CantidadImpuesto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramTipo, paramCantidad);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Impuesto insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el impuesto {impuesto.TipoImpuesto}");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza un impuesto existente en la base de datos
        /// </summary>
        /// <param name="impuesto">Objeto impuesto con los datos actualizados</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarImpuesto(Impuesto impuesto)
        {
            try
            {
                string query = "UPDATE Impuestos " +
                              "SET tipo_impuesto = @TipoImpuesto, " +
                              "    cantidad_impuesto = @CantidadImpuesto " +
                              "WHERE id_impuesto = @IdImpuesto";

                // Crea los parámetros
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdImpuesto", impuesto.IdImpuesto);
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@TipoImpuesto", impuesto.TipoImpuesto);
                NpgsqlParameter paramCantidad = _dbAccess.CreateParameter("@CantidadImpuesto", impuesto.CantidadImpuesto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId, paramTipo, paramCantidad);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Impuesto con ID {impuesto.IdImpuesto} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el impuesto con ID {impuesto.IdImpuesto}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el impuesto con ID {impuesto.IdImpuesto}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un impuesto de la base de datos
        /// </summary>
        /// <param name="idImpuesto">ID del impuesto a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarImpuesto(int idImpuesto)
        {
            try
            {
                string query = "DELETE FROM Impuestos WHERE id_impuesto = @IdImpuesto";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdImpuesto", idImpuesto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Impuesto con ID {idImpuesto} eliminado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el impuesto con ID {idImpuesto}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el impuesto con ID {idImpuesto}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un impuesto por su ID
        /// </summary>
        /// <param name="idImpuesto">ID del impuesto a buscar</param>
        /// <returns>Objeto Impuesto si se encuentra, null si no existe</returns>
        public Impuesto? ObtenerImpuestoPorId(int idImpuesto)
        {
            try
            {
                string query = "SELECT id_impuesto, tipo_impuesto, cantidad_impuesto " +
                              "FROM Impuestos " +
                              "WHERE id_impuesto = @IdImpuesto";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdImpuesto", idImpuesto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún impuesto con ID {idImpuesto}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear el objeto Impuesto
                Impuesto impuesto = new Impuesto(
                    Convert.ToInt32(row["id_impuesto"]),
                    row["tipo_impuesto"].ToString() ?? "",
                    Convert.ToDecimal(row["cantidad_impuesto"])
                );

                return impuesto;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el impuesto con ID {idImpuesto}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los impuestos de la base de datos
        /// </summary>
        /// <returns>Lista de impuestos</returns>
        public List<Impuesto> ObtenerTodosLosImpuestos()
        {
            List<Impuesto> impuestos = new List<Impuesto>();

            try
            {
                string query = "SELECT id_impuesto, tipo_impuesto, cantidad_impuesto FROM Impuestos";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa los resultados
                foreach (DataRow row in resultado.Rows)
                {
                    Impuesto impuesto = new Impuesto(
                        Convert.ToInt32(row["id_impuesto"]),
                        row["tipo_impuesto"].ToString() ?? "",
                        Convert.ToDecimal(row["cantidad_impuesto"])
                    );

                    impuestos.Add(impuesto);
                }

                _logger.Info($"Se obtuvieron {impuestos.Count} impuestos de la base de datos");
                return impuestos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los impuestos");
                return impuestos; // Retorna lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un tipo de impuesto en la base de datos
        /// </summary>
        /// <param name="tipoImpuesto">Tipo de impuesto a verificar</param>
        /// <returns>True si existe, False si no existe</returns>
        public bool ExisteTipoImpuesto(string tipoImpuesto)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Impuestos WHERE tipo_impuesto = @TipoImpuesto";

                // Crea el parámetro
                NpgsqlParameter paramTipo = _dbAccess.CreateParameter("@TipoImpuesto", tipoImpuesto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramTipo);

                int count = Convert.ToInt32(resultado);
                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del tipo de impuesto: {tipoImpuesto}");
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