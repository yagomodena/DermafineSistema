namespace Dermafine.Formularios.ADMIN.Produtos.Cadastro
{
    partial class frmCadastroProdutos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCadastroProdutos));
            this.label1 = new System.Windows.Forms.Label();
            this.txtNomeProduto = new System.Windows.Forms.TextBox();
            this.btnCadastrarProduto = new System.Windows.Forms.Button();
            this.cmbCategoriaProduto = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(22, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nome do Produto";
            // 
            // txtNomeProduto
            // 
            this.txtNomeProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNomeProduto.Location = new System.Drawing.Point(25, 40);
            this.txtNomeProduto.Name = "txtNomeProduto";
            this.txtNomeProduto.Size = new System.Drawing.Size(249, 24);
            this.txtNomeProduto.TabIndex = 1;
            // 
            // btnCadastrarProduto
            // 
            this.btnCadastrarProduto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCadastrarProduto.Location = new System.Drawing.Point(25, 82);
            this.btnCadastrarProduto.Name = "btnCadastrarProduto";
            this.btnCadastrarProduto.Size = new System.Drawing.Size(412, 31);
            this.btnCadastrarProduto.TabIndex = 2;
            this.btnCadastrarProduto.Text = "Cadastrar Produto";
            this.btnCadastrarProduto.UseVisualStyleBackColor = true;
            this.btnCadastrarProduto.Click += new System.EventHandler(this.btnCadastrarProduto_Click);
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
            this.cmbCategoriaProduto.Location = new System.Drawing.Point(290, 40);
            this.cmbCategoriaProduto.Name = "cmbCategoriaProduto";
            this.cmbCategoriaProduto.Size = new System.Drawing.Size(147, 26);
            this.cmbCategoriaProduto.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(287, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(150, 18);
            this.label2.TabIndex = 4;
            this.label2.Text = "Categoria do Produto";
            // 
            // frmCadastroProdutos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 128);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cmbCategoriaProduto);
            this.Controls.Add(this.btnCadastrarProduto);
            this.Controls.Add(this.txtNomeProduto);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmCadastroProdutos";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DERMAFINE - CADASTRO DE PRODUTOS";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNomeProduto;
        private System.Windows.Forms.Button btnCadastrarProduto;
        private System.Windows.Forms.ComboBox cmbCategoriaProduto;
        private System.Windows.Forms.Label label2;
    }
}