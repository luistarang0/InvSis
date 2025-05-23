namespace InvSis.Views
{
    partial class frmUsuarios
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
            components = new System.ComponentModel.Container();
            lblTitulo = new Label();
            scUsuarios = new SplitContainer();
            gbAlta = new GroupBox();
            btAlta = new Button();
            pbPersona = new PictureBox();
            btRegistroPersona = new Button();
            cbPersonas = new ComboBox();
            lblPersona = new Label();
            lblDatosObligatorios = new Label();
            cbEstatus = new ComboBox();
            lblEstatus = new Label();
            txtContraseña = new TextBox();
            lblContraseña = new Label();
            cbRol = new ComboBox();
            lblRol = new Label();
            txtNickname = new TextBox();
            lblNickname = new Label();
            gbEdicionOEliminacion = new GroupBox();
            btEliminar = new Button();
            btGuardarCambios = new Button();
            lblCambioPersona = new Label();
            cbCambioEstatus = new ComboBox();
            lblCambioEstatus = new Label();
            txtCambioContraseña = new TextBox();
            lblCambioContraseña = new Label();
            cbCambioRol = new ComboBox();
            lblCambioRol = new Label();
            txtCambioNickname = new TextBox();
            lblCambioNickname = new Label();
            lblSelección = new Label();
            cbSelección = new ComboBox();
            ForeColor = ColorTranslator.FromHtml("#9F7AEA"); 
            Font = new Font("Segoe UI", 9F, FontStyle.Bold); 
            toolTipPersona = new ToolTip(components);
            ((System.ComponentModel.ISupportInitialize)scUsuarios).BeginInit();
            scUsuarios.Panel1.SuspendLayout();
            scUsuarios.Panel2.SuspendLayout();
            scUsuarios.SuspendLayout();
            gbAlta.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersona).BeginInit();
            gbEdicionOEliminacion.SuspendLayout();
            SuspendLayout();
            // lblTitulo 
            lblTitulo.BackColor = ColorTranslator.FromHtml("#9F7AEA"); 
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(833, 55);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "ADMINISTRACIÓN DE USUARIOS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // scUsuarios
            // 
            scUsuarios.Dock = DockStyle.Fill;
            scUsuarios.Location = new Point(0, 75);
            scUsuarios.Margin = new Padding(4, 4, 4, 4);
            scUsuarios.Name = "scUsuarios";
            // 
            // scUsuarios.Panel1
            // 
            scUsuarios.Panel1.Controls.Add(gbAlta);
            // 
            // scUsuarios.Panel2
            // 
            scUsuarios.Panel2.Controls.Add(gbEdicionOEliminacion);
            scUsuarios.Size = new Size(1041, 777);
            scUsuarios.SplitterDistance = 442;
            scUsuarios.SplitterWidth = 5;
            scUsuarios.TabIndex = 1;
            // 
            // gbAlta
            // 
            gbAlta.BackColor = ColorTranslator.FromHtml("#E6F2F8");
            gbAlta.Controls.Add(btAlta);
            gbAlta.Controls.Add(pbPersona);
            gbAlta.Controls.Add(btRegistroPersona);
            gbAlta.Controls.Add(cbPersonas);
            gbAlta.Controls.Add(lblPersona);
            gbAlta.Controls.Add(lblDatosObligatorios);
            gbAlta.Controls.Add(cbEstatus);
            gbAlta.Controls.Add(lblEstatus);
            gbAlta.Controls.Add(txtContraseña);
            gbAlta.Controls.Add(lblContraseña);
            gbAlta.Controls.Add(cbRol);
            gbAlta.Controls.Add(lblRol);
            gbAlta.Controls.Add(txtNickname);
            gbAlta.Controls.Add(lblNickname);
            gbAlta.Dock = DockStyle.Top;
            gbAlta.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbAlta.Location = new Point(0, 0);
            gbAlta.Margin = new Padding(4, 4, 4, 4);
            gbAlta.Name = "gbAlta";
            gbAlta.Padding = new Padding(4, 4, 4, 4);
            gbAlta.Size = new Size(442, 790);
            gbAlta.TabIndex = 0;
            gbAlta.TabStop = false;
            gbAlta.Text = "Alta de usuario";
            // 
            // btAlta
            // 
            btAlta.AutoSize = true;
            btAlta.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btAlta.Location = new Point(285, 719);
            btAlta.Margin = new Padding(4, 4, 4, 4);
            btAlta.Name = "btAlta";
            btAlta.Size = new Size(121, 50);
            btAlta.TabIndex = 13;
            btAlta.Text = "Guardar";
            btAlta.TextAlign = ContentAlignment.MiddleRight;
            btAlta.UseVisualStyleBackColor = true;
            btAlta.Click += btAlta_Click;
            // 
            // pbPersona
            // 
            pbPersona.Location = new Point(253, 627);
            pbPersona.Margin = new Padding(4, 4, 4, 4);
            pbPersona.Name = "pbPersona";
            pbPersona.Size = new Size(45, 44);
            pbPersona.SizeMode = PictureBoxSizeMode.StretchImage;
            pbPersona.TabIndex = 12;
            pbPersona.TabStop = false;
            toolTipPersona.SetToolTip(pbPersona, "Si no existe la persona, seleccione Registrar persona");
            // 
            // btRegistroPersona
            // 
            btRegistroPersona.AutoSize = true;
            btRegistroPersona.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btRegistroPersona.Location = new Point(15, 621);
            btRegistroPersona.Margin = new Padding(4, 4, 4, 4);
            btRegistroPersona.Name = "btRegistroPersona";
            btRegistroPersona.Size = new Size(230, 50);
            btRegistroPersona.TabIndex = 11;
            btRegistroPersona.Text = "Registrar persona";
            btRegistroPersona.UseVisualStyleBackColor = true;
            btRegistroPersona.Click += btRegistroPersona_Click;
            // 
            // cbPersonas
            // 
            cbPersonas.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPersonas.FormattingEnabled = true;
            cbPersonas.Location = new Point(15, 550);
            cbPersonas.Margin = new Padding(4, 4, 4, 4);
            cbPersonas.Name = "cbPersonas";
            cbPersonas.Size = new Size(372, 38);
            cbPersonas.TabIndex = 10;
            // 
            // lblPersona
            // 
            lblPersona.AutoSize = true;
            lblPersona.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblPersona.Location = new Point(15, 506);
            lblPersona.Margin = new Padding(4, 0, 4, 0);
            lblPersona.Name = "lblPersona";
            lblPersona.Size = new Size(101, 30);
            lblPersona.TabIndex = 9;
            lblPersona.Text = "Persona *";
            // 
            // lblDatosObligatorios
            // 
            lblDatosObligatorios.AutoSize = true;
            lblDatosObligatorios.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblDatosObligatorios.Location = new Point(15, 731);
            lblDatosObligatorios.Margin = new Padding(4, 0, 4, 0);
            lblDatosObligatorios.Name = "lblDatosObligatorios";
            lblDatosObligatorios.Size = new Size(197, 30);
            lblDatosObligatorios.TabIndex = 8;
            lblDatosObligatorios.Text = "* Datos obligatorios";
            // 
            // cbEstatus
            // 
            cbEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstatus.FormattingEnabled = true;
            cbEstatus.Location = new Point(15, 428);
            cbEstatus.Margin = new Padding(4, 4, 4, 4);
            cbEstatus.Name = "cbEstatus";
            cbEstatus.Size = new Size(372, 38);
            cbEstatus.TabIndex = 7;
            // 
            // lblEstatus
            // 
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblEstatus.Location = new Point(15, 395);
            lblEstatus.Margin = new Padding(4, 0, 4, 0);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(94, 30);
            lblEstatus.TabIndex = 6;
            lblEstatus.Text = "Estatus *";
            // 
            // txtContraseña
            // 
            txtContraseña.Location = new Point(15, 311);
            txtContraseña.Margin = new Padding(4, 4, 4, 4);
            txtContraseña.MaxLength = 20;
            txtContraseña.Name = "txtContraseña";
            txtContraseña.Size = new Size(372, 36);
            txtContraseña.TabIndex = 5;
            // 
            // lblContraseña
            // 
            lblContraseña.ForeColor = Color.MediumPurple;
            lblContraseña.AutoSize = true;
            lblContraseña.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblContraseña.Location = new Point(15, 279);
            lblContraseña.Margin = new Padding(4, 0, 4, 0);
            lblContraseña.Name = "lblContraseña";
            lblContraseña.Size = new Size(133, 30);
            lblContraseña.TabIndex = 4;
            lblContraseña.Text = "Contraseña *";
            // 
            // cbRol
            // 
            cbRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbRol.FormattingEnabled = true;
            cbRol.Location = new Point(15, 198);
            cbRol.Margin = new Padding(4, 4, 4, 4);
            cbRol.Name = "cbRol";
            cbRol.Size = new Size(372, 38);
            cbRol.TabIndex = 3;
            // 
            // lblRol
            // 
            lblRol.ForeColor = Color.MediumPurple;
            lblRol.AutoSize = true;
            lblRol.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblRol.Location = new Point(15, 165);
            lblRol.Margin = new Padding(4, 0, 4, 0);
            lblRol.Name = "lblRol";
            lblRol.Size = new Size(57, 30);
            lblRol.TabIndex = 2;
            lblRol.Text = "Rol *";
            // 
            // txtNickname
            // 
            txtNickname.Location = new Point(15, 94);
            txtNickname.Margin = new Padding(4, 4, 4, 4);
            txtNickname.MaxLength = 20;
            txtNickname.Name = "txtNickname";
            txtNickname.Size = new Size(372, 36);
            txtNickname.TabIndex = 1;
            // 
            // lblNickname
            // 
            lblNickname.ForeColor = Color.MediumPurple;
            lblNickname.AutoSize = true;
            lblNickname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblNickname.Location = new Point(15, 61);
            lblNickname.Margin = new Padding(4, 0, 4, 0);
            lblNickname.Name = "lblNickname";
            lblNickname.Size = new Size(121, 30);
            lblNickname.TabIndex = 0;
            lblNickname.Text = "Nickname *";
            // 
            // gbEdicionOEliminacion
            // 
            gbEdicionOEliminacion.BackColor = ColorTranslator.FromHtml("#E6F2F8");
            gbEdicionOEliminacion.AutoSize = true;
            gbEdicionOEliminacion.Controls.Add(btEliminar);
            gbEdicionOEliminacion.Controls.Add(btGuardarCambios);
            gbEdicionOEliminacion.Controls.Add(lblCambioPersona);
            gbEdicionOEliminacion.Controls.Add(cbCambioEstatus);
            gbEdicionOEliminacion.Controls.Add(lblCambioEstatus);
            gbEdicionOEliminacion.Controls.Add(txtCambioContraseña);
            gbEdicionOEliminacion.Controls.Add(lblCambioContraseña);
            gbEdicionOEliminacion.Controls.Add(cbCambioRol);
            gbEdicionOEliminacion.Controls.Add(lblCambioRol);
            gbEdicionOEliminacion.Controls.Add(txtCambioNickname);
            gbEdicionOEliminacion.Controls.Add(lblCambioNickname);
            gbEdicionOEliminacion.Controls.Add(lblSelección);
            gbEdicionOEliminacion.Controls.Add(cbSelección);
            gbEdicionOEliminacion.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbEdicionOEliminacion.Location = new Point(4, 0);
            gbEdicionOEliminacion.Margin = new Padding(4, 4, 4, 4);
            gbEdicionOEliminacion.Name = "gbEdicionOEliminacion";
            gbEdicionOEliminacion.Padding = new Padding(4, 4, 4, 4);
            gbEdicionOEliminacion.Size = new Size(660, 812);
            gbEdicionOEliminacion.TabIndex = 0;
            gbEdicionOEliminacion.TabStop = false;
            gbEdicionOEliminacion.Text = "Edición o eliminación de usuario";
            // 
            // btEliminar
            // 
            btEliminar.AutoSize = true;
            btEliminar.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btEliminar.Location = new Point(365, 719);
            btEliminar.Margin = new Padding(4, 4, 4, 4);
            btEliminar.Name = "btEliminar";
            btEliminar.Size = new Size(214, 50);
            btEliminar.TabIndex = 24;
            btEliminar.Text = "Eliminar usuario";
            btEliminar.TextAlign = ContentAlignment.MiddleRight;
            btEliminar.UseVisualStyleBackColor = true;
            btEliminar.Click += btEliminar_Click;
            // 
            // btGuardarCambios
            // 
            btGuardarCambios.AutoSize = true;
            btGuardarCambios.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btGuardarCambios.Location = new Point(26, 719);
            btGuardarCambios.Margin = new Padding(4, 4, 4, 4);
            btGuardarCambios.Name = "btGuardarCambios";
            btGuardarCambios.Size = new Size(225, 50);
            btGuardarCambios.TabIndex = 23;
            btGuardarCambios.Text = "Guardar cambios";
            btGuardarCambios.TextAlign = ContentAlignment.MiddleRight;
            btGuardarCambios.UseVisualStyleBackColor = true;
            btGuardarCambios.Click += btGuardarCambios_Click;
            // 
            // lblCambioPersona
            // 
            lblCambioPersona.AutoSize = true;
            lblCambioPersona.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioPersona.Location = new Point(26, 604);
            lblCambioPersona.Margin = new Padding(4, 0, 4, 0);
            lblCambioPersona.Name = "lblCambioPersona";
            lblCambioPersona.Size = new Size(501, 90);
            lblCambioPersona.TabIndex = 14;
            lblCambioPersona.Text = "Cambio de persona no disponible mediante edición, \r\nelimine al usuario y vuelva a crearlo seleccionando\r\nla persona correcta";
            // 
            // cbCambioEstatus
            // 
            cbCambioEstatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioEstatus.FormattingEnabled = true;
            cbCambioEstatus.Location = new Point(26, 526);
            cbCambioEstatus.Margin = new Padding(4, 4, 4, 4);
            cbCambioEstatus.Name = "cbCambioEstatus";
            cbCambioEstatus.Size = new Size(372, 38);
            cbCambioEstatus.TabIndex = 22;
            // 
            // lblCambioEstatus
            // 
            lblCambioEstatus.AutoSize = true;
            lblCambioEstatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioEstatus.Location = new Point(26, 494);
            lblCambioEstatus.Margin = new Padding(4, 0, 4, 0);
            lblCambioEstatus.Name = "lblCambioEstatus";
            lblCambioEstatus.Size = new Size(185, 30);
            lblCambioEstatus.TabIndex = 21;
            lblCambioEstatus.Text = "Cambio de estatus";
            // 
            // txtCambioContraseña
            // 
            txtCambioContraseña.Location = new Point(26, 410);
            txtCambioContraseña.Margin = new Padding(4, 4, 4, 4);
            txtCambioContraseña.MaxLength = 20;
            txtCambioContraseña.Name = "txtCambioContraseña";
            txtCambioContraseña.Size = new Size(372, 36);
            txtCambioContraseña.TabIndex = 20;
            // 
            // lblCambioContraseña
            // 
            lblCambioContraseña.AutoSize = true;
            lblCambioContraseña.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioContraseña.Location = new Point(26, 378);
            lblCambioContraseña.Margin = new Padding(4, 0, 4, 0);
            lblCambioContraseña.Name = "lblCambioContraseña";
            lblCambioContraseña.Size = new Size(221, 30);
            lblCambioContraseña.TabIndex = 19;
            lblCambioContraseña.Text = "Cambio de contraseña";
            // 
            // cbCambioRol
            // 
            cbCambioRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioRol.FormattingEnabled = true;
            cbCambioRol.Location = new Point(26, 296);
            cbCambioRol.Margin = new Padding(4, 4, 4, 4);
            cbCambioRol.Name = "cbCambioRol";
            cbCambioRol.Size = new Size(372, 38);
            cbCambioRol.TabIndex = 18;
            // 
            // lblCambioRol
            // 
            lblCambioRol.AutoSize = true;
            lblCambioRol.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioRol.Location = new Point(26, 264);
            lblCambioRol.Margin = new Padding(4, 0, 4, 0);
            lblCambioRol.Name = "lblCambioRol";
            lblCambioRol.Size = new Size(143, 30);
            lblCambioRol.TabIndex = 17;
            lblCambioRol.Text = "Cambio de rol";
            // 
            // txtCambioNickname
            // 
            txtCambioNickname.Location = new Point(26, 192);
            txtCambioNickname.Margin = new Padding(4, 4, 4, 4);
            txtCambioNickname.MaxLength = 20;
            txtCambioNickname.Name = "txtCambioNickname";
            txtCambioNickname.Size = new Size(372, 36);
            txtCambioNickname.TabIndex = 16;
            // 
            // lblCambioNickname
            // 
            lblCambioNickname.AutoSize = true;
            lblCambioNickname.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblCambioNickname.Location = new Point(26, 160);
            lblCambioNickname.Margin = new Padding(4, 0, 4, 0);
            lblCambioNickname.Name = "lblCambioNickname";
            lblCambioNickname.Size = new Size(208, 30);
            lblCambioNickname.TabIndex = 15;
            lblCambioNickname.Text = "Cambio de nickname";
            // 
            // lblSelección
            // 
            lblSelección.AutoSize = true;
            lblSelección.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSelección.Location = new Point(26, 61);
            lblSelección.Margin = new Padding(4, 0, 4, 0);
            lblSelección.Name = "lblSelección";
            lblSelección.Size = new Size(218, 30);
            lblSelección.TabIndex = 14;
            lblSelección.Text = "Selección de usuario *";
            // 
            // cbSelección
            // 
            cbSelección.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelección.FormattingEnabled = true;
            cbSelección.Location = new Point(26, 94);
            cbSelección.Margin = new Padding(4, 4, 4, 4);
            cbSelección.Name = "cbSelección";
            cbSelección.Size = new Size(515, 38);
            cbSelección.TabIndex = 4;
            cbSelección.SelectedIndexChanged += cbSelección_SelectedIndexChanged;
            // 
            // frmUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1041, 852);
            Controls.Add(scUsuarios);
            Controls.Add(lblTitulo);
            Margin = new Padding(4, 4, 4, 4);
            Name = "frmUsuarios";
            Text = "frmUsuarios";
            scUsuarios.Panel1.ResumeLayout(false);
            scUsuarios.Panel2.ResumeLayout(false);
            scUsuarios.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scUsuarios).EndInit();
            scUsuarios.ResumeLayout(false);
            gbAlta.ResumeLayout(false);
            gbAlta.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pbPersona).EndInit();
            gbEdicionOEliminacion.ResumeLayout(false);
            gbEdicionOEliminacion.PerformLayout();
            ResumeLayout(false);
        }
       
        #endregion

        private Label lblTitulo;
        private SplitContainer scUsuarios;
        private GroupBox gbAlta;
        private GroupBox gbEdicionOEliminacion;
        private Label lblNickname;
        private Label lblRol;
        private TextBox txtNickname;
        private ComboBox cbRol;
        private ComboBox cbEstatus;
        private Label lblEstatus;
        private TextBox txtContraseña;
        private Label lblContraseña;
        private Label lblDatosObligatorios;
        private Button btRegistroPersona;
        private ComboBox cbPersonas;
        private Label lblPersona;
        private PictureBox pbPersona;
        private ToolTip toolTipPersona;
        private Button btAlta;
        private ComboBox cbSelección;
        private Label lblSelección;
        private ComboBox comboBox1;
        private ComboBox cbCambioEstatus;
        private Label lblCambioEstatus;
        private TextBox txtCambioContraseña;
        private Label lblCambioContraseña;
        private ComboBox cbCambioRol;
        private Label lblCambioRol;
        private TextBox txtCambioNickname;
        private Label lblCambioNickname;
        private Button btGuardarCambios;
        private Label lblCambioPersona;
        private Button btEliminar;
    }
}