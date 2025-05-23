using InvSis.Data;
using InvSis.Model;
using InvSis.Utilities;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Controller
{
    public class ProductoController
    {
        private static readonly Logger _logger = LoggingManager.GetLogger("Sistema_Ventas.Controller.CompraController");
        private readonly ProductosDataAccess _productosData;

        public ProductoController()
        {
            try
            {
                _productosData = new ProductosDataAccess();
            }
            catch (Exception)
            {
                _logger.Error("Error al inicializar la clase ProductoController");
                throw;
            }
        }

        public List<Producto> ObtenerProductos()
        {
            try
            {
                var productos = _productosData.ObtenerTodosLosProductos();
                _logger.Info($"Compras obtenidas con filtros: {productos.Count} registros encontrados");
                return productos;
            }
            catch (Exception ex)
            {
                _logger.Error(ex, "Error al buscar compras filtradas.");
                throw;
            }
        }
    }
}
