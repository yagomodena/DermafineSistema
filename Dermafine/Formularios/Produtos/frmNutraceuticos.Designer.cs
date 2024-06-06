namespace Dermafine.Formularios.Produtos
{
    partial class frmNutraceuticos
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureUnissy = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUnissy)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.pictureUnissy);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(514, 353);
            this.panel2.TabIndex = 17;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(38, 313);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(466, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "clique na imagem do produto para visualizar a sua descrição.";
            // 
            // pictureUnissy
            // 
            this.pictureUnissy.Cursor = System.Windows.Forms.Cursors.Help;
            this.pictureUnissy.Image = global::Dermafine.Properties.Resources.Unissy__Cabelos_e_Unhas;
            this.pictureUnissy.Location = new System.Drawing.Point(160, 62);
            this.pictureUnissy.Name = "pictureUnissy";
            this.pictureUnissy.Size = new System.Drawing.Size(224, 238);
            this.pictureUnissy.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureUnissy.TabIndex = 0;
            this.pictureUnissy.TabStop = false;
            this.pictureUnissy.Click += new System.EventHandler(this.pictureUnissy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(155, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(217, 25);
            this.label1.TabIndex = 1;
            this.label1.Text = "Unissy+ 60 Cápsulas";
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(514, 353);
            this.panel1.TabIndex = 13;
            // 
            // frmNutraceuticos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 353);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.Name = "frmNutraceuticos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DERMAFINE - Nutracêuticos";
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureUnissy)).EndInit();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.PictureBox pictureUnissy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
    }
}