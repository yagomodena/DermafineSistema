namespace Dermafine.Formularios.ADMIN.Produtos.Cadastro
{
    partial class frmEditarProduto
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
            this.label3 = new System.Windows.Forms.Label();
            this.numPontuacao = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbNomeProduto = new System.Windows.Forms.ComboBox();
            this.cmbCategoriaProduto = new System.Windows.Forms.ComboBox();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.numPontuacao)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(31, 138);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Pontuação do Produto";
            // 
            // numPontuacao
            // 
            this.numPontuacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPontuacao.Location = new System.Drawing.Point(34, 155);
            this.numPontuacao.Margin = new System.Windows.Forms.Padding(2);
            this.numPontuacao.Name = "numPontuacao";
            this.numPontuacao.Size = new System.Drawing.Size(126, 24);
            this.numPontuacao.TabIndex = 23;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(223, 19);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 15);
            this.label2.TabIndex = 22;
            this.label2.Text = "Categoria do Produto";
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarProduto.Location = new System.Drawing.Point(34, 193);
            this.btnCadastrarProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(309, 25);
            this.btnCadastrarProduto.TabIndex = 20;
            this.btnCadastrarProduto.Text = "Salvar edição do Produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(21, 19);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 15);
            this.label1.TabIndex = 18;
            this.label1.Text = "Nome do Produto";
            // 
            // cmbNomeProduto
            // 
            this.cmbNomeProduto.FormattingEnabled = true;
            this.cmbNomeProduto.Location = new System.Drawing.Point(24, 50);
            this.cmbNomeProduto.Name = "cmbNomeProduto";
            this.cmbNomeProduto.Size = new System.Drawing.Size(121, 21);
            this.cmbNomeProduto.TabIndex = 25;
            this.cmbNomeProduto.SelectedIndexChanged += new System.EventHandler(this.cmbNomeProduto_SelectedIndexChanged);
            // 
            // cmbCategoriaProduto
            // 
            this.cmbCategoriaProduto.FormattingEnabled = true;
            this.cmbCategoriaProduto.Location = new System.Drawing.Point(226, 74);
            this.cmbCategoriaProduto.Name = "cmbCategoriaProduto";
            this.cmbCategoriaProduto.Size = new System.Drawing.Size(121, 21);
            this.cmbCategoriaProduto.TabIndex = 26;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Location = new System.Drawing.Point(24, 87);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(100, 20);
            this.txtNomeProduto.TabIndex = 27;
            // 
            // frmEditarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(464, 281);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.cmbCategoriaProduto);
            this.Controls.Add(this.cmbNomeProduto);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPontuacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnCadastrarProduto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmEditarProduto";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Editar produto";
            ((System.ComponentModel.ISupportInitialize)(this.numPontuacao)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numPontuacao;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbNomeProduto;
        private System.Windows.Forms.ComboBox cmbCategoriaProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
    }
}