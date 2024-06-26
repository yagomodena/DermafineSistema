﻿using Dermafine.Classes;
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
            // Verificar se o clique foi na coluna do botão de pagamento e se não é uma linha vazia
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvUsuarios.Columns["Pagamento"].Index && !isCellClickEventHandled)
            {
                isCellClickEventHandled = true;  // Define o flag para evitar múltiplos disparos

                string nomeUsuario = dgvUsuarios.Rows[e.RowIndex].Cells["NomeCompleto"].Value?.ToString();
                if (string.IsNullOrEmpty(nomeUsuario))
                {
                    MessageBox.Show("Selecione um usuário válido.");
                    isCellClickEventHandled = false;
                    return;
                }

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
            progressBarPagamento.Visible = true;
            progressBarPagamento.Value = 0; // Inicia com 0%

            try
            {
                // Passo 1: Buscar usuário pelo nome completo
                progressBarPagamento.Value = 20; // Atualiza para 20%
                var response = await client.GetAsync("usuarios");
                if (response.Body == "null")
                {
                    MessageBox.Show("Usuário não encontrado.");
                    progressBarPagamento.Visible = false;
                    return;
                }

                var usuariosDict = response.ResultAs<Dictionary<string, register>>();
                var usuario = usuariosDict.Values.FirstOrDefault(u => u.NomeCompleto.Equals(nomeUsuario, StringComparison.OrdinalIgnoreCase));

                if (usuario == null)
                {
                    MessageBox.Show("Usuário não encontrado.");
                    progressBarPagamento.Visible = false;
                    return;
                }

                // Verificar se a pontuação do usuário é zero
                if (usuario.pontuacaoTotal == 0)
                {
                    MessageBox.Show("Usuário não tem pontuação suficiente para realizar o pagamento.");
                    progressBarPagamento.Visible = false;
                    return;
                }

                // Passo 2: Excluir atendimentos do usuário
                progressBarPagamento.Value = 50; // Atualiza para 50%
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

                // Passo 3: Zerar a pontuação do usuário
                progressBarPagamento.Value = 80; // Atualiza para 80%
                usuario.pontuacaoTotal = 0;
                await client.UpdateAsync($"usuarios/{usuario.Usuario}", usuario);

                MessageBox.Show("Pagamento realizado com sucesso. Pontuação zerada e atendimentos excluídos.");
                await CarregarUsuarios(); // Recarregar a lista de usuários para refletir a mudança

                // Atualizar a label no frmPrincipal
                frmPrincipal mainForm = Application.OpenForms.OfType<frmPrincipal>().FirstOrDefault();
                if (mainForm != null)
                {
                    // Atualizar UserSession.pontuacaoTotal
                    UserSession.pontuacaoTotal = usuario.pontuacaoTotal;

                    // Invocar a atualização da interface no thread principal
                    mainForm.Invoke(new Action(() =>
                    {
                        mainForm.AtualizarPontuacaoTotal(UserSession.pontuacaoTotal);
                    }));
                }

                progressBarPagamento.Value = 100; // Atualiza para 100%
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao realizar pagamento: " + ex.Message);
            }
            finally
            {
                progressBarPagamento.Visible = false; // Esconde a ProgressBar ao final da operação
            }
        }
    }
}
