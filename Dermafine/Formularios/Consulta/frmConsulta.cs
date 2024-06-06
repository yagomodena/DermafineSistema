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

                await CarregarCategorias();
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

        private async Task CarregarCategorias()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("produtos");
                if (response.Body != "null")
                {
                    var categorias = response.ResultAs<Dictionary<string, Dictionary<string, Produto>>>();
                    if (categorias != null)
                    {
                        foreach (var categoria in categorias)
                        {
                            cmbCategoria.Items.Add(categoria.Key);
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
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar categorias: " + ex.Message);
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

                var atendimentosUsuario = atendimentos
                    .Where(a => a.Value.NomeUsuario == usuarioLogado)
                    .Select(a => a.Value)
                    .ToList();

                ExibirAtendimentos(atendimentosUsuario);
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

            // Adicionar linhas
            foreach (var atendimento in atendimentos)
            {
                foreach (var item in atendimento.Itens)
                {
                    // Tentar converter a string para DateTime
                    DateTime dataAtendimento;
                    bool dataValida = DateTime.TryParse(atendimento.Data, out dataAtendimento);

                    dataGridViewAtendimentos.Rows.Add(
                        atendimento.NomeCompleto,
                        dataValida ? dataAtendimento.ToString("g") : "Data Inválida",
                        item.Categoria,
                        item.NomeProduto,
                        item.Quantidade
                    );
                }
            }
        }

        private async void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                string categoriaFiltro = cmbCategoria.Text.Trim();
                var usuarioLogado = UserSession.Usuario;

                var response = await client.GetAsync("atendimentos");
                var atendimentos = response.ResultAs<Dictionary<string, Atendimento>>();

                var atendimentosFiltrados = atendimentos
                    .Where(a => a.Value.NomeUsuario == usuarioLogado)
                    .Select(a => a.Value)
                    .Where(a => string.IsNullOrEmpty(categoriaFiltro) || a.Itens.Any(i => i.Categoria.Contains(categoriaFiltro)))
                    .ToList();

                ExibirAtendimentos(atendimentosFiltrados);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao filtrar atendimentos: " + ex.Message);
            }
        }
    }
}
