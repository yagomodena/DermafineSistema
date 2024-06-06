namespace Dermafine.Formularios.ADMIN
{
    partial class frmADMIN
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
            this.btnProdutos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnProdutos
            // 
            this.btnProdutos.BackColor = System.Drawing.SystemColors.Control;
            this.btnProdutos.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnProdutos.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.btnProdutos.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.btnProdutos.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnProdutos.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnProdutos.Location = new System.Drawing.Point(37, 49);
            this.btnProdutos.Name = "btnProdutos";
            this.btnProdutos.Size = new System.Drawing.Size(275, 100);
            this.btnProdutos.TabIndex = 3;
            this.btnProdutos.Text = "PRODUTOS";
            this.btnProdutos.UseVisualStyleBackColor = false;
            this.btnProdutos.Click += new System.EventHandler(this.btnProdutos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.Control;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(129)))), ((int)(((byte)(212)))), ((int)(((byte)(247)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(328, 49);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(275, 100);
            this.button1.TabIndex = 4;
            this.button1.Text = "USUÁRIOS";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmADMIN
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnProdutos);
            this.Name = "frmADMIN";
            this.Text = "ADMINISTRADOR";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnProdutos;
        private System.Windows.Forms.Button button1;
    }
}