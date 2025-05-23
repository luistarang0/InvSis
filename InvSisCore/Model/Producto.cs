using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Producto
    {
        /// <summary>
        /// Identificador único del producto
        /// </summary>
        public int IdProducto { get; set; }

        /// <summary>
        /// Nombre del producto
        /// </summary>
        public string Nombre { get; set; }

        /// <summary>
        /// Categoría del producto
        /// </summary>
        public string Categoria { get; set; }

        /// <summary>
        /// Costo del producto
        /// </summary>
        public decimal Costo { get; set; }

        /// <summary>
        /// Stock disponible
        /// </summary>
        public int Stock { get; set; }

        /// <summary>
        /// Ubicación del producto
        /// </summary>
        public string Ubicacion { get; set; }

        /// <summary>
        /// Clave única del producto
        /// </summary>
        public string Clave { get; set; }

        /// <summary>
        /// Estado del producto (múltiples valores según diccionario)
        /// </summary>
        public int Estatus { get; set; }

        /// <summary>
        /// Indica si aplica impuesto
        /// </summary>
        public bool AplicaImpuesto { get; set; }

        /// <summary>
        /// Identificador del impuesto aplicable
        /// </summary>
        public int? IdImpuesto { get; set; }

        /// <summary>
        /// Referencia al impuesto
        /// </summary>
        public Impuesto Impuesto { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Producto()
        {
            Nombre = string.Empty;
            Categoria = string.Empty;
            Ubicacion = string.Empty;
            Clave = string.Empty;
            Estatus = 1; // Activo por defecto
            AplicaImpuesto = false;
            Impuesto = new Impuesto();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Producto(string nombre, string clave, decimal costo)
        {
            Nombre = nombre;
            Clave = clave;
            Costo = costo;
            Categoria = string.Empty;
            Ubicacion = string.Empty;
            Estatus = 1; // Activo por defecto
            AplicaImpuesto = false;
            Impuesto = new Impuesto();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Producto(int idProducto, string nombre, string categoria, decimal costo, int stock,
                    string ubicacion, string clave, int estatus, bool aplicaImpuesto, int? idImpuesto)
        {
            IdProducto = idProducto;
            Nombre = nombre;
            Categoria = categoria;
            Costo = costo;
            Stock = stock;
            Ubicacion = ubicacion;
            Clave = clave;
            Estatus = estatus;
            AplicaImpuesto = aplicaImpuesto;
            IdImpuesto = idImpuesto;
            Impuesto = new Impuesto();
        }
    }
}
