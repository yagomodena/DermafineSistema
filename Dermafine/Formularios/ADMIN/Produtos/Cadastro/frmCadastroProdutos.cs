using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Threading;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN.Produtos.Cadastro
{
    public partial class frmCadastroProdutos : Form
    {

        Thread t1;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public frmCadastroProdutos()
        {
            InitializeComponent();
        }

        private async void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeProduto.Text) || string.IsNullOrEmpty(cmbCategoriaProduto.Text))
            {
                MessageBox.Show("Informe todos os campos obrigatórios!");
                return;
            }

            // Instanciar o produto com os dados informados pelo usuário
            var produto = new Produto
            {
                NomeProduto = txtNomeProduto.Text,
                Categoria = cmbCategoriaProduto.Text,
                Pontuacao = (int)numPontuacao.Value // Captura a pontuação do campo numPontuacao
            };

            try
            {
                // Inicializar o cliente Firebase
                client = new FireSharp.FirebaseClient(config);
                if (client != null)
                {
                    // Gerar uma chave única para o produto
                    var key = Guid.NewGuid().ToString();

                    // Realizar o cadastro do produto no banco de dados Firebase
                    FirebaseResponse response = await client.SetAsync("produtos/" + produto.Categoria + "/" + key, produto);

                    // Verificar se o cadastro foi realizado com sucesso
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        MessageBox.Show("Produto cadastrado com sucesso!");

                        // Limpar os campos após o cadastro
                        LimparCampos();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao cadastrar produto.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            txtNomeProduto.Text = "";
            cmbCategoriaProduto.Text = "";
        }

    }
}
