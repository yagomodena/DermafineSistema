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

namespace Dermafine.Formularios.ADMIN.Pontuação
{
    public partial class frmPontuacao : Form
    {

        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;

        public frmPontuacao()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private async void frmPontuacao_Load(object sender, System.EventArgs e)
        {
            await CarregarUsuarios();
            await AplicarFiltros(); // Carrega os dados ao abrir o formulário
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("usuarios");
                if (response.Body != "null" && response.Body != null)
                {
                    var usuariosDict = response.ResultAs<Dictionary<string, register>>();
                    cmbUsuarios.Items.Add("Todos");
                    foreach (var usuario in usuariosDict.Values)
                    {
                        cmbUsuarios.Items.Add(usuario.NomeCompleto);
                    }
                    cmbUsuarios.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message);
            }
        }

        private async void btnFiltrar_Click(object sender, EventArgs e)
        {
            await AplicarFiltros();
        }

        private async Task AplicarFiltros()
        {
            var dataInicio = dtpDataInicio.Value;
            var dataFinal = dtpDataFinal.Value;
            var usuarioSelecionado = cmbUsuarios.SelectedItem?.ToString();

            var atendimentos = await GetAtendimentos();

            // Filtrar por data
            var atendimentosFiltrados = atendimentos.Where(a => a.Data >= dataInicio && a.Data <= dataFinal).ToList();

            // Filtrar por usuário, se selecionado
            if (usuarioSelecionado != "Todos")
            {
                atendimentosFiltrados = atendimentosFiltrados.Where(a => a.NomeCompleto == usuarioSelecionado).ToList();
            }

            // Exibir os dados no DataGridView
            ExibirAtendimentos(atendimentosFiltrados);
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

                            DateTime dataAtendimento;
                            bool dataValida = DateTime.TryParse(atendimento.Data, out dataAtendimento);

                            // Calcular pontos (1 ponto por item utilizado)
                            int pontos = item.Quantidade;

                            var atendimentoViewModel = new AtendimentoViewModel
                            {
                                NomeCompleto = atendimento.NomeCompleto,
                                Telefone = usuario.Telefone,
                                Cidade = usuario.Cidade,
                                Categoria = item.Categoria,
                                NomeProduto = item.NomeProduto,
                                Quantidade = item.Quantidade,
                                Data = dataValida ? dataAtendimento : DateTime.MinValue,
                                Pontos = pontos
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

        private void ExibirAtendimentos(List<AtendimentoViewModel> atendimentos)
        {
            dataGridViewPontuacao.Rows.Clear();
            dataGridViewPontuacao.Columns.Clear();

            // Definindo a fonte para o título das colunas
            var columnHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            dataGridViewPontuacao.ColumnHeadersDefaultCellStyle.Font = columnHeaderFont;

            // Definindo a fonte para o conteúdo das células
            var cellFont = new Font("Arial", 11);
            dataGridViewPontuacao.DefaultCellStyle.Font = cellFont;

            var colNomeCompleto = new DataGridViewTextBoxColumn
            {
                HeaderText = "Nome Completo",
                DataPropertyName = "NomeCompleto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colTelefone = new DataGridViewTextBoxColumn
            {
                HeaderText = "Telefone",
                DataPropertyName = "Telefone",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colCidade = new DataGridViewTextBoxColumn
            {
                HeaderText = "Cidade",
                DataPropertyName = "Cidade",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colPrescricao = new DataGridViewTextBoxColumn
            {
                HeaderText = "Quantidade de Prescrições Médicas",
                DataPropertyName = "QuantidadePrescicao",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            var colPontuacao = new DataGridViewTextBoxColumn
            {
                HeaderText = "Pontuação",
                DataPropertyName = "Pontuacao",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            };

            dataGridViewPontuacao.Columns.Add(colNomeCompleto);
            dataGridViewPontuacao.Columns.Add(colTelefone);
            dataGridViewPontuacao.Columns.Add(colCidade);
            dataGridViewPontuacao.Columns.Add(colPrescricao);
            dataGridViewPontuacao.Columns.Add(colPontuacao);

            foreach (var usuario in atendimentos.GroupBy(a => a.NomeCompleto))
            {
                var totalAtendimentos = usuario.Count();
                var totalPontos = usuario.Sum(a => a.Pontos);
                dataGridViewPontuacao.Rows.Add(usuario.Key, usuario.First().Telefone, usuario.First().Cidade, totalAtendimentos, totalPontos);
            }
        }
        public class AtendimentoViewModel
        {
            public string NomeCompleto { get; set; }
            public string Telefone { get; set; }
            public string Cidade { get; set; }
            public string Categoria { get; set; }
            public string NomeProduto { get; set; }
            public int Quantidade { get; set; }
            public DateTime Data { get; set; }
            public int Pontos { get; set; }
        }
    }
}
