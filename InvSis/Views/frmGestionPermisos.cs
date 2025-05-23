using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvSis.Controller;
using InvSis.Model;

namespace InvSis.Views
{
    public partial class frmGestionPermisos : Form
    {
        private Permiso? permisoActual = null;
        private PermisosController _permisosController;

        public frmGestionPermisos()
        {
            InitializeComponent();
            _permisosController = new PermisosController();
            CargarComboEstatus();
            EstablecerCamposActivos(false);
            CargarComboPermisosEliminar();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();
            string descripcion = txtDescripcionPermiso.Text.Trim();
            int estatus = (int)cbxEstatus.SelectedValue;

            if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(descripcion))
            {
                MessageBox.Show("Por favor, completa todos los campos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (permisoActual == null)
            {
                // Agregar nuevo permiso
                Permiso nuevo = new Permiso
                {
                    Descripcion = nombre,
                    Estatus = estatus
                };

                bool exito = _permisosController.GuardarPermiso(nuevo);

                if (exito)
                {
                    MessageBox.Show("Permiso agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposPermiso();
                    CargarComboPermisosEliminar();
                }
                else
                {
                    MessageBox.Show("Error al agregar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarComboPermisosEliminar();
                }
            }
            else
            {
                // Editar permiso existente
                permisoActual.Descripcion = descripcion;
                permisoActual.Estatus = estatus;

                bool exito = _permisosController.GuardarPermiso(permisoActual);

                if (exito)
                {
                    MessageBox.Show("Permiso actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarCamposPermiso();
                    CargarComboPermisosEliminar();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    CargarComboPermisosEliminar();
                }
            }
        }

        private void cbxEstatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CargarComboEstatus()
        {
            var estatus = new Dictionary<int, string>
            {
                { 1, "Activo" },
                { 2, "Inactivo" }
            };

            cbxEstatus.DataSource = new BindingSource(estatus, null);
            cbxEstatus.DisplayMember = "Value";
            cbxEstatus.ValueMember = "Key";
        }

        private void EstablecerCamposActivos(bool activos)
        {
            txtDescripcionPermiso.Enabled = activos;
            cbxEstatus.Enabled = activos;
            btnAgregar.Enabled = activos;
        }

        private void txtNombrePermiso_TextChanged(object sender, EventArgs e)
        {
            string nombre = txtNombrePermiso.Text.Trim();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                EstablecerCamposActivos(false);
                txtDescripcionPermiso.Clear();
                cbxEstatus.SelectedIndex = 0;
                btnAgregar.Text = "Agregar";
                permisoActual = null;
                return;
            }

            // Verificamos si ya existe
            if (_permisosController.ExistePermiso(nombre))
            {
                permisoActual = _permisosController.ObtenerPermisoPorDescripcion(nombre);
                if (permisoActual != null)
                {
                    txtDescripcionPermiso.Text = permisoActual.Descripcion;
                    cbxEstatus.SelectedValue = permisoActual.Estatus;
                    EstablecerCamposActivos(true);
                    btnAgregar.Text = "Editar";
                }
            }
            else
            {
                permisoActual = null;
                txtDescripcionPermiso.Clear();
                cbxEstatus.SelectedIndex = 0;
                EstablecerCamposActivos(true);
                btnAgregar.Text = "Agregar";
            }
        }

        private void LimpiarCamposPermiso()
        {
            txtNombrePermiso.Clear();
            txtDescripcionPermiso.Clear();
            cbxEstatus.SelectedIndex = 0;
            EstablecerCamposActivos(false);
            btnAgregar.Text = "Agregar";
            permisoActual = null;
        }

        private void cbxPermisoEliminar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPermisoEliminar.SelectedItem is Permiso permiso)
            {
                lbDescripcionPermiso.Text = permiso.Descripcion;
                lblEstatus.Text = permiso.Estatus == 1 ? "Activo" : "Inactivo";
                lblEstatus.ForeColor = permiso.Estatus == 1 ? Color.Green : Color.Red;
            }
            else
            {
                lbDescripcionPermiso.Text = "";
                lblEstatus.Text = "";
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbxPermisoEliminar.SelectedItem is not Permiso permisoSeleccionado)
            {
                MessageBox.Show("Selecciona un permiso a eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show($"¿Estás seguro de eliminar el permiso \"{permisoSeleccionado.Descripcion}\"?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                bool exito = _permisosController.EliminarPermiso(permisoSeleccionado.IdPermiso);

                if (exito)
                {
                    MessageBox.Show("Permiso eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarComboPermisosEliminar();
                    lbDescripcionPermiso.Text = "";
                    lblEstatus.Text = "";
                }
                else
                {
                    MessageBox.Show("Error al eliminar el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void CargarComboPermisosEliminar()
        {
            var permisos = _permisosController.ObtenerPermisos(true); // true = traer Activos
            cbxPermisoEliminar.DataSource = null;
            cbxPermisoEliminar.DataSource = permisos;
            cbxPermisoEliminar.DisplayMember = "Descripcion";
            cbxPermisoEliminar.ValueMember = "IdPermiso";
        }

        private void lblTitulo_Click(object sender, EventArgs e)
        {

        }
    }
}
