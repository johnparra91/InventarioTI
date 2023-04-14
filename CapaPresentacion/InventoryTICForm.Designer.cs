namespace CapaPresentacion
{
    partial class InventoryTICForm
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataGridViewDispositivos = new System.Windows.Forms.DataGridView();
            this.BtnGrabarDispositivoTI = new System.Windows.Forms.Button();
            this.BtnEliminarDispositivoTI = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDispositivos)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // dataGridViewDispositivos
            // 
            this.dataGridViewDispositivos.AllowUserToOrderColumns = true;
            this.dataGridViewDispositivos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewDispositivos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewDispositivos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewDispositivos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewDispositivos.Location = new System.Drawing.Point(0, 72);
            this.dataGridViewDispositivos.Name = "dataGridViewDispositivos";
            this.dataGridViewDispositivos.Size = new System.Drawing.Size(800, 378);
            this.dataGridViewDispositivos.TabIndex = 1;
            this.dataGridViewDispositivos.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridViewDispositivos_CellBeginEdit);
            this.dataGridViewDispositivos.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewDispositivos_CellEndEdit);
            this.dataGridViewDispositivos.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewDispositivos_CellFormatting);
            // 
            // BtnGrabarDispositivoTI
            // 
            this.BtnGrabarDispositivoTI.Location = new System.Drawing.Point(12, 27);
            this.BtnGrabarDispositivoTI.Name = "BtnGrabarDispositivoTI";
            this.BtnGrabarDispositivoTI.Size = new System.Drawing.Size(54, 39);
            this.BtnGrabarDispositivoTI.TabIndex = 4;
            this.BtnGrabarDispositivoTI.Text = "Insertar";
            this.BtnGrabarDispositivoTI.UseVisualStyleBackColor = true;
            this.BtnGrabarDispositivoTI.Click += new System.EventHandler(this.BtnGrabarDispositivoTI_Click);
            // 
            // BtnEliminarDispositivoTI
            // 
            this.BtnEliminarDispositivoTI.Location = new System.Drawing.Point(72, 27);
            this.BtnEliminarDispositivoTI.Name = "BtnEliminarDispositivoTI";
            this.BtnEliminarDispositivoTI.Size = new System.Drawing.Size(54, 39);
            this.BtnEliminarDispositivoTI.TabIndex = 5;
            this.BtnEliminarDispositivoTI.Text = "Eliminar";
            this.BtnEliminarDispositivoTI.UseVisualStyleBackColor = true;
            this.BtnEliminarDispositivoTI.Click += new System.EventHandler(this.BtnEliminarDispositivoTI_Click);
            // 
            // InventoryTICForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEliminarDispositivoTI);
            this.Controls.Add(this.BtnGrabarDispositivoTI);
            this.Controls.Add(this.dataGridViewDispositivos);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InventoryTICForm";
            this.Text = "InventoryTICForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewDispositivos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
        private System.Windows.Forms.DataGridView dataGridViewDispositivos;
        private System.Windows.Forms.Button BtnGrabarDispositivoTI;
        private System.Windows.Forms.Button BtnEliminarDispositivoTI;
    }
}