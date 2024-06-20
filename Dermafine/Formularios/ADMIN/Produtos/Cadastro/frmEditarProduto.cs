using Dermafine.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN.Produtos.Cadastro
{
    public partial class frmEditarProduto : Form
    {

        private Produto produto;


        public frmEditarProduto(Produto produto)
        {
            InitializeComponent();
            this.produto = produto;
            PreencherCampos();
        }

        private void PreencherCampos()
        {
            // Preencha os campos do formulário com as informações do produto
            txtNomeProduto.Text = produto.NomeProduto;
            cmbCategoriaProduto.SelectedItem = produto.Categoria;
            numPontuacao.Value = produto.Pontuacao;
            // Preencha outros campos conforme necessário
        }
    }
}
