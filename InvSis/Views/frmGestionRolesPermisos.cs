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
    public partial class frmGestionRolesPermisos : Form
    {
        public frmGestionRolesPermisos()
        {
            InitializeComponent();
            PoblaComboEstatus(cbEstatusRolAlta, "Activo", "Inactivo");
            PoblaComboEstatus(cbEstatusPermisoAlta, "Activo", "Inactivo");
            PoblaComboEstatus(cbCambioEstatusRol, "Activo", "Inactivo");
            PoblaComboEstatus(cbCambioEstatusPermiso, "Activo", "Inactivo");
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void PoblaComboEstatus(ComboBox comboBox, string valorActivo, string valorInactivo)
        {
            Dictionary<int, string> list_estatus = new Dictionary<int, string>()
            {
                { 1, valorActivo},
                { 0, valorInactivo},
            };
            // Asignar el diccionario al comboBox
            comboBox.DataSource = new BindingSource(list_estatus, null);
            comboBox.DisplayMember = "Value";  //lo que se muestra
            comboBox.ValueMember = "Key";      //lo que se guarda como seleccionado
            comboBox.SelectedValue = 1;
        }

        private bool DatosVaciosRol()
        {
            if (txtNombreRol.Text == "" || cbEstatusRolAlta.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GuardarRol()
        {
            if (DatosVaciosRol())
            {
                MessageBox.Show("Por favor, llene todos los campos del rol.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool SeleccionarRol()
        {
            if (cbCambioSelecciónRol.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un rol.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DatosVaciosPermiso()
        {
            if (txtDescripciónPermiso.Text == "" || cbEstatusPermisoAlta.SelectedIndex == -1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GuardarPermiso()
        {
            if (DatosVaciosPermiso())
            {
                MessageBox.Show("Por favor, llene todos los campos del permiso.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool SeleccionarPermiso()
        {
            if (cbCambioSelecciónPermiso.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un permiso.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private bool DatosVaciosAsignacion()
        {
            if (cbAsignaciónSelecciónRol.SelectedIndex == -1 ||
                (cbSelecciónPermiso1.SelectedIndex == -1 &&
                 cbSelecciónPermiso2.SelectedIndex == -1 &&
                 cbSelecciónPermiso3.SelectedIndex == -1))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private bool GuardarAsignacion()
        {
            if (DatosVaciosAsignacion())
            {
                MessageBox.Show("Por favor, seleccione un rol y al menos un permiso.", "Información del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }

        private void btAltaRol_Click(object sender, EventArgs e)
        {
            if (GuardarRol())
            {
                MessageBox.Show("Rol guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btGuardarCambiosRol_Click(object sender, EventArgs e)
        {
            if (SeleccionarRol())
            {
                MessageBox.Show("Rol editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEliminarRol_Click(object sender, EventArgs e)
        {
            if (SeleccionarRol())
            {
                MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btAltaPermiso_Click(object sender, EventArgs e)
        {
            if (GuardarPermiso())
            {
                MessageBox.Show("Permiso guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btGuardarCambiosPermiso_Click(object sender, EventArgs e)
        {
            if (SeleccionarPermiso())
            {
                MessageBox.Show("Permiso editado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btEliminarPermiso_Click(object sender, EventArgs e)
        {
            if (SeleccionarPermiso())
            {
                MessageBox.Show("Permiso eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btGuardarAsignaciónRP_Click(object sender, EventArgs e)
        {
            if (GuardarAsignacion())
            {
                MessageBox.Show("Asignación de permisos guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void lblSelecciónPermiso3_Click(object sender, EventArgs e)
        {

        }

        private void cbEstatusRolAlta_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
