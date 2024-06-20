using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.Cadastro
{
    public partial class frmRecuperarSenha : Form
    {

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public frmRecuperarSenha()
        {
            InitializeComponent();
        }

        private async void btnAtualizarCadastro_Click(object sender, System.EventArgs e)
        {
            try
            {
                var register = new register
                {
                    Usuario = txtUsuario.Text,
                    NomeCompleto = txtNomeCompleto.Text,
                    Cidade = txtCidade.Text,
                    Senha = txtSenha.Text,
                };

                FirebaseResponse response = await client.UpdateAsync("usuarios/" + txtUsuario.Text, register);
                if (response.StatusCode == System.Net.HttpStatusCode.OK)
                {
                    this.Hide(); // Esconder o formulário de login antes de abrir o principal
                    frmLogin login = new frmLogin();
                    login.FormClosed += (s, args) => Application.Exit(); // Fechar a aplicação quando o frmPrincipal for fechado
                    login.Show();
                    return;
                }
                else
                {
                    MessageBox.Show("Erro ao atualizar cadastro.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao atualizar cadastro: " + ex.Message);
            }
        }

        private void frmRecuperarSenha_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " Verifique sua conexão!");
            }
        }

        private async void picPesquisar_Click(object sender, EventArgs e)
        {
             FirebaseResponse userResponse = await client.GetAsync("usuarios/" + txtUsuario.Text);
            if (userResponse.Body == "null")
            {
                MessageBox.Show("Usuário não encontrado.");
                return;
            }

            // Se o usuário for encontrado, obtenha as informações do usuário
            register user = userResponse.ResultAs<register>();

            // Preencha os campos com as informações do usuário
            txtNomeCompleto.Text = user.NomeCompleto;
            txtCidade.Text = user.Cidade;
            txtSenha.Text = user.Senha;
        }
    }
}
