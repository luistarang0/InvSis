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
    public partial class frmUsuarios : Form
    {
        public frmUsuarios()
        {
            InitializeComponent();
            PoblaComboEstatus(cbEstatus);
            PoblaComboEstatus(cbCambioEstatus);
        }

        private void PoblaComboEstatus(ComboBox comboBox)
        {
            Dictionary<int, string> list_estatus = new Dictionary<int, string>()
            {
                { 1, "Activo"},
                { 0, "Inactivo"},
            };
            // Asignar el diccionario al comboBox
            comboBox.DataSource = new BindingSource(list_estatus, null);
            comboBox.DisplayMember = "Value";  //lo que se muestra
            comboBox.ValueMember = "Key";      //lo que se guarda como seleccionado

            comboBox.SelectedValue = 1;
        }

        private bool GuardarUsuario()
        {
            if (DatosVacios())
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool SeleccionarUsuario()
        {
            if (cbSelección.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione usuario.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DatosVacios()
        {
            if (txtNickname.Text == "" || txtContraseña.Text == "" || cbRol.SelectedIndex == -1
                || cbEstatus.SelectedIndex == -1 || cbPersonas.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void btAlta_Click(object sender, EventArgs e)
        {
            if (GuardarUsuario())
            {
                MessageBox.Show("Usuario guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btRegistroPersona_Click(object sender, EventArgs e)
        {
            frmPersona formPersona = new frmPersona();
            formPersona.ShowDialog();
        }


        private void btGuardarCambios_Click(object sender, EventArgs e)
        {
            if (SeleccionarUsuario())
            {
                MessageBox.Show("Usuario editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (SeleccionarUsuario())
            {
                MessageBox.Show("Usuario eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cbSelección_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
