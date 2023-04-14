namespace CapaPresentacion
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.TxtIniciaSesionUsuario = new System.Windows.Forms.TextBox();
            this.btnInicia = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtIniciaSesionContraseña = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnCrea = new System.Windows.Forms.Button();
            this.TxtCreaUsuario = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtCreaContraseña = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.TxtActualizaUsuario = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtActualizaContraseña = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.BtnActualiza = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.TxtEliminaUsuario = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.TxtEliminaContraseña = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.BtnElimina = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtIniciaSesionUsuario
            // 
            this.TxtIniciaSesionUsuario.Location = new System.Drawing.Point(128, 51);
            this.TxtIniciaSesionUsuario.Name = "TxtIniciaSesionUsuario";
            this.TxtIniciaSesionUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtIniciaSesionUsuario.TabIndex = 0;
            // 
            // btnInicia
            // 
            this.btnInicia.Location = new System.Drawing.Point(232, 144);
            this.btnInicia.Name = "btnInicia";
            this.btnInicia.Size = new System.Drawing.Size(75, 23);
            this.btnInicia.TabIndex = 2;
            this.btnInicia.Text = "Inicia";
            this.btnInicia.UseVisualStyleBackColor = true;
            this.btnInicia.Click += new System.EventHandler(this.btnIniciar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(30, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Usuario:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Contraseña:";
            // 
            // TxtIniciaSesionContraseña
            // 
            this.TxtIniciaSesionContraseña.Location = new System.Drawing.Point(128, 90);
            this.TxtIniciaSesionContraseña.Name = "TxtIniciaSesionContraseña";
            this.TxtIniciaSesionContraseña.Size = new System.Drawing.Size(100, 20);
            this.TxtIniciaSesionContraseña.TabIndex = 1;
            this.TxtIniciaSesionContraseña.UseSystemPasswordChar = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TxtIniciaSesionUsuario);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.TxtIniciaSesionContraseña);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnInicia);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(414, 255);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(338, 224);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Inicia  Sesión";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnCrea);
            this.groupBox2.Controls.Add(this.TxtCreaUsuario);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.TxtCreaContraseña);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(338, 224);
            this.groupBox2.TabIndex = 6;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Crea Usuario";
            // 
            // BtnCrea
            // 
            this.BtnCrea.Location = new System.Drawing.Point(232, 144);
            this.BtnCrea.Name = "BtnCrea";
            this.BtnCrea.Size = new System.Drawing.Size(75, 23);
            this.BtnCrea.TabIndex = 5;
            this.BtnCrea.Text = "Crea";
            this.BtnCrea.UseVisualStyleBackColor = true;
            this.BtnCrea.Click += new System.EventHandler(this.BtnCrea_Click);
            // 
            // TxtCreaUsuario
            // 
            this.TxtCreaUsuario.Location = new System.Drawing.Point(128, 51);
            this.TxtCreaUsuario.Name = "TxtCreaUsuario";
            this.TxtCreaUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtCreaUsuario.TabIndex = 0;
            this.TxtCreaUsuario.TextChanged += new System.EventHandler(this.TxtCreaUsuario_TextChanged);
            this.TxtCreaUsuario.Leave += new System.EventHandler(this.TxtCreaUsuario_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 97);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Contraseña:";
            // 
            // TxtCreaContraseña
            // 
            this.TxtCreaContraseña.Location = new System.Drawing.Point(128, 90);
            this.TxtCreaContraseña.Name = "TxtCreaContraseña";
            this.TxtCreaContraseña.Size = new System.Drawing.Size(100, 20);
            this.TxtCreaContraseña.TabIndex = 1;
            this.TxtCreaContraseña.UseSystemPasswordChar = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(30, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Usuario:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.TxtActualizaUsuario);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.TxtActualizaContraseña);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.BtnActualiza);
            this.groupBox3.Location = new System.Drawing.Point(414, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(338, 224);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Actualiza Usuario";
            // 
            // TxtActualizaUsuario
            // 
            this.TxtActualizaUsuario.Location = new System.Drawing.Point(128, 51);
            this.TxtActualizaUsuario.Name = "TxtActualizaUsuario";
            this.TxtActualizaUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtActualizaUsuario.TabIndex = 0;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(30, 97);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Contraseña:";
            // 
            // TxtActualizaContraseña
            // 
            this.TxtActualizaContraseña.Location = new System.Drawing.Point(128, 90);
            this.TxtActualizaContraseña.Name = "TxtActualizaContraseña";
            this.TxtActualizaContraseña.Size = new System.Drawing.Size(100, 20);
            this.TxtActualizaContraseña.TabIndex = 1;
            this.TxtActualizaContraseña.UseSystemPasswordChar = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(30, 57);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(46, 13);
            this.label6.TabIndex = 3;
            this.label6.Text = "Usuario:";
            // 
            // BtnActualiza
            // 
            this.BtnActualiza.Location = new System.Drawing.Point(232, 144);
            this.BtnActualiza.Name = "BtnActualiza";
            this.BtnActualiza.Size = new System.Drawing.Size(75, 23);
            this.BtnActualiza.TabIndex = 2;
            this.BtnActualiza.Text = "Actualiza";
            this.BtnActualiza.UseVisualStyleBackColor = true;
            this.BtnActualiza.Click += new System.EventHandler(this.BtnActualiza_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.TxtEliminaUsuario);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.TxtEliminaContraseña);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.BtnElimina);
            this.groupBox4.Location = new System.Drawing.Point(12, 255);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(338, 224);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Elimina Usuario";
            // 
            // TxtEliminaUsuario
            // 
            this.TxtEliminaUsuario.Location = new System.Drawing.Point(128, 51);
            this.TxtEliminaUsuario.Name = "TxtEliminaUsuario";
            this.TxtEliminaUsuario.Size = new System.Drawing.Size(100, 20);
            this.TxtEliminaUsuario.TabIndex = 0;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(30, 97);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Contraseña:";
            // 
            // TxtEliminaContraseña
            // 
            this.TxtEliminaContraseña.Enabled = false;
            this.TxtEliminaContraseña.Location = new System.Drawing.Point(128, 90);
            this.TxtEliminaContraseña.Name = "TxtEliminaContraseña";
            this.TxtEliminaContraseña.Size = new System.Drawing.Size(100, 20);
            this.TxtEliminaContraseña.TabIndex = 1;
            this.TxtEliminaContraseña.UseSystemPasswordChar = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(30, 57);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(46, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "Usuario:";
            // 
            // BtnElimina
            // 
            this.BtnElimina.Location = new System.Drawing.Point(232, 144);
            this.BtnElimina.Name = "BtnElimina";
            this.BtnElimina.Size = new System.Drawing.Size(75, 23);
            this.BtnElimina.TabIndex = 2;
            this.BtnElimina.Text = "Elimina";
            this.BtnElimina.UseVisualStyleBackColor = true;
            this.BtnElimina.Click += new System.EventHandler(this.BtnElimina_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 519);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.Text = "Mantenedor de Usuarios";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtIniciaSesionUsuario;
        private System.Windows.Forms.Button btnInicia;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtIniciaSesionContraseña;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox TxtCreaUsuario;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtCreaContraseña;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox TxtActualizaUsuario;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtActualizaContraseña;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button BtnActualiza;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox TxtEliminaUsuario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox TxtEliminaContraseña;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button BtnElimina;
        private System.Windows.Forms.Button BtnCrea;
    }
}