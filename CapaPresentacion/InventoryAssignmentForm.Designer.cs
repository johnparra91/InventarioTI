namespace CapaPresentacion
{
    partial class InventoryAssignmentForm
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
            this.BtnDevolucion = new System.Windows.Forms.Button();
            this.BtnAsignar = new System.Windows.Forms.Button();
            this.dataGridViewAsignaciones = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.LblCod_Usuario = new System.Windows.Forms.Label();
            this.LblCodUsuario = new System.Windows.Forms.Label();
            this.Btn_Enviar = new System.Windows.Forms.Button();
            this.BtnPDF = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.LblUsuarioEntrega = new System.Windows.Forms.Label();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.BtnDescargarActa = new System.Windows.Forms.Button();
            this.signaturePictureBox = new System.Windows.Forms.PictureBox();
            this.BtnFirmar = new System.Windows.Forms.Button();
            this.BtnDescargarFirma = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.LblProgreso = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnCargarActa = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signaturePictureBox)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnDevolucion
            // 
            this.BtnDevolucion.Location = new System.Drawing.Point(91, 17);
            this.BtnDevolucion.Name = "BtnDevolucion";
            this.BtnDevolucion.Size = new System.Drawing.Size(79, 39);
            this.BtnDevolucion.TabIndex = 14;
            this.BtnDevolucion.Text = "Devolucion";
            this.BtnDevolucion.UseVisualStyleBackColor = true;
            this.BtnDevolucion.Click += new System.EventHandler(this.BtnDevolucion_Click);
            // 
            // BtnAsignar
            // 
            this.BtnAsignar.Location = new System.Drawing.Point(6, 17);
            this.BtnAsignar.Name = "BtnAsignar";
            this.BtnAsignar.Size = new System.Drawing.Size(79, 39);
            this.BtnAsignar.TabIndex = 13;
            this.BtnAsignar.Text = "Asignar";
            this.BtnAsignar.UseVisualStyleBackColor = true;
            this.BtnAsignar.Click += new System.EventHandler(this.BtnAsignar_Click);
            // 
            // dataGridViewAsignaciones
            // 
            this.dataGridViewAsignaciones.AllowUserToAddRows = false;
            this.dataGridViewAsignaciones.AllowUserToOrderColumns = true;
            this.dataGridViewAsignaciones.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewAsignaciones.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewAsignaciones.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewAsignaciones.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAsignaciones.Location = new System.Drawing.Point(0, 221);
            this.dataGridViewAsignaciones.Name = "dataGridViewAsignaciones";
            this.dataGridViewAsignaciones.Size = new System.Drawing.Size(1236, 332);
            this.dataGridViewAsignaciones.TabIndex = 12;
            this.dataGridViewAsignaciones.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewAsignaciones_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1236, 24);
            this.menuStrip1.TabIndex = 15;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(6, 122);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 16;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox2
            // 
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(6, 80);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(305, 21);
            this.comboBox2.TabIndex = 17;
            // 
            // LblCod_Usuario
            // 
            this.LblCod_Usuario.AutoSize = true;
            this.LblCod_Usuario.Location = new System.Drawing.Point(6, 106);
            this.LblCod_Usuario.Name = "LblCod_Usuario";
            this.LblCod_Usuario.Size = new System.Drawing.Size(24, 13);
            this.LblCod_Usuario.TabIndex = 18;
            this.LblCod_Usuario.Text = "PC:";
            // 
            // LblCodUsuario
            // 
            this.LblCodUsuario.AutoSize = true;
            this.LblCodUsuario.Location = new System.Drawing.Point(6, 64);
            this.LblCodUsuario.Name = "LblCodUsuario";
            this.LblCodUsuario.Size = new System.Drawing.Size(44, 13);
            this.LblCodUsuario.TabIndex = 19;
            this.LblCodUsuario.Text = "Recibe:";
            // 
            // Btn_Enviar
            // 
            this.Btn_Enviar.Location = new System.Drawing.Point(260, 100);
            this.Btn_Enviar.Name = "Btn_Enviar";
            this.Btn_Enviar.Size = new System.Drawing.Size(75, 23);
            this.Btn_Enviar.TabIndex = 20;
            this.Btn_Enviar.Text = "ENVIAR";
            this.Btn_Enviar.UseVisualStyleBackColor = true;
            this.Btn_Enviar.Click += new System.EventHandler(this.Btn_Enviar_Click);
            // 
            // BtnPDF
            // 
            this.BtnPDF.Location = new System.Drawing.Point(260, 76);
            this.BtnPDF.Name = "BtnPDF";
            this.BtnPDF.Size = new System.Drawing.Size(75, 23);
            this.BtnPDF.TabIndex = 21;
            this.BtnPDF.Text = "PDF";
            this.BtnPDF.UseVisualStyleBackColor = true;
            this.BtnPDF.Click += new System.EventHandler(this.BtnPDF_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.LblUsuarioEntrega);
            this.groupBox1.Controls.Add(this.comboBox3);
            this.groupBox1.Controls.Add(this.LblCodUsuario);
            this.groupBox1.Controls.Add(this.comboBox1);
            this.groupBox1.Controls.Add(this.comboBox2);
            this.groupBox1.Controls.Add(this.LblCod_Usuario);
            this.groupBox1.Location = new System.Drawing.Point(12, 39);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 154);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Asignar Un Computador";
            // 
            // LblUsuarioEntrega
            // 
            this.LblUsuarioEntrega.AutoSize = true;
            this.LblUsuarioEntrega.Location = new System.Drawing.Point(6, 21);
            this.LblUsuarioEntrega.Name = "LblUsuarioEntrega";
            this.LblUsuarioEntrega.Size = new System.Drawing.Size(47, 13);
            this.LblUsuarioEntrega.TabIndex = 21;
            this.LblUsuarioEntrega.Text = "Entrega:";
            // 
            // comboBox3
            // 
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Location = new System.Drawing.Point(6, 35);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(305, 21);
            this.comboBox3.TabIndex = 20;
            // 
            // BtnDescargarActa
            // 
            this.BtnDescargarActa.Location = new System.Drawing.Point(176, 17);
            this.BtnDescargarActa.Name = "BtnDescargarActa";
            this.BtnDescargarActa.Size = new System.Drawing.Size(98, 39);
            this.BtnDescargarActa.TabIndex = 23;
            this.BtnDescargarActa.Text = "Descargar Acta";
            this.BtnDescargarActa.UseVisualStyleBackColor = true;
            this.BtnDescargarActa.Click += new System.EventHandler(this.BtnDescargarActa_Click);
            // 
            // signaturePictureBox
            // 
            this.signaturePictureBox.BackColor = System.Drawing.Color.Black;
            this.signaturePictureBox.Location = new System.Drawing.Point(6, 21);
            this.signaturePictureBox.Name = "signaturePictureBox";
            this.signaturePictureBox.Size = new System.Drawing.Size(248, 90);
            this.signaturePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.signaturePictureBox.TabIndex = 24;
            this.signaturePictureBox.TabStop = false;
            // 
            // BtnFirmar
            // 
            this.BtnFirmar.Location = new System.Drawing.Point(260, 21);
            this.BtnFirmar.Name = "BtnFirmar";
            this.BtnFirmar.Size = new System.Drawing.Size(76, 23);
            this.BtnFirmar.TabIndex = 25;
            this.BtnFirmar.Text = "Firmar";
            this.BtnFirmar.UseVisualStyleBackColor = true;
            this.BtnFirmar.Click += new System.EventHandler(this.BtnFirmar_Click);
            // 
            // BtnDescargarFirma
            // 
            this.BtnDescargarFirma.Location = new System.Drawing.Point(260, 50);
            this.BtnDescargarFirma.Name = "BtnDescargarFirma";
            this.BtnDescargarFirma.Size = new System.Drawing.Size(76, 23);
            this.BtnDescargarFirma.TabIndex = 26;
            this.BtnDescargarFirma.Text = "Descargar";
            this.BtnDescargarFirma.UseVisualStyleBackColor = true;
            this.BtnDescargarFirma.Click += new System.EventHandler(this.BtnDescargarFirma_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar1.Location = new System.Drawing.Point(885, 559);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(339, 23);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 27;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.signaturePictureBox);
            this.groupBox2.Controls.Add(this.BtnFirmar);
            this.groupBox2.Controls.Add(this.BtnDescargarFirma);
            this.groupBox2.Controls.Add(this.BtnPDF);
            this.groupBox2.Controls.Add(this.Btn_Enviar);
            this.groupBox2.Location = new System.Drawing.Point(1002, 39);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(344, 127);
            this.groupBox2.TabIndex = 28;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            this.groupBox2.Visible = false;
            // 
            // LblProgreso
            // 
            this.LblProgreso.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LblProgreso.AutoSize = true;
            this.LblProgreso.Location = new System.Drawing.Point(682, 563);
            this.LblProgreso.Name = "LblProgreso";
            this.LblProgreso.Size = new System.Drawing.Size(43, 13);
            this.LblProgreso.TabIndex = 29;
            this.LblProgreso.Text = "Estado:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnCargarActa);
            this.groupBox3.Controls.Add(this.BtnAsignar);
            this.groupBox3.Controls.Add(this.BtnDevolucion);
            this.groupBox3.Controls.Add(this.BtnDescargarActa);
            this.groupBox3.Location = new System.Drawing.Point(356, 39);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(286, 154);
            this.groupBox3.TabIndex = 24;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Acciones - Acta";
            // 
            // BtnCargarActa
            // 
            this.BtnCargarActa.Location = new System.Drawing.Point(6, 60);
            this.BtnCargarActa.Name = "BtnCargarActa";
            this.BtnCargarActa.Size = new System.Drawing.Size(79, 39);
            this.BtnCargarActa.TabIndex = 24;
            this.BtnCargarActa.Text = "Cargar...";
            this.BtnCargarActa.UseVisualStyleBackColor = true;
            this.BtnCargarActa.Click += new System.EventHandler(this.BtnCargarActa_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog1";
            // 
            // InventoryAssignmentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1236, 585);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.LblProgreso);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridViewAsignaciones);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "InventoryAssignmentForm";
            this.Text = "InventoryAssignmentForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAsignaciones)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.signaturePictureBox)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnDevolucion;
        private System.Windows.Forms.Button BtnAsignar;
        private System.Windows.Forms.DataGridView dataGridViewAsignaciones;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label LblCod_Usuario;
        private System.Windows.Forms.Label LblCodUsuario;
        private System.Windows.Forms.Button Btn_Enviar;
        private System.Windows.Forms.Button BtnPDF;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnDescargarActa;
        private System.Windows.Forms.PictureBox signaturePictureBox;
        private System.Windows.Forms.Button BtnFirmar;
        private System.Windows.Forms.Button BtnDescargarFirma;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label LblProgreso;
        private System.Windows.Forms.Label LblUsuarioEntrega;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnCargarActa;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}