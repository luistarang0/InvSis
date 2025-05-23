using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using InvSis.Business;
using InvSis.Views;

namespace InvSis.Views
{
    public partial class frmLogIn : Form
    {
        public frmLogIn()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnIniciarSesion_Click(object sender, EventArgs e)
        {
            // Validaciones 

            // Validar que el campo usuario no este vacio
            if (string.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                MessageBox.Show("El campo de usuario no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que el campo contraseña no este vacio
            if (string.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                MessageBox.Show("El campo de contraseña no puede de estar vacio. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (txtUsuario.Text.Trim().ToLower() == "admin")
            {
                // Si es admin, permitir acceso sin validar formato
                Sesion.IniciarSesion(txtUsuario.Text);
                MessageBox.Show("Ha iniciado sesion como administrador. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            // Validar que el campo usuario tenga un formato correcto

            if (!UsuarioNegocio.EsFormatoValido(txtUsuario.Text))
            {
                MessageBox.Show("El campo usuario no tiene un formato correcto. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            Sesion.IniciarSesion(txtUsuario.Text);
            MessageBox.Show("Ha iniciado sesion. ", "Informacion del sistema", MessageBoxButtons.OK, MessageBoxIcon.Information);
            
                    
            this.DialogResult = DialogResult.OK;
            this.Close();
            
        }
    }
}
