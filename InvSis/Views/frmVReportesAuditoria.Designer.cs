namespace InvSis.Views
{
    partial class frmVReportesAuditoria
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
        // En el archivo AuditoriasForm.Designer.cs (dentro del InitializeComponent)
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle4 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            pnlTitulo = new Panel();
            lblTitulo = new Label();
            gbFiltros = new GroupBox();
            btnExportar = new Button();
            btnGenerar = new Button();
            cmbProducto = new ComboBox();
            label5 = new Label();
            cmbAccion = new ComboBox();
            label4 = new Label();
            cmbUsuario = new ComboBox();
            label3 = new Label();
            dtpFechaFin = new DateTimePicker();
            dtpFechaInicio = new DateTimePicker();
            label2 = new Label();
            label1 = new Label();
            dgvAuditorias = new DataGridView();
            colIdMovimiento = new DataGridViewTextBoxColumn();
            colFecha = new DataGridViewTextBoxColumn();
            colTipoMovimiento = new DataGridViewTextBoxColumn();
            colIdUsuario = new DataGridViewTextBoxColumn();
            colIpEquipo = new DataGridViewTextBoxColumn();
            colNombreEquipo = new DataGridViewTextBoxColumn();
            toolTip = new ToolTip(components);
            pnlTitulo.SuspendLayout();
            gbFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditorias).BeginInit();
            SuspendLayout();
            // 
            // pnlTitulo
            // 
            pnlTitulo.BackColor = Color.FromArgb(159, 122, 234);
            pnlTitulo.Controls.Add(lblTitulo);
            pnlTitulo.Dock = DockStyle.Top;
            pnlTitulo.Location = new Point(0, 0);
            pnlTitulo.Name = "pnlTitulo";
            pnlTitulo.Size = new Size(1307, 60);
            pnlTitulo.TabIndex = 0;
            // 
            // lblTitulo
            // 
            lblTitulo.BackColor = Color.FromArgb(159, 122, 234);
            lblTitulo.Dock = DockStyle.Top;
            lblTitulo.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.ForeColor = Color.White;
            lblTitulo.Location = new Point(0, 0);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Padding = new Padding(0, 10, 0, 0);
            lblTitulo.Size = new Size(1307, 60);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "REPORTE DE AUDITORÍAS";
            lblTitulo.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // gbFiltros
            // 
            gbFiltros.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            gbFiltros.BackColor = Color.FromArgb(230, 242, 248);
            gbFiltros.Controls.Add(btnExportar);
            gbFiltros.Controls.Add(btnGenerar);
            gbFiltros.Controls.Add(cmbProducto);
            gbFiltros.Controls.Add(label5);
            gbFiltros.Controls.Add(cmbAccion);
            gbFiltros.Controls.Add(label4);
            gbFiltros.Controls.Add(cmbUsuario);
            gbFiltros.Controls.Add(label3);
            gbFiltros.Controls.Add(dtpFechaFin);
            gbFiltros.Controls.Add(dtpFechaInicio);
            gbFiltros.Controls.Add(label2);
            gbFiltros.Controls.Add(label1);
            gbFiltros.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold);
            gbFiltros.ForeColor = Color.FromArgb(159, 122, 234);
            gbFiltros.Location = new Point(12, 77);
            gbFiltros.Name = "gbFiltros";
            gbFiltros.Size = new Size(1283, 157);
            gbFiltros.TabIndex = 1;
            gbFiltros.TabStop = false;
            gbFiltros.Text = "Filtros de Auditoría";
            // 
            // btnExportar
            // 
            btnExportar.BackColor = Color.FromArgb(76, 175, 80);
            btnExportar.FlatStyle = FlatStyle.Flat;
            btnExportar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnExportar.ForeColor = Color.White;
            btnExportar.Location = new Point(916, 97);
            btnExportar.Name = "btnExportar";
            btnExportar.Size = new Size(180, 35);
            btnExportar.TabIndex = 11;
            btnExportar.Text = "Exportar a Excel";
            btnExportar.UseVisualStyleBackColor = false;
            // 
            // btnGenerar
            // 
            btnGenerar.BackColor = Color.FromArgb(159, 122, 234);
            btnGenerar.FlatStyle = FlatStyle.Flat;
            btnGenerar.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnGenerar.ForeColor = Color.White;
            btnGenerar.Location = new Point(707, 97);
            btnGenerar.Name = "btnGenerar";
            btnGenerar.Size = new Size(180, 35);
            btnGenerar.TabIndex = 10;
            btnGenerar.Text = "Generar Reporte";
            btnGenerar.UseVisualStyleBackColor = false;
            // 
            // cmbProducto
            // 
            cmbProducto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProducto.FormattingEnabled = true;
            cmbProducto.Location = new Point(707, 26);
            cmbProducto.Name = "cmbProducto";
            cmbProducto.Size = new Size(200, 36);
            cmbProducto.TabIndex = 9;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(592, 26);
            label5.Name = "label5";
            label5.Size = new Size(103, 28);
            label5.TabIndex = 8;
            label5.Text = "Producto:";
            // 
            // cmbAccion
            // 
            cmbAccion.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbAccion.FormattingEnabled = true;
            cmbAccion.Items.AddRange(new object[] { "Todos", "Creación", "Modificación", "Eliminación", "Login", "Acceso" });
            cmbAccion.Location = new Point(340, 107);
            cmbAccion.Name = "cmbAccion";
            cmbAccion.Size = new Size(200, 36);
            cmbAccion.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(250, 107);
            label4.Name = "label4";
            label4.Size = new Size(81, 28);
            label4.TabIndex = 6;
            label4.Text = "Acción:";
            // 
            // cmbUsuario
            // 
            cmbUsuario.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbUsuario.FormattingEnabled = true;
            cmbUsuario.Location = new Point(349, 23);
            cmbUsuario.Name = "cmbUsuario";
            cmbUsuario.Size = new Size(200, 36);
            cmbUsuario.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(260, 30);
            label3.Name = "label3";
            label3.Size = new Size(89, 28);
            label3.TabIndex = 4;
            label3.Text = "Usuario:";
            // 
            // dtpFechaFin
            // 
            dtpFechaFin.Format = DateTimePickerFormat.Short;
            dtpFechaFin.Location = new Point(124, 103);
            dtpFechaFin.Name = "dtpFechaFin";
            dtpFechaFin.Size = new Size(120, 33);
            dtpFechaFin.TabIndex = 3;
            // 
            // dtpFechaInicio
            // 
            dtpFechaInicio.Format = DateTimePickerFormat.Short;
            dtpFechaInicio.Location = new Point(124, 40);
            dtpFechaInicio.Name = "dtpFechaInicio";
            dtpFechaInicio.Size = new Size(120, 33);
            dtpFechaInicio.TabIndex = 2;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 100);
            label2.Name = "label2";
            label2.Size = new Size(105, 28);
            label2.TabIndex = 1;
            label2.Text = "Fecha Fin:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(0, 45);
            label1.Name = "label1";
            label1.Size = new Size(129, 28);
            label1.TabIndex = 0;
            label1.Text = "Fecha Inicio:";
            // 
            // dgvAuditorias
            // 
            dgvAuditorias.AllowUserToAddRows = false;
            dgvAuditorias.AllowUserToDeleteRows = false;
            dgvAuditorias.AllowUserToResizeColumns = false;
            dgvAuditorias.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(250, 250, 250);
            dgvAuditorias.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dgvAuditorias.Anchor = AnchorStyles.None;
            dgvAuditorias.BackgroundColor = Color.FromArgb(42, 34, 58);
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(159, 122, 234);
            dataGridViewCellStyle2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            dgvAuditorias.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            dgvAuditorias.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAuditorias.Columns.AddRange(new DataGridViewColumn[] { colIdMovimiento, colFecha, colTipoMovimiento, colIdUsuario, colIpEquipo, colNombreEquipo });
            dataGridViewCellStyle4.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = SystemColors.Window;
            dataGridViewCellStyle4.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle4.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = Color.FromArgb(232, 218, 255);
            dataGridViewCellStyle4.SelectionForeColor = Color.Black;
            dataGridViewCellStyle4.WrapMode = DataGridViewTriState.False;
            dgvAuditorias.DefaultCellStyle = dataGridViewCellStyle4;
            dgvAuditorias.GridColor = SystemColors.Info;
            dgvAuditorias.ImeMode = ImeMode.Disable;
            dgvAuditorias.Location = new Point(69, 254);
            dgvAuditorias.Margin = new Padding(4, 5, 4, 5);
            dgvAuditorias.Name = "dgvAuditorias";
            dgvAuditorias.ReadOnly = true;
            dgvAuditorias.RowHeadersVisible = false;
            dgvAuditorias.RowHeadersWidth = 62;
            dgvAuditorias.Size = new Size(1147, 437);
            dgvAuditorias.TabIndex = 0;
            // 
            // colIdMovimiento
            // 
            colIdMovimiento.DataPropertyName = "id_Movimiento_Producto";
            colIdMovimiento.HeaderText = "ID Movimiento";
            colIdMovimiento.MinimumWidth = 8;
            colIdMovimiento.Name = "colIdMovimiento";
            colIdMovimiento.ReadOnly = true;
            colIdMovimiento.Width = 150;
            // 
            // colFecha
            // 
            colFecha.DataPropertyName = "Fecha";
            dataGridViewCellStyle3.BackColor = Color.FromArgb(74, 60, 96);
            dataGridViewCellStyle3.ForeColor = Color.White;
            colFecha.DefaultCellStyle = dataGridViewCellStyle3;
            colFecha.HeaderText = "FECHA";
            colFecha.MinimumWidth = 8;
            colFecha.Name = "colFecha";
            colFecha.ReadOnly = true;
            colFecha.Width = 150;
            // 
            // colTipoMovimiento
            // 
            colTipoMovimiento.DataPropertyName = "tipo_movimiento";
            colTipoMovimiento.DefaultCellStyle = dataGridViewCellStyle3;
            colTipoMovimiento.HeaderText = "TIPO DE MOVIMIENTO";
            colTipoMovimiento.MinimumWidth = 8;
            colTipoMovimiento.Name = "colTipoMovimiento";
            colTipoMovimiento.ReadOnly = true;
            colTipoMovimiento.Width = 180;
            // 
            // colIdUsuario
            // 
            colIdUsuario.DataPropertyName = "id_Usuario";
            colIdUsuario.DefaultCellStyle = dataGridViewCellStyle3;
            colIdUsuario.HeaderText = "ID USUARIO";
            colIdUsuario.MinimumWidth = 8;
            colIdUsuario.Name = "colIdUsuario";
            colIdUsuario.ReadOnly = true;
            colIdUsuario.Width = 120;
            // 
            // colIpEquipo
            // 
            colIpEquipo.DataPropertyName = "ip_equipo";
            colIpEquipo.DefaultCellStyle = dataGridViewCellStyle3;
            colIpEquipo.HeaderText = "IP EQUIPO";
            colIpEquipo.MinimumWidth = 8;
            colIpEquipo.Name = "colIpEquipo";
            colIpEquipo.ReadOnly = true;
            colIpEquipo.Width = 150;
            // 
            // colNombreEquipo
            // 
            colNombreEquipo.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            colNombreEquipo.DataPropertyName = "nombre_equipo";
            colNombreEquipo.DefaultCellStyle = dataGridViewCellStyle3;
            colNombreEquipo.HeaderText = "EQUIPO";
            colNombreEquipo.MinimumWidth = 8;
            colNombreEquipo.Name = "colNombreEquipo";
            colNombreEquipo.ReadOnly = true;
            // 
            // frmVReportesAuditoria
            // 
            BackColor = Color.FromArgb(245, 245, 245);
            ClientSize = new Size(1307, 661);
            Controls.Add(dgvAuditorias);
            Controls.Add(gbFiltros);
            Controls.Add(pnlTitulo);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frmVReportesAuditoria";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Reporte de Auditorías";
            pnlTitulo.ResumeLayout(false);
            gbFiltros.ResumeLayout(false);
            gbFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAuditorias).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTitulo;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.GroupBox gbFiltros;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpFechaInicio;
        private System.Windows.Forms.DateTimePicker dtpFechaFin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbUsuario;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbAccion;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmbProducto;
        private System.Windows.Forms.Button btnGenerar;
        private System.Windows.Forms.Button btnExportar;
        private DataGridView dgvAuditorias;
        private DataGridViewTextBoxColumn colIdMovimiento;
        private DataGridViewTextBoxColumn colFecha;
        private DataGridViewTextBoxColumn colTipoMovimiento;
        private DataGridViewTextBoxColumn colIdUsuario;
        private DataGridViewTextBoxColumn colIpEquipo;
        private DataGridViewTextBoxColumn colNombreEquipo;
        private System.Windows.Forms.ToolTip toolTip;
    }
}