namespace InvSis
{
    partial class frmAdminProd
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BackColor = ColorTranslator.FromHtml("#F5F5F5");
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle5 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle6 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle7 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle8 = new DataGridViewCellStyle();
            dgvProductos = new DataGridView();
            colClave = new DataGridViewTextBoxColumn();
            colNombre = new DataGridViewTextBoxColumn();
            colCategoria = new DataGridViewTextBoxColumn();
            colStock = new DataGridViewTextBoxColumn();
            colEstatus = new DataGridViewTextBoxColumn();
            detalle = new DataGridViewButtonColumn();
            colEdit = new DataGridViewButtonColumn();
            colDelete = new DataGridViewButtonColumn();
            btnEdittemp = new Button();
            btnCarga = new Button();
            spcProductos = new SplitContainer();
            groupBox1 = new GroupBox();
            lblFilCat = new Label();
            lblFilStatus = new Label();
            cmbCat = new ComboBox();
            btnDetalle = new Button();
            btnApF = new Button();
            cmbEstatus = new ComboBox();
            btnAgregar = new Button();
            groupBox2 = new GroupBox();
            btnCancelar = new Button();
            btnGuardar = new Button();
            cmbxImpuesto = new ComboBox();
            cmbxStatus = new ComboBox();
            nmupdnStock = new NumericUpDown();
            txtClave = new TextBox();
            cmbxUbi = new ComboBox();
            cmbxCat = new ComboBox();
            txtNombre = new TextBox();
            lblImpuesto = new Label();
            lblEstatus = new Label();
            lblClave = new Label();
            lblUbicacion = new Label();
            lblStock = new Label();
            lblCosto = new Label();
            lblCat = new Label();
            lblNombre = new Label();
            lblTitulo = new Label();
            txtCosto = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvProductos).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spcProductos).BeginInit();
            spcProductos.Panel1.SuspendLayout();
            spcProductos.Panel2.SuspendLayout();
            spcProductos.SuspendLayout();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nmupdnStock).BeginInit();
            SuspendLayout();
            // 
            // dgvProductos
            // 
            dgvProductos.AllowUserToAddRows = false;
            dgvProductos.AllowUserToDeleteRows = false;
            dgvProductos.AllowUserToResizeColumns = false;
            dgvProductos.AllowUserToResizeRows = false;
            dgvProductos.Anchor = AnchorStyles.None;
            dgvProductos.BackgroundColor = Color.FromArgb(42, 34, 58);
            dgvProductos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvProductos.Columns.AddRange(new DataGridViewColumn[] { colClave, colNombre, colCategoria, colStock, colEstatus, detalle, colEdit, colDelete });
            dgvProductos.GridColor = SystemColors.Info;
            dgvProductos.ImeMode = ImeMode.Disable;
            dgvProductos.Location = new Point(114, 380);
            dgvProductos.Margin = new Padding(4, 5, 4, 5);
            dgvProductos.Name = "dgvProductos";
            dgvProductos.ReadOnly = true;
            dgvProductos.RowHeadersVisible = false;
            dgvProductos.RowHeadersWidth = 62;
            dgvProductos.Size = new Size(1147, 437);
            dgvProductos.TabIndex = 0;

            
            dgvProductos.ColumnHeadersDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#9F7AEA"); 
            dgvProductos.ColumnHeadersDefaultCellStyle.ForeColor = Color.MediumPurple;
            dgvProductos.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

           
            dgvProductos.AlternatingRowsDefaultCellStyle.BackColor = ColorTranslator.FromHtml("#FAFAFA");
            dgvProductos.DefaultCellStyle.SelectionBackColor = ColorTranslator.FromHtml("#E8DAFF"); // Morado claro
            dgvProductos.DefaultCellStyle.SelectionForeColor = Color.MediumPurple;
            // 
            // colClave
            // 
            dataGridViewCellStyle1.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle1.ForeColor = Color.White;
            colClave.DefaultCellStyle = dataGridViewCellStyle1;
            colClave.HeaderText = "Clave";
            colClave.MinimumWidth = 8;
            colClave.Name = "colClave";
            colClave.ReadOnly = true;
            colClave.Width = 150;
            // 
            // colNombre
            // 
            dataGridViewCellStyle2.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle2.ForeColor = Color.White;
            colNombre.DefaultCellStyle = dataGridViewCellStyle2;
            colNombre.HeaderText = "Nombre";
            colNombre.MinimumWidth = 8;
            colNombre.Name = "colNombre";
            colNombre.ReadOnly = true;
            colNombre.Width = 150;
            // 
            // colCategoria
            // 
            dataGridViewCellStyle3.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle3.ForeColor = Color.White;
            colCategoria.DefaultCellStyle = dataGridViewCellStyle3;
            colCategoria.HeaderText = "Categoria";
            colCategoria.MinimumWidth = 8;
            colCategoria.Name = "colCategoria";
            colCategoria.ReadOnly = true;
            colCategoria.Width = 150;
            // 
            // colStock
            // 
            dataGridViewCellStyle4.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle4.ForeColor = Color.White;
            colStock.DefaultCellStyle = dataGridViewCellStyle4;
            colStock.HeaderText = "Stock";
            colStock.MinimumWidth = 8;
            colStock.Name = "colStock";
            colStock.ReadOnly = true;
            colStock.Width = 150;
            // 
            // colEstatus
            // 
            dataGridViewCellStyle5.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle5.ForeColor = Color.White;
            colEstatus.DefaultCellStyle = dataGridViewCellStyle5;
            colEstatus.HeaderText = "Estatus";
            colEstatus.MinimumWidth = 8;
            colEstatus.Name = "colEstatus";
            colEstatus.ReadOnly = true;
            colEstatus.Width = 150;
            // 
            // detalle
            // 
            dataGridViewCellStyle6.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle6.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle6.ForeColor = Color.White;
            detalle.DefaultCellStyle = dataGridViewCellStyle6;
            detalle.HeaderText = "Detalle";
            detalle.MinimumWidth = 8;
            detalle.Name = "detalle";
            detalle.ReadOnly = true;
            detalle.Width = 150;
            // 
            // colEdit
            // 
            dataGridViewCellStyle7.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle7.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle7.ForeColor = Color.Black;
            colEdit.DefaultCellStyle = dataGridViewCellStyle7;
            colEdit.HeaderText = "Editar";
            colEdit.MinimumWidth = 8;
            colEdit.Name = "colEdit";
            colEdit.ReadOnly = true;
            colEdit.Text = "Editar";
            colEdit.Width = 150;
            // 
            // colDelete
            // 
            dataGridViewCellStyle8.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle8.BackColor = Color.FromArgb(255, 111, 97);
            dataGridViewCellStyle8.ForeColor = Color.Black;
            colDelete.DefaultCellStyle = dataGridViewCellStyle8;
            colDelete.HeaderText = "Eliminar";
            colDelete.MinimumWidth = 8;
            colDelete.Name = "colDelete";
            colDelete.ReadOnly = true;
            colDelete.Text = "Eliminar";
            colDelete.Width = 150;
            // 
            // btnEdittemp
            // 
            btnEdittemp.BackColor = Color.FromArgb(159, 122, 234);
            btnEdittemp.Cursor = Cursors.Hand;
            btnEdittemp.FlatAppearance.BorderSize = 0;
            btnEdittemp.FlatAppearance.MouseDownBackColor = Color.FromArgb(100, 80, 140);
            btnEdittemp.FlatAppearance.MouseOverBackColor = Color.FromArgb(120, 95, 160);
            btnEdittemp.FlatStyle = FlatStyle.Flat;
            btnEdittemp.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            btnEdittemp.ForeColor = Color.Black;
            btnEdittemp.Location = new Point(1150, 870);
            btnEdittemp.Margin = new Padding(4, 5, 4, 5);
            btnEdittemp.Name = "btnEdittemp";
            btnEdittemp.Size = new Size(111, 60);
            btnEdittemp.TabIndex = 1;
            btnEdittemp.Text = "Editar";
            btnEdittemp.UseVisualStyleBackColor = false;
            btnEdittemp.Click += btnEdittemp_Click;
            // 
            // btnCarga
            // 
            btnCarga.BackColor = Color.FromArgb(159, 122, 234);
            btnCarga.FlatAppearance.BorderSize = 0;
            btnCarga.FlatStyle = FlatStyle.Flat;
            btnCarga.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            btnCarga.ForeColor = Color.Black;
            btnCarga.Location = new Point(114, 880);
            btnCarga.Margin = new Padding(4, 5, 4, 5);
            btnCarga.Name = "btnCarga";
            btnCarga.Size = new Size(219, 60);
            btnCarga.TabIndex = 2;
            btnCarga.Text = "Carga Excel";
            btnCarga.UseVisualStyleBackColor = false;
            btnCarga.Click += btnCrg_Click;
            // 
            // spcProductos
            // 
            spcProductos.Location = new Point(0, 67);
            spcProductos.Margin = new Padding(4, 5, 4, 5);
            spcProductos.Name = "spcProductos";
            // 
            // spcProductos.Panel1
            // 
            spcProductos.Panel1.Controls.Add(groupBox1);
            // 
            // spcProductos.Panel2
            // 
            spcProductos.Panel2.Controls.Add(groupBox2);
            spcProductos.Size = new Size(1936, 1240);
            spcProductos.SplitterDistance = 1390;
            spcProductos.SplitterWidth = 6;
            spcProductos.TabIndex = 4;
            // 
            // groupBox1
            // 
            groupBox1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            groupBox1.BackColor =ColorTranslator.FromHtml("#E6F2F8");
            groupBox1.Controls.Add(lblFilCat);
            groupBox1.Controls.Add(lblFilStatus);
            groupBox1.Controls.Add(cmbCat);
            groupBox1.Controls.Add(btnDetalle);
            groupBox1.Controls.Add(btnApF);
            groupBox1.Controls.Add(cmbEstatus);
            groupBox1.Controls.Add(btnAgregar);
            groupBox1.Controls.Add(btnEdittemp);
            groupBox1.Controls.Add(btnCarga);
            groupBox1.Controls.Add(dgvProductos);
            groupBox1.Location = new Point(4, 5);
            groupBox1.Margin = new Padding(0);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(10);
            groupBox1.Size = new Size(1383, 1235);
            groupBox1.TabIndex = 0;
            groupBox1.TabStop = false;
            // 
            // lblFilCat
            // 
            lblFilCat.AutoSize = true;
            lblFilCat.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilCat.ForeColor = Color.MediumPurple;
            lblFilCat.Location = new Point(571, 142);
            lblFilCat.Margin = new Padding(4, 0, 4, 0);
            lblFilCat.Name = "lblFilCat";
            lblFilCat.Size = new Size(325, 45);
            lblFilCat.TabIndex = 14;
            lblFilCat.Text = "Filtrar Por Categoría";
            lblFilCat.Click += lblFilCat_Click;
            // 
            // lblFilStatus
            // 
            lblFilStatus.AutoSize = true;
            lblFilStatus.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblFilStatus.ForeColor = Color.MediumPurple;
            lblFilStatus.Location = new Point(144, 142);
            lblFilStatus.Margin = new Padding(4, 0, 4, 0);
            lblFilStatus.Name = "lblFilStatus";
            lblFilStatus.Size = new Size(285, 45);
            lblFilStatus.TabIndex = 13;
            lblFilStatus.Text = "Filtrar Por Estatus";
            // 
            // cmbCat
            // 
            cmbCat.BackColor = Color.Lavender;
            cmbCat.ForeColor = Color.Black;
            cmbCat.FormattingEnabled = true;
            cmbCat.Items.AddRange(new object[] { "Todo", "Cat X", "Cat Y", "Cat Z" });
            cmbCat.Location = new Point(585, 204);
            cmbCat.Margin = new Padding(4, 5, 4, 5);
            cmbCat.Name = "cmbCat";
            cmbCat.Size = new Size(284, 33);
            cmbCat.TabIndex = 12;
            // 
            // btnDetalle
            // 
            btnDetalle.BackColor = Color.MediumPurple;
            btnDetalle.FlatStyle = FlatStyle.Flat;
            btnDetalle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnDetalle.ForeColor = Color.White;
            btnDetalle.Location = new Point(1054, 945);
            btnDetalle.Margin = new Padding(4, 5, 4, 5);
            btnDetalle.Name = "btnDetalle";
            btnDetalle.Size = new Size(207, 93);
            btnDetalle.TabIndex = 11;
            btnDetalle.Text = "Detalle del Producto";
            btnDetalle.UseVisualStyleBackColor = false;
            btnDetalle.Click += btnDetalle_Click;
            // 
            // btnApF
            // 
            btnApF.BackColor = Color.MediumPurple;
            btnApF.FlatStyle = FlatStyle.Flat;
            btnApF.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnApF.ForeColor = Color.White;
            btnApF.Location = new Point(1124, 192);
            btnApF.Margin = new Padding(4, 5, 4, 5);
            btnApF.Name = "btnApF";
            btnApF.Size = new Size(206, 45);
            btnApF.TabIndex = 10;
            btnApF.Text = "Aplicar Filtro";
            btnApF.UseVisualStyleBackColor = false;
            btnApF.Click += btnApF_Click;
            // 
            // cmbEstatus
            // 
            cmbEstatus.BackColor = Color.Lavender;
            cmbEstatus.ForeColor = Color.Black;
            cmbEstatus.FormattingEnabled = true;
            cmbEstatus.Items.AddRange(new object[] { "Activo", "Inactivo" });
            cmbEstatus.Location = new Point(187, 192);
            cmbEstatus.Margin = new Padding(4, 5, 4, 5);
            cmbEstatus.Name = "cmbEstatus";
            cmbEstatus.Size = new Size(171, 33);
            cmbEstatus.TabIndex = 8;
            // 
            // btnAgregar
            // 
            btnAgregar.BackColor = Color.MediumPurple;
            btnAgregar.FlatStyle = FlatStyle.Flat;
            btnAgregar.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            btnAgregar.ForeColor = Color.White;
            btnAgregar.Location = new Point(589, 870);
            btnAgregar.Margin = new Padding(4, 5, 4, 5);
            btnAgregar.Name = "btnAgregar";
            btnAgregar.Size = new Size(191, 80);
            btnAgregar.TabIndex = 3;
            btnAgregar.Text = "Agregar Productos";
            btnAgregar.UseVisualStyleBackColor = false;
            btnAgregar.Click += btnAgregar_Click;
            // 
            // groupBox2
            // 
            groupBox2.BackColor = ColorTranslator.FromHtml("#E6F2F8");
            groupBox2.Controls.Add(btnCancelar);
            groupBox2.Controls.Add(btnGuardar);
            groupBox2.Controls.Add(cmbxImpuesto);
            groupBox2.Controls.Add(cmbxStatus);
            groupBox2.Controls.Add(nmupdnStock);
            groupBox2.Controls.Add(txtCosto);
            groupBox2.Controls.Add(txtClave);
            groupBox2.Controls.Add(cmbxUbi);
            groupBox2.Controls.Add(cmbxCat);
            groupBox2.Controls.Add(txtNombre);
            groupBox2.Controls.Add(lblImpuesto);
            groupBox2.Controls.Add(lblEstatus);
            groupBox2.Controls.Add(lblClave);
            groupBox2.Controls.Add(lblUbicacion);
            groupBox2.Controls.Add(lblStock);
            groupBox2.Controls.Add(lblCosto);
            groupBox2.Controls.Add(lblCat);
            groupBox2.Controls.Add(lblNombre);
            groupBox2.ForeColor = Color.FromArgb(159, 122, 234);
            groupBox2.Location = new Point(4, 5);
            groupBox2.Margin = new Padding(4, 5, 4, 5);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 5, 4, 5);
            groupBox2.Size = new Size(524, 1235);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            // 
            // btnCancelar
            // 
            btnCancelar.BackColor = Color.FromArgb(245, 245, 245);
            btnCancelar.FlatAppearance.BorderColor = Color.FromArgb(159, 122, 234);
            btnCancelar.FlatStyle = FlatStyle.Flat;
            btnCancelar.ForeColor = Color.FromArgb(159, 122, 234);
            btnCancelar.Location = new Point(51, 1112);
            btnCancelar.Margin = new Padding(4, 5, 4, 5);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(107, 38);
            btnCancelar.TabIndex = 35;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = false;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // btnGuardar
            // 
            btnGuardar.BackColor = Color.FromArgb(159, 122, 234);
            btnGuardar.FlatAppearance.BorderSize = 0;
            btnGuardar.FlatStyle = FlatStyle.Flat;
            btnGuardar.ForeColor = Color.White;
            btnGuardar.Location = new Point(51, 1045);
            btnGuardar.Margin = new Padding(4, 5, 4, 5);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(107, 38);
            btnGuardar.TabIndex = 34;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = false;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // cmbxImpuesto
            // 
            cmbxImpuesto.BackColor = Color.White;
            cmbxImpuesto.FlatStyle = FlatStyle.Flat;
            cmbxImpuesto.ForeColor = Color.FromArgb(42, 34, 58);
            cmbxImpuesto.FormattingEnabled = true;
            cmbxImpuesto.Items.AddRange(new object[] { "No Aplica", "Impuesto A", "Impuesto B", "Impuesto C" });
            cmbxImpuesto.Location = new Point(51, 978);
            cmbxImpuesto.Margin = new Padding(4, 5, 4, 5);
            cmbxImpuesto.Name = "cmbxImpuesto";
            cmbxImpuesto.Size = new Size(360, 33);
            cmbxImpuesto.TabIndex = 33;
            // 
            // cmbxStatus
            // 
            cmbxStatus.BackColor = Color.White;
            cmbxStatus.FlatStyle = FlatStyle.Flat;
            cmbxStatus.ForeColor = Color.FromArgb(42, 34, 58);
            cmbxStatus.FormattingEnabled = true;
            cmbxStatus.Items.AddRange(new object[] { "Inactivo", "Activo" });
            cmbxStatus.Location = new Point(51, 852);
            cmbxStatus.Margin = new Padding(4, 5, 4, 5);
            cmbxStatus.Name = "cmbxStatus";
            cmbxStatus.Size = new Size(360, 33);
            cmbxStatus.TabIndex = 32;
            // 
            // nmupdnStock
            // 
            nmupdnStock.BackColor = Color.White;
            nmupdnStock.BorderStyle = BorderStyle.FixedSingle;
            nmupdnStock.Font = new Font("MS PGothic", 11.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            nmupdnStock.ForeColor = Color.FromArgb(42, 34, 58);
            nmupdnStock.Location = new Point(51, 472);
            nmupdnStock.Margin = new Padding(4, 5, 4, 5);
            nmupdnStock.Name = "nmupdnStock";
            nmupdnStock.Size = new Size(171, 30);
            nmupdnStock.TabIndex = 31;
            // 
            // txtClave
            // 
            txtClave.BackColor = Color.White;
            txtClave.BorderStyle = BorderStyle.FixedSingle;
            txtClave.ForeColor = Color.FromArgb(42, 34, 58);
            txtClave.Location = new Point(51, 725);
            txtClave.Margin = new Padding(4, 5, 4, 5);
            txtClave.Name = "txtClave";
            txtClave.Size = new Size(360, 31);
            txtClave.TabIndex = 29;
            txtClave.KeyPress += txtClave_KeyPress;
            // 
            // cmbxUbi
            // 
            cmbxUbi.BackColor = Color.FromArgb(245, 245, 245);
            cmbxUbi.FlatStyle = FlatStyle.Flat;
            cmbxUbi.Font = new Font("Segoe UI", 10F);
            cmbxUbi.ForeColor = Color.FromArgb(159, 122, 234);
            cmbxUbi.FormattingEnabled = true;
            cmbxUbi.Items.AddRange(new object[] { "Tijuana", "CDMX", "Toluca", "Durango", "SLP", "Cancún" });
            cmbxUbi.Location = new Point(51, 598);
            cmbxUbi.Margin = new Padding(4, 5, 4, 5);
            cmbxUbi.Name = "cmbxUbi";
            cmbxUbi.Size = new Size(360, 36);
            cmbxUbi.TabIndex = 28;
            // 
            // cmbxCat
            //  
            cmbxCat.BackColor = Color.FromArgb(245, 245, 245);
            cmbxCat.FlatStyle = FlatStyle.Flat;
            cmbxCat.Font = new Font("Segoe UI", 10F);
            cmbxCat.ForeColor = Color.FromArgb(159, 122, 234);
            cmbxCat.FormattingEnabled = true;
            cmbxCat.Items.AddRange(new object[] { "Cat X", "Cat Y", "Cat Z" });
            cmbxCat.Location = new Point(51, 218);
            cmbxCat.Margin = new Padding(4, 5, 4, 5);
            cmbxCat.Name = "cmbxCat";
            cmbxCat.Size = new Size(360, 36);
            cmbxCat.Sorted = true;
            cmbxCat.TabIndex = 27;
            // 
            // txtNombre
            // 
            txtNombre.BackColor = Color.FromArgb(245, 245, 245);
            txtNombre.BorderStyle = BorderStyle.FixedSingle;
            txtNombre.Font = new Font("Segoe UI", 10F);
            txtNombre.ForeColor = Color.FromArgb(159, 122, 234);
            txtNombre.Location = new Point(51, 92);
            txtNombre.Margin = new Padding(4, 5, 4, 5);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(360, 34);
            txtNombre.TabIndex = 26;
            // lblImpuesto
            lblImpuesto.AutoSize = true;
            lblImpuesto.Font = new Font("Segoe UI", 12F, FontStyle.Bold); 
            lblImpuesto.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Morado humo exacto
            lblImpuesto.Location = new Point(51, 918);
            lblImpuesto.Margin = new Padding(4, 0, 4, 0);
            lblImpuesto.Name = "lblImpuesto";
            lblImpuesto.Size = new Size(138, 21); // Ajuste por cambio de fuente
            lblImpuesto.TabIndex = 25;
            lblImpuesto.Text = "Impuesto:";

            // lblEstatus
            lblEstatus.AutoSize = true;
            lblEstatus.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblEstatus.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Mismo morado
            lblEstatus.Location = new Point(51, 792);
            lblEstatus.Margin = new Padding(4, 0, 4, 0);
            lblEstatus.Name = "lblEstatus";
            lblEstatus.Size = new Size(118, 21);
            lblEstatus.TabIndex = 24;
            lblEstatus.Text = "Estatus:";

            // lblClave
            lblClave.AutoSize = true;
            lblClave.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblClave.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Mismo color
            lblClave.Location = new Point(51, 665);
            lblClave.Margin = new Padding(4, 0, 4, 0);
            lblClave.Name = "lblClave";
            lblClave.Size = new Size(93, 21);
            lblClave.TabIndex = 23;
            lblClave.Text = "Clave:";
            // lblUbicacion
            lblUbicacion.AutoSize = true;
            lblUbicacion.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            lblUbicacion.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); 
            lblUbicacion.Location = new Point(51, 538);
            lblUbicacion.Margin = new Padding(4, 0, 4, 0);
            lblUbicacion.Name = "lblUbicacion";
            lblUbicacion.Size = new Size(148, 29);
            lblUbicacion.TabIndex = 22;
            lblUbicacion.Text = "Ubicacion:";

            // lblStock
            lblStock.AutoSize = true;
            lblStock.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            lblStock.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); 
            lblStock.Location = new Point(51, 412);
            lblStock.Margin = new Padding(4, 0, 4, 0);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(95, 29);
            lblStock.TabIndex = 21;
            lblStock.Text = "Stock:";

            // lblCosto
            lblCosto.AutoSize = true;
            lblCosto.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            lblCosto.ForeColor = ColorTranslator.FromHtml("#9F7AEA");
            lblCosto.Location = new Point(51, 285);
            lblCosto.Margin = new Padding(4, 0, 4, 0);
            lblCosto.Name = "lblCosto";
            lblCosto.Size = new Size(97, 29);
            lblCosto.TabIndex = 20;
            lblCosto.Text = "Costo:";

            // lblCat
            lblCat.AutoSize = true;
            lblCat.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            lblCat.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Color consistente
            lblCat.Location = new Point(51, 158);
            lblCat.Margin = new Padding(4, 0, 4, 0);
            lblCat.Name = "lblCat";
            lblCat.Size = new Size(155, 29);
            lblCat.TabIndex = 19;
            lblCat.Text = "Categoria: ";
            // 
            // lblNombre
            lblNombre.AutoSize = true;
            lblNombre.Font = new Font("MS PGothic", 14.25F, FontStyle.Bold);
            lblNombre.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Smoky purple
            lblNombre.Location = new Point(51, 32);
            lblNombre.Margin = new Padding(4, 0, 4, 0);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(120, 29);
            lblNombre.TabIndex = 18;
            lblNombre.Text = "Nombre:";
            // lblTitulo - Diseño premium
            lblTitulo.BackColor = ColorTranslator.FromHtml("#9F7AEA");  // Fondo morado humo
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 20F, FontStyle.Bold | FontStyle.Italic);
            lblTitulo.ForeColor = Color.White;  // Texto blanco puro
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Margin = new Padding(0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(1924, 70);  
            lblTitulo.TabIndex = 5;
            lblTitulo.Text = " ADMINISTRACIÓN DE PRODUCTOS ";  
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;

            // txtCosto
            txtCosto.BackColor = ColorTranslator.FromHtml("#F5F5F5"); // Off-white
            txtCosto.BorderStyle = BorderStyle.FixedSingle;
            txtCosto.ForeColor = ColorTranslator.FromHtml("#9F7AEA"); // Smoky purple
            txtCosto.Location = new Point(51, 345);
            txtCosto.Margin = new Padding(4, 5, 4, 5);
            txtCosto.Name = "txtCosto";
            txtCosto.Size = new Size(360, 31);
            txtCosto.TabIndex = 30;
            txtCosto.KeyPress += txtCosto_KeyPress;
            // 
            // frmAdminProd
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = ColorTranslator.FromHtml("#E6F2F8");
            ClientSize = new Size(1924, 1050);
            Controls.Add(lblTitulo);
            Controls.Add(spcProductos);
            Margin = new Padding(4, 5, 4, 5);
            Name = "frmAdminProd";
            Text = "Administración de Inventarios";
            ((System.ComponentModel.ISupportInitialize)dgvProductos).EndInit();
            spcProductos.Panel1.ResumeLayout(false);
            spcProductos.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)spcProductos).EndInit();
            spcProductos.ResumeLayout(false);
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nmupdnStock).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvProductos;
        private Button btnEdittemp;
        private Button btnCarga;
        private SplitContainer spcProductos;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button btnCancelar;
        private Button btnGuardar;
        private ComboBox cmbxImpuesto;
        private ComboBox cmbxStatus;
        private NumericUpDown nmupdnStock;
        private TextBox txtClave;
        private ComboBox cmbxUbi;
        private ComboBox cmbxCat;
        private TextBox txtNombre;
        private Label lblImpuesto;
        private Label lblEstatus;
        private Label lblClave;
        private Label lblUbicacion;
        private Label lblStock;
        private Label lblCosto;
        private Label lblCat;
        private Label lblNombre;
        private Button btnAgregar;
        private Label lblTitulo;
        private ComboBox cmbEstatus;
        private Button btnApF;
        private Button btnDetalle;
        private ComboBox cmbCat;
        private Label lblFilCat;
        private Label lblFilStatus;
        private DataGridViewTextBoxColumn colClave;
        private DataGridViewTextBoxColumn colNombre;
        private DataGridViewTextBoxColumn colCategoria;
        private DataGridViewTextBoxColumn colStock;
        private DataGridViewTextBoxColumn colEstatus;
        private DataGridViewButtonColumn detalle;
        private DataGridViewButtonColumn colEdit;
        private DataGridViewButtonColumn colDelete;
        private TextBox txtCosto;
    }
}
