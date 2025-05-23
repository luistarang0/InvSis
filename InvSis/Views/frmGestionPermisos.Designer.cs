
namespace InvSis.Views
{
    partial class frmGestionPermisos
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitContainer1 = new SplitContainer();
            btnAgregar = new Button();
            lblEstatus = new Label();
            lblEstatusEliminar = new Label();
            lbDescripcionPermiso = new Label();
            LBdESCpERMISO = new Label();
            cbxPermisoEliminar = new ComboBox();
            LBpERMISOeLIMINAR = new Label();
            lbEliminarPermiso = new Label();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).BeginInit();
            splitContainer1.Panel1.SuspendLayout();
            splitContainer1.Panel2.SuspendLayout();
            splitContainer1.SuspendLayout();
            SuspendLayout();
            // 
            // splitContainer1
            // 
            splitContainer1.ForeColor = Color.FromArgb(159, 122, 234);
            splitContainer1.Location = new Point(2, 40);
            splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            splitContainer1.Panel1.Controls.Add(btnAgregar);
            // 
            // splitContainer1.Panel2
            // 
            splitContainer1.Panel2.Controls.Add(lblEstatus);
            splitContainer1.Panel2.Controls.Add(lblEstatusEliminar);
            splitContainer1.Panel2.Controls.Add(lbDescripcionPermiso);
            splitContainer1.Panel2.Controls.Add(LBdESCpERMISO);
            splitContainer1.Panel2.Controls.Add(cbxPermisoEliminar);
            splitContainer1.Panel2.Controls.Add(LBpERMISOeLIMINAR);
            splitContainer1.Panel2.Controls.Add(lbEliminarPermiso);
            splitContainer1.Panel2.Paint += splitContainer1_Panel2_Paint;
            splitContainer1.Size = new Size(1340, 288);
            splitContainer1.SplitterDistance = 667;
            splitContainer1.TabIndex = 2;
            // 
            // btnAgregar
            // 
            btnAgregar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnAgregar.Location = new Point(532, 174);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(94, 33);
            btnAgregar.TabIndex = 7;
            btnAgregar.Text = "Agregar";
            btnAgregar.UseVisualStyleBackColor = true;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstatus.Location = new Point(241, 194);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(220, 21);
            lblEstatus.TabIndex = 7;
            lblEstatus.Text = "AQUI VA EL ESTATUS DEL ROL";
            // 
            // lblEstatusEliminar
            // 
            lblEstatusEliminar.AutoSize = true;
            lblEstatusEliminar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstatusEliminar.Location = new Point(32, 194);
            lblEstatusEliminar.Name = "lblEstatusEliminar";
            lblEstatusEliminar.Size = new Size(59, 21);
            lblEstatusEliminar.TabIndex = 6;
            lblEstatusEliminar.Text = "Estatus";
            // 
            // lbDescripcionPermiso
            // 
            lbDescripcionPermiso.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbDescripcionPermiso.Location = new Point(241, 94);
            lbDescripcionPermiso.Name = "lbDescripcionPermiso";
            lbDescripcionPermiso.Size = new Size(405, 83);
            lbDescripcionPermiso.TabIndex = 5;
            // 
            // LBdESCpERMISO
            // 
            LBdESCpERMISO.AutoSize = true;
            LBdESCpERMISO.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBdESCpERMISO.Location = new Point(32, 123);
            LBdESCpERMISO.Name = "LBdESCpERMISO";
            LBdESCpERMISO.Size = new Size(177, 21);
            LBdESCpERMISO.TabIndex = 4;
            LBdESCpERMISO.Text = "Descripcion del permiso";
            // 
            // cbxPermisoEliminar
            // 
            cbxPermisoEliminar.FormattingEnabled = true;
            cbxPermisoEliminar.Location = new Point(241, 56);
            cbxPermisoEliminar.Name = "cbxPermisoEliminar";
            cbxPermisoEliminar.Size = new Size(406, 23);
            cbxPermisoEliminar.TabIndex = 3;
            cbxPermisoEliminar.SelectedIndexChanged += cbxPermisoEliminar_SelectedIndexChanged;
            // 
            // LBpERMISOeLIMINAR
            // 
            LBpERMISOeLIMINAR.AutoSize = true;
            LBpERMISOeLIMINAR.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LBpERMISOeLIMINAR.Location = new Point(32, 56);
            LBpERMISOeLIMINAR.Name = "LBpERMISOeLIMINAR";
            LBpERMISOeLIMINAR.Size = new Size(139, 21);
            LBpERMISOeLIMINAR.TabIndex = 2;
            LBpERMISOeLIMINAR.Text = "Permiso a eliminar";
            // 
            // lbEliminarPermiso
            // 
            lbEliminarPermiso.AutoSize = true;
            lbEliminarPermiso.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbEliminarPermiso.Location = new Point(241, 11);
            lbEliminarPermiso.Name = "lbEliminarPermiso";
            lbEliminarPermiso.Size = new Size(174, 30);
            lbEliminarPermiso.TabIndex = 1;
            lbEliminarPermiso.Text = "Eliminar permiso";
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1347, 49);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "GESTION DE PERMISOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            lblTitulo.Click += lblTitulo_Click;
            // 
            // frmGestionPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(1347, 337);
            Controls.Add(splitContainer1);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            Name = "frmGestionPermisos";
            Text = "frmGestionPermisos";
            splitContainer1.Panel1.ResumeLayout(false);
            splitContainer1.Panel2.ResumeLayout(false);
            splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainer1).EndInit();
            splitContainer1.ResumeLayout(false);
            ResumeLayout(false);
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {
            //algo
        }

        #endregion
        private Label lblTitulo;
        private SplitContainer splitContainer1;
        private Label lbAgregarEditarPermiso;
        private Label lbEliminarPermiso;
        private Label lbEstatuS;
        private TextBox txtDescripcionPermiso;
        private Label lbDescripciopn;
        private TextBox txtNombrePermiso;
        private Label lblNombrePermiso;
        private ComboBox cbxEstatus;
        private Button btnAgregar;
        private Label lblEstatus;
        private Label lblEstatusEliminar;
        private Label lbDescripcionPermiso;
        private Label LBdESCpERMISO;
        private ComboBox cbxPermisoEliminar;
        private Label LBpERMISOeLIMINAR;
        private Button btnEliminar;
    }
}