using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InvSis.Model
{
    public class Bitacora
    {
        /// <summary>
        /// Identificador único de la auditoría
        /// </summary>
        public int IdAuditoria { get; set; }

        /// <summary>
        /// Identificador del movimiento de producto relacionado
        /// </summary>
        public int? IdMovimientoProducto { get; set; }

        /// <summary>
        /// Identificador del usuario que realizó la acción
        /// </summary>
        public int? IdUsuario { get; set; }

        /// <summary>
        /// Identificador del equipo desde donde se realizó
        /// </summary>
        public string IdEquipo { get; set; }

        /// <summary>
        /// Nombre del equipo desde donde se realizó
        /// </summary>
        public string NombreEquipo { get; set; }

        /// <summary>
        /// Fecha y hora exacta del registro
        /// </summary>
        public DateTime Fecha { get; set; }

        /// <summary>
        /// Tipo de movimiento registrado
        /// </summary>
        public string TipoMovimiento { get; set; }

        /// <summary>
        /// Referencia al movimiento de producto
        /// </summary>
        public MovimientoProducto MovimientoProducto { get; set; }

        /// <summary>
        /// Referencia al usuario
        /// </summary>
        public Usuario Usuario { get; set; }

        /// <summary>
        /// Constructor por defecto
        /// </summary>
        public Bitacora()
        {
            IdEquipo = string.Empty;
            NombreEquipo = string.Empty;
            Fecha = DateTime.Now;
            TipoMovimiento = string.Empty;
            MovimientoProducto = new MovimientoProducto();
            Usuario = new Usuario();
        }

        /// <summary>
        /// Constructor con datos básicos
        /// </summary>
        public Bitacora(string idEquipo, string nombreEquipo, string tipoMovimiento)
        {
            IdEquipo = idEquipo;
            NombreEquipo = nombreEquipo;
            TipoMovimiento = tipoMovimiento;
            Fecha = DateTime.Now;
            MovimientoProducto = new MovimientoProducto();
            Usuario = new Usuario();
        }

        /// <summary>
        /// Constructor completo
        /// </summary>
        public Bitacora(int idAuditoria, int? idMovimientoProducto, int? idUsuario, string idEquipo,
                    string nombreEquipo, DateTime fecha, string tipoMovimiento)
        {
            IdAuditoria = idAuditoria;
            IdMovimientoProducto = idMovimientoProducto;
            IdUsuario = idUsuario;
            IdEquipo = idEquipo;
            NombreEquipo = nombreEquipo;
            Fecha = fecha;
            TipoMovimiento = tipoMovimiento;
            MovimientoProducto = new MovimientoProducto();
            Usuario = new Usuario();
        }
    }

}
