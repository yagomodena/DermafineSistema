using Dermafine.Classes;
using Dermafine.Formularios.Principal;
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
        private List<Produto> produtos = new List<Produto>();
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

            dataGridViewCarrinho.CellEndEdit += dataGridViewCarrinho_CellEndEdit;
            dataGridViewCarrinho.CellClick += dataGridViewCarrinho_CellClick;
        }

        private async void frmPedido_Load(object sender, EventArgs e)
        {
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
                        var categorias = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                        if (categorias != null)
                        {
                            foreach (var categoria in categorias)
                            {
                                foreach (var produto in categoria.Value.Values)
                                {
                                    produtos.Add(produto);
                                }
                            }

                            produtos = produtos.OrderBy(p => p.NomeProduto).ToList();
                            foreach (var produto in produtos)
                            {
                                cmbProduto.Items.Add(produto.NomeProduto);
                            }

                            if (cmbProduto.Items.Count > 0)
                                cmbProduto.SelectedIndex = 0;
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

                DefinirColunasDataGridView();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }

            int pontuacaoTotal = carrinho.Sum(item => item.Produto.Pontuacao * item.Quantidade);
        }

        private void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedItem != null)
            {
                txtNomeProduto.Text = cmbProduto.SelectedItem.ToString();
            }
        }

        private void btnAdicionarAoCarrinho_Click(object sender, EventArgs e)
        {
            if (cmbProduto.SelectedItem != null)
            {
                string nomeProdutoSelecionado = cmbProduto.SelectedItem.ToString().Trim();
                int quantidade = (int)numQuantidade.Value;

                if (quantidade <= 0)
                {
                    MessageBox.Show("A quantidade deve ser maior que zero.");
                    return;
                }

                Produto produtoSelecionado = produtos
                    .FirstOrDefault(p => p.NomeProduto.Trim().Equals(nomeProdutoSelecionado, StringComparison.OrdinalIgnoreCase));

                if (produtoSelecionado != null)
                {
                    var itemExistente = carrinho.FirstOrDefault(item => item.Produto.NomeProduto == nomeProdutoSelecionado);

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

                    LimparCamposSelecao();
                }
                else
                {
                    MessageBox.Show("Erro ao adicionar produto ao carrinho. Produto não encontrado.");
                }
            }
            else
            {
                MessageBox.Show("Selecione um produto antes de adicionar ao carrinho.");
            }
        }

        private void AtualizarExibicaoCarrinho()
        {
            dataGridViewCarrinho.Rows.Clear();

            foreach (var item in carrinho)
            {
                int pontuacaoTotalItem = item.Produto.Pontuacao * item.Quantidade;
                dataGridViewCarrinho.Rows.Add(item.Produto.Categoria, item.Produto.NomeProduto, item.Quantidade, pontuacaoTotalItem);
            }
        }

        private void DefinirColunasDataGridView()
        {
            // Verificar se as colunas já foram definidas para evitar duplicação
            if (dataGridViewCarrinho.Columns.Count == 0)
            {
                dataGridViewCarrinho.Columns.Add("Categoria", "Categoria");
                dataGridViewCarrinho.Columns.Add("NomeProduto", "Nome do Produto");

                var quantidadeColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Quantidade",
                    HeaderText = "Quantidade",
                    ReadOnly = false // Definir como editável
                };
                dataGridViewCarrinho.Columns.Add(quantidadeColumn);

                var pontuacaoColumn = new DataGridViewTextBoxColumn
                {
                    Name = "Pontuacao",
                    HeaderText = "Pontuação",
                    ReadOnly = false // Definir como editável
                };
                dataGridViewCarrinho.Columns.Add(pontuacaoColumn);

                var deleteButtonColumn = new DataGridViewButtonColumn
                {
                    Name = "Excluir",
                    HeaderText = "Excluir",
                    Text = "Excluir",
                    UseColumnTextForButtonValue = true
                };
                dataGridViewCarrinho.Columns.Add(deleteButtonColumn);

                // Desabilitar edição para as outras colunas
                foreach (DataGridViewColumn column in dataGridViewCarrinho.Columns)
                {
                    if (column.Name != "Quantidade")
                    {
                        column.ReadOnly = true;
                    }
                }
            }
        }

        private void dataGridViewCarrinho_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se a célula editada está na coluna de quantidade e se a linha não está vazia
            if (e.ColumnIndex == dataGridViewCarrinho.Columns["Quantidade"].Index &&
                dataGridViewCarrinho.Rows[e.RowIndex].Cells["NomeProduto"].Value != null)
            {
                // Obter o nome do produto da linha editada
                string nomeProduto = dataGridViewCarrinho.Rows[e.RowIndex].Cells["NomeProduto"].Value.ToString();

                // Obter o valor editado da célula de quantidade
                int novaQuantidade;
                if (int.TryParse(dataGridViewCarrinho.Rows[e.RowIndex].Cells["Quantidade"].Value.ToString(), out novaQuantidade))
                {
                    // Se a nova quantidade for zero, definir para 1
                    if (novaQuantidade == 0)
                    {
                        dataGridViewCarrinho.Rows[e.RowIndex].Cells["Quantidade"].Value = 1;
                        MessageBox.Show("A quantidade não pode ser zero. O valor foi ajustado para 1.");
                        novaQuantidade = 1;
                    }

                    // Atualizar a quantidade no carrinho
                    var itemAtualizar = carrinho.FirstOrDefault(item => item.Produto.NomeProduto == nomeProduto);
                    if (itemAtualizar != null)
                    {
                        itemAtualizar.Quantidade = novaQuantidade;

                        // Recalcular a pontuação total do item
                        int pontuacaoTotalItem = itemAtualizar.Produto.Pontuacao * novaQuantidade;
                        dataGridViewCarrinho.Rows[e.RowIndex].Cells["Pontuacao"].Value = pontuacaoTotalItem;
                    }

                    // Atualizar a pontuação total do atendimento
                    CalcularPontuacaoTotalAtendimento();
                }
                else
                {
                    MessageBox.Show("Por favor, insira um valor numérico válido para a quantidade.");
                }
            }
        }
        private void CalcularPontuacaoTotalAtendimento()
        {
            int pontuacaoTotal = 0;
            foreach (var item in carrinho)
            {
                pontuacaoTotal += item.Produto.Pontuacao * item.Quantidade;
            }
        }

        private void dataGridViewCarrinho_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se o clique foi na coluna "Excluir" e se a célula clicada não é nula
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewCarrinho.Columns["Excluir"].Index &&
                dataGridViewCarrinho.Rows[e.RowIndex].Cells["NomeProduto"].Value != null)
            {
                // Obter o nome do produto da linha clicada
                string nomeProduto = dataGridViewCarrinho.Rows[e.RowIndex].Cells["NomeProduto"].Value.ToString();

                // Remover o produto do carrinho com base no nome
                var itemRemover = carrinho.FirstOrDefault(item => item.Produto.NomeProduto == nomeProduto);
                if (itemRemover != null)
                {
                    carrinho.Remove(itemRemover);
                    AtualizarExibicaoCarrinho();
                    MessageBox.Show("Produto removido do carrinho!");
                }
            }
        }

        private void LimparCamposSelecao()
        {
            txtNomeProduto.Clear();
            numQuantidade.Value = 1;
            cmbProduto.SelectedIndex = -1;
        }

        public class CarrinhoItem
        {
            public Produto Produto { get; set; }
            public int Quantidade { get; set; }
        }

        private async void btnFinalizar_Click(object sender, EventArgs e)
        {
            if (carrinho.Count == 0)
            {
                MessageBox.Show("Adicione itens ao carrinho antes de finalizar o atendimento.");
                return;
            }

            // Calcular a pontuação total do atendimento
            int pontuacaoTotal = carrinho.Sum(item => item.Produto.Pontuacao * item.Quantidade);

            try
            {
                Atendimento atendimento = new Atendimento
                {
                    NomeUsuario = UserSession.Usuario,
                    NomeCompleto = UserSession.NomeCompleto,
                    Itens = carrinho.Select(item => new ItemAtendimento
                    {
                        Categoria = item.Produto.Categoria,
                        NomeProduto = item.Produto.NomeProduto,
                        Quantidade = item.Quantidade,
                        Pontos = item.Produto.Pontuacao * item.Quantidade
                    }).ToList(),
                    Data = DateTime.Now.ToString("yyyyMMddHHmmss"), // formato string para Data
                    Pontos = pontuacaoTotal // já calculando a pontuação total aqui
                };

                // Salvar o atendimento no Firebase
                SetResponse response = await client.SetAsync("atendimentos/" + atendimento.Data, atendimento);

                // Atualizar a pontuação total do usuário
                UserSession.pontuacaoTotal += atendimento.Pontos;

                // Salvar a pontuação total atualizada no Firebase
                await client.SetAsync("usuarios/" + UserSession.Usuario + "/pontuacaoTotal", UserSession.pontuacaoTotal);

                // Atualizar a label no frmPrincipal
                frmPrincipal mainForm = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.Invoke(new Action(() =>
                    {
                        mainForm.AtualizarPontuacaoTotal(UserSession.pontuacaoTotal);
                    }));
                }

                // Limpar o carrinho e atualizar a exibição
                carrinho.Clear();
                AtualizarExibicaoCarrinho();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao finalizar o atendimento: " + ex.Message);
            }
        }

        private void LimparCampos()
        {
            LimparCamposSelecao();
        }

        private void dataGridViewCarrinho_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            // Verificar se a célula sendo editada está na coluna de quantidade e se a linha não está vazia
            if (e.ColumnIndex == dataGridViewCarrinho.Columns["Quantidade"].Index &&
                dataGridViewCarrinho.Rows[e.RowIndex].Cells["NomeProduto"].Value != null)
            {
                // Permitir a edição
                e.Cancel = false;
            }
            else
            {
                // Cancelar a edição
                e.Cancel = true;
            }
        }
    }
}
