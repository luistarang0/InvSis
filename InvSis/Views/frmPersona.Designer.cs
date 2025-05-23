namespace InvSis.Views
{
    partial class frmPersona
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
            scPersonas = new SplitContainer();
            gbAlta = new GroupBox();
            nudEdad = new NumericUpDown();
            btAlta = new Button();
            lblDatosObligatorios = new Label();
            lblEdad = new Label();
            txtNacionalidad = new TextBox();
            lblNacionalidad = new Label();
            cbSexo = new ComboBox();
            lblSexo = new Label();
            txtNombre = new TextBox();
            lblNombre = new Label();
            gbEdicionOEliminacion = new GroupBox();
            nudCambioEdad = new NumericUpDown();
            btEliminar = new Button();
            btGuardarCambios = new Button();
            lblCambioEdad = new Label();
            txtCambioNacionalidad = new TextBox();
            lblCambioNacionalidad = new Label();
            cbCambioSexo = new ComboBox();
            lblCambioSexo = new Label();
            txtCambioNombre = new TextBox();
            lblCambioNombre = new Label();
            lblSelección = new Label();
            cbSelección = new ComboBox();
            lblTitulo = new Label();
            ((System.ComponentModel.ISupportInitialize)scPersonas).BeginInit();
            scPersonas.Panel1.SuspendLayout();
            scPersonas.Panel2.SuspendLayout();
            scPersonas.SuspendLayout();
            gbAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdad).BeginInit();
            gbEdicionOEliminacion.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudCambioEdad).BeginInit();
            SuspendLayout();
            // 
            // scPersonas
            // 
            scPersonas.Dock = DockStyle.Fill;
            scPersonas.Location = new Point(0, 41);
            scPersonas.Margin = new Padding(3, 2, 3, 2);
            scPersonas.Name = "scPersonas";
            // 
            // scPersonas.Panel1
            // 
            scPersonas.Panel1.Controls.Add(gbAlta);
            // 
            // scPersonas.Panel2
            // 
            scPersonas.Panel2.Controls.Add(gbEdicionOEliminacion);
            scPersonas.Size = new Size(737, 412);
            scPersonas.SplitterDistance = 312;
            scPersonas.TabIndex = 3;
            // 
            // gbAlta
            // 
            gbAlta.Controls.Add(nudEdad);
            gbAlta.Controls.Add(btAlta);
            gbAlta.Controls.Add(lblDatosObligatorios);
            gbAlta.Controls.Add(lblEdad);
            gbAlta.Controls.Add(txtNacionalidad);
            gbAlta.Controls.Add(lblNacionalidad);
            gbAlta.Controls.Add(cbSexo);
            gbAlta.Controls.Add(lblSexo);
            gbAlta.Controls.Add(txtNombre);
            gbAlta.Controls.Add(lblNombre);
            gbAlta.Dock = DockStyle.Top;
            gbAlta.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbAlta.Location = new Point(0, 0);
            gbAlta.Margin = new Padding(3, 2, 3, 2);
            gbAlta.Name = "gbAlta";
            gbAlta.Padding = new Padding(3, 2, 3, 2);
            gbAlta.Size = new Size(312, 416);
            gbAlta.TabIndex = 0;
            gbAlta.TabStop = false;
            gbAlta.Text = "Alta de persona";
            // 
            // nudEdad
            // 
            nudEdad.Location = new Point(10, 256);
            nudEdad.Margin = new Padding(3, 2, 3, 2);
            nudEdad.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            nudEdad.Name = "nudEdad";
            nudEdad.Size = new Size(131, 27);
            nudEdad.TabIndex = 14;
            nudEdad.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // btAlta
            // 
            btAlta.AutoSize = true;
            btAlta.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btAlta.Location = new Point(200, 306);
            btAlta.Margin = new Padding(3, 2, 3, 2);
            btAlta.Name = "btAlta";
            btAlta.Size = new Size(72, 29);
            btAlta.TabIndex = 13;
            btAlta.Text = "Guardar";
            btAlta.TextAlign = ContentAlignment.MiddleRight;
            btAlta.UseVisualStyleBackColor = true;
            btAlta.Click += btAlta_Click;
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatosObligatorios.Location = new Point(10, 314);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(131, 19);
            lblDatosObligatorios.TabIndex = 8;
            lblDatosObligatorios.Text = "* Datos obligatorios";
            // 
            // lblEdad
            // 
            lblEdad.AutoSize = true;
            lblEdad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEdad.Location = new Point(10, 237);
            lblEdad.Name = "lblEdad";
            lblEdad.Size = new Size(49, 19);
            lblEdad.TabIndex = 6;
            lblEdad.Text = "Edad *";
            // 
            // txtNacionalidad
            // 
            txtNacionalidad.Location = new Point(10, 187);
            txtNacionalidad.Margin = new Padding(3, 2, 3, 2);
            txtNacionalidad.MaxLength = 20;
            txtNacionalidad.Name = "txtNacionalidad";
            txtNacionalidad.Size = new Size(261, 27);
            txtNacionalidad.TabIndex = 5;
            // 
            // lblNacionalidad
            // 
            lblNacionalidad.AutoSize = true;
            lblNacionalidad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNacionalidad.Location = new Point(10, 167);
            lblNacionalidad.Name = "lblNacionalidad";
            lblNacionalidad.Size = new Size(97, 19);
            lblNacionalidad.TabIndex = 4;
            lblNacionalidad.Text = "Nacionalidad *";
            // 
            // cbSexo
            // 
            cbSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSexo.FormattingEnabled = true;
            cbSexo.Location = new Point(10, 118);
            cbSexo.Margin = new Padding(3, 2, 3, 2);
            cbSexo.Name = "cbSexo";
            cbSexo.Size = new Size(261, 27);
            cbSexo.TabIndex = 3;
            // 
            // lblSexo
            // 
            lblSexo.AutoSize = true;
            lblSexo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSexo.Location = new Point(10, 99);
            lblSexo.Name = "lblSexo";
            lblSexo.Size = new Size(47, 19);
            lblSexo.TabIndex = 2;
            lblSexo.Text = "Sexo *";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(10, 56);
            txtNombre.Margin = new Padding(3, 2, 3, 2);
            txtNombre.MaxLength = 20;
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(261, 27);
            txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNombre.Location = new Point(10, 37);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(130, 19);
            lblNombre.TabIndex = 0;
            lblNombre.Text = "Nombre completo *";
            // 
            // gbEdicionOEliminacion
            // 
            gbEdicionOEliminacion.AutoSize = true;
            gbEdicionOEliminacion.Controls.Add(nudCambioEdad);
            gbEdicionOEliminacion.Controls.Add(btEliminar);
            gbEdicionOEliminacion.Controls.Add(btGuardarCambios);
            gbEdicionOEliminacion.Controls.Add(lblCambioEdad);
            gbEdicionOEliminacion.Controls.Add(txtCambioNacionalidad);
            gbEdicionOEliminacion.Controls.Add(lblCambioNacionalidad);
            gbEdicionOEliminacion.Controls.Add(cbCambioSexo);
            gbEdicionOEliminacion.Controls.Add(lblCambioSexo);
            gbEdicionOEliminacion.Controls.Add(txtCambioNombre);
            gbEdicionOEliminacion.Controls.Add(lblCambioNombre);
            gbEdicionOEliminacion.Controls.Add(lblSelección);
            gbEdicionOEliminacion.Controls.Add(cbSelección);
            gbEdicionOEliminacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbEdicionOEliminacion.Location = new Point(3, 0);
            gbEdicionOEliminacion.Margin = new Padding(3, 2, 3, 2);
            gbEdicionOEliminacion.Name = "gbEdicionOEliminacion";
            gbEdicionOEliminacion.Padding = new Padding(3, 2, 3, 2);
            gbEdicionOEliminacion.Size = new Size(413, 421);
            gbEdicionOEliminacion.TabIndex = 0;
            gbEdicionOEliminacion.TabStop = false;
            gbEdicionOEliminacion.Text = "Edición o eliminación de persona";
            // 
            // nudCambioEdad
            // 
            nudCambioEdad.Location = new Point(18, 316);
            nudCambioEdad.Margin = new Padding(3, 2, 3, 2);
            nudCambioEdad.Minimum = new decimal(new int[] { 18, 0, 0, 0 });
            nudCambioEdad.Name = "nudCambioEdad";
            nudCambioEdad.Size = new Size(131, 27);
            nudCambioEdad.TabIndex = 25;
            nudCambioEdad.Value = new decimal(new int[] { 18, 0, 0, 0 });
            // 
            // btEliminar
            // 
            btEliminar.AutoSize = true;
            btEliminar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btEliminar.Location = new Point(251, 368);
            btEliminar.Margin = new Padding(3, 2, 3, 2);
            btEliminar.Name = "btEliminar";
            btEliminar.Size = new Size(129, 29);
            btEliminar.TabIndex = 24;
            btEliminar.Text = "Eliminar persona";
            btEliminar.TextAlign = ContentAlignment.MiddleRight;
            btEliminar.UseVisualStyleBackColor = true;
            btEliminar.Click += btEliminar_Click;
            // 
            // btGuardarCambios
            // 
            btGuardarCambios.AutoSize = true;
            btGuardarCambios.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btGuardarCambios.Location = new Point(18, 368);
            btGuardarCambios.Margin = new Padding(3, 2, 3, 2);
            btGuardarCambios.Name = "btGuardarCambios";
            btGuardarCambios.Size = new Size(131, 29);
            btGuardarCambios.TabIndex = 23;
            btGuardarCambios.Text = "Guardar cambios";
            btGuardarCambios.TextAlign = ContentAlignment.MiddleRight;
            btGuardarCambios.UseVisualStyleBackColor = true;
            btGuardarCambios.Click += btGuardarCambios_Click;
            // 
            // lblCambioEdad
            // 
            lblCambioEdad.AutoSize = true;
            lblCambioEdad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioEdad.Location = new Point(18, 296);
            lblCambioEdad.Name = "lblCambioEdad";
            lblCambioEdad.Size = new Size(109, 19);
            lblCambioEdad.TabIndex = 21;
            lblCambioEdad.Text = "Cambio de edad";
            // 
            // txtCambioNacionalidad
            // 
            txtCambioNacionalidad.Location = new Point(18, 246);
            txtCambioNacionalidad.Margin = new Padding(3, 2, 3, 2);
            txtCambioNacionalidad.MaxLength = 20;
            txtCambioNacionalidad.Name = "txtCambioNacionalidad";
            txtCambioNacionalidad.Size = new Size(261, 27);
            txtCambioNacionalidad.TabIndex = 20;
            // 
            // lblCambioNacionalidad
            // 
            lblCambioNacionalidad.AutoSize = true;
            lblCambioNacionalidad.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioNacionalidad.Location = new Point(18, 226);
            lblCambioNacionalidad.Name = "lblCambioNacionalidad";
            lblCambioNacionalidad.Size = new Size(155, 19);
            lblCambioNacionalidad.TabIndex = 19;
            lblCambioNacionalidad.Text = "Cambio de nacionalidad";
            // 
            // cbCambioSexo
            // 
            cbCambioSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioSexo.FormattingEnabled = true;
            cbCambioSexo.Location = new Point(18, 178);
            cbCambioSexo.Margin = new Padding(3, 2, 3, 2);
            cbCambioSexo.Name = "cbCambioSexo";
            cbCambioSexo.Size = new Size(261, 27);
            cbCambioSexo.TabIndex = 18;
            // 
            // lblCambioSexo
            // 
            lblCambioSexo.AutoSize = true;
            lblCambioSexo.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioSexo.Location = new Point(18, 158);
            lblCambioSexo.Name = "lblCambioSexo";
            lblCambioSexo.Size = new Size(106, 19);
            lblCambioSexo.TabIndex = 17;
            lblCambioSexo.Text = "Cambio de sexo";
            // 
            // txtCambioNombre
            // 
            txtCambioNombre.Location = new Point(18, 116);
            txtCambioNombre.Margin = new Padding(3, 2, 3, 2);
            txtCambioNombre.MaxLength = 20;
            txtCambioNombre.Name = "txtCambioNombre";
            txtCambioNombre.Size = new Size(261, 27);
            txtCambioNombre.TabIndex = 16;
            // 
            // lblCambioNombre
            // 
            lblCambioNombre.AutoSize = true;
            lblCambioNombre.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioNombre.Location = new Point(18, 96);
            lblCambioNombre.Name = "lblCambioNombre";
            lblCambioNombre.Size = new Size(127, 19);
            lblCambioNombre.TabIndex = 15;
            lblCambioNombre.Text = "Cambio de nombre";
            // 
            // lblSelección
            // 
            lblSelección.AutoSize = true;
            lblSelección.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelección.Location = new Point(18, 37);
            lblSelección.Name = "lblSelección";
            lblSelección.Size = new Size(146, 19);
            lblSelección.TabIndex = 14;
            lblSelección.Text = "Selección de persona *";
            // 
            // cbSelección
            // 
            cbSelección.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelección.FormattingEnabled = true;
            cbSelección.Location = new Point(18, 56);
            cbSelección.Margin = new Padding(3, 2, 3, 2);
            cbSelección.Name = "cbSelección";
            cbSelección.Size = new Size(362, 27);
            cbSelección.TabIndex = 4;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(737, 41);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "CONTROL DE PERSONAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // frmPersona
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(230, 242, 248);
            ClientSize = new Size(737, 453);
            Controls.Add(scPersonas);
            Controls.Add(lblTitulo);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            ForeColor = Color.FromArgb(159, 122, 234);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmPersona";
            Text = "frmPersona";
            scPersonas.Panel1.ResumeLayout(false);
            scPersonas.Panel2.ResumeLayout(false);
            scPersonas.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scPersonas).EndInit();
            scPersonas.ResumeLayout(false);
            gbAlta.ResumeLayout(false);
            gbAlta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudEdad).EndInit();
            gbEdicionOEliminacion.ResumeLayout(false);
            gbEdicionOEliminacion.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudCambioEdad).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Label lblTitulo;
        private SplitContainer scPersonas;
        private GroupBox gbAlta;
        private Button btAlta;
        private PictureBox pbPersona;
        private Button btRegistroPersona;
        private ComboBox cbPersonas;
        private Label lblPersona;
        private Label lblDatosObligatorios;
        private ComboBox cbEstatus;
        private Label lblEdad;
        private TextBox txtNacionalidad;
        private Label lblNacionalidad;
        private ComboBox cbSexo;
        private Label lblSexo;
        private TextBox txtNombre;
        private Label lblNombre;
        private GroupBox gbEdicionOEliminacion;
        private Button btEliminar;
        private Button btGuardarCambios;
        private Label lblCambioPersona;
        private ComboBox cbCambioEstatus;
        private Label lblCambioEdad;
        private TextBox txtCambioNacionalidad;
        private Label lblCambioNacionalidad;
        private ComboBox cbCambioSexo;
        private Label lblCambioSexo;
        private TextBox txtCambioNombre;
        private Label lblCambioNombre;
        private Label lblSelección;
        private ComboBox cbSelección;
        
        private NumericUpDown nudEdad;
        private NumericUpDown nudCambioEdad;
    }
}