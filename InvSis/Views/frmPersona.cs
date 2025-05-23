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
    public partial class frmPersona : Form
    {
        public frmPersona()
        {
            InitializeComponent();
            PoblaComboSexo(cbSexo);
            PoblaComboSexo(cbCambioSexo);
        }

        private void PoblaComboSexo(ComboBox comboBox)
        {
            Dictionary<int, string> list_estatus = new Dictionary<int, string>()
            {
                { 1, "Masculino"},
                { 0, "Femenino"},
            };
            // Asignar el diccionario al comboBox
            comboBox.DataSource = new BindingSource(list_estatus, null);
            comboBox.DisplayMember = "Value";  //lo que se muestra
            comboBox.ValueMember = "Key";      //lo que se guarda como seleccionado
        }

        private bool GuardarPersona()
        {
            if (DatosVacios())
            {
                MessageBox.Show("Por favor, llene todos los campos.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DatosVacios()
        {
            if (txtNombre.Text == "" || txtNacionalidad.Text == "" || cbSexo.SelectedIndex == -1)
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
            if (GuardarPersona())
            {
                MessageBox.Show("Persona guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btGuardarCambios_Click(object sender, EventArgs e)
        {
            if (SeleccionarPersona())
            {
                MessageBox.Show("Persona editada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool SeleccionarPersona()
        {
            if (cbSelección.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione persona.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btEliminar_Click(object sender, EventArgs e)
        {
            if (SeleccionarPersona())
            {
                MessageBox.Show("Persona eliminada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



    }
}
