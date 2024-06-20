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

namespace Dermafine.Formularios.ADMIN.DashBoard
{
    public partial class frmDashboard : Form
    {

        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;

        public frmDashboard()
        {
            InitializeComponent();
        }

        private async void frmDashboard_Load(object sender, System.EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
                if (client == null)
                {
                    MessageBox.Show("Erro ao conectar ao Firebase. Verifique sua conexão com a internet.");
                    return;
                }

                ConfigurarDataGridView();

                // Carregar os filtros
                await CarregarFiltros();

                // Carregar todos os atendimentos
                await CarregarAtendimentos();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar dados: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvAtendimentos.Columns.Clear();
            dgvAtendimentos.AutoGenerateColumns = false;

            // Definindo a fonte para o título das colunas
            var columnHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            dgvAtendimentos.ColumnHeadersDefaultCellStyle.Font = columnHeaderFont;

            // Definindo a fonte para o conteúdo das células
            var cellFont = new Font("Arial", 11);
            dgvAtendimentos.DefaultCellStyle.Font = cellFont;

            var colData = new DataGridViewTextBoxColumn
            {
                HeaderText = "Data",
                DataPropertyName = "Data",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells,
                DefaultCellStyle = new DataGridViewCellStyle { Format = "dd/MM/yyyy" } // Formato de data desejado (sem hora)
            };

            var colNomeCompleto = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome Completo",
                DataPropertyName = "NomeCompleto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colCidade = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cidade",
                DataPropertyName = "Cidade",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

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

            var colQuantidade = new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantidade",
                DataPropertyName = "Quantidade",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colPontuacao = new DataGridViewTextBoxColumn
            {
                HeaderText = "Pontuação",
                DataPropertyName = "Pontuacao",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dgvAtendimentos.Columns.Add(colData);
            dgvAtendimentos.Columns.Add(colNomeCompleto);
            dgvAtendimentos.Columns.Add(colCidade);
            dgvAtendimentos.Columns.Add(colCategoria);
            dgvAtendimentos.Columns.Add(colNomeProduto);
            dgvAtendimentos.Columns.Add(colQuantidade);
            dgvAtendimentos.Columns.Add(colPontuacao);
        }

        private async Task CarregarFiltros()
        {
            await CarregarUsuarios();
            await CarregarCategorias();
            await CarregarProdutos();

            // Configurar DataTimePickers para o intervalo de datas
            dtpDataInicial.Value = DateTime.Now.AddMonths(-1); // Padrão para um mês atrás
            dtpDataFinal.Value = DateTime.Now; // Padrão para hoje
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("usuarios");
                if (response.Body != "null" && response.Body != null)
                {
                    var usuariosDict = response.ResultAs<Dictionary<string, register>>();
                    cmbUsuario.Items.Add("Todos");
                    foreach (var usuario in usuariosDict.Values)
                    {
                        cmbUsuario.Items.Add(usuario.NomeCompleto);
                    }
                    cmbUsuario.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message);
            }
        }

        private async Task CarregarCategorias()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null" && response.Body != null)
                {
                    var produtosDict = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                    cmbCategoria.Items.Add("Todos");
                    foreach (var categoria in produtosDict.Keys)
                    {
                        cmbCategoria.Items.Add(categoria);
                    }
                    cmbCategoria.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
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
                    cmbProduto.Items.Add("Todos");
                    foreach (var categoria in produtosDict.Values)
                    {
                        foreach (var produto in categoria.Values)
                        {
                            cmbProduto.Items.Add(produto.NomeProduto);
                        }
                    }
                    cmbProduto.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar produtos: " + ex.Message);
            }
        }

        private async Task CarregarAtendimentos()
        {
            var atendimentos = await GetAtendimentos();

            // Ordenar os atendimentos por Nome Completo
            atendimentos = atendimentos.OrderBy(a => a.NomeCompleto).ToList();

            dgvAtendimentos.DataSource = atendimentos;
        }

        private async Task<List<AtendimentoViewModel>> GetAtendimentos()
        {
            var atendimentos = new List<AtendimentoViewModel>();

            try
            {
                FirebaseResponse response = await client.GetAsync("atendimentos");
                if (response.Body != "null")
                {
                    var atendimentosDict = response.ResultAs<Dictionary<string, Atendimento>>();
                    foreach (var atendimento in atendimentosDict.Values)
                    {
                        foreach (var item in atendimento.Itens)
                        {
                            var usuarioResponse = await client.GetAsync($"usuarios/{atendimento.NomeUsuario}");
                            var usuario = usuarioResponse.ResultAs<register>();

                            // Converter a data do atendimento para DateTime
                            DateTime dataAtendimento;
                            bool dataValida = DateTime.TryParseExact(atendimento.Data, "yyyyMMddHHmmss", null, System.Globalization.DateTimeStyles.None, out dataAtendimento);

                            var atendimentoViewModel = new AtendimentoViewModel
                            {
                                NomeCompleto = atendimento.NomeCompleto,
                                Cidade = usuario.Cidade,
                                Categoria = item.Categoria,
                                NomeProduto = item.NomeProduto,
                                Quantidade = item.Quantidade,
                                Pontuacao = item.Pontos,
                                Data = dataValida ? dataAtendimento.Date : DateTime.MinValue.Date // Apenas a parte da data, sem a hora
                            };

                            atendimentos.Add(atendimentoViewModel);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar atendimentos: " + ex.Message);
            }

            return atendimentos;
        }

        public class AtendimentoViewModel
        {
            public string NomeCompleto { get; set; }
            public string Cidade { get; set; }
            public string Categoria { get; set; }
            public string NomeProduto { get; set; }
            public int Quantidade { get; set; }
            public int Pontuacao { get; set; }
            public DateTime Data { get; set; }
        }

        private async Task AplicarFiltros()
        {
            var atendimentos = await GetAtendimentos();

            if (cmbUsuario.SelectedItem != null && cmbUsuario.SelectedItem.ToString() != "Todos")
            {
                atendimentos = atendimentos.Where(a => a.NomeCompleto == cmbUsuario.SelectedItem.ToString()).ToList();
            }

            if (cmbCategoria.SelectedItem != null && cmbCategoria.SelectedItem.ToString() != "Todos")
            {
                atendimentos = atendimentos.Where(a => a.Categoria == cmbCategoria.SelectedItem.ToString()).ToList();
            }

            if (cmbProduto.SelectedItem != null && cmbProduto.SelectedItem.ToString() != "Todos")
            {
                atendimentos = atendimentos.Where(a => a.NomeProduto == cmbProduto.SelectedItem.ToString()).ToList();
            }

            if (dtpDataInicial.Value.Date <= dtpDataFinal.Value.Date)
            {
                atendimentos = atendimentos.Where(a => a.Data.Date >= dtpDataInicial.Value.Date && a.Data.Date <= dtpDataFinal.Value.Date).ToList();
            }

            dgvAtendimentos.DataSource = atendimentos;
        }

        private async void cmbCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async void cmbProduto_SelectedIndexChanged(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async void cmbUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async void dtpDataInicial_ValueChanged(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async void dtpDataFinal_ValueChanged(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }
    }
}
