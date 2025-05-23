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
    public partial class frmDetalleProductoForm : Form
    {
        public frmDetalleProductoForm()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Validaciones
            // Validar que el campo categoria no este vacio
            if (string.IsNullOrEmpty(txtCategoria.Text))
            {
                MessageBox.Show("El campo categoria no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el campo costo no este vacio
            if (string.IsNullOrEmpty(txtCosto.Text))
            {
                MessageBox.Show("El campo costo no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el campo idProducto no este vacio
            if (string.IsNullOrEmpty(txtIdProducto.Text))
            {
                MessageBox.Show("El campo IdProducto no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el campo nombre no este vacio
            if (string.IsNullOrEmpty(txtNombre.Text))
            {
                MessageBox.Show("El campo nombre no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el campo stock no este vacio
            if (string.IsNullOrEmpty(txtStock.Text))
            {
                MessageBox.Show("El campo stock no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // Validar que el campo ubicacion no este vacio
            if (string.IsNullOrEmpty(txtUbicacion.Text))
            {
                MessageBox.Show("El campo ubicacion no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            MessageBox.Show("Producto guardado. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
