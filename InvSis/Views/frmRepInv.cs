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
    public partial class frmRepInv : Form
    {
        public frmRepInv()
        {
            InitializeComponent();
            // Establecer la fecha máxima como la fecha actual
            dtpFin.MaxDate = DateTime.Today;

            // Establecer la fecha inicial como la fecha actual
            dtpFin.Value = DateTime.Today;
            cmbCat.SelectedIndex = 0;
            cmbMov.SelectedIndex = 0;
        }

        private void dtpFin_ValueChanged(object sender, EventArgs e)
        {
            if (dtpFin.Value > DateTime.Today)
            {                
                // Revertir a la fecha actual
                dtpFin.Value = DateTime.Today;
            }
        }

        private void btnApF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Aplica los filtros a la tabla",
                    "Filtrado", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
