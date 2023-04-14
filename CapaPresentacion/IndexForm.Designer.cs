namespace CapaPresentacion
{
    partial class IndexForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IndexForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computadoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.creaTabletToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaTelefonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crearAsignacionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarPDAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.asignarTelefonoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.itemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.eliminaItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loginToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creaUsuariosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.menuStrip1.Font = new System.Drawing.Font("Roboto", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.loginToolStripMenuItem,
            this.usuariosToolStripMenuItem,
            this.computadoresToolStripMenuItem,
            this.asignarToolStripMenuItem,
            this.itemToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.Professional;
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesionToolStripMenuItem});
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(48, 20);
            this.toolStripMenuItem1.Text = "Inicio";
            // 
            // cerrarSesionToolStripMenuItem
            // 
            this.cerrarSesionToolStripMenuItem.Name = "cerrarSesionToolStripMenuItem";
            this.cerrarSesionToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.cerrarSesionToolStripMenuItem.Text = "Cerrar sesión";
            this.cerrarSesionToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // usuariosToolStripMenuItem
            // 
            this.usuariosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem});
            this.usuariosToolStripMenuItem.Name = "usuariosToolStripMenuItem";
            this.usuariosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.usuariosToolStripMenuItem.Text = "Usuarios";
            // 
            // crearToolStripMenuItem
            // 
            this.crearToolStripMenuItem.Name = "crearToolStripMenuItem";
            this.crearToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.crearToolStripMenuItem.Text = "Crea Usuario";
            this.crearToolStripMenuItem.Click += new System.EventHandler(this.crearToolStripMenuItem_Click);
            // 
            // computadoresToolStripMenuItem
            // 
            this.computadoresToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearToolStripMenuItem1,
            this.creaTabletToolStripMenuItem,
            this.creaTelefonoToolStripMenuItem});
            this.computadoresToolStripMenuItem.Name = "computadoresToolStripMenuItem";
            this.computadoresToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.computadoresToolStripMenuItem.Text = "Dispositivos";
            // 
            // crearToolStripMenuItem1
            // 
            this.crearToolStripMenuItem1.Name = "crearToolStripMenuItem1";
            this.crearToolStripMenuItem1.Size = new System.Drawing.Size(171, 22);
            this.crearToolStripMenuItem1.Text = "Crea Computador";
            this.crearToolStripMenuItem1.Click += new System.EventHandler(this.crearToolStripMenuItem1_Click);
            // 
            // creaTabletToolStripMenuItem
            // 
            this.creaTabletToolStripMenuItem.Name = "creaTabletToolStripMenuItem";
            this.creaTabletToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.creaTabletToolStripMenuItem.Text = "Crea Tablet";
            // 
            // creaTelefonoToolStripMenuItem
            // 
            this.creaTelefonoToolStripMenuItem.Name = "creaTelefonoToolStripMenuItem";
            this.creaTelefonoToolStripMenuItem.Size = new System.Drawing.Size(171, 22);
            this.creaTelefonoToolStripMenuItem.Text = "Crea Telefono";
            // 
            // asignarToolStripMenuItem
            // 
            this.asignarToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crearAsignacionToolStripMenuItem,
            this.asignarPDAToolStripMenuItem,
            this.asignarTelefonoToolStripMenuItem});
            this.asignarToolStripMenuItem.Name = "asignarToolStripMenuItem";
            this.asignarToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.asignarToolStripMenuItem.Text = "Asignar";
            // 
            // crearAsignacionToolStripMenuItem
            // 
            this.crearAsignacionToolStripMenuItem.Name = "crearAsignacionToolStripMenuItem";
            this.crearAsignacionToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.crearAsignacionToolStripMenuItem.Text = "Asigna Computador";
            this.crearAsignacionToolStripMenuItem.Click += new System.EventHandler(this.crearAsignacionToolStripMenuItem_Click);
            // 
            // asignarPDAToolStripMenuItem
            // 
            this.asignarPDAToolStripMenuItem.Name = "asignarPDAToolStripMenuItem";
            this.asignarPDAToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.asignarPDAToolStripMenuItem.Text = "Asignar PDA";
            // 
            // asignarTelefonoToolStripMenuItem
            // 
            this.asignarTelefonoToolStripMenuItem.Name = "asignarTelefonoToolStripMenuItem";
            this.asignarTelefonoToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
            this.asignarTelefonoToolStripMenuItem.Text = "Asignar Telefono";
            // 
            // itemToolStripMenuItem
            // 
            this.itemToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaItemToolStripMenuItem,
            this.eliminaItemToolStripMenuItem});
            this.itemToolStripMenuItem.Name = "itemToolStripMenuItem";
            this.itemToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.itemToolStripMenuItem.Text = "Item";
            // 
            // creaItemToolStripMenuItem
            // 
            this.creaItemToolStripMenuItem.Name = "creaItemToolStripMenuItem";
            this.creaItemToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.creaItemToolStripMenuItem.Text = "Crea Item";
            this.creaItemToolStripMenuItem.Click += new System.EventHandler(this.creaItemToolStripMenuItem_Click);
            // 
            // eliminaItemToolStripMenuItem
            // 
            this.eliminaItemToolStripMenuItem.Name = "eliminaItemToolStripMenuItem";
            this.eliminaItemToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.eliminaItemToolStripMenuItem.Text = "Elimina Item";
            // 
            // loginToolStripMenuItem
            // 
            this.loginToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.creaUsuariosToolStripMenuItem});
            this.loginToolStripMenuItem.Name = "loginToolStripMenuItem";
            this.loginToolStripMenuItem.Size = new System.Drawing.Size(49, 20);
            this.loginToolStripMenuItem.Text = "Login";
            // 
            // creaUsuariosToolStripMenuItem
            // 
            this.creaUsuariosToolStripMenuItem.Name = "creaUsuariosToolStripMenuItem";
            this.creaUsuariosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.creaUsuariosToolStripMenuItem.Text = "Crea Usuarios";
            this.creaUsuariosToolStripMenuItem.Click += new System.EventHandler(this.creaUsuariosToolStripMenuItem_Click);
            // 
            // IndexForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "IndexForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Utilidades Cerasus";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem usuariosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearAsignacionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computadoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem crearToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem creaTabletToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaTelefonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarPDAToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem asignarTelefonoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem itemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem eliminaItemToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loginToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem creaUsuariosToolStripMenuItem;
    }
}