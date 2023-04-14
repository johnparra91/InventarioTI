namespace CapaPresentacion
{
    partial class SignatureForm
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
            this.signaturepanel = new System.Windows.Forms.Panel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.BtnResetFirma = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.signaturepanel.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // signaturepanel
            // 
            this.signaturepanel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.signaturepanel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.signaturepanel.Controls.Add(this.groupBox1);
            this.signaturepanel.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.signaturepanel.Location = new System.Drawing.Point(0, 12);
            this.signaturepanel.Name = "signaturepanel";
            this.signaturepanel.Size = new System.Drawing.Size(893, 260);
            this.signaturepanel.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.groupBox1.Controls.Add(this.BtnResetFirma);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Location = new System.Drawing.Point(12, 135);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 122);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Acciones";
            // 
            // BtnResetFirma
            // 
            this.BtnResetFirma.ForeColor = System.Drawing.Color.Goldenrod;
            this.BtnResetFirma.Location = new System.Drawing.Point(6, 28);
            this.BtnResetFirma.Name = "BtnResetFirma";
            this.BtnResetFirma.Size = new System.Drawing.Size(120, 23);
            this.BtnResetFirma.TabIndex = 3;
            this.BtnResetFirma.Text = "Volver a Firmar";
            this.BtnResetFirma.UseVisualStyleBackColor = true;
            this.BtnResetFirma.Click += new System.EventHandler(this.BtnResetFirma_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.ForeColor = System.Drawing.Color.Firebrick;
            this.btnCancel.Location = new System.Drawing.Point(6, 86);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(120, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cerrar";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.ForeColor = System.Drawing.Color.DarkGreen;
            this.btnSave.Location = new System.Drawing.Point(6, 57);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(120, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Guardar";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // SignatureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 272);
            this.Controls.Add(this.signaturepanel);
            this.Cursor = System.Windows.Forms.Cursors.Hand;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "SignatureForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Firmar Acta El que Recibe";
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.SignatureForm_MouseMove);
            this.signaturepanel.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel signaturepanel;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button BtnResetFirma;
        private System.Windows.Forms.GroupBox groupBox1;
    }
}