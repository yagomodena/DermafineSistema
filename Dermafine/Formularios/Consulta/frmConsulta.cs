using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dermafine.Formularios.Consulta
{
    public partial class frmConsulta : Form
    {

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        private bool atendimentosCarregados = false;

        public frmConsulta()
        {
            InitializeComponent();
        }

        private async void frmConsulta_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                    return;
                }

                // Limpar a lista de itens da combobox
                cmbProduto.Items.Clear();

                // Adicionar o item "Todos" à combobox
                cmbProduto.Items.Add("Todos");

                // Selecionar "Todos" como padrão
                cmbProduto.SelectedItem = "Todos";

                // Definir o item "Todos" como selecionado por padrão
                cmbProduto.SelectedIndex = 0;

                // Inicializar atendimentosCarregados como false
                atendimentosCarregados = false;

                // Carregar categorias, produtos e atendimentos
                await CarregarProdutos();
                await CarregarAtendimentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }

            // Ajuste automático do tamanho das colunas
            dataGridViewAtendimentos.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            // Definir o tamanho da fonte para os itens das células
            dataGridViewAtendimentos.DefaultCellStyle.Font = new Font("Microsoft Sans Serif", 11);

            // Definir o tamanho da fonte para os títulos das colunas
            dataGridViewAtendimentos.ColumnHeadersDefaultCellStyle.Font = new Font("Microsoft Sans Serif", 12, FontStyle.Bold);
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
                            produtosList.Add(produto.NomeProduto);
                        }
                    }
                    produtosList.Sort(); // Ordena os produtos em ordem alfabética
                    cmbProduto.Items.AddRange(produtosList.ToArray());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private async Task CarregarAtendimentos()
        {
            try
            {
                var usuarioLogado = UserSession.Usuario;
                var response = await client.GetAsync("atendimentos");

                // Verificar se há algum dado de atendimento
                if (response.Body == "null")
                {
                    MessageBox.Show("Não há atendimentos para carregar.");
                    return;
                }

                var atendimentos = response.ResultAs<Dictionary<string, Atendimento>>();

                // Filtrar atendimentos com base no produto selecionado
                string produtoSelecionado = cmbProduto.SelectedItem.ToString();
                List<Atendimento> atendimentosFiltrados;

                if (produtoSelecionado == "Todos")
                {
                    // Se "Todos" estiver selecionado, mostrar todos os atendimentos do usuário
                    atendimentosFiltrados = atendimentos
                        .Where(a => a.Value.NomeUsuario == usuarioLogado)
                        .Select(a => a.Value)
                        .ToList();
                }
                else
                {
                    // Filtrar atendimentos apenas para o produto selecionado
                    atendimentosFiltrados = atendimentos
                        .Where(a => a.Value.NomeUsuario == usuarioLogado && a.Value.Itens.Any(item => item.NomeProduto == produtoSelecionado))
                        .Select(a => a.Value)
                        .ToList();
                }

                ExibirAtendimentos(atendimentosFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar atendimentos: " + ex.Message);
            }
        }

        private void ExibirAtendimentos(List<Atendimento> atendimentos)
        {
            dataGridViewAtendimentos.Rows.Clear();
            dataGridViewAtendimentos.Columns.Clear();

            // Definir colunas do DataGridView
            dataGridViewAtendimentos.Columns.Add("NomeCompleto", "Nome Completo");
            dataGridViewAtendimentos.Columns.Add("Data", "Data");
            dataGridViewAtendimentos.Columns.Add("Categoria", "Categoria");
            dataGridViewAtendimentos.Columns.Add("NomeProduto", "Nome do Produto");
            dataGridViewAtendimentos.Columns.Add("Quantidade", "Quantidade");
            dataGridViewAtendimentos.Columns.Add("Pontos", "Pontuação");

            // Adicionar linhas
            foreach (var atendimento in atendimentos)
            {
                foreach (var item in atendimento.Itens)
                {
                    // Tentar converter a string para DateTime
                    DateTime dataAtendimento;
                    bool dataValida = DateTime.TryParseExact(atendimento.Data, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out dataAtendimento);

                    dataGridViewAtendimentos.Rows.Add(
                        atendimento.NomeCompleto,
                        dataValida ? dataAtendimento.ToString("g") : "Data Inválida",
                        item.Categoria,
                        item.NomeProduto,
                        item.Quantidade,
                        item.Pontos
                    );
                }
            }
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await CarregarAtendimentos();
        }
    }
}
