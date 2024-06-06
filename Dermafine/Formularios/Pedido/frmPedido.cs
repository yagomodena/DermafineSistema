using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Dermafine.Formularios.Pedido
{
    public partial class frmPedido : Form
    {
        private Dictionary<string, List<Produto>> categoriasProdutos = new Dictionary<string, List<Produto>>();
        private List<CarrinhoItem> carrinho = new List<CarrinhoItem>();

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public frmPedido()
        {
            InitializeComponent();
        }

        private async void frmPedido_Load(object sender, EventArgs e)
        {
            cmbCategoria.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbProduto.DropDownStyle = ComboBoxStyle.DropDownList;
            dataGridViewCarrinho.Rows.Clear();

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
                                cmbCategoria.Items.Add(categoria.Key);

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

                // Definir as colunas do DataGridView uma única vez
                DefinirColunasDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }

        private async void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            cmbProduto.Items.Clear();
            txtNomeProduto.Clear();

            if (cmbCategoria.SelectedItem != null)
            {
                string categoriaSelecionada = cmbCategoria.SelectedItem.ToString();

                try
                {
                    FirebaseResponse response = await client.GetAsync("produtos/" + categoriaSelecionada);
                    if (response.Body != "null")
                    {
                        var produtosDict = response.ResultAs<Dictionary<string, Produto>>();

                        categoriasProdutos[categoriaSelecionada] = produtosDict.Values.ToList();

                        foreach (var produto in produtosDict.Values)
                        {
                            cmbProduto.Items.Add(produto.NomeProduto);
                        }
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

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Verificar se algum item foi selecionado na ComboBox de produtos
            if (cmbProduto.SelectedItem != null)
            {
                txtNomeProduto.Text = cmbProduto.SelectedItem.ToString();
            }
        }

        private void btnAdicionarAoCarrinho_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedItem != null && cmbCategoria.SelectedItem != null)
            {
                string categoriaSelecionada = cmbCategoria.SelectedItem.ToString();
                string nomeProdutoSelecionado = cmbProduto.SelectedItem.ToString().Trim();
                int quantidade = (int)numQuantidade.Value;

                if (categoriasProdutos.TryGetValue(categoriaSelecionada, out var produtosDaCategoria))
                {
                    Produto produtoSelecionado = produtosDaCategoria
                        .FirstOrDefault(p => p.NomeProduto.Trim().Equals(nomeProdutoSelecionado, StringComparison.OrdinalIgnoreCase));

                    if (produtoSelecionado != null)
                    {
                        var itemExistente = carrinho.FirstOrDefault(item => item.Produto.NomeProduto == nomeProdutoSelecionado && item.Produto.Categoria == categoriaSelecionada);

                        if (itemExistente != null)
                        {
                            itemExistente.Quantidade += quantidade;
                        }
                        else
                        {
                            carrinho.Add(new CarrinhoItem { Produto = produtoSelecionado, Quantidade = quantidade });
                        }

                        AtualizarExibicaoCarrinho();
                        MessageBox.Show("Produto adicionado ao carrinho!");

                        // Limpar a seleção das ComboBoxes e campos de texto
                        LimparCamposSelecao();
                    }
                    else
                    {
                        MessageBox.Show("Erro ao adicionar produto ao carrinho. Produto não encontrado.");
                    }
                }
                else
                {
                    MessageBox.Show("Erro ao acessar produtos da categoria selecionada.");
                }
            }
            else
            {
                MessageBox.Show("Selecione uma categoria e um produto antes de adicionar ao carrinho.");
            }
        }

        private void AtualizarExibicaoCarrinho()
        {
            dataGridViewCarrinho.Rows.Clear();

            foreach (var item in carrinho)
            {
                dataGridViewCarrinho.Rows.Add(item.Produto.Categoria, item.Produto.NomeProduto, item.Quantidade);
            }
        }

        private void DefinirColunasDataGridView()
        {
            // Verificar se as colunas já foram definidas para evitar duplicação
            if (dataGridViewCarrinho.Columns.Count == 0)
            {
                dataGridViewCarrinho.Columns.Add("Categoria", "Categoria");
                dataGridViewCarrinho.Columns.Add("NomeProduto", "Nome do Produto");
                dataGridViewCarrinho.Columns.Add("Quantidade", "Quantidade");
            }
        }

        private void LimparCamposSelecao()
        {
            cmbCategoria.SelectedIndex = -1;
            cmbProduto.Items.Clear();
            txtNomeProduto.Clear();
            numQuantidade.Value = 0;
        }

        public class CarrinhoItem
        {
            public Produto Produto { get; set; }
            public int Quantidade { get; set; }
        }

        private async void btnFinalizar_Click(object sender, EventArgs e)
        {
            // Verificar se o carrinho está vazio antes de finalizar o atendimento
            if (carrinho.Count == 0)
            {
                MessageBox.Show("O carrinho está vazio. Adicione produtos antes de finalizar o atendimento.");
                return;
            }

            // Obter informações do usuário a partir da UserSession
            var usuario = new
            {
                Usuario = UserSession.Usuario,
                NomeCompleto = UserSession.NomeCompleto,
                Telefone = UserSession.Telefone,
                Cidade = UserSession.Cidade
            };

            var atendimento = new Atendimento
            {
                NomeUsuario = usuario.Usuario,
                NomeCompleto = usuario.NomeCompleto,
                //Data = DateTime.Now,
                Data = DateTime.Now.ToString("o"), // Formato ISO 8601
                Itens = new List<ItemAtendimento>()
            };

            foreach (var item in carrinho)
            {
                var itemAtendimento = new ItemAtendimento
                {
                    Categoria = item.Produto.Categoria,
                    NomeProduto = item.Produto.NomeProduto,
                    Quantidade = item.Quantidade
                };
                atendimento.Itens.Add(itemAtendimento);
            }

            try
            {
                var response = await client.PushAsync("atendimentos", atendimento);
                MessageBox.Show("Atendimento finalizado com sucesso!");

                LimparCampos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar atendimento: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            cmbCategoria.SelectedIndex = -1;
            cmbProduto.SelectedIndex = -1;
            txtNomeProduto.Clear();
            numQuantidade.Value = 0;

            dataGridViewCarrinho.Rows.Clear();
            carrinho.Clear();
        }
    }
}
