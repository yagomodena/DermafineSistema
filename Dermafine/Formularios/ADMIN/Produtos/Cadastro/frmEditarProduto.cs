using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN.Produtos.Cadastro
{
    public partial class frmEditarProduto : Form
    {
        private List<Produto> produtos = new List<Produto>();

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private Produto produto;

        public frmEditarProduto()
        {
            InitializeComponent();

            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                    return;
                }

                // Carregar produtos
                CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private async void frmEditarProduto_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                    return;
                }

                // Carregar produtos
                await CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private async void btnSalvar_Click(object sender, EventArgs e)
        {
            if (produto != null)
            {
                // Atualizar os dados do produto
                produto.NomeProduto = txtNomeProduto.Text;
                produto.Categoria = cmbCategoriaProduto.SelectedItem.ToString();
                produto.Pontuacao = (int)numPontuacao.Value;

                string categoria = produto.Categoria;
                string produtoId = null;

                var produtosDict = (Dictionary<string, Produto>)cmbNomeProduto.Tag;
                foreach (var item in produtosDict)
                {
                    if (item.Value.NomeProduto == produto.NomeProduto)
                    {
                        produtoId = item.Key;
                        break;
                    }
                }

                if (produtoId != null)
                {
                    // Mostrar controle de carregamento
                    MostrarControleCarregamento(true);

                    // Atualizar no Firebase
                    try
                    {
                        FirebaseResponse response = await client.UpdateAsync($"produtos/{categoria}/{produtoId}", produto);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Produto atualizado com sucesso!");
                            this.Close(); // Fechar o formulário após a atualização
                        }
                        else
                        {
                            MessageBox.Show("Erro ao atualizar produto.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao atualizar produto: " + ex.Message);
                    }
                    finally
                    {
                        // Esconder controle de carregamento
                        MostrarControleCarregamento(false);
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter o ID do produto.");
                }
            }
        }

        private void MostrarControleCarregamento(bool mostrar)
        {
            // Exemplo: Mostrar controle de carregamento (ProgressBar)
            // progressBar1.Visible = mostrar;

            // Ou, se preferir, pode usar uma imagem animada (PictureBox)
            // pictureBox1.Visible = mostrar;
        }

        private void cmbNomeProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbNomeProduto.SelectedItem != null)
            {
                string nomeProdutoSelecionado = cmbNomeProduto.SelectedItem.ToString();
                produto = produtos.FirstOrDefault(p => p.NomeProduto == nomeProdutoSelecionado);

                if (produto != null)
                {
                    txtNomeProduto.Text = produto.NomeProduto;
                    cmbCategoriaProduto.SelectedItem = produto.Categoria;
                    numPontuacao.Value = produto.Pontuacao;
                }
            }
        }

        private async Task CarregarProdutos()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null" && response.Body != null)
                {
                    var produtosDict = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                    var produtosList = new List<string>();
                    foreach (var categoria in produtosDict.Values)
                    {
                        foreach (var produto in categoria.Values)
                        {
                            produtos.Add(produto);
                            produtosList.Add(produto.NomeProduto);
                        }
                    }
                    produtosList.Sort(); // Ordena os produtos em ordem alfabética
                    cmbNomeProduto.Items.AddRange(produtosList.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }
    }
}
