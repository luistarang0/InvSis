using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InvSis.Model;
using InvSis.Utilities;

namespace InvSis.Data
{
    public class MovimientoProductoDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.MovimientoProductoDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly ProductosDataAccess _productosDataAccess;
        private readonly MovimientosDataAccess _movimientosDataAccess;

        public MovimientoProductoDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _productosDataAccess = new ProductosDataAccess();
                _movimientosDataAccess = new MovimientosDataAccess();
                _logger.Info("MovimientoProductoDataAccess inicializado correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar MovimientoProductoDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo movimiento de producto en la base de datos
        /// </summary>
        /// <param name="movimientoProducto">Objeto MovimientoProducto con la información a insertar</param>
        /// <returns>El ID generado si fue exitoso, -1 en caso de error</returns>
        public int InsertarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            try
            {
                // Validar que existan el producto y el movimiento
                var producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto);
                if (producto == null)
                {
                    _logger.Error($"No existe el producto con ID {movimientoProducto.IdProducto}");
                    return -1;
                }

                var movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento);
                if (movimiento == null)
                {
                    _logger.Error($"No existe el movimiento con ID {movimientoProducto.IdMovimiento}");
                    return -1;
                }

                string query = "INSERT INTO Movimientos_Productos (id_producto, id_movimiento, cantidad, fecha) " +
                              "VALUES (@IdProducto, @IdMovimiento, @Cantidad, @Fecha) " +
                              "RETURNING id_movimiento_producto";

                // Crea parámetros para la consulta
                NpgsqlParameter paramIdProducto = _dbAccess.CreateParameter("@IdProducto", movimientoProducto.IdProducto);
                NpgsqlParameter paramIdMovimiento = _dbAccess.CreateParameter("@IdMovimiento", movimientoProducto.IdMovimiento);
                NpgsqlParameter paramCantidad = _dbAccess.CreateParameter("@Cantidad", movimientoProducto.Cantidad);
                NpgsqlParameter paramFecha = _dbAccess.CreateParameter("@Fecha", movimientoProducto.Fecha);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la inserción y obtiene el ID generado
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdProducto, paramIdMovimiento, paramCantidad, paramFecha);

                // Convierte el resultado a entero
                int idGenerado = Convert.ToInt32(resultado);
                _logger.Info($"Movimiento de producto insertado correctamente con ID: {idGenerado}");

                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al insertar el movimiento de producto");
                return -1;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza los datos de un movimiento de producto existente
        /// </summary>
        /// <param name="movimientoProducto">Objeto MovimientoProducto con la información actualizada</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarMovimientoProducto(MovimientoProducto movimientoProducto)
        {
            try
            {
                // Validar que existan el producto y el movimiento
                var producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto);
                if (producto == null)
                {
                    _logger.Error($"No existe el producto con ID {movimientoProducto.IdProducto}");
                    return false;
                }

                var movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento);
                if (movimiento == null)
                {
                    _logger.Error($"No existe el movimiento con ID {movimientoProducto.IdMovimiento}");
                    return false;
                }

                string query = "UPDATE Movimientos_Productos " +
                              "SET id_producto = @IdProducto, " +
                              "    id_movimiento = @IdMovimiento, " +
                              "    cantidad = @Cantidad, " +
                              "    fecha = @Fecha " +
                              "WHERE id_movimiento_producto = @IdMovimientoProducto";

                // Crea los parámetros
                NpgsqlParameter paramIdMovimientoProducto = _dbAccess.CreateParameter("@IdMovimientoProducto", movimientoProducto.IdMovimientoProducto);
                NpgsqlParameter paramIdProducto = _dbAccess.CreateParameter("@IdProducto", movimientoProducto.IdProducto);
                NpgsqlParameter paramIdMovimiento = _dbAccess.CreateParameter("@IdMovimiento", movimientoProducto.IdMovimiento);
                NpgsqlParameter paramCantidad = _dbAccess.CreateParameter("@Cantidad", movimientoProducto.Cantidad);
                NpgsqlParameter paramFecha = _dbAccess.CreateParameter("@Fecha", movimientoProducto.Fecha);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdMovimientoProducto, paramIdProducto,
                                                             paramIdMovimiento, paramCantidad, paramFecha);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento de producto con ID {movimientoProducto.IdMovimientoProducto} actualizado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar el movimiento de producto con ID {movimientoProducto.IdMovimientoProducto}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el movimiento de producto con ID {movimientoProducto.IdMovimientoProducto}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un movimiento de producto de la base de datos
        /// </summary>
        /// <param name="idMovimientoProducto">ID del movimiento de producto a eliminar</param>
        /// <returns>True si la eliminación fue exitosa, False en caso contrario</returns>
        public bool EliminarMovimientoProducto(int idMovimientoProducto)
        {
            try
            {
                string query = "DELETE FROM Movimientos_Productos WHERE id_movimiento_producto = @IdMovimientoProducto";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdMovimientoProducto", idMovimientoProducto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la eliminación
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento de producto con ID {idMovimientoProducto} eliminado correctamente");
                }
                else
                {
                    _logger.Warn($"No se pudo eliminar el movimiento de producto con ID {idMovimientoProducto}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el movimiento de producto con ID {idMovimientoProducto}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un movimiento de producto por su ID, incluyendo los datos del producto y movimiento asociados
        /// </summary>
        /// <param name="idMovimientoProducto">ID del movimiento de producto a buscar</param>
        /// <returns>Objeto MovimientoProducto si se encuentra, null si no existe</returns>
        public MovimientoProducto? ObtenerMovimientoProductoPorId(int idMovimientoProducto)
        {
            try
            {
                string query = "SELECT id_movimiento_producto, id_producto, id_movimiento, cantidad, fecha " +
                              "FROM Movimientos_Productos WHERE id_movimiento_producto = @IdMovimientoProducto";

                // Crea el parámetro
                NpgsqlParameter paramId = _dbAccess.CreateParameter("@IdMovimientoProducto", idMovimientoProducto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún movimiento de producto con ID {idMovimientoProducto}");
                    return null;
                }

                // Obtiene la primera fila (debería ser la única)
                DataRow row = resultado.Rows[0];

                // Crear objeto MovimientoProducto
                MovimientoProducto movimientoProducto = CrearMovimientoProductoDesdeDataRow(row);

                // Obtener datos del producto y movimiento asociados
                movimientoProducto.Producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto) ?? new Producto();
                movimientoProducto.Movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento) ?? new Movimiento();

                return movimientoProducto;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el movimiento de producto con ID {idMovimientoProducto}");
                return null;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los movimientos de productos de la base de datos, incluyendo los datos de productos y movimientos
        /// </summary>
        /// <returns>Lista de objetos MovimientoProducto</returns>
        public List<MovimientoProducto> ObtenerTodosLosMovimientosProductos()
        {
            List<MovimientoProducto> movimientosProductos = new List<MovimientoProducto>();

            try
            {
                string query = "SELECT id_movimiento_producto, id_producto, id_movimiento, cantidad, fecha FROM Movimientos_Productos";

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    MovimientoProducto movimientoProducto = CrearMovimientoProductoDesdeDataRow(row);
                    movimientosProductos.Add(movimientoProducto);
                }

                // Cargar datos de productos y movimientos asociados
                foreach (var movimientoProducto in movimientosProductos)
                {
                    movimientoProducto.Producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto) ?? new Producto();
                    movimientoProducto.Movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento) ?? new Movimiento();
                }

                _logger.Info($"Se obtuvieron {movimientosProductos.Count} movimientos de productos de la base de datos");
                return movimientosProductos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los movimientos de productos");
                return movimientosProductos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene los movimientos de productos asociados a un producto específico
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Lista de movimientos de productos del producto especificado</returns>
        public List<MovimientoProducto> ObtenerMovimientosProductosPorProducto(int idProducto)
        {
            List<MovimientoProducto> movimientosProductos = new List<MovimientoProducto>();

            try
            {
                // Verificar que exista el producto
                var producto = _productosDataAccess.ObtenerProductoPorId(idProducto);
                if (producto == null)
                {
                    _logger.Warn($"No existe el producto con ID {idProducto}");
                    return movimientosProductos;
                }

                string query = "SELECT id_movimiento_producto, id_producto, id_movimiento, cantidad, fecha " +
                               "FROM Movimientos_Productos WHERE id_producto = @IdProducto";

                // Crea el parámetro
                NpgsqlParameter paramIdProducto = _dbAccess.CreateParameter("@IdProducto", idProducto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdProducto);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    MovimientoProducto movimientoProducto = CrearMovimientoProductoDesdeDataRow(row);
                    movimientoProducto.Producto = producto;

                    // Obtener datos del movimiento asociado
                    movimientoProducto.Movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento) ?? new Movimiento();

                    movimientosProductos.Add(movimientoProducto);
                }

                _logger.Info($"Se encontraron {movimientosProductos.Count} movimientos para el producto con ID {idProducto}");
                return movimientosProductos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos de productos para el producto con ID {idProducto}");
                return movimientosProductos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene los movimientos de productos asociados a un movimiento específico
        /// </summary>
        /// <param name="idMovimiento">ID del movimiento</param>
        /// <returns>Lista de movimientos de productos del movimiento especificado</returns>
        public List<MovimientoProducto> ObtenerMovimientosProductosPorMovimiento(int idMovimiento)
        {
            List<MovimientoProducto> movimientosProductos = new List<MovimientoProducto>();

            try
            {
                // Verificar que exista el movimiento
                var movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(idMovimiento);
                if (movimiento == null)
                {
                    _logger.Warn($"No existe el movimiento con ID {idMovimiento}");
                    return movimientosProductos;
                }

                string query = "SELECT id_movimiento_producto, id_producto, id_movimiento, cantidad, fecha " +
                               "FROM Movimientos_Productos WHERE id_movimiento = @IdMovimiento";

                // Crea el parámetro
                NpgsqlParameter paramIdMovimiento = _dbAccess.CreateParameter("@IdMovimiento", idMovimiento);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramIdMovimiento);

                // Procesa las filas devueltas
                foreach (DataRow row in resultado.Rows)
                {
                    MovimientoProducto movimientoProducto = CrearMovimientoProductoDesdeDataRow(row);
                    movimientoProducto.Movimiento = movimiento;

                    // Obtener datos del producto asociado
                    movimientoProducto.Producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto) ?? new Producto();

                    movimientosProductos.Add(movimientoProducto);
                }

                _logger.Info($"Se encontraron {movimientosProductos.Count} movimientos de productos para el movimiento con ID {idMovimiento}");
                return movimientosProductos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos de productos para el movimiento con ID {idMovimiento}");
                return movimientosProductos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene movimientos de productos realizados en un rango de fechas
        /// </summary>
        /// <param name="fechaInicio">Fecha de inicio del rango</param>
        /// <param name="fechaFin">Fecha de fin del rango</param>
        /// <returns>Lista de movimientos de productos realizados en el rango de fechas</returns>
        public List<MovimientoProducto> ObtenerMovimientosProductosPorRangoFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            List<MovimientoProducto> movimientosProductos = new List<MovimientoProducto>();

            try
            {
                string query = "SELECT id_movimiento_producto, id_producto, id_movimiento, cantidad, fecha " +
                              "FROM Movimientos_Productos WHERE fecha BETWEEN @FechaInicio AND @FechaFin";

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
                    MovimientoProducto movimientoProducto = CrearMovimientoProductoDesdeDataRow(row);

                    // Obtener datos del producto y movimiento asociados
                    movimientoProducto.Producto = _productosDataAccess.ObtenerProductoPorId(movimientoProducto.IdProducto) ?? new Producto();
                    movimientoProducto.Movimiento = _movimientosDataAccess.ObtenerMovimientoPorId(movimientoProducto.IdMovimiento) ?? new Movimiento();

                    movimientosProductos.Add(movimientoProducto);
                }

                _logger.Info($"Se encontraron {movimientosProductos.Count} movimientos de productos entre {fechaInicio.ToShortDateString()} y {fechaFin.ToShortDateString()}");
                return movimientosProductos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener movimientos de productos por rango de fechas");
                return movimientosProductos; // Devuelve lista vacía en caso de error
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza la cantidad de un movimiento de producto existente
        /// </summary>
        /// <param name="idMovimientoProducto">ID del movimiento de producto</param>
        /// <param name="nuevaCantidad">Nueva cantidad a asignar</param>
        /// <returns>True si la actualización fue exitosa, False en caso contrario</returns>
        public bool ActualizarCantidadMovimientoProducto(int idMovimientoProducto, int nuevaCantidad)
        {
            try
            {
                if (nuevaCantidad <= 0)
                {
                    _logger.Error($"La cantidad debe ser mayor que cero: {nuevaCantidad}");
                    return false;
                }

                string query = "UPDATE Movimientos_Productos SET cantidad = @Cantidad WHERE id_movimiento_producto = @IdMovimientoProducto";

                // Crea los parámetros
                NpgsqlParameter paramIdMovimientoProducto = _dbAccess.CreateParameter("@IdMovimientoProducto", idMovimientoProducto);
                NpgsqlParameter paramCantidad = _dbAccess.CreateParameter("@Cantidad", nuevaCantidad);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la actualización
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramIdMovimientoProducto, paramCantidad);

                bool exito = filasAfectadas > 0;
                if (exito)
                {
                    _logger.Info($"Movimiento de producto con ID {idMovimientoProducto} actualizó su cantidad a {nuevaCantidad}");
                }
                else
                {
                    _logger.Warn($"No se pudo actualizar la cantidad del movimiento de producto con ID {idMovimientoProducto}. No se encontró el registro");
                }

                return exito;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar la cantidad del movimiento de producto con ID {idMovimientoProducto}");
                return false;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene la suma total de cantidades por producto
        /// </summary>
        /// <param name="idProducto">ID del producto</param>
        /// <returns>Suma total de cantidades, 0 si no hay movimientos o en caso de error</returns>
        public int ObtenerTotalCantidadPorProducto(int idProducto)
        {
            try
            {
                string query = "SELECT SUM(cantidad) FROM Movimientos_Productos WHERE id_producto = @IdProducto";

                // Crea el parámetro
                NpgsqlParameter paramIdProducto = _dbAccess.CreateParameter("@IdProducto", idProducto);

                // Establece la conexión a la BD
                _dbAccess.Connect();

                // Ejecuta la consulta
                object? resultado = _dbAccess.ExecuteScalar(query, paramIdProducto);

                // Si no hay resultados, devuelve 0
                if (resultado == null || resultado == DBNull.Value)
                {
                    return 0;
                }

                int totalCantidad = Convert.ToInt32(resultado);
                _logger.Info($"La suma total de cantidades para el producto con ID {idProducto} es: {totalCantidad}");
                return totalCantidad;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener la suma total de cantidades para el producto con ID {idProducto}");
                return 0;
            }
            finally
            {
                // Asegura que se cierre la conexión
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Método privado auxiliar para crear un objeto MovimientoProducto desde un DataRow
        /// </summary>
        /// <param name="row">DataRow con los datos del movimiento de producto</param>
        /// <returns>Objeto MovimientoProducto con los datos de la fila</returns>
        private MovimientoProducto CrearMovimientoProductoDesdeDataRow(DataRow row)
        {
            return new MovimientoProducto(
                idMovimientoProducto: Convert.ToInt32(row["id_movimiento_producto"]),
                idProducto: Convert.ToInt32(row["id_producto"]),
                idMovimiento: Convert.ToInt32(row["id_movimiento"]),
                cantidad: Convert.ToInt32(row["cantidad"]),
                fecha: Convert.ToDateTime(row["fecha"])
            );
        }
    
    }
}