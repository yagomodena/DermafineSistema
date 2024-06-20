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
            this.cmbCategoriaProduto = new System.Windows.Forms.ComboBox();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numPontuacao)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(21, 69);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(129, 15);
            this.label3.TabIndex = 24;
            this.label3.Text = "Pontuação do Produto";
            // 
            // numPontuacao
            // 
            this.numPontuacao.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numPontuacao.Location = new System.Drawing.Point(24, 86);
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
            // cmbCategoriaProduto
            // 
            this.cmbCategoriaProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCategoriaProduto.FormattingEnabled = true;
            this.cmbCategoriaProduto.Items.AddRange(new object[] {
            "Anti Acne",
            "Cabelos e Unhas",
            "Cílios e Sobrancelhas",
            "Cuidados Faciais",
            "Hidratação Corporal",
            "Nutraceuticos",
            "Proteção Solar"});
            this.cmbCategoriaProduto.Location = new System.Drawing.Point(226, 36);
            this.cmbCategoriaProduto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbCategoriaProduto.Name = "cmbCategoriaProduto";
            this.cmbCategoriaProduto.Size = new System.Drawing.Size(120, 23);
            this.cmbCategoriaProduto.TabIndex = 21;
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarProduto.Location = new System.Drawing.Point(24, 124);
            this.btnCadastrarProduto.Margin = new System.Windows.Forms.Padding(2);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(309, 25);
            this.btnCadastrarProduto.TabIndex = 20;
            this.btnCadastrarProduto.Text = "Salvar edição do Produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(24, 36);
            this.txtNomeProduto.Margin = new System.Windows.Forms.Padding(2);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(188, 21);
            this.txtNomeProduto.TabIndex = 19;
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
            // frmEditarProduto
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(394, 158);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numPontuacao);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategoriaProduto);
            this.Controls.Add(this.btnCadastrarProduto);
            this.Controls.Add(this.txtNomeProduto);
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
        private System.Windows.Forms.ComboBox cmbCategoriaProduto;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Label label1;
    }
}