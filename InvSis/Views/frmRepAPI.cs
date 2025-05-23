using InvSis.Business;
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
    public partial class frmRepAPI : Form
    {
        public frmRepAPI()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            // Verificar si ambos campos están vacíos
            if (string.IsNullOrWhiteSpace(txtBusID.Text) && string.IsNullOrWhiteSpace(txtBusNom.Text))
            {
                MessageBox.Show("Debe ingresar al menos un criterio de búsqueda (código o nombre).",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBusID.Focus();
                return;
            }

            // Si ambos campos tienen datos, priorizar búsqueda por clave
            if (!string.IsNullOrWhiteSpace(txtBusID.Text) && !string.IsNullOrWhiteSpace(txtBusNom.Text))
            {
                MessageBox.Show("Se ha detectado información en ambos campos. La búsqueda se realizará por clave.",
                    "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Si hay clave, verificar que sea válida antes de buscar
            if (!string.IsNullOrWhiteSpace(txtBusID.Text))
            {
                if (ClaveProducto.ValidarCodigoProducto(txtBusID.Text))
                {
                    // Realizar búsqueda por clave
                    // BuscarPorClave(txtBusID.Text);
                }
                else
                {
                    MessageBox.Show("El código ingresado no es válido.",
                        "Código inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtBusID.Focus();
                    return;
                }
            }
            // Si no hay clave pero sí hay nombre, buscar por nombre
            else if (!string.IsNullOrWhiteSpace(txtBusNom.Text))
            {
                // Realizar búsqueda por nombre
                // BuscarPorNombre(txtBusNom.Text);
            }

        }

        private void btnEnviar_Click(object sender, EventArgs e)
        {
            if (dgvProductos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto de la tabla para enviar la información.",
                    "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } else
            {
                // Validar que el Stock del producto sea mayor a 0
                // Validar que el producto no esté en estado de baja
                // Llamar al método de envío de información
            }

        }
    }
}
