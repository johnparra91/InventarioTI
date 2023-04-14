namespace CapaPresentacion
{
    partial class CaracteristicasPCForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.TxtTipoPC = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnTipoPC = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.BtnProcesador = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.TxtProcesador = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.BtnRam = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.TxtRam = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.BtnSO = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.TxtSO = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.BtnCapDisco = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.TxtCapDisco = new System.Windows.Forms.TextBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.BtnTipoDisco = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.TxtTipoDisco = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Crear Tipo PC:";
            // 
            // TxtTipoPC
            // 
            this.TxtTipoPC.Location = new System.Drawing.Point(9, 48);
            this.TxtTipoPC.Name = "TxtTipoPC";
            this.TxtTipoPC.Size = new System.Drawing.Size(181, 20);
            this.TxtTipoPC.TabIndex = 1;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.BtnTipoPC);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.TxtTipoPC);
            this.groupBox1.Location = new System.Drawing.Point(12, 44);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(197, 109);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Tipo PC:";
            // 
            // BtnTipoPC
            // 
            this.BtnTipoPC.Location = new System.Drawing.Point(9, 74);
            this.BtnTipoPC.Name = "BtnTipoPC";
            this.BtnTipoPC.Size = new System.Drawing.Size(181, 23);
            this.BtnTipoPC.TabIndex = 2;
            this.BtnTipoPC.Text = "Guardar";
            this.BtnTipoPC.UseVisualStyleBackColor = true;
            this.BtnTipoPC.Click += new System.EventHandler(this.BtnTipoPC_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.BtnProcesador);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.TxtProcesador);
            this.groupBox2.Location = new System.Drawing.Point(12, 176);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(197, 109);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Procesador:";
            // 
            // BtnProcesador
            // 
            this.BtnProcesador.Location = new System.Drawing.Point(9, 74);
            this.BtnProcesador.Name = "BtnProcesador";
            this.BtnProcesador.Size = new System.Drawing.Size(181, 23);
            this.BtnProcesador.TabIndex = 2;
            this.BtnProcesador.Text = "Guardar";
            this.BtnProcesador.UseVisualStyleBackColor = true;
            this.BtnProcesador.Click += new System.EventHandler(this.BtnProcesador_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Crear Procesador:";
            // 
            // TxtProcesador
            // 
            this.TxtProcesador.Location = new System.Drawing.Point(9, 48);
            this.TxtProcesador.Name = "TxtProcesador";
            this.TxtProcesador.Size = new System.Drawing.Size(181, 20);
            this.TxtProcesador.TabIndex = 1;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.BtnRam);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.TxtRam);
            this.groupBox3.Location = new System.Drawing.Point(236, 44);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(197, 109);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Ram (GB):";
            // 
            // BtnRam
            // 
            this.BtnRam.Location = new System.Drawing.Point(9, 74);
            this.BtnRam.Name = "BtnRam";
            this.BtnRam.Size = new System.Drawing.Size(181, 23);
            this.BtnRam.TabIndex = 2;
            this.BtnRam.Text = "Guardar";
            this.BtnRam.UseVisualStyleBackColor = true;
            this.BtnRam.Click += new System.EventHandler(this.BtnRam_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 0;
            this.label3.Text = "Crear Ram:";
            // 
            // TxtRam
            // 
            this.TxtRam.Location = new System.Drawing.Point(9, 48);
            this.TxtRam.Name = "TxtRam";
            this.TxtRam.Size = new System.Drawing.Size(181, 20);
            this.TxtRam.TabIndex = 1;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.BtnSO);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.TxtSO);
            this.groupBox4.Location = new System.Drawing.Point(457, 176);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(197, 109);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Sistema Operativo:";
            // 
            // BtnSO
            // 
            this.BtnSO.Location = new System.Drawing.Point(9, 74);
            this.BtnSO.Name = "BtnSO";
            this.BtnSO.Size = new System.Drawing.Size(181, 23);
            this.BtnSO.TabIndex = 2;
            this.BtnSO.Text = "Guardar";
            this.BtnSO.UseVisualStyleBackColor = true;
            this.BtnSO.Click += new System.EventHandler(this.BtnSO_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 31);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(124, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Crear Sistema Operativo:";
            // 
            // TxtSO
            // 
            this.TxtSO.Location = new System.Drawing.Point(9, 48);
            this.TxtSO.Name = "TxtSO";
            this.TxtSO.Size = new System.Drawing.Size(181, 20);
            this.TxtSO.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.BtnCapDisco);
            this.groupBox5.Controls.Add(this.label5);
            this.groupBox5.Controls.Add(this.TxtCapDisco);
            this.groupBox5.Location = new System.Drawing.Point(457, 44);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(197, 109);
            this.groupBox5.TabIndex = 3;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Capacidad De Disco:";
            // 
            // BtnCapDisco
            // 
            this.BtnCapDisco.Location = new System.Drawing.Point(6, 74);
            this.BtnCapDisco.Name = "BtnCapDisco";
            this.BtnCapDisco.Size = new System.Drawing.Size(184, 23);
            this.BtnCapDisco.TabIndex = 2;
            this.BtnCapDisco.Text = "Guardar";
            this.BtnCapDisco.UseVisualStyleBackColor = true;
            this.BtnCapDisco.Click += new System.EventHandler(this.BtnCapDisco_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(119, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Crear Capacidad Disco:";
            // 
            // TxtCapDisco
            // 
            this.TxtCapDisco.Location = new System.Drawing.Point(9, 48);
            this.TxtCapDisco.Name = "TxtCapDisco";
            this.TxtCapDisco.Size = new System.Drawing.Size(181, 20);
            this.TxtCapDisco.TabIndex = 1;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.BtnTipoDisco);
            this.groupBox6.Controls.Add(this.label6);
            this.groupBox6.Controls.Add(this.TxtTipoDisco);
            this.groupBox6.Location = new System.Drawing.Point(236, 176);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(197, 109);
            this.groupBox6.TabIndex = 3;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Tipo De Disco:";
            // 
            // BtnTipoDisco
            // 
            this.BtnTipoDisco.Location = new System.Drawing.Point(9, 74);
            this.BtnTipoDisco.Name = "BtnTipoDisco";
            this.BtnTipoDisco.Size = new System.Drawing.Size(181, 23);
            this.BtnTipoDisco.TabIndex = 2;
            this.BtnTipoDisco.Text = "Guardar";
            this.BtnTipoDisco.UseVisualStyleBackColor = true;
            this.BtnTipoDisco.Click += new System.EventHandler(this.BtnTipoDisco_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 31);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(106, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Crear Tipo De Disco:";
            // 
            // TxtTipoDisco
            // 
            this.TxtTipoDisco.Location = new System.Drawing.Point(9, 48);
            this.TxtTipoDisco.Name = "TxtTipoDisco";
            this.TxtTipoDisco.Size = new System.Drawing.Size(181, 20);
            this.TxtTipoDisco.TabIndex = 1;
            // 
            // CaracteristicasPCForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 306);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.groupBox1);
            this.Name = "CaracteristicasPCForm";
            this.Text = "CaracteristicasPCForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox TxtTipoPC;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button BtnTipoPC;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button BtnProcesador;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TxtProcesador;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button BtnRam;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TxtRam;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button BtnSO;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox TxtSO;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button BtnCapDisco;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TxtCapDisco;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.Button BtnTipoDisco;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox TxtTipoDisco;
    }
}