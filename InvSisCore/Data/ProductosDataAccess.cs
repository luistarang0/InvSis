using System;
using System.Collections.Generic;
using System.Data;
using Npgsql;
using NLog;
using InvSis.Model;
using InvSis.Utilities;

namespace InvSis.Data
{
    public class ProductosDataAccess
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("InvSis.Data.ProductosDataAccess");
        private readonly PostgreSQLDataAccess _dbAccess;
        private readonly ImpuestosDataAccess _impuestosDataAccess;

        public ProductosDataAccess()
        {
            try
            {
                _dbAccess = PostgreSQLDataAccess.GetInstance();
                _impuestosDataAccess = new ImpuestosDataAccess();
                _logger.Info("ProductosDataAccess inicializado correctamente");
            }
            catch (Exception ex)
            {
                _logger.Fatal(ex, "Error al inicializar ProductosDataAccess");
                throw;
            }
        }

        /// <summary>
        /// Inserta un nuevo producto en la base de datos
        /// </summary>
        public int InsertarProducto(Producto producto)
        {
            try
            {
                // Validación adicional para impuestos
                if (producto.AplicaImpuesto && !producto.IdImpuesto.HasValue)
                {
                    throw new ArgumentException("Debe especificar un ID de impuesto cuando AplicaImpuesto es verdadero");
                }

                // Validar que el impuesto exista si aplica
                if (producto.AplicaImpuesto && producto.IdImpuesto.HasValue)
                {
                    var impuesto = _impuestosDataAccess.ObtenerImpuestoPorId(producto.IdImpuesto.Value);
                    if (impuesto == null)
                    {
                        throw new ArgumentException($"No existe el impuesto con ID {producto.IdImpuesto.Value}");
                    }
                }

                string query = @"INSERT INTO Productos (nombre, categoria, costo, stock, ubicacion, clave, estatus, aplica_impuesto, id_impuesto) 
                                VALUES (@Nombre, @Categoria, @Costo, @Stock, @Ubicacion, @Clave, @Estatus, @AplicaImpuesto, @IdImpuesto) 
                                RETURNING id_producto";

                // Creación de parámetros con manejo de nulos
                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@Nombre", producto.Nombre),
                    _dbAccess.CreateParameter("@Categoria", producto.Categoria ?? (object)DBNull.Value),
                    _dbAccess.CreateParameter("@Costo", producto.Costo),
                    _dbAccess.CreateParameter("@Stock", producto.Stock),
                    _dbAccess.CreateParameter("@Ubicacion", producto.Ubicacion ?? (object)DBNull.Value),
                    _dbAccess.CreateParameter("@Clave", producto.Clave),
                    _dbAccess.CreateParameter("@Estatus", producto.Estatus),
                    _dbAccess.CreateParameter("@AplicaImpuesto", producto.AplicaImpuesto),
                    _dbAccess.CreateParameter("@IdImpuesto",
                        producto.AplicaImpuesto && producto.IdImpuesto.HasValue ?
                        (object)producto.IdImpuesto.Value : DBNull.Value)
                };

                _dbAccess.Connect();
                var idGenerado = Convert.ToInt32(_dbAccess.ExecuteScalar(query, parameters));

                _logger.Info($"Producto insertado correctamente con ID: {idGenerado}");
                return idGenerado;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al insertar el producto {producto.Nombre}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza un producto existente en la base de datos
        /// </summary>
        public bool ActualizarProducto(Producto producto)
        {
            try
            {
                // Validación adicional para impuestos
                if (producto.AplicaImpuesto && !producto.IdImpuesto.HasValue)
                {
                    throw new ArgumentException("Debe especificar un ID de impuesto cuando AplicaImpuesto es verdadero");
                }

                // Validar que el impuesto exista si aplica
                if (producto.AplicaImpuesto && producto.IdImpuesto.HasValue)
                {
                    var impuesto = _impuestosDataAccess.ObtenerImpuestoPorId(producto.IdImpuesto.Value);
                    if (impuesto == null)
                    {
                        throw new ArgumentException($"No existe el impuesto con ID {producto.IdImpuesto.Value}");
                    }
                }

                string query = @"UPDATE Productos 
                                SET nombre = @Nombre, 
                                    categoria = @Categoria, 
                                    costo = @Costo, 
                                    stock = @Stock, 
                                    ubicacion = @Ubicacion, 
                                    clave = @Clave, 
                                    estatus = @Estatus, 
                                    aplica_impuesto = @AplicaImpuesto, 
                                    id_impuesto = @IdImpuesto 
                                WHERE id_producto = @IdProducto";

                // Creación de parámetros con manejo de nulos
                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@IdProducto", producto.IdProducto),
                    _dbAccess.CreateParameter("@Nombre", producto.Nombre),
                    _dbAccess.CreateParameter("@Categoria", producto.Categoria ?? (object)DBNull.Value),
                    _dbAccess.CreateParameter("@Costo", producto.Costo),
                    _dbAccess.CreateParameter("@Stock", producto.Stock),
                    _dbAccess.CreateParameter("@Ubicacion", producto.Ubicacion ?? (object)DBNull.Value),
                    _dbAccess.CreateParameter("@Clave", producto.Clave),
                    _dbAccess.CreateParameter("@Estatus", producto.Estatus),
                    _dbAccess.CreateParameter("@AplicaImpuesto", producto.AplicaImpuesto),
                    _dbAccess.CreateParameter("@IdImpuesto",
                        producto.AplicaImpuesto && producto.IdImpuesto.HasValue ?
                        (object)producto.IdImpuesto.Value : DBNull.Value)
                };

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, parameters);

                if (filasAfectadas > 0)
                {
                    _logger.Info($"Producto con ID {producto.IdProducto} actualizado correctamente");
                    return true;
                }

                _logger.Warn($"No se encontró el producto con ID {producto.IdProducto} para actualizar");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el producto con ID {producto.IdProducto}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Elimina un producto de la base de datos
        /// </summary>
        public bool EliminarProducto(int idProducto)
        {
            try
            {
                string query = "DELETE FROM Productos WHERE id_producto = @IdProducto";
                var paramId = _dbAccess.CreateParameter("@IdProducto", idProducto);

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, paramId);

                if (filasAfectadas > 0)
                {
                    _logger.Info($"Producto con ID {idProducto} eliminado correctamente");
                    return true;
                }

                _logger.Warn($"No se encontró el producto con ID {idProducto} para eliminar");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al eliminar el producto con ID {idProducto}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene un producto por su ID
        /// </summary>
        public Producto? ObtenerProductoPorId(int idProducto)
        {
            try
            {
                string query = @"SELECT id_producto, nombre, categoria, costo, stock, ubicacion, 
                               clave, estatus, aplica_impuesto, id_impuesto 
                               FROM Productos 
                               WHERE id_producto = @IdProducto";

                var paramId = _dbAccess.CreateParameter("@IdProducto", idProducto);
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramId);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún producto con ID {idProducto}");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                var producto = CrearProductoDesdeDataRow(row);

                // Cargar impuesto si aplica
                if (producto.AplicaImpuesto && producto.IdImpuesto.HasValue)
                {
                    producto.Impuesto = _impuestosDataAccess.ObtenerImpuestoPorId(producto.IdImpuesto.Value) ?? new Impuesto();
                }

                return producto;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el producto con ID {idProducto}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene todos los productos de la base de datos
        /// </summary>
        public List<Producto> ObtenerTodosLosProductos()
        {
            var productos = new List<Producto>();

            try
            {
                string query = @"SELECT id_producto, nombre, categoria, costo, stock, ubicacion, 
                               clave, estatus, aplica_impuesto, id_impuesto 
                               FROM Productos";

                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query);

                foreach (DataRow row in resultado.Rows)
                {
                    var producto = CrearProductoDesdeDataRow(row);
                    productos.Add(producto);
                }

                // Cargar impuestos para los productos que los tienen
                foreach (var producto in productos)
                {
                    if (producto.AplicaImpuesto && producto.IdImpuesto.HasValue)
                    {
                        producto.Impuesto = _impuestosDataAccess.ObtenerImpuestoPorId(producto.IdImpuesto.Value) ?? new Impuesto();
                    }
                }

                _logger.Info($"Se obtuvieron {productos.Count} productos");
                return productos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al obtener todos los productos");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Actualiza el stock de un producto
        /// </summary>
        public bool ActualizarStock(int idProducto, int nuevoStock)
        {
            try
            {
                string query = "UPDATE Productos SET stock = @Stock WHERE id_producto = @IdProducto";
                var parameters = new[]
                {
                    _dbAccess.CreateParameter("@IdProducto", idProducto),
                    _dbAccess.CreateParameter("@Stock", nuevoStock)
                };

                _dbAccess.Connect();
                int filasAfectadas = _dbAccess.ExecuteNonQuery(query, parameters);

                if (filasAfectadas > 0)
                {
                    _logger.Info($"Stock del producto con ID {idProducto} actualizado a {nuevoStock}");
                    return true;
                }

                _logger.Warn($"No se encontró el producto con ID {idProducto} para actualizar stock");
                return false;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al actualizar el stock del producto con ID {idProducto}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Verifica si existe un producto por su clave
        /// </summary>
        public bool ExisteProductoPorClave(string clave)
        {
            try
            {
                string query = "SELECT COUNT(*) FROM Productos WHERE clave = @Clave";
                var paramClave = _dbAccess.CreateParameter("@Clave", clave);

                _dbAccess.Connect();
                var count = Convert.ToInt32(_dbAccess.ExecuteScalar(query, paramClave));

                return count > 0;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al verificar la existencia del producto con clave: {clave}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Obtiene producto por clave
        /// </summary>
        public Producto? ObtenerProductoPorClave(string clave)
        {
            try
            {
                string query = @"SELECT id_producto, nombre, categoria, costo, stock, ubicacion, 
                               clave, estatus, aplica_impuesto, id_impuesto 
                               FROM Productos 
                               WHERE clave = @Clave";

                var paramClave = _dbAccess.CreateParameter("@Clave", clave);
                _dbAccess.Connect();
                DataTable resultado = _dbAccess.ExecuteQuery_Reader(query, paramClave);

                if (resultado.Rows.Count == 0)
                {
                    _logger.Warn($"No se encontró ningún producto con clave {clave}");
                    return null;
                }

                DataRow row = resultado.Rows[0];
                var producto = CrearProductoDesdeDataRow(row);

                // Cargar impuesto si aplica
                if (producto.AplicaImpuesto && producto.IdImpuesto.HasValue)
                {
                    producto.Impuesto = _impuestosDataAccess.ObtenerImpuestoPorId(producto.IdImpuesto.Value) ?? new Impuesto();
                }

                return producto;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, $"Error al obtener el producto con clave {clave}");
                throw;
            }
            finally
            {
                _dbAccess.Disconnect();
            }
        }

        /// <summary>
        /// Método auxiliar para crear un Producto desde DataRow
        /// </summary>
        private Producto CrearProductoDesdeDataRow(DataRow row)
        {
            return new Producto(
                idProducto: Convert.ToInt32(row["id_producto"]),
                nombre: row["nombre"].ToString() ?? string.Empty,
                categoria: row["categoria"] != DBNull.Value ? row["categoria"].ToString() : string.Empty,
                costo: Convert.ToDecimal(row["costo"]),
                stock: Convert.ToInt32(row["stock"]),
                ubicacion: row["ubicacion"] != DBNull.Value ? row["ubicacion"].ToString() : string.Empty,
                clave: row["clave"].ToString() ?? string.Empty,
                estatus: Convert.ToInt32(row["estatus"]),
                aplicaImpuesto: Convert.ToBoolean(row["aplica_impuesto"]),
                idImpuesto: row["id_impuesto"] != DBNull.Value ? Convert.ToInt32(row["id_impuesto"]) : (int?)null
            );
        }
    }
}