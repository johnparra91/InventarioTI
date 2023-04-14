namespace CapaPresentacion
{
    partial class LoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.TxtIniciaSesionUsuario = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIniciaSesionContraseña = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnIniciaLogin = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.BtnSalirLogin = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // TxtIniciaSesionUsuario
            // 
            this.TxtIniciaSesionUsuario.Location = new System.Drawing.Point(12, 133);
            this.TxtIniciaSesionUsuario.Name = "TxtIniciaSesionUsuario";
            this.TxtIniciaSesionUsuario.Size = new System.Drawing.Size(236, 20);
            this.TxtIniciaSesionUsuario.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(12, 162);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // TxtIniciaSesionContraseña
            // 
            this.TxtIniciaSesionContraseña.Location = new System.Drawing.Point(12, 178);
            this.TxtIniciaSesionContraseña.Name = "TxtIniciaSesionContraseña";
            this.TxtIniciaSesionContraseña.Size = new System.Drawing.Size(236, 20);
            this.TxtIniciaSesionContraseña.TabIndex = 1;
            this.TxtIniciaSesionContraseña.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(9, 117);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // btnIniciaLogin
            // 
            this.btnIniciaLogin.BackColor = System.Drawing.Color.Green;
            this.btnIniciaLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnIniciaLogin.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIniciaLogin.ForeColor = System.Drawing.Color.White;
            this.btnIniciaLogin.Location = new System.Drawing.Point(12, 218);
            this.btnIniciaLogin.Name = "btnIniciaLogin";
            this.btnIniciaLogin.Size = new System.Drawing.Size(134, 23);
            this.btnIniciaLogin.TabIndex = 2;
            this.btnIniciaLogin.Text = "Iniciar";
            this.btnIniciaLogin.UseVisualStyleBackColor = false;
            this.btnIniciaLogin.Click += new System.EventHandler(this.btnIniciaLogin_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(78, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(100, 73);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            // 
            // BtnSalirLogin
            // 
            this.BtnSalirLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            this.BtnSalirLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnSalirLogin.Font = new System.Drawing.Font("Roboto", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnSalirLogin.ForeColor = System.Drawing.Color.White;
            this.BtnSalirLogin.Location = new System.Drawing.Point(152, 218);
            this.BtnSalirLogin.Name = "BtnSalirLogin";
            this.BtnSalirLogin.Size = new System.Drawing.Size(96, 23);
            this.BtnSalirLogin.TabIndex = 6;
            this.BtnSalirLogin.Text = "Salir";
            this.BtnSalirLogin.UseVisualStyleBackColor = false;
            this.BtnSalirLogin.Click += new System.EventHandler(this.BtnSalirLogin_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 320);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(260, 17);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 7;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(260, 337);
            this.ControlBox = false;
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.BtnSalirLogin);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.TxtIniciaSesionUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TxtIniciaSesionContraseña);
            this.Controls.Add(this.btnIniciaLogin);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoginForm";
            this.Opacity = 0.95D;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Identificación";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtIniciaSesionUsuario;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIniciaSesionContraseña;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIniciaLogin;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button BtnSalirLogin;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}