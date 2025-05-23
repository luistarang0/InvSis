using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InvSis.Model;
using InvSis.Utilities;

namespace InvSis.Data
{
    public class BitacoraDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.BitacoraDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly MovimientoProductoDataAccess _movimientoProductoDataAccess;
        private readonly UsuariosDataAccess _usuariosDataAccess;

        public BitacoraDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _movimientoProductoDataAccess = new MovimientoProductoDataAccess();
                _usuariosDataAccess = new UsuariosDataAccess();
                _logger.Info("BitacoraDataAccess inicializado correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar BitacoraDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo registro en la bitácora
        /// </summary>
        /// <param name="bitacora">Objeto Bitacora con la información a registrar</param>
        /// <returns>El ID generado para el registro si fue exitoso, -1 en caso de error</returns>
        public int InsertarRegistroBitacora(Bitacora bitacora)
        {
            try
            {
                // Validaciones básicas
                if (bitacora == null)
                {
                    _logger.Error("El objeto bitácora no puede ser nulo");
                    return -1;
                }

                if (string.IsNullOrEmpty(bitacora.IdEquipo))
                {
                    _logger.Error("El ID del equipo no puede estar vacío");
                    return -1;
                }

                if (string.IsNullOrEmpty(bitacora.TipoMovimiento))
                {
                    _logger.Error("El tipo de movimiento no puede estar vacío");
                    return -1;
                }

                // Verificar existencia de relaciones si se proporcionan
                if (bitacora.IdMovimientoProducto.HasValue)
                {
                    var movimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value);
                    if (movimientoProducto == null)
                    {
                        _logger.Warn($"No existe el movimiento producto con ID {bitacora.IdMovimientoProducto.Value}");
                        // No detenemos la inserción, sólo se registra la advertencia
                    }
                }

                if (bitacora.IdUsuario.HasValue)
                {
                    var usuario = _usuariosDataAccess.ObtenerUsuarioPorId(bitacora.IdUsuario.Value);
                    if (usuario == null)
                    {
                        _logger.Warn($"No existe el usuario con ID {bitacora.IdUsuario.Value}");
                        // No detenemos la inserción, sólo se registra la advertencia
                    }
                }

                string query = @"INSERT INTO Bitacora 
                                (id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento) 
                                VALUES 
                                (@IdMovimientoProducto, @IdUsuario, @IdEquipo, @NombreEquipo, @Fecha, @TipoMovimiento) 
                                RETURNING id_auditoria";

                // Crear parámetros para la consulta
                var parameters = new List<NpgsqlParameter>
                {
                    _dbAccess.CreateParameter("@IdMovimientoProducto", bitacora.IdMovimientoProducto),
                    _dbAccess.CreateParameter("@IdUsuario", bitacora.IdUsuario),
                    _dbAccess.CreateParameter("@IdEquipo", bitacora.IdEquipo),
                    _dbAccess.CreateParameter("@NombreEquipo", bitacora.NombreEquipo),
                    _dbAccess.CreateParameter("@Fecha", bitacora.Fecha),
                    _dbAccess.CreateParameter("@TipoMovimiento", bitacora.TipoMovimiento)
                };

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la inserción y obtener el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, parameters.ToArray());

                // Convertir el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Registro de bitácora insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar registro en la bitácora");
                return -1;
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un registro de la bitácora por su ID
        /// </summary>
        /// <param name="idAuditoria">ID del registro a consultar</param>
        /// <returns>Objeto Bitacora si se encuentra, null si no existe</returns>
        public Bitacora? ObtenerRegistroBitacoraPorId(int idAuditoria)
        {
            try
            {
                string query = @"SELECT id_auditoria, id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento 
                               FROM Bitacora 
                               WHERE id_auditoria = @IdAuditoria";

                // Crear parámetro
                var paramId = _dbAccess.CreateParameter("@IdAuditoria", idAuditoria);

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún registro de bitácora con ID {idAuditoria}");
                    return null;
                }

                // Obtener la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear objeto Bitacora
                Bitacora bitacora = CrearBitacoraDesdeDataRow(row);

                // Cargar relaciones si existen
                if (bitacora.IdMovimientoProducto.HasValue)
                {
                    bitacora.MovimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value) ?? new MovimientoProducto();
                }

                if (bitacora.IdUsuario.HasValue)
                {
                    bitacora.Usuario = _usuariosDataAccess.ObtenerUsuarioPorId(bitacora.IdUsuario.Value) ?? new Usuario();
                }

                return bitacora;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el registro de bitácora con ID {idAuditoria}");
                return null;
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los registros de la bitácora
        /// </summary>
        /// <returns>Lista de objetos Bitacora</returns>
        public List<Bitacora> ObtenerTodosLosRegistrosBitacora()
        {
            List<Bitacora> registros = new List<Bitacora>();

            try
            {
                string query = @"SELECT id_auditoria, id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento 
                               FROM Bitacora 
                               ORDER BY fecha DESC";

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    // Crear objeto Bitacora
                    Bitacora bitacora = CrearBitacoraDesdeDataRow(row);
                    registros.Add(bitacora);
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros de bitácora");

                // Cargar relaciones para cada registro si es necesario
                foreach (var bitacora in registros)
                {
                    if (bitacora.IdMovimientoProducto.HasValue)
                    {
                        bitacora.MovimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value) ?? new MovimientoProducto();
                    }

                    if (bitacora.IdUsuario.HasValue)
                    {
                        bitacora.Usuario = _usuariosDataAccess.ObtenerUsuarioPorId(bitacora.IdUsuario.Value) ?? new Usuario();
                    }
                }

                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los registros de bitácora");
                return registros; // Devolver lista vacía en caso de error
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene registros de bitácora en un rango de fechas específico
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango</param>
        /// <param name="fechaFin">Fecha de fin del rango</param>
        /// <returns>Lista de objetos Bitacora dentro del rango de fechas</returns>
        public List<Bitacora> ObtenerRegistrosBitacoraPorFecha(DateTime fechaInicio, DateTime fechaFin)
        {
            List<Bitacora> registros = new List<Bitacora>();

            try
            {
                string query = @"SELECT id_auditoria, id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento 
                               FROM Bitacora 
                               WHERE fecha BETWEEN @FechaInicio AND @FechaFin 
                               ORDER BY fecha DESC";

                // Crear parámetros
                var paramFechaInicio = _dbAccess.CreateParameter("@FechaInicio", fechaInicio);
                var paramFechaFin = _dbAccess.CreateParameter("@FechaFin", fechaFin);

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramFechaInicio, paramFechaFin);

                foreach (DataRow row in resultado.Rows)
                {
                    // Crear objeto Bitacora
                    Bitacora bitacora = CrearBitacoraDesdeDataRow(row);
                    registros.Add(bitacora);
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros de bitácora entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()}");

                // Cargar relaciones para cada registro si es necesario
                foreach (var bitacora in registros)
                {
                    if (bitacora.IdMovimientoProducto.HasValue)
                    {
                        bitacora.MovimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value) ?? new MovimientoProducto();
                    }

                    if (bitacora.IdUsuario.HasValue)
                    {
                        bitacora.Usuario = _usuariosDataAccess.ObtenerUsuarioPorId(bitacora.IdUsuario.Value) ?? new Usuario();
                    }
                }

                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener registros de bitácora por rango de fechas");
                return registros; // Devolver lista vacía en caso de error
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene registros de bitácora realizados por un usuario específico
        /// </summary>
        /// <param name="idUsuario">ID del usuario</param>
        /// <returns>Lista de objetos Bitacora del usuario especificado</returns>
        public List<Bitacora> ObtenerRegistrosBitacoraPorUsuario(int idUsuario)
        {
            List<Bitacora> registros = new List<Bitacora>();

            try
            {
                // Verificar que exista el usuario
                var usuario = _usuariosDataAccess.ObtenerUsuarioPorId(idUsuario);
                if (usuario == null)
                {
                    _logger.Warn($"No existe el usuario con ID {idUsuario}");
                    return registros;
                }

                string query = @"SELECT id_auditoria, id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento 
                               FROM Bitacora 
                               WHERE id_usuario = @IdUsuario 
                               ORDER BY fecha DESC";

                // Crear parámetro
                var paramIdUsuario = _dbAccess.CreateParameter("@IdUsuario", idUsuario);

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdUsuario);

                foreach (DataRow row in resultado.Rows)
                {
                    // Crear objeto Bitacora
                    Bitacora bitacora = CrearBitacoraDesdeDataRow(row);
                    bitacora.Usuario = usuario; // Ya tenemos el usuario cargado

                    // Cargar relación de MovimientoProducto si existe
                    if (bitacora.IdMovimientoProducto.HasValue)
                    {
                        bitacora.MovimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value) ?? new MovimientoProducto();
                    }

                    registros.Add(bitacora);
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros de bitácora para el usuario con ID {idUsuario}");
                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener registros de bitácora para el usuario con ID {idUsuario}");
                return registros; // Devolver lista vacía en caso de error
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene registros de bitácora por tipo de movimiento
        /// </summary>
        /// <param name="tipoMovimiento">Tipo de movimiento a filtrar</param>
        /// <returns>Lista de objetos Bitacora del tipo de movimiento especificado</returns>
        public List<Bitacora> ObtenerRegistrosBitacoraPorTipoMovimiento(string tipoMovimiento)
        {
            List<Bitacora> registros = new List<Bitacora>();

            try
            {
                if (string.IsNullOrEmpty(tipoMovimiento))
                {
                    _logger.Error("El tipo de movimiento no puede estar vacío");
                    return registros;
                }

                string query = @"SELECT id_auditoria, id_movimiento_producto, id_usuario, id_equipo, nombre_equipo, fecha, tipo_movimiento 
                               FROM Bitacora 
                               WHERE tipo_movimiento = @TipoMovimiento 
                               ORDER BY fecha DESC";

                // Crear parámetro
                var paramTipoMovimiento = _dbAccess.CreateParameter("@TipoMovimiento", tipoMovimiento);

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramTipoMovimiento);

                foreach (DataRow row in resultado.Rows)
                {
                    // Crear objeto Bitacora
                    Bitacora bitacora = CrearBitacoraDesdeDataRow(row);
                    registros.Add(bitacora);
                }

                _logger.Info($"Se obtuvieron {registros.Count} registros de bitácora para el tipo de movimiento '{tipoMovimiento}'");

                // Cargar relaciones para cada registro si es necesario
                foreach (var bitacora in registros)
                {
                    if (bitacora.IdMovimientoProducto.HasValue)
                    {
                        bitacora.MovimientoProducto = _movimientoProductoDataAccess.ObtenerMovimientoProductoPorId(bitacora.IdMovimientoProducto.Value) ?? new MovimientoProducto();
                    }

                    if (bitacora.IdUsuario.HasValue)
                    {
                        bitacora.Usuario = _usuariosDataAccess.ObtenerUsuarioPorId(bitacora.IdUsuario.Value) ?? new Usuario();
                    }
                }

                return registros;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener registros de bitácora para el tipo de movimiento '{tipoMovimiento}'");
                return registros; // Devolver lista vacía en caso de error
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un registro de la bitácora por su ID
        /// </summary>
        /// <param name="idAuditoria">ID del registro a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarRegistroBitacora(int idAuditoria)
        {
            try
            {
                _logger.Warn($"Solicitud para eliminar registro de bitácora con ID {idAuditoria}. Esta operación no es recomendada para registros de auditoría.");

                string query = "DELETE FROM Bitacora WHERE id_auditoria = @IdAuditoria";

                // Crear parámetro
                var paramId = _dbAccess.CreateParameter("@IdAuditoria", idAuditoria);

                // Establecer conexión a la BD
                _dbAccess.Connect();

                // Ejecutar la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Registro de bitácora con ID {idAuditoria} eliminado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el registro de bitácora con ID {idAuditoria}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el registro de bitácora con ID {idAuditoria}");
                return false;
            }
            finally
            {
                // Asegurar que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Método privado auxiliar para crear un objeto Bitacora desde un DataRow
        /// </summary>
        /// <param name="row">DataRow con los datos del registro de bitácora</param>
        /// <returns>Objeto Bitacora con los datos de la fila</returns>
        private Bitacora CrearBitacoraDesdeDataRow(DataRow row)
        {
            return new Bitacora(
                idAuditoria: Convert.ToInt32(row["id_auditoria"]),
                idMovimientoProducto: row["id_movimiento_producto"] != DBNull.Value ? Convert.ToInt32(row["id_movimiento_producto"]) : null,
                idUsuario: row["id_usuario"] != DBNull.Value ? Convert.ToInt32(row["id_usuario"]) : null,
                idEquipo: row["id_equipo"].ToString() ?? string.Empty,
                nombreEquipo: row["nombre_equipo"].ToString() ?? string.Empty,
                fecha: Convert.ToDateTime(row["fecha"]),
                tipoMovimiento: row["tipo_movimiento"].ToString() ?? string.Empty
            );
        }
    }
}