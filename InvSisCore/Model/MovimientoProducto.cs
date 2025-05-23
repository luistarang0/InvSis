using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class MovimientoProducto
    {
        /// <summary>
        /// Identificador único del movimiento de producto
        /// </summary>
        public int IdMovimientoProducto { get; set; }

        /// <summary>
        /// Identificador del producto asociado
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Identificador del movimiento asociado
        /// </summary>
        public int IdMovimiento { get; set; }

        /// <summary>
        /// Cantidad de productos
        /// </summary>
        public int Cantidad { get; set; }

        /// <summary>
        /// Fecha del movimiento de producto
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Referencia al producto
        /// </summary>
        public Producto Producto { get; set; }

        /// <summary>
        /// Referencia al movimiento
        /// </summary>
        public Movimiento Movimiento { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public MovimientoProducto()
        {
            Fecha = DateTime.Now;
            Cantidad = 0;
            Producto = new Producto();
            Movimiento = new Movimiento();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public MovimientoProducto(int idProducto, int idMovimiento, int cantidad)
        {
            IdProducto = idProducto;
            IdMovimiento = idMovimiento;
            Cantidad = cantidad;
            Fecha = DateTime.Now;
            Producto = new Producto();
            Movimiento = new Movimiento();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public MovimientoProducto(int idMovimientoProducto, int idProducto, int idMovimiento, int cantidad, DateTime fecha)
        {
            IdMovimientoProducto = idMovimientoProducto;
            IdProducto = idProducto;
            IdMovimiento = idMovimiento;
            Cantidad = cantidad;
            Fecha = fecha;
            Producto = new Producto();
            Movimiento = new Movimiento();
        }
    }

}
