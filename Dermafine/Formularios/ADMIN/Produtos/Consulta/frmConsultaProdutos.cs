using Dermafine.Classes;
using Dermafine.Formularios.ADMIN.Produtos.Cadastro;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN.Produtos.Consulta
{
    public partial class frmConsultaProdutos : Form
    {

        private IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;

        public frmConsultaProdutos()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private void btnCadastrarProduto_Click(object sender, EventArgs e)
        {
            frmCadastroProdutos inicio = new frmCadastroProdutos();
            inicio.Show();
            return;
        }

        private async void frmConsultaProdutos_Load(object sender, EventArgs e)
        {
            try
            {
                // Inicializar o cliente Firebase
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                    return;
                }

                // Configurar as colunas do DataGridView
                ConfigurarDataGridView();

                // Carregar as categorias do Firebase e preencher o ComboBox
                await CarregarCategorias();

                // Carregar todos os produtos do Firebase e ordenar por categoria
                await CarregarProdutos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private async Task<int> ObterQuantidadeProdutos()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null")
                {
                    var produtosDict = response.ResultAs<Dictionary<string, Produto>>();
                    return produtosDict.Count;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar quantidade de produtos: " + ex.Message);
            }

            return 0;
        }

        private void ConfigurarDataGridView()
        {
            dgvProdutos.Columns.Clear();
            dgvProdutos.AutoGenerateColumns = false;

            // Definindo a fonte para o título das colunas
            var columnHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            dgvProdutos.ColumnHeadersDefaultCellStyle.Font = columnHeaderFont;

            // Definindo a fonte para o conteúdo das células
            var cellFont = new Font("Arial", 11);
            dgvProdutos.DefaultCellStyle.Font = cellFont;

            var colCategoria = new DataGridViewTextBoxColumn
            {
                HeaderText = "Categoria",
                DataPropertyName = "Categoria",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colNomeProduto = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome do Produto",
                DataPropertyName = "NomeProduto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            };

            dgvProdutos.Columns.Add(colCategoria);
            dgvProdutos.Columns.Add(colNomeProduto);
        }

        private async Task CarregarCategorias()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null" && response.Body != null)
                {
                    var produtosDict = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                    var categorias = produtosDict.Keys.ToList();

                    cmbCategoriaProdutos.Items.Add("Todos");
                    foreach (var categoria in categorias)
                    {
                        cmbCategoriaProdutos.Items.Add(categoria);
                    }
                    cmbCategoriaProdutos.SelectedIndex = 0;
                }
                else
                {
                    MessageBox.Show("Nenhuma categoria encontrada no Firebase.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
            }
        }

        private async Task CarregarProdutos()
        {
            var produtos = await GetProdutos();
            produtos = produtos.OrderBy(p => p.Categoria).ToList();
            dgvProdutos.DataSource = produtos;
        }

        private async Task<List<Produto>> GetProdutos()
        {
            var produtos = new List<Produto>();

            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null")
                {
                    var categoriasDict = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                    foreach (var categoria in categoriasDict.Values)
                    {
                        foreach (var produto in categoria.Values)
                        {
                            produtos.Add(produto);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }

            return produtos;
        }

        private async void cmbCategoriaProdutos_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaSelecionada = cmbCategoriaProdutos.SelectedItem.ToString();

            List<Produto> produtos = await GetProdutos();

            if (categoriaSelecionada != "Todos")
            {
                produtos = produtos.Where(p => p.Categoria == categoriaSelecionada).ToList();
            }

            dgvProdutos.DataSource = produtos;
        }
    }
}
