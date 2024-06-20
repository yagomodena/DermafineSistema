namespace Dermafine.Formularios.ADMIN.Armazenamento
{
    partial class frmVerificarArmazenamento
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
            this.btnVerificarArmazenamento = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnVerificarArmazenamento
            // 
            this.btnVerificarArmazenamento.Location = new System.Drawing.Point(262, 85);
            this.btnVerificarArmazenamento.Name = "btnVerificarArmazenamento";
            this.btnVerificarArmazenamento.Size = new System.Drawing.Size(75, 23);
            this.btnVerificarArmazenamento.TabIndex = 0;
            this.btnVerificarArmazenamento.Text = "button1";
            this.btnVerificarArmazenamento.UseVisualStyleBackColor = true;
            this.btnVerificarArmazenamento.Click += new System.EventHandler(this.btnVerificarArmazenamento_Click);
            // 
            // frmVerificarArmazenamento
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnVerificarArmazenamento);
            this.Name = "frmVerificarArmazenamento";
            this.Text = "frmVerificarArmazenamento";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnVerificarArmazenamento;
    }
}