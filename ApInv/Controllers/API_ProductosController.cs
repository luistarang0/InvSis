using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InvSis.Controller;

namespace API_Ventas.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasAPIController : ControllerBase
    {
        private readonly ProductoController _productosController;
        private readonly ILogger<VentasAPIController> _logger;

        public VentasAPIController(ProductoController compraController, ILogger<VentasAPIController> logger)
        {
            _productosController = compraController;
            _logger = logger;
        }

        /// <summary>
        /// Obtiene las ventas generadas por artículo con filtros opcionales
        /// </summary>
        /// <param name="idProducto">ID del producto o artículo (opcional)</param>
        /// <param name="idCliente">ID del cliente (opcional)</param>
        /// <param name="fechaInicio">Fecha inicial del rango (opcional)</param>
        /// <param name="fechaFin">Fecha final del rango (opcional)</param>
        /// <param name="estatus">Estatus de la compra (opcional)</param>
        /// <returns>Lista de compras/ventas con detalles como fecha, número de venta, cliente, estatus, cantidad y costo</returns>
        [HttpGet("productos")]
        public IActionResult GetVentasPorArticulo(
            [FromQuery] int? idProducto = null)
        {
            try
            {
                var compras = _productosController.ObtenerProductos();

                _logger.LogInformation($"Ventas por artículo obtenidas: {compras.Count} registros encontrados");
                return Ok(compras);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al obtener ventas por artículo");
                return StatusCode(500, "Error interno del servidor: " + ex.Message);
            }
        }
    }
}

