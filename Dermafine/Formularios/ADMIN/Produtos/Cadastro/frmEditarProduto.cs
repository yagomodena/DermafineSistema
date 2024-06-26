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
        private Dictionary<string, List<Produto>> categoriasProdutos = new Dictionary<string, List<Produto>>();
        public event EventHandler ProdutosAtualizados;

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
        }

        private async void frmEditarProduto_Load(object sender, EventArgs e)
        {
            cmbCategoriaProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbNomeProduto.DropDownStyle = ComboBoxStyle.DropDownList;

            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client != null)
                {
                    FirebaseResponse response = await client.GetAsync("produtos");
                    if (response.Body != "null")
                    {
                        var categorias = response.ResultAs<Dictionary<string, CategoriaProdutos>>();
                        if (categorias != null)
                        {
                            foreach (var categoria in categorias)
                            {
                                cmbCategoriaProduto.Items.Add(categoria.Key);

                                if (categoria.Value.Produtos != null)
                                {
                                    categoriasProdutos.Add(categoria.Key, categoria.Value.Produtos.Values.ToList());
                                }
                                else
                                {
                                    categoriasProdutos.Add(categoria.Key, new List<Produto>());
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("Nenhuma categoria encontrada no Firebase.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Nenhum produto foi encontrado no Firebase.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
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
                string produtoId = produto.produtoID;

                if (!string.IsNullOrEmpty(produtoId))
                {
                    // Atualizar no Firebase
                    try
                    {
                        FirebaseResponse response = await client.UpdateAsync($"produtos/{categoria}/{produtoId}", produto);
                        if (response.StatusCode == System.Net.HttpStatusCode.OK)
                        {
                            MessageBox.Show("Produto atualizado com sucesso!");
                            ProdutosAtualizados?.Invoke(this, EventArgs.Empty);
                            this.Close();
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
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter o ID do produto.");
                }
            }
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
                else
                {
                    MessageBox.Show("Produto não encontrado na lista.");
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

        private async void cmbCategoriaProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbNomeProduto.Items.Clear();
            txtNomeProduto.Clear();
            produtos.Clear(); // Limpa a lista de produtos para evitar duplicações

            if (cmbCategoriaProduto.SelectedItem != null)
            {
                string categoriaSelecionada = cmbCategoriaProduto.SelectedItem.ToString();

                try
                {
                    FirebaseResponse response = await client.GetAsync("produtos/" + categoriaSelecionada);
                    if (response.Body != "null")
                    {
                        var produtosDict = response.ResultAs<Dictionary<string, Produto>>();

                        categoriasProdutos[categoriaSelecionada] = produtosDict.Values.ToList();

                        foreach (var kvp in produtosDict)
                        {
                            Produto p = kvp.Value;
                            p.produtoID = kvp.Key; // Armazena a chave do produto
                            cmbNomeProduto.Items.Add(p.NomeProduto);
                            produtos.Add(p); // Adiciona o produto à lista de produtos para ser encontrado posteriormente
                        }

                        cmbNomeProduto.Tag = produtosDict; // Atualiza a propriedade Tag
                    }
                    else
                    {
                        MessageBox.Show("Nenhum produto encontrado para a categoria selecionada: " + categoriaSelecionada);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
                }
            }
        }

        private async void btnExcluirProduto_Click(object sender, EventArgs e)
        {
            if (cmbNomeProduto.SelectedItem != null && cmbCategoriaProduto.SelectedItem != null)
            {
                string categoria = cmbCategoriaProduto.SelectedItem.ToString();
                string nomeProdutoSelecionado = cmbNomeProduto.SelectedItem.ToString();

                var produtosDict = (Dictionary<string, Produto>)cmbNomeProduto.Tag;
                string produtoId = produtosDict.FirstOrDefault(x => x.Value.NomeProduto == nomeProdutoSelecionado).Key;

                if (!string.IsNullOrEmpty(produtoId))
                {
                    DialogResult dialogResult = MessageBox.Show("Deseja realmente excluir este produto?", "Excluir produto", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        await ExcluirProduto(categoria, produtoId);
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao obter o ID do produto.");
                }
            }
            else
            {
                MessageBox.Show("Por favor, selecione uma categoria e um produto.");
            }
        }

        private async Task ExcluirProduto(string categoria, string produtoId)
        {
            try
            {
                FirebaseResponse response = await client.DeleteAsync($"produtos/{categoria}/{produtoId}");
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    MessageBox.Show("Produto excluído com sucesso!");
                    ProdutosAtualizados?.Invoke(this, EventArgs.Empty);
                    await CarregarProdutos();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Erro ao excluir produto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao excluir produto: " + ex.Message);
            }
        }
    }
}
