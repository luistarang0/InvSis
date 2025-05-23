using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvSis.Controller;
using InvSis.Model;

namespace InvSis.Views
{
    public partial class frmGestionRoles : Form
    {
        private RolesController _rolesController = new RolesController();
        private Rol? rolEncontrado = null;

        public frmGestionRoles()
        {
            InitializeComponent();
            CargarEstatusCombo();
            CargarComboRolesEliminar();
            CargarPermisosActivosEnCombo();

        }

        private void iconMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void btnAgregarRol_Click(object sender, EventArgs e)
        {
            string nombre = txtNombreRol.Text.Trim();
            int estatus = (int)cbxEstatus.SelectedValue;

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Por favor, ingresa un nombre para el rol.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si estamos en modo Agregar
            if (rolEncontrado == null)
            {
                if (_rolesController.ExisteRol(nombre))
                {
                    // Cambiar a modo edición
                    rolEncontrado = _rolesController.ObtenerTodosLosRoles(false).FirstOrDefault(r => r.NombreRol.Equals(nombre, StringComparison.OrdinalIgnoreCase));

                    if (rolEncontrado != null)
                    {
                        txtNombreRol.Text = rolEncontrado.NombreRol;
                        cbxEstatus.SelectedValue = rolEncontrado.Estatus;
                        btnAgregarRol.Text = "Editar";
                        MessageBox.Show("El rol ya existe. Puedes modificarlo y presionar 'Editar' para actualizar.", "Rol existente", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                // Insertar nuevo rol
                Rol nuevo = new Rol
                {
                    NombreRol = nombre,
                    Estatus = estatus
                };

                bool exito = _rolesController.GuardarRol(nuevo);

                if (exito)
                {
                    MessageBox.Show("Rol agregado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioRol();
                    CargarComboRolesEliminar();
                }
                else
                {
                    MessageBox.Show("Error al agregar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Modo edición
                rolEncontrado.NombreRol = nombre;
                rolEncontrado.Estatus = estatus;

                bool exito = _rolesController.GuardarRol(rolEncontrado);

                if (exito)
                {
                    MessageBox.Show("Rol actualizado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LimpiarFormularioRol();
                    CargarComboRolesEliminar();
                }
                else
                {
                    MessageBox.Show("Error al actualizar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (cbxRolEliminar.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un rol para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol = (int)cbxRolEliminar.SelectedValue;
            string nombreRol = ((Rol)cbxRolEliminar.SelectedItem).NombreRol;

            DialogResult confirmacion = MessageBox.Show($"¿Estás seguro de eliminar el rol '{nombreRol}'?",
                "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmacion == DialogResult.Yes)
            {
                bool exito = _rolesController.EliminarRol(idRol);

                if (exito)
                {
                    MessageBox.Show("Rol eliminado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    CargarComboRolesEliminar();
                }
                else
                {
                    MessageBox.Show("No se pudo eliminar el rol.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void CargarEstatusCombo()
        {
            // Puedes usar un diccionario para mostrar texto pero usar el valor correspondiente
            var estatusItems = new Dictionary<int, string>
            {
                { 1, "Activo" },
                { 2, "Inactivo" }
            };

            cbxEstatus.DataSource = new BindingSource(estatusItems, null);
            cbxEstatus.DisplayMember = "Value";
            cbxEstatus.ValueMember = "Key";
        }

        private void CargarComboRolesEliminar()
        {
            var listaRoles = _rolesController.ObtenerTodosLosRoles(); // Puede filtrar activos si gustas

            cbxRolEliminar.DataSource = null;
            cbxRolEliminar.DataSource = listaRoles;
            cbxRolEliminar.DisplayMember = "Nombre";
            cbxRolEliminar.ValueMember = "IdRol";
        }

        private void CargarComboRolesAgregarPermisos()
        {
            var listaRoles = _rolesController.ObtenerTodosLosRoles();
            cbxRolAgregarPermisos.DataSource = null;
            cbxRolAgregarPermisos.DataSource = listaRoles;
            cbxRolAgregarPermisos.DisplayMember = "Nombre";
            cbxRolAgregarPermisos.ValueMember = "IdRol";
        }

        private void LimpiarFormularioRol()
        {
            txtNombreRol.Clear();
            cbxEstatus.SelectedIndex = 0;
            rolEncontrado = null;
            btnAgregarRol.Text = "Agregar";
        }

        private void CargarPermisosActivosEnCombo()
        {
            var permisos = _rolesController.ObtenerPermisos(true); // true = solo permisos activos

            cbxPermiso.DataSource = null;
            cbxPermiso.DataSource = permisos;
            cbxPermiso.DisplayMember = "Descripcion";
            cbxPermiso.ValueMember = "IdPermiso";
        }

        private void cbxRolAgregarPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxPermiso.SelectedItem is Permiso permisoSeleccionado)
            {
                lblContenidoDescripcion.Text = permisoSeleccionado.Descripcion;

                lbEstatusRol.Text = permisoSeleccionado.Estatus == 1
                    ? "Activo"
                    : "Inactivo";

                lbEstatusRol.ForeColor = permisoSeleccionado.Estatus == 1
                    ? Color.Green
                    : Color.Red;
            }
            else
            {
                lblContenidoDescripcion.Text = "";
                lbEstatusRol.Text = "";
            }
        }

        private void CargarRolesEnComboRemover()
        {
            var roles = _rolesController.ObtenerTodosLosRoles();
            cbxRolRemoverPermisos.DataSource = null;
            cbxRolRemoverPermisos.DataSource = roles;
            cbxRolRemoverPermisos.DisplayMember = "Nombre";
            cbxRolRemoverPermisos.ValueMember = "IdRol";
        }

        private void btnAgregarPermiso_Click(object sender, EventArgs e)
        {
            if (cbxRolAgregarPermisos.SelectedValue == null || cbxPermiso.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un rol y un permiso antes de continuar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol = (int)cbxRolAgregarPermisos.SelectedValue;
            int idPermiso = (int)cbxPermiso.SelectedValue;

            // Aquí llamamos a un método que asigna el permiso al rol
            bool exito = _rolesController.AsignarPermisoARol(idRol, idPermiso);

            if (exito)
            {
                MessageBox.Show("Permiso asignado correctamente al rol.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // Aquí podrías actualizar una tabla de permisos asignados si la tienes
            }
            else
            {
                MessageBox.Show("Error al asignar el permiso. Es posible que ya esté asignado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cbxRolRemoverPermisos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbxRolRemoverPermisos.SelectedValue is int idRol)
            {
                var permisosAsignados = _rolesController.ObtenerPermisosDeRol(idRol); // Método en el controller

                cbxPermisoAremover.DataSource = null;
                cbxPermisoAremover.DataSource = permisosAsignados;
                cbxPermisoAremover.DisplayMember = "Descripcion";
                cbxPermisoAremover.ValueMember = "IdPermiso";
            }
        }

        private void btnRemoverPermiso_Click(object sender, EventArgs e)
        {
            if (cbxRolRemoverPermisos.SelectedValue == null || cbxPermisoAremover.SelectedValue == null)
            {
                MessageBox.Show("Selecciona un rol y un permiso para remover.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idRol = (int)cbxRolRemoverPermisos.SelectedValue;
            int idPermiso = (int)cbxPermisoAremover.SelectedValue;

            DialogResult confirm = MessageBox.Show("¿Estás seguro de remover este permiso del rol?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes)
            {
                bool exito = _rolesController.RemoverPermisoDeRol(idRol, idPermiso);

                if (exito)
                {
                    MessageBox.Show("Permiso removido correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    cbxRolRemoverPermisos_SelectedIndexChanged(null, null); // Recargar lista de permisos asignados
                }
                else
                {
                    MessageBox.Show("Error al remover el permiso.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void lbEstatusRol_Click(object sender, EventArgs e)
        {

        }
    }
}
