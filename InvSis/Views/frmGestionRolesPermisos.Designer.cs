namespace InvSis.Views
{
    partial class frmGestionRolesPermisos
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
            lblTitulo = new Label();
            gbRoles = new GroupBox();
            scRoles = new SplitContainer();
            btAltaRol = new Button();
            cbEstatusRolAlta = new ComboBox();
            lblEstatusRol = new Label();
            txtNombreRol = new TextBox();
            lblNombreRol = new Label();
            lblAltaRol = new Label();
            btEliminarRol = new Button();
            txtCambioNombreRol = new TextBox();
            lblCambioNombreRol = new Label();
            cbCambioSelecciónRol = new ComboBox();
            btGuardarCambiosRol = new Button();
            cbCambioEstatusRol = new ComboBox();
            lblCambioEstatusRol = new Label();
            lblSelecciónRol = new Label();
            lblEdiciónOEliminaciónRol = new Label();
            gbPermisos = new GroupBox();
            scPermisos = new SplitContainer();
            btAltaPermiso = new Button();
            cbEstatusPermisoAlta = new ComboBox();
            lblEstatusPermiso = new Label();
            txtDescripciónPermiso = new TextBox();
            lblDescripciónPermiso = new Label();
            lblAltaPermiso = new Label();
            btEliminarPermiso = new Button();
            txtCambioDescripciónPermiso = new TextBox();
            lblCambioDescripciónPermiso = new Label();
            cbCambioSelecciónPermiso = new ComboBox();
            btGuardarCambiosPermiso = new Button();
            cbCambioEstatusPermiso = new ComboBox();
            lblCambioEstatusPermiso = new Label();
            lblSelecciónPermiso = new Label();
            lblEdiciónOEliminaciónPermiso = new Label();
            gbAsignaciónRP = new GroupBox();
            btGuardarAsignaciónRP = new Button();
            cbSelecciónPermiso3 = new ComboBox();
            lblSelecciónPermiso3 = new Label();
            cbSelecciónPermiso2 = new ComboBox();
            lblSelecciónPermiso2 = new Label();
            cbSelecciónPermiso1 = new ComboBox();
            lblSelecciónPermiso1 = new Label();
            cbAsignaciónSelecciónRol = new ComboBox();
            lblAsignaciónSelecciónRol = new Label();
            gbRoles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scRoles).BeginInit();
            scRoles.Panel1.SuspendLayout();
            scRoles.Panel2.SuspendLayout();
            scRoles.SuspendLayout();
            gbPermisos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scPermisos).BeginInit();
            scPermisos.Panel1.SuspendLayout();
            scPermisos.Panel2.SuspendLayout();
            scPermisos.SuspendLayout();
            gbAsignaciónRP.SuspendLayout();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = SystemColors.InactiveCaption;
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI Symbol", 15F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = SystemColors.ActiveCaptionText;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1347, 37);
            lblTitulo.TabIndex = 1;
            lblTitulo.Text = "Gestión de roles y permisos (PRUEBA)";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbRoles
            // 
            gbRoles.Controls.Add(scRoles);
            gbRoles.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbRoles.Location = new Point(6, 39);
            gbRoles.Margin = new Padding(3, 2, 3, 2);
            gbRoles.Name = "gbRoles";
            gbRoles.Padding = new Padding(3, 2, 3, 2);
            gbRoles.Size = new Size(673, 629);
            gbRoles.TabIndex = 2;
            gbRoles.TabStop = false;
            gbRoles.Text = "Roles";
            // 
            // scRoles
            // 
            scRoles.Dock = DockStyle.Fill;
            scRoles.Location = new Point(3, 21);
            scRoles.Margin = new Padding(3, 2, 3, 2);
            scRoles.Name = "scRoles";
            scRoles.Orientation = Orientation.Horizontal;
            // 
            // scRoles.Panel1
            // 
            scRoles.Panel1.Controls.Add(btAltaRol);
            scRoles.Panel1.Controls.Add(cbEstatusRolAlta);
            scRoles.Panel1.Controls.Add(lblEstatusRol);
            scRoles.Panel1.Controls.Add(txtNombreRol);
            scRoles.Panel1.Controls.Add(lblNombreRol);
            scRoles.Panel1.Controls.Add(lblAltaRol);
            // 
            // scRoles.Panel2
            // 
            scRoles.Panel2.Controls.Add(btEliminarRol);
            scRoles.Panel2.Controls.Add(txtCambioNombreRol);
            scRoles.Panel2.Controls.Add(lblCambioNombreRol);
            scRoles.Panel2.Controls.Add(cbCambioSelecciónRol);
            scRoles.Panel2.Controls.Add(btGuardarCambiosRol);
            scRoles.Panel2.Controls.Add(cbCambioEstatusRol);
            scRoles.Panel2.Controls.Add(lblCambioEstatusRol);
            scRoles.Panel2.Controls.Add(lblSelecciónRol);
            scRoles.Panel2.Controls.Add(lblEdiciónOEliminaciónRol);
            scRoles.Size = new Size(667, 606);
            scRoles.SplitterDistance = 282;
            scRoles.SplitterWidth = 2;
            scRoles.TabIndex = 0;
            scRoles.SplitterMoved += splitContainer1_SplitterMoved;
            // 
            // btAltaRol
            // 
            btAltaRol.AutoSize = true;
            btAltaRol.Location = new Point(335, 216);
            btAltaRol.Margin = new Padding(3, 2, 3, 2);
            btAltaRol.Name = "btAltaRol";
            btAltaRol.Size = new Size(105, 34);
            btAltaRol.TabIndex = 5;
            btAltaRol.Text = "Guardar";
            btAltaRol.TextAlign = ContentAlignment.MiddleRight;
            btAltaRol.UseVisualStyleBackColor = true;
            btAltaRol.Click += btAltaRol_Click;
            // 
            // cbEstatusRolAlta
            // 
            cbEstatusRolAlta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstatusRolAlta.FormattingEnabled = true;
            cbEstatusRolAlta.Location = new Point(25, 218);
            cbEstatusRolAlta.Margin = new Padding(3, 2, 3, 2);
            cbEstatusRolAlta.Name = "cbEstatusRolAlta";
            cbEstatusRolAlta.Size = new Size(111, 27);
            cbEstatusRolAlta.TabIndex = 4;
            cbEstatusRolAlta.SelectedIndexChanged += cbEstatusRolAlta_SelectedIndexChanged;
            // 
            // lblEstatusRol
            // 
            lblEstatusRol.AutoSize = true;
            lblEstatusRol.Location = new Point(25, 181);
            lblEstatusRol.Name = "lblEstatusRol";
            lblEstatusRol.Size = new Size(96, 19);
            lblEstatusRol.TabIndex = 3;
            lblEstatusRol.Text = "Estatus *";
            // 
            // txtNombreRol
            // 
            txtNombreRol.Location = new Point(227, 71);
            txtNombreRol.Margin = new Padding(3, 2, 3, 2);
            txtNombreRol.MaxLength = 20;
            txtNombreRol.Name = "txtNombreRol";
            txtNombreRol.Size = new Size(216, 26);
            txtNombreRol.TabIndex = 2;
            // 
            // lblNombreRol
            // 
            lblNombreRol.AutoSize = true;
            lblNombreRol.Location = new Point(25, 74);
            lblNombreRol.Name = "lblNombreRol";
            lblNombreRol.Size = new Size(95, 19);
            lblNombreRol.TabIndex = 1;
            lblNombreRol.Text = "Nombre *";
            // 
            // lblAltaRol
            // 
            lblAltaRol.AutoSize = true;
            lblAltaRol.Location = new Point(5, 3);
            lblAltaRol.Name = "lblAltaRol";
            lblAltaRol.Size = new Size(104, 19);
            lblAltaRol.TabIndex = 0;
            lblAltaRol.Text = "Alta de rol";
            // 
            // btEliminarRol
            // 
            btEliminarRol.AutoSize = true;
            btEliminarRol.Location = new Point(348, 274);
            btEliminarRol.Margin = new Padding(3, 2, 3, 2);
            btEliminarRol.Name = "btEliminarRol";
            btEliminarRol.Size = new Size(142, 34);
            btEliminarRol.TabIndex = 15;
            btEliminarRol.Text = "Eliminar rol";
            btEliminarRol.TextAlign = ContentAlignment.MiddleRight;
            btEliminarRol.UseVisualStyleBackColor = true;
            btEliminarRol.Click += btEliminarRol_Click;
            // 
            // txtCambioNombreRol
            // 
            txtCambioNombreRol.Location = new Point(348, 116);
            txtCambioNombreRol.Margin = new Padding(3, 2, 3, 2);
            txtCambioNombreRol.MaxLength = 20;
            txtCambioNombreRol.Name = "txtCambioNombreRol";
            txtCambioNombreRol.Size = new Size(95, 26);
            txtCambioNombreRol.TabIndex = 14;
            // 
            // lblCambioNombreRol
            // 
            lblCambioNombreRol.AutoSize = true;
            lblCambioNombreRol.Location = new Point(348, 79);
            lblCambioNombreRol.Name = "lblCambioNombreRol";
            lblCambioNombreRol.Size = new Size(77, 19);
            lblCambioNombreRol.TabIndex = 13;
            lblCambioNombreRol.Text = "Nombre";
            // 
            // cbCambioSelecciónRol
            // 
            cbCambioSelecciónRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioSelecciónRol.FormattingEnabled = true;
            cbCambioSelecciónRol.Location = new Point(25, 116);
            cbCambioSelecciónRol.Margin = new Padding(3, 2, 3, 2);
            cbCambioSelecciónRol.Name = "cbCambioSelecciónRol";
            cbCambioSelecciónRol.Size = new Size(110, 27);
            cbCambioSelecciónRol.TabIndex = 12;
            // 
            // btGuardarCambiosRol
            // 
            btGuardarCambiosRol.AutoSize = true;
            btGuardarCambiosRol.Location = new Point(348, 173);
            btGuardarCambiosRol.Margin = new Padding(3, 2, 3, 2);
            btGuardarCambiosRol.Name = "btGuardarCambiosRol";
            btGuardarCambiosRol.Size = new Size(201, 34);
            btGuardarCambiosRol.TabIndex = 11;
            btGuardarCambiosRol.Text = "Guardar cambios";
            btGuardarCambiosRol.TextAlign = ContentAlignment.MiddleRight;
            btGuardarCambiosRol.UseVisualStyleBackColor = true;
            btGuardarCambiosRol.Click += btGuardarCambiosRol_Click;
            // 
            // cbCambioEstatusRol
            // 
            cbCambioEstatusRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioEstatusRol.FormattingEnabled = true;
            cbCambioEstatusRol.Location = new Point(25, 276);
            cbCambioEstatusRol.Margin = new Padding(3, 2, 3, 2);
            cbCambioEstatusRol.Name = "cbCambioEstatusRol";
            cbCambioEstatusRol.Size = new Size(111, 27);
            cbCambioEstatusRol.TabIndex = 10;
            // 
            // lblCambioEstatusRol
            // 
            lblCambioEstatusRol.AutoSize = true;
            lblCambioEstatusRol.Location = new Point(25, 236);
            lblCambioEstatusRol.Name = "lblCambioEstatusRol";
            lblCambioEstatusRol.Size = new Size(78, 19);
            lblCambioEstatusRol.TabIndex = 9;
            lblCambioEstatusRol.Text = "Estatus";
            // 
            // lblSelecciónRol
            // 
            lblSelecciónRol.AutoSize = true;
            lblSelecciónRol.Location = new Point(25, 79);
            lblSelecciónRol.Name = "lblSelecciónRol";
            lblSelecciónRol.Size = new Size(174, 19);
            lblSelecciónRol.TabIndex = 7;
            lblSelecciónRol.Text = "Selección de rol *";
            // 
            // lblEdiciónOEliminaciónRol
            // 
            lblEdiciónOEliminaciónRol.AutoSize = true;
            lblEdiciónOEliminaciónRol.Location = new Point(25, 16);
            lblEdiciónOEliminaciónRol.Name = "lblEdiciónOEliminaciónRol";
            lblEdiciónOEliminaciónRol.Size = new Size(258, 19);
            lblEdiciónOEliminaciónRol.TabIndex = 6;
            lblEdiciónOEliminaciónRol.Text = "Edición o eliminación de rol";
            // 
            // gbPermisos
            // 
            gbPermisos.Controls.Add(scPermisos);
            gbPermisos.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbPermisos.Location = new Point(689, 39);
            gbPermisos.Margin = new Padding(3, 2, 3, 2);
            gbPermisos.Name = "gbPermisos";
            gbPermisos.Padding = new Padding(3, 2, 3, 2);
            gbPermisos.Size = new Size(646, 629);
            gbPermisos.TabIndex = 3;
            gbPermisos.TabStop = false;
            gbPermisos.Text = "Permisos";
            // 
            // scPermisos
            // 
            scPermisos.Dock = DockStyle.Fill;
            scPermisos.Location = new Point(3, 21);
            scPermisos.Margin = new Padding(3, 2, 3, 2);
            scPermisos.Name = "scPermisos";
            scPermisos.Orientation = Orientation.Horizontal;
            // 
            // scPermisos.Panel1
            // 
            scPermisos.Panel1.Controls.Add(btAltaPermiso);
            scPermisos.Panel1.Controls.Add(cbEstatusPermisoAlta);
            scPermisos.Panel1.Controls.Add(lblEstatusPermiso);
            scPermisos.Panel1.Controls.Add(txtDescripciónPermiso);
            scPermisos.Panel1.Controls.Add(lblDescripciónPermiso);
            scPermisos.Panel1.Controls.Add(lblAltaPermiso);
            // 
            // scPermisos.Panel2
            // 
            scPermisos.Panel2.Controls.Add(btEliminarPermiso);
            scPermisos.Panel2.Controls.Add(txtCambioDescripciónPermiso);
            scPermisos.Panel2.Controls.Add(lblCambioDescripciónPermiso);
            scPermisos.Panel2.Controls.Add(cbCambioSelecciónPermiso);
            scPermisos.Panel2.Controls.Add(btGuardarCambiosPermiso);
            scPermisos.Panel2.Controls.Add(cbCambioEstatusPermiso);
            scPermisos.Panel2.Controls.Add(lblCambioEstatusPermiso);
            scPermisos.Panel2.Controls.Add(lblSelecciónPermiso);
            scPermisos.Panel2.Controls.Add(lblEdiciónOEliminaciónPermiso);
            scPermisos.Size = new Size(640, 606);
            scPermisos.SplitterDistance = 282;
            scPermisos.SplitterWidth = 2;
            scPermisos.TabIndex = 0;
            // 
            // btAltaPermiso
            // 
            btAltaPermiso.AutoSize = true;
            btAltaPermiso.Location = new Point(352, 218);
            btAltaPermiso.Margin = new Padding(3, 2, 3, 2);
            btAltaPermiso.Name = "btAltaPermiso";
            btAltaPermiso.Size = new Size(105, 34);
            btAltaPermiso.TabIndex = 5;
            btAltaPermiso.Text = "Guardar";
            btAltaPermiso.TextAlign = ContentAlignment.MiddleRight;
            btAltaPermiso.UseVisualStyleBackColor = true;
            btAltaPermiso.Click += btAltaPermiso_Click;
            // 
            // cbEstatusPermisoAlta
            // 
            cbEstatusPermisoAlta.DropDownStyle = ComboBoxStyle.DropDownList;
            cbEstatusPermisoAlta.FormattingEnabled = true;
            cbEstatusPermisoAlta.Location = new Point(28, 218);
            cbEstatusPermisoAlta.Margin = new Padding(3, 2, 3, 2);
            cbEstatusPermisoAlta.Name = "cbEstatusPermisoAlta";
            cbEstatusPermisoAlta.Size = new Size(143, 27);
            cbEstatusPermisoAlta.TabIndex = 4;
            // 
            // lblEstatusPermiso
            // 
            lblEstatusPermiso.AutoSize = true;
            lblEstatusPermiso.Location = new Point(28, 181);
            lblEstatusPermiso.Name = "lblEstatusPermiso";
            lblEstatusPermiso.Size = new Size(96, 19);
            lblEstatusPermiso.TabIndex = 3;
            lblEstatusPermiso.Text = "Estatus *";
            // 
            // txtDescripciónPermiso
            // 
            txtDescripciónPermiso.Location = new Point(251, 71);
            txtDescripciónPermiso.Margin = new Padding(3, 2, 3, 2);
            txtDescripciónPermiso.MaxLength = 100;
            txtDescripciónPermiso.Name = "txtDescripciónPermiso";
            txtDescripciónPermiso.Size = new Size(216, 26);
            txtDescripciónPermiso.TabIndex = 2;
            // 
            // lblDescripciónPermiso
            // 
            lblDescripciónPermiso.AutoSize = true;
            lblDescripciónPermiso.Location = new Point(28, 74);
            lblDescripciónPermiso.Name = "lblDescripciónPermiso";
            lblDescripciónPermiso.Size = new Size(133, 19);
            lblDescripciónPermiso.TabIndex = 1;
            lblDescripciónPermiso.Text = "Descripción *";
            // 
            // lblAltaPermiso
            // 
            lblAltaPermiso.AutoSize = true;
            lblAltaPermiso.Location = new Point(5, 3);
            lblAltaPermiso.Name = "lblAltaPermiso";
            lblAltaPermiso.Size = new Size(150, 19);
            lblAltaPermiso.TabIndex = 0;
            lblAltaPermiso.Text = "Alta de permiso";
            // 
            // btEliminarPermiso
            // 
            btEliminarPermiso.AutoSize = true;
            btEliminarPermiso.Location = new Point(352, 274);
            btEliminarPermiso.Margin = new Padding(3, 2, 3, 2);
            btEliminarPermiso.Name = "btEliminarPermiso";
            btEliminarPermiso.Size = new Size(199, 34);
            btEliminarPermiso.TabIndex = 15;
            btEliminarPermiso.Text = "Eliminar permiso";
            btEliminarPermiso.TextAlign = ContentAlignment.MiddleRight;
            btEliminarPermiso.UseVisualStyleBackColor = true;
            btEliminarPermiso.Click += btEliminarPermiso_Click;
            // 
            // txtCambioDescripciónPermiso
            // 
            txtCambioDescripciónPermiso.Location = new Point(352, 95);
            txtCambioDescripciónPermiso.Margin = new Padding(3, 2, 3, 2);
            txtCambioDescripciónPermiso.MaxLength = 100;
            txtCambioDescripciónPermiso.Name = "txtCambioDescripciónPermiso";
            txtCambioDescripciónPermiso.Size = new Size(95, 26);
            txtCambioDescripciónPermiso.TabIndex = 14;
            // 
            // lblCambioDescripciónPermiso
            // 
            lblCambioDescripciónPermiso.AutoSize = true;
            lblCambioDescripciónPermiso.Location = new Point(352, 56);
            lblCambioDescripciónPermiso.Name = "lblCambioDescripciónPermiso";
            lblCambioDescripciónPermiso.Size = new Size(115, 19);
            lblCambioDescripciónPermiso.TabIndex = 13;
            lblCambioDescripciónPermiso.Text = "Descripción";
            // 
            // cbCambioSelecciónPermiso
            // 
            cbCambioSelecciónPermiso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioSelecciónPermiso.FormattingEnabled = true;
            cbCambioSelecciónPermiso.Location = new Point(28, 94);
            cbCambioSelecciónPermiso.Margin = new Padding(3, 2, 3, 2);
            cbCambioSelecciónPermiso.Name = "cbCambioSelecciónPermiso";
            cbCambioSelecciónPermiso.Size = new Size(110, 27);
            cbCambioSelecciónPermiso.TabIndex = 12;
            // 
            // btGuardarCambiosPermiso
            // 
            btGuardarCambiosPermiso.AutoSize = true;
            btGuardarCambiosPermiso.Location = new Point(352, 189);
            btGuardarCambiosPermiso.Margin = new Padding(3, 2, 3, 2);
            btGuardarCambiosPermiso.Name = "btGuardarCambiosPermiso";
            btGuardarCambiosPermiso.Size = new Size(201, 34);
            btGuardarCambiosPermiso.TabIndex = 11;
            btGuardarCambiosPermiso.Text = "Guardar cambios";
            btGuardarCambiosPermiso.TextAlign = ContentAlignment.MiddleRight;
            btGuardarCambiosPermiso.UseVisualStyleBackColor = true;
            btGuardarCambiosPermiso.Click += btGuardarCambiosPermiso_Click;
            // 
            // cbCambioEstatusPermiso
            // 
            cbCambioEstatusPermiso.DropDownStyle = ComboBoxStyle.DropDownList;
            cbCambioEstatusPermiso.FormattingEnabled = true;
            cbCambioEstatusPermiso.Location = new Point(28, 274);
            cbCambioEstatusPermiso.Margin = new Padding(3, 2, 3, 2);
            cbCambioEstatusPermiso.Name = "cbCambioEstatusPermiso";
            cbCambioEstatusPermiso.Size = new Size(111, 27);
            cbCambioEstatusPermiso.TabIndex = 10;
            // 
            // lblCambioEstatusPermiso
            // 
            lblCambioEstatusPermiso.AutoSize = true;
            lblCambioEstatusPermiso.Location = new Point(28, 236);
            lblCambioEstatusPermiso.Name = "lblCambioEstatusPermiso";
            lblCambioEstatusPermiso.Size = new Size(78, 19);
            lblCambioEstatusPermiso.TabIndex = 9;
            lblCambioEstatusPermiso.Text = "Estatus";
            // 
            // lblSelecciónPermiso
            // 
            lblSelecciónPermiso.AutoSize = true;
            lblSelecciónPermiso.Location = new Point(28, 56);
            lblSelecciónPermiso.Name = "lblSelecciónPermiso";
            lblSelecciónPermiso.Size = new Size(220, 19);
            lblSelecciónPermiso.TabIndex = 7;
            lblSelecciónPermiso.Text = "Selección de permiso *";
            // 
            // lblEdiciónOEliminaciónPermiso
            // 
            lblEdiciónOEliminaciónPermiso.AutoSize = true;
            lblEdiciónOEliminaciónPermiso.Location = new Point(28, 3);
            lblEdiciónOEliminaciónPermiso.Name = "lblEdiciónOEliminaciónPermiso";
            lblEdiciónOEliminaciónPermiso.Size = new Size(304, 19);
            lblEdiciónOEliminaciónPermiso.TabIndex = 6;
            lblEdiciónOEliminaciónPermiso.Text = "Edición o eliminación de permiso";
            // 
            // gbAsignaciónRP
            // 
            gbAsignaciónRP.Controls.Add(btGuardarAsignaciónRP);
            gbAsignaciónRP.Controls.Add(cbSelecciónPermiso3);
            gbAsignaciónRP.Controls.Add(lblSelecciónPermiso3);
            gbAsignaciónRP.Controls.Add(cbSelecciónPermiso2);
            gbAsignaciónRP.Controls.Add(lblSelecciónPermiso2);
            gbAsignaciónRP.Controls.Add(cbSelecciónPermiso1);
            gbAsignaciónRP.Controls.Add(lblSelecciónPermiso1);
            gbAsignaciónRP.Controls.Add(cbAsignaciónSelecciónRol);
            gbAsignaciónRP.Controls.Add(lblAsignaciónSelecciónRol);
            gbAsignaciónRP.Font = new Font("MS PGothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gbAsignaciónRP.Location = new Point(2, 666);
            gbAsignaciónRP.Margin = new Padding(3, 2, 3, 2);
            gbAsignaciónRP.Name = "gbAsignaciónRP";
            gbAsignaciónRP.Padding = new Padding(3, 2, 3, 2);
            gbAsignaciónRP.Size = new Size(1333, 104);
            gbAsignaciónRP.TabIndex = 4;
            gbAsignaciónRP.TabStop = false;
            gbAsignaciónRP.Text = "Asignación de permisos a rol";
            // 
            // btGuardarAsignaciónRP
            // 
            btGuardarAsignaciónRP.AutoSize = true;
            btGuardarAsignaciónRP.Location = new Point(10, 78);
            btGuardarAsignaciónRP.Margin = new Padding(3, 2, 3, 2);
            btGuardarAsignaciónRP.Name = "btGuardarAsignaciónRP";
            btGuardarAsignaciónRP.Size = new Size(90, 29);
            btGuardarAsignaciónRP.TabIndex = 6;
            btGuardarAsignaciónRP.Text = "Guardar";
            btGuardarAsignaciónRP.TextAlign = ContentAlignment.MiddleRight;
            btGuardarAsignaciónRP.UseVisualStyleBackColor = true;
            btGuardarAsignaciónRP.Click += btGuardarAsignaciónRP_Click;
            // 
            // cbSelecciónPermiso3
            // 
            cbSelecciónPermiso3.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelecciónPermiso3.FormattingEnabled = true;
            cbSelecciónPermiso3.Location = new Point(1142, 42);
            cbSelecciónPermiso3.Margin = new Padding(3, 2, 3, 2);
            cbSelecciónPermiso3.Name = "cbSelecciónPermiso3";
            cbSelecciónPermiso3.Size = new Size(155, 23);
            cbSelecciónPermiso3.TabIndex = 20;
            // 
            // lblSelecciónPermiso3
            // 
            lblSelecciónPermiso3.AutoSize = true;
            lblSelecciónPermiso3.Location = new Point(1118, 25);
            lblSelecciónPermiso3.Name = "lblSelecciónPermiso3";
            lblSelecciónPermiso3.Size = new Size(179, 15);
            lblSelecciónPermiso3.TabIndex = 19;
            lblSelecciónPermiso3.Text = "Selección de permiso 3";
            lblSelecciónPermiso3.Click += lblSelecciónPermiso3_Click;
            // 
            // cbSelecciónPermiso2
            // 
            cbSelecciónPermiso2.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelecciónPermiso2.FormattingEnabled = true;
            cbSelecciónPermiso2.Location = new Point(767, 42);
            cbSelecciónPermiso2.Margin = new Padding(3, 2, 3, 2);
            cbSelecciónPermiso2.Name = "cbSelecciónPermiso2";
            cbSelecciónPermiso2.Size = new Size(155, 23);
            cbSelecciónPermiso2.TabIndex = 18;
            // 
            // lblSelecciónPermiso2
            // 
            lblSelecciónPermiso2.AutoSize = true;
            lblSelecciónPermiso2.Location = new Point(767, 25);
            lblSelecciónPermiso2.Name = "lblSelecciónPermiso2";
            lblSelecciónPermiso2.Size = new Size(179, 15);
            lblSelecciónPermiso2.TabIndex = 17;
            lblSelecciónPermiso2.Text = "Selección de permiso 2";
            // 
            // cbSelecciónPermiso1
            // 
            cbSelecciónPermiso1.DropDownStyle = ComboBoxStyle.DropDownList;
            cbSelecciónPermiso1.FormattingEnabled = true;
            cbSelecciónPermiso1.Location = new Point(392, 42);
            cbSelecciónPermiso1.Margin = new Padding(3, 2, 3, 2);
            cbSelecciónPermiso1.Name = "cbSelecciónPermiso1";
            cbSelecciónPermiso1.Size = new Size(155, 23);
            cbSelecciónPermiso1.TabIndex = 16;
            // 
            // lblSelecciónPermiso1
            // 
            lblSelecciónPermiso1.AutoSize = true;
            lblSelecciónPermiso1.Location = new Point(392, 25);
            lblSelecciónPermiso1.Name = "lblSelecciónPermiso1";
            lblSelecciónPermiso1.Size = new Size(194, 15);
            lblSelecciónPermiso1.TabIndex = 15;
            lblSelecciónPermiso1.Text = "Selección de permiso 1 *";
            // 
            // cbAsignaciónSelecciónRol
            // 
            cbAsignaciónSelecciónRol.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAsignaciónSelecciónRol.FormattingEnabled = true;
            cbAsignaciónSelecciónRol.Location = new Point(10, 42);
            cbAsignaciónSelecciónRol.Margin = new Padding(3, 2, 3, 2);
            cbAsignaciónSelecciónRol.Name = "cbAsignaciónSelecciónRol";
            cbAsignaciónSelecciónRol.Size = new Size(162, 23);
            cbAsignaciónSelecciónRol.TabIndex = 14;
            // 
            // lblAsignaciónSelecciónRol
            // 
            lblAsignaciónSelecciónRol.AutoSize = true;
            lblAsignaciónSelecciónRol.Font = new Font("MS PGothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblAsignaciónSelecciónRol.Location = new Point(10, 25);
            lblAsignaciónSelecciónRol.Name = "lblAsignaciónSelecciónRol";
            lblAsignaciónSelecciónRol.Size = new Size(142, 15);
            lblAsignaciónSelecciónRol.TabIndex = 13;
            lblAsignaciónSelecciónRol.Text = "Selección de rol *";
            // 
            // frmGestionRolesPermisos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1347, 781);
            Controls.Add(gbAsignaciónRP);
            Controls.Add(gbPermisos);
            Controls.Add(gbRoles);
            Controls.Add(lblTitulo);
            Margin = new Padding(3, 2, 3, 2);
            Name = "frmGestionRolesPermisos";
            Text = "frmGestionRolesPermisos";
            gbRoles.ResumeLayout(false);
            scRoles.Panel1.ResumeLayout(false);
            scRoles.Panel1.PerformLayout();
            scRoles.Panel2.ResumeLayout(false);
            scRoles.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scRoles).EndInit();
            scRoles.ResumeLayout(false);
            gbPermisos.ResumeLayout(false);
            scPermisos.Panel1.ResumeLayout(false);
            scPermisos.Panel1.PerformLayout();
            scPermisos.Panel2.ResumeLayout(false);
            scPermisos.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scPermisos).EndInit();
            scPermisos.ResumeLayout(false);
            gbAsignaciónRP.ResumeLayout(false);
            gbAsignaciónRP.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblTitulo;
        private GroupBox gbRoles;
        private SplitContainer scRoles;
        private Label lblAltaRol;
        private Button btAltaRol;
        private ComboBox cbEstatusRolAlta;
        private Label lblEstatusRol;
        private TextBox txtNombreRol;
        private Label lblNombreRol;
        private Button btGuardarCambiosRol;
        private ComboBox cbCambioEstatusRol;
        private Label lblCambioEstatusRol;
        private Label lblSelecciónRol;
        private Label lblEdiciónOEliminaciónRol;
        private TextBox txtCambioNombreRol;
        private Label lblCambioNombreRol;
        private ComboBox cbCambioSelecciónRol;
        private Button btEliminarRol;
        private GroupBox gbPermisos;
        private SplitContainer scPermisos;
        private Button btAltaPermiso;
        private ComboBox cbEstatusPermisoAlta;
        private Label lblEstatusPermiso;
        private TextBox txtDescripciónPermiso;
        private Label lblDescripciónPermiso;
        private Label lblAltaPermiso;
        private Button btEliminarPermiso;
        private TextBox txtCambioDescripciónPermiso;
        private Label lblCambioDescripciónPermiso;
        private ComboBox cbCambioSelecciónPermiso;
        private Button btGuardarCambiosPermiso;
        private ComboBox cbCambioEstatusPermiso;
        private Label lblCambioEstatusPermiso;
        private Label lblSelecciónPermiso;
        private Label lblEdiciónOEliminaciónPermiso;
        private GroupBox gbAsignaciónRP;
        private Button btGuardarAsignaciónRP;
        private ComboBox cbSelecciónPermiso3;
        private Label lblSelecciónPermiso3;
        private ComboBox cbSelecciónPermiso2;
        private Label lblSelecciónPermiso2;
        private ComboBox cbSelecciónPermiso1;
        private Label lblSelecciónPermiso1;
        private ComboBox cbAsignaciónSelecciónRol;
        private Label lblAsignaciónSelecciónRol;
    }
}