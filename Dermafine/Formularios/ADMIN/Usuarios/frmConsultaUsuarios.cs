using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Drawing;
using System.Linq;
using Dermafine.Formularios.Principal;

namespace Dermafine.Formularios.ADMIN.Usuarios
{
    public partial class frmConsultaUsuarios : Form
    {
        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;
        private bool isCellClickEventHandled = false;

        public frmConsultaUsuarios()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
        }

        private async void frmConsultaUsuarios_Load(object sender, System.EventArgs e)
        {
            ConfigurarDataGridView();
            await CarregarUsuarios();

            // Ajuste automático do tamanho das colunas
            dgvUsuarios.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                dgvUsuarios.Rows.Clear(); // Limpar as linhas antes de recarregar os dados
                FirebaseResponse response = await client.GetAsync("usuarios");
                if (response.Body != "null")
                {
                    var usuariosDict = response.ResultAs<Dictionary<string, register>>();

                    foreach (var usuario in usuariosDict.Values)
                    {
                        dgvUsuarios.Rows.Add(usuario.NomeCompleto, usuario.Cidade, usuario.pontuacaoTotal);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar usuários: " + ex.Message);
            }
        }

        private void ConfigurarDataGridView()
        {
            // Limpando colunas existentes, se houver
            dgvUsuarios.Columns.Clear();

            // Definindo a fonte para o título das colunas
            var columnHeaderFont = new Font("Arial", 12, FontStyle.Bold);
            dgvUsuarios.ColumnHeadersDefaultCellStyle.Font = columnHeaderFont;

            // Definindo a fonte para o conteúdo das células
            var cellFont = new Font("Arial", 11);
            dgvUsuarios.DefaultCellStyle.Font = cellFont;

            // Adicionando as colunas necessárias
            dgvUsuarios.Columns.Add("NomeCompleto", "Nome Completo");
            dgvUsuarios.Columns.Add("Cidade", "Cidade");
            dgvUsuarios.Columns.Add("Pontuacao", "Pontuação");

            // Bloquear a edição das colunas
            foreach (DataGridViewColumn column in dgvUsuarios.Columns)
            {
                column.ReadOnly = true;
            }

            // Adicionar coluna de botão de pagamento
            DataGridViewButtonColumn btnPagamento = new DataGridViewButtonColumn();
            btnPagamento.Name = "Pagamento";
            btnPagamento.HeaderText = "Pagamento";
            btnPagamento.Text = "Pagar";
            btnPagamento.UseColumnTextForButtonValue = true;
            dgvUsuarios.Columns.Add(btnPagamento);

            // Adicionar evento de clique no botão de pagamento
            dgvUsuarios.CellClick -= dgvUsuarios_CellClick; // Remover o evento para evitar múltiplas adições
            dgvUsuarios.CellClick += dgvUsuarios_CellClick;
        }

        private async void dgvUsuarios_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Verificar se o clique foi na coluna do botão de pagamento
            if (e.ColumnIndex == dgvUsuarios.Columns["Pagamento"].Index && e.RowIndex >= 0 && !isCellClickEventHandled)
            {
                isCellClickEventHandled = true;  // Define o flag para evitar múltiplos disparos

                string nomeUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["NomeCompleto"].Value.ToString();
                DialogResult result = MessageBox.Show($"Deseja realmente fazer o pagamento para {nomeUsuario}?", "Confirmação de Pagamento", MessageBoxButtons.YesNo);

                if (result == DialogResult.Yes)
                {
                    await RealizarPagamento(nomeUsuario);
                }

                isCellClickEventHandled = false;  // Reseta o flag após a operação
            }
        }

        private async Task RealizarPagamento(string nomeUsuario)
        {
            try
            {
                // Buscar usuário pelo nome completo
                var response = await client.GetAsync("usuarios");
                if (response.Body == "null")
                {
                    MessageBox.Show("Usuário não encontrado.");
                    return;
                }

                var usuariosDict = response.ResultAs<Dictionary<string, register>>();
                var usuario = usuariosDict.Values.FirstOrDefault(u => u.NomeCompleto == nomeUsuario);

                if (usuario == null)
                {
                    MessageBox.Show("Usuário não encontrado.");
                    return;
                }

                // Excluir atendimentos do usuário
                var responseAtendimentos = await client.GetAsync("atendimentos");
                if (responseAtendimentos.Body != "null")
                {
                    var atendimentosDict = responseAtendimentos.ResultAs<Dictionary<string, Atendimento>>();
                    foreach (var atendimento in atendimentosDict)
                    {
                        if (atendimento.Value.NomeUsuario == usuario.Usuario)
                        {
                            await client.DeleteAsync($"atendimentos/{atendimento.Key}");
                        }
                    }
                }

                // Zerar a pontuação do usuário
                usuario.pontuacaoTotal = 0;
                await client.UpdateAsync($"usuarios/{usuario.Usuario}", usuario);

                MessageBox.Show("Pagamento realizado com sucesso. Pontuação zerada e atendimentos excluídos.");
                await CarregarUsuarios(); // Recarregar a lista de usuários para refletir a mudança

                // Atualizar a label no frmPrincipal
                frmPrincipal mainForm = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
                if (mainForm != null)
                {
                    mainForm.Invoke(new Action(() =>
                    {
                        mainForm.AtualizarPontuacaoTotal(UserSession.pontuacaoTotal);
                    }));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar pagamento: " + ex.Message);
            }
        }
    }
}
