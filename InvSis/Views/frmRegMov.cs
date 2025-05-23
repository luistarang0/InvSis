using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace InvSis.Views
{
    public partial class frmRegMov : Form
    {
        public frmRegMov()
        {
            InitializeComponent();
            cmbEstatus.SelectedIndex = 0;
            // Establecer la fecha máxima como la fecha actual
            dtpFecha.MaxDate = DateTime.Today;

            // Establecer la fecha inicial como la fecha actual
            dtpFecha.Value = DateTime.Today;
            PoblaComboProd();
            PoblaComboOperador();
        }

        private void btnAgregarP_Click(object sender, EventArgs e)
        {
            // Validar que haya un producto seleccionado en el combo
            if (cmbProd.SelectedIndex == -1 || cmbProd.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un producto.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbProd.Focus();
                return;
            }

            // Validar que la cantidad sea mayor a cero
            if (nudCantidad.Value <= 0)
            {
                MessageBox.Show("La cantidad debe ser mayor a cero.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                nudCantidad.Focus();
                return;
            }

            // Obtener los datos del producto seleccionado
            int producto = Convert.ToInt32(cmbProd.SelectedValue);
            string nombreProducto = cmbProd.Text;
            decimal cantidad = nudCantidad.Value;

            // Verificar si el producto ya existe en la tabla
            bool productoExistente = false;
            int filaExistente = -1;

            for (int i = 0; i < dgvSeleccion.Rows.Count; i++)
            {
                if (dgvSeleccion.Rows[i].Cells["Producto"].Value != null &&
                    Convert.ToInt32(dgvSeleccion.Rows[i].Cells["Producto"].Value) == producto)
                {
                    productoExistente = true;
                    filaExistente = i;
                    break;
                }
            }

            if (productoExistente)
            {
                // Sumar la cantidad al producto existente
                decimal cantidadActual = Convert.ToDecimal(dgvSeleccion.Rows[filaExistente].Cells["Cantidad"].Value);
                dgvSeleccion.Rows[filaExistente].Cells["Cantidad"].Value = cantidadActual + cantidad;

                MessageBox.Show($"Se actualizó la cantidad del producto '{nombreProducto}'.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Agregar el nuevo producto a la tabla
                int rowIndex = dgvSeleccion.Rows.Add();
                dgvSeleccion.Rows[rowIndex].Cells["Producto"].Value = producto;
                dgvSeleccion.Rows[rowIndex].Cells["Cantidad"].Value = cantidad;

                // Agregar otros campos si los tienes, como precio, subtotal, etc.
            }

            // Opcional: Restablecer controles para el siguiente producto
            // cmbProductos.SelectedIndex = -1;
            nudCantidad.Value = 1;
            cmbProd.Focus();

        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Verificar que se haya seleccionado un tipo de movimiento
            if (cmbTipoMov.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un tipo de movimiento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbTipoMov.Focus();
                return;
            }

            // Verificar que se haya seleccionado un operador/responsable
            if (cmbOpe.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un operador o responsable.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbOpe.Focus();
                return;
            }

            // Verificar que se haya seleccionado un estatus
            if (cmbEstatus.SelectedIndex == -1)
            {
                MessageBox.Show("Debe seleccionar un estatus.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                cmbEstatus.Focus();
                return;
            }

            // Verificar que haya productos en la tabla
            if (dgvSeleccion.Rows.Count == 0 || dgvSeleccion.Rows[0].IsNewRow)
            {
                MessageBox.Show("Debe agregar al menos un producto al movimiento.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todas las validaciones pasan, proceder a guardar
            MessageBox.Show("El movimiento se ha guardado correctamente.", "Operación exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);

            LimpiarFormulario();

        }

        // Método para limpiar el formulario
        private void LimpiarFormulario()
        {
            cmbTipoMov.SelectedIndex = 0;
            cmbOpe.SelectedIndex = 0;
            cmbEstatus.SelectedIndex = 0;
            dtpFecha.Value = DateTime.Today;
            dgvSeleccion.Rows.Clear();
        }

        private void PoblaComboProd()
        {
            Dictionary<int, string> list_prod = new Dictionary<int, string>()
            {
                { 1, "p1"},
                { 2, "p2"},
            };
            // Asignar el diccionario al comboBox
            cmbProd.DataSource = new BindingSource(list_prod, null);
            cmbProd.DisplayMember = "Value";  //lo que se muestra
            cmbProd.ValueMember = "Key";      //lo que se guarda como seleccionado
            cmbProd.SelectedValue = 0;
        }

        private void PoblaComboOperador()
        {
            Dictionary<int, string> list_operador = new Dictionary<int, string>()
            {
                { 1, "o1"},
                { 2, "o2"},
            };
            // Asignar el diccionario al comboBox
            cmbOpe.DataSource = new BindingSource(list_operador, null);
            cmbOpe.DisplayMember = "Value";  //lo que se muestra
            cmbOpe.ValueMember = "Key";      //lo que se guarda como seleccionado
            cmbOpe.SelectedValue = 0;
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void dgvSeleccion_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
