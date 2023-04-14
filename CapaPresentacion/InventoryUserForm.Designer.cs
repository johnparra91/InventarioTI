namespace CapaPresentacion
{
    partial class InventoryUserForm
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
            this.BtnEliminarUSUARIO_PC = new System.Windows.Forms.Button();
            this.BtnGrabarDispositivoTI = new System.Windows.Forms.Button();
            this.dataGridViewUsuariosInventory = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.cerrarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuariosInventory)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // BtnEliminarUSUARIO_PC
            // 
            this.BtnEliminarUSUARIO_PC.Location = new System.Drawing.Point(72, 43);
            this.BtnEliminarUSUARIO_PC.Name = "BtnEliminarUSUARIO_PC";
            this.BtnEliminarUSUARIO_PC.Size = new System.Drawing.Size(54, 39);
            this.BtnEliminarUSUARIO_PC.TabIndex = 10;
            this.BtnEliminarUSUARIO_PC.Text = "Eliminar";
            this.BtnEliminarUSUARIO_PC.UseVisualStyleBackColor = true;
            this.BtnEliminarUSUARIO_PC.Click += new System.EventHandler(this.BtnEliminarUSUARIO_PC_Click);
            // 
            // BtnGrabarDispositivoTI
            // 
            this.BtnGrabarDispositivoTI.Location = new System.Drawing.Point(12, 43);
            this.BtnGrabarDispositivoTI.Name = "BtnGrabarDispositivoTI";
            this.BtnGrabarDispositivoTI.Size = new System.Drawing.Size(54, 39);
            this.BtnGrabarDispositivoTI.TabIndex = 9;
            this.BtnGrabarDispositivoTI.Text = "Insertar";
            this.BtnGrabarDispositivoTI.UseVisualStyleBackColor = true;
            this.BtnGrabarDispositivoTI.Click += new System.EventHandler(this.BtnGrabarDispositivoTI_Click);
            // 
            // dataGridViewUsuariosInventory
            // 
            this.dataGridViewUsuariosInventory.AllowUserToOrderColumns = true;
            this.dataGridViewUsuariosInventory.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridViewUsuariosInventory.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dataGridViewUsuariosInventory.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridViewUsuariosInventory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewUsuariosInventory.Location = new System.Drawing.Point(0, 147);
            this.dataGridViewUsuariosInventory.Name = "dataGridViewUsuariosInventory";
            this.dataGridViewUsuariosInventory.Size = new System.Drawing.Size(800, 290);
            this.dataGridViewUsuariosInventory.TabIndex = 6;
            this.dataGridViewUsuariosInventory.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewUsuariosInventory_CellEndEdit);
            this.dataGridViewUsuariosInventory.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridViewUsuariosInventory_CellFormatting);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // cerrarToolStripMenuItem
            // 
            this.cerrarToolStripMenuItem.Name = "cerrarToolStripMenuItem";
            this.cerrarToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.cerrarToolStripMenuItem.Text = "Cerrar";
            this.cerrarToolStripMenuItem.Click += new System.EventHandler(this.cerrarToolStripMenuItem_Click);
            // 
            // InventoryUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.BtnEliminarUSUARIO_PC);
            this.Controls.Add(this.BtnGrabarDispositivoTI);
            this.Controls.Add(this.dataGridViewUsuariosInventory);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "InventoryUserForm";
            this.Text = "InventoryUserForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewUsuariosInventory)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnEliminarUSUARIO_PC;
        private System.Windows.Forms.Button BtnGrabarDispositivoTI;
        private System.Windows.Forms.DataGridView dataGridViewUsuariosInventory;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem cerrarToolStripMenuItem;
    }
}