namespace InvSis.Views
{
    partial class frmDetalleProductoForm
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">Indica si los recursos administrados deben ser eliminados.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        private void InitializeComponent()
        {
            label1 = new Label();
            txtIdProducto = new TextBox();
            label2 = new Label();
            txtNombre = new TextBox();
            label3 = new Label();
            txtCategoria = new TextBox();
            label4 = new Label();
            txtCosto = new TextBox();
            label5 = new Label();
            txtStock = new TextBox();
            label6 = new Label();
            txtUbicacion = new TextBox();
            btnGuardar = new Button();
            btnCancelar = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(91, 55);
            label1.Name = "label1";
            label1.Size = new Size(73, 15);
            label1.TabIndex = 0;
            label1.Text = "ID Producto:";
            // 
            // txtIdProducto
            // 
            txtIdProducto.Location = new Point(191, 48);
            txtIdProducto.MaxLength = 10;
            txtIdProducto.Name = "txtIdProducto";
            txtIdProducto.ReadOnly = true;
            txtIdProducto.Size = new Size(200, 23);
            txtIdProducto.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(91, 85);
            label2.Name = "label2";
            label2.Size = new Size(54, 15);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(191, 78);
            txtNombre.MaxLength = 30;
            txtNombre.Name = "txtNombre";
            txtNombre.ReadOnly = true;
            txtNombre.Size = new Size(200, 23);
            txtNombre.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(91, 115);
            label3.Name = "label3";
            label3.Size = new Size(61, 15);
            label3.TabIndex = 4;
            label3.Text = "Categoría:";
            // 
            // txtCategoria
            // 
            txtCategoria.Location = new Point(191, 108);
            txtCategoria.Name = "txtCategoria";
            txtCategoria.ReadOnly = true;
            txtCategoria.Size = new Size(200, 23);
            txtCategoria.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(91, 145);
            label4.Name = "label4";
            label4.Size = new Size(41, 15);
            label4.TabIndex = 6;
            label4.Text = "Costo:";
            // 
            // txtCosto
            // 
            txtCosto.Location = new Point(191, 138);
            txtCosto.MaxLength = 30;
            txtCosto.Name = "txtCosto";
            txtCosto.ReadOnly = true;
            txtCosto.Size = new Size(200, 23);
            txtCosto.TabIndex = 7;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(91, 175);
            label5.Name = "label5";
            label5.Size = new Size(39, 15);
            label5.TabIndex = 8;
            label5.Text = "Stock:";
            // 
            // txtStock
            // 
            txtStock.Location = new Point(191, 168);
            txtStock.MaxLength = 30;
            txtStock.Name = "txtStock";
            txtStock.ReadOnly = true;
            txtStock.Size = new Size(200, 23);
            txtStock.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(91, 205);
            label6.Name = "label6";
            label6.Size = new Size(63, 15);
            label6.TabIndex = 10;
            label6.Text = "Ubicación:";
            // 
            // txtUbicacion
            // 
            txtUbicacion.Location = new Point(191, 198);
            txtUbicacion.MaxLength = 30;
            txtUbicacion.Name = "txtUbicacion";
            txtUbicacion.ReadOnly = true;
            txtUbicacion.Size = new Size(200, 23);
            txtUbicacion.TabIndex = 11;
            // 
            // btnGuardar
            // 
            btnGuardar.Location = new Point(191, 240);
            btnGuardar.Name = "btnGuardar";
            btnGuardar.Size = new Size(88, 36);
            btnGuardar.TabIndex = 12;
            btnGuardar.Text = "Guardar";
            btnGuardar.UseVisualStyleBackColor = true;
            btnGuardar.Click += btnGuardar_Click;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(316, 240);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(90, 36);
            btnCancelar.TabIndex = 13;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            btnCancelar.Click += btnCancelar_Click;
            // 
            // frmDetalleProductoForm
            // 
            ClientSize = new Size(539, 352);
            Controls.Add(btnCancelar);
            Controls.Add(btnGuardar);
            Controls.Add(txtUbicacion);
            Controls.Add(label6);
            Controls.Add(txtStock);
            Controls.Add(label5);
            Controls.Add(txtCosto);
            Controls.Add(label4);
            Controls.Add(txtCategoria);
            Controls.Add(label3);
            Controls.Add(txtNombre);
            Controls.Add(label2);
            Controls.Add(txtIdProducto);
            Controls.Add(label1);
            Name = "frmDetalleProductoForm";
            Text = "Detalle de Productos";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIdProducto;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCosto;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtUbicacion;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnCancelar;
    }
}