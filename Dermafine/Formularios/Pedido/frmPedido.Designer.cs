namespace Dermafine.Formularios.Pedido
{
    partial class frmPedido
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
            this.btnFinalizar = new System.Windows.Forms.Button();
            this.cmbCategoria = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.cmbProduto = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnAdicionarAoCarrinho = new System.Windows.Forms.Button();
            this.numQuantidade = new System.Windows.Forms.NumericUpDown();
            this.dataGridViewCarrinho = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrinho)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFinalizar
            // 
            this.btnFinalizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnFinalizar.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFinalizar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFinalizar.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinalizar.ForeColor = System.Drawing.Color.White;
            this.btnFinalizar.Location = new System.Drawing.Point(431, 424);
            this.btnFinalizar.Name = "btnFinalizar";
            this.btnFinalizar.Size = new System.Drawing.Size(165, 41);
            this.btnFinalizar.TabIndex = 7;
            this.btnFinalizar.Text = "Finalizar";
            this.btnFinalizar.UseVisualStyleBackColor = false;
            this.btnFinalizar.Click += new System.EventHandler(this.btnFinalizar_Click);
            // 
            // cmbCategoria
            // 
            this.cmbCategoria.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoria.FormattingEnabled = true;
            this.cmbCategoria.Location = new System.Drawing.Point(34, 55);
            this.cmbCategoria.Name = "cmbCategoria";
            this.cmbCategoria.Size = new System.Drawing.Size(265, 30);
            this.cmbCategoria.TabIndex = 3;
            this.cmbCategoria.SelectedIndexChanged += new System.EventHandler(this.cmbCategoria_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(310, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 6;
            this.label4.Text = "Produto";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(480, 98);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(114, 25);
            this.label5.TabIndex = 7;
            this.label5.Text = "Quantidade";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(29, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(197, 25);
            this.label6.TabIndex = 8;
            this.label6.Text = "Categoria do Produto";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Enabled = false;
            this.txtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(34, 126);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(435, 28);
            this.txtNomeProduto.TabIndex = 4;
            // 
            // cmbProduto
            // 
            this.cmbProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProduto.FormattingEnabled = true;
            this.cmbProduto.Location = new System.Drawing.Point(315, 55);
            this.cmbProduto.Name = "cmbProduto";
            this.cmbProduto.Size = new System.Drawing.Size(281, 30);
            this.cmbProduto.TabIndex = 10;
            this.cmbProduto.SelectedIndexChanged += new System.EventHandler(this.cmbProduto_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(29, 98);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(164, 25);
            this.label8.TabIndex = 11;
            this.label8.Text = "Nome do Produto";
            // 
            // btnAdicionarAoCarrinho
            // 
            this.btnAdicionarAoCarrinho.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(51)))), ((int)(((byte)(76)))));
            this.btnAdicionarAoCarrinho.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAdicionarAoCarrinho.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdicionarAoCarrinho.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdicionarAoCarrinho.ForeColor = System.Drawing.Color.White;
            this.btnAdicionarAoCarrinho.Location = new System.Drawing.Point(431, 175);
            this.btnAdicionarAoCarrinho.Name = "btnAdicionarAoCarrinho";
            this.btnAdicionarAoCarrinho.Size = new System.Drawing.Size(165, 41);
            this.btnAdicionarAoCarrinho.TabIndex = 13;
            this.btnAdicionarAoCarrinho.Text = "Adicionar";
            this.btnAdicionarAoCarrinho.UseVisualStyleBackColor = false;
            this.btnAdicionarAoCarrinho.Click += new System.EventHandler(this.btnAdicionarAoCarrinho_Click);
            // 
            // numQuantidade
            // 
            this.numQuantidade.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numQuantidade.Location = new System.Drawing.Point(485, 126);
            this.numQuantidade.Name = "numQuantidade";
            this.numQuantidade.Size = new System.Drawing.Size(111, 28);
            this.numQuantidade.TabIndex = 15;
            // 
            // dataGridViewCarrinho
            // 
            this.dataGridViewCarrinho.BackgroundColor = System.Drawing.Color.White;
            this.dataGridViewCarrinho.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewCarrinho.Location = new System.Drawing.Point(34, 237);
            this.dataGridViewCarrinho.Name = "dataGridViewCarrinho";
            this.dataGridViewCarrinho.RowHeadersWidth = 51;
            this.dataGridViewCarrinho.RowTemplate.Height = 24;
            this.dataGridViewCarrinho.Size = new System.Drawing.Size(562, 166);
            this.dataGridViewCarrinho.TabIndex = 16;
            // 
            // frmPedido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(610, 479);
            this.Controls.Add(this.dataGridViewCarrinho);
            this.Controls.Add(this.numQuantidade);
            this.Controls.Add(this.btnAdicionarAoCarrinho);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cmbCategoria);
            this.Controls.Add(this.btnFinalizar);
            this.Name = "frmPedido";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "INDICAÇÃO";
            this.Load += new System.EventHandler(this.frmPedido_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numQuantidade)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewCarrinho)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnFinalizar;
        private System.Windows.Forms.ComboBox cmbCategoria;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.ComboBox cmbProduto;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnAdicionarAoCarrinho;
        private System.Windows.Forms.NumericUpDown numQuantidade;
        private System.Windows.Forms.DataGridView dataGridViewCarrinho;
    }
}