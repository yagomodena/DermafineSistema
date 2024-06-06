namespace Dermafine.Formularios.Consulta
{
    partial class frmConsulta
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.btnPesquisar = new System.Windows.Forms.Button();
            this.dataGridViewAtendimentos = new System.Windows.Forms.DataGridView();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtendimentos)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label6);
            this.panel1.Controls.Add(this.cmbCategoria);
            this.panel1.Controls.Add(this.btnPesquisar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 95);
            this.panel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(21, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 13;
            this.label6.Text = "Categoria do Produto";
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(26, 46);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(265, 30);
            this.cmbCategoria.TabIndex = 11;
            // 
            // btnPesquisar
            // 
            this.btnPesquisar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPesquisar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPesquisar.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPesquisar.Location = new System.Drawing.Point(834, 26);
            this.btnPesquisar.Name = "btnPesquisar";
            this.btnPesquisar.Size = new System.Drawing.Size(124, 42);
            this.btnPesquisar.TabIndex = 3;
            this.btnPesquisar.Text = "Pesquisar";
            this.btnPesquisar.UseVisualStyleBackColor = true;
            this.btnPesquisar.Click += new System.EventHandler(this.btnPesquisar_Click);
            // 
            // dataGridViewAtendimentos
            // 
            this.dataGridViewAtendimentos.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewAtendimentos.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dataGridViewAtendimentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAtendimentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAtendimentos.Location = new System.Drawing.Point(0, 95);
            this.dataGridViewAtendimentos.Name = "dataGridViewAtendimentos";
            this.dataGridViewAtendimentos.RowHeadersWidth = 51;
            this.dataGridViewAtendimentos.RowTemplate.Height = 24;
            this.dataGridViewAtendimentos.Size = new System.Drawing.Size(978, 521);
            this.dataGridViewAtendimentos.TabIndex = 2;
            // 
            // frmConsulta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 616);
            this.Controls.Add(this.dataGridViewAtendimentos);
            this.Controls.Add(this.panel1);
            this.Name = "frmConsulta";
            this.Text = "CONSULTA";
            this.Load += new System.EventHandler(this.frmConsulta_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAtendimentos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnPesquisar;
        private System.Windows.Forms.DataGridView dataGridViewAtendimentos;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbCategoria;
    }
}