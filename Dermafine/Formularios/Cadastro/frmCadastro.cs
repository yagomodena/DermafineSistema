using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Dermafine.Formularios.Cadastro
{
    public partial class frmCadastro : Form
    {
        Thread t1;
        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;

        public frmCadastro()
        {
            InitializeComponent();
        }     

        private void txtCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirLogin);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void abrirLogin(object obj)
        {
            Application.Run(new frmLogin());
        }

        private async void btnCadastrar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNomeCompleto.Text) || string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe todos os campos!");
                return;
            }

            // Verificar se o nome de usuário já está em uso
            FirebaseResponse userCheckResponse = await client.GetAsync("usuarios/" + txtUsuario.Text);
            if (userCheckResponse.Body != "null")
            {
                MessageBox.Show("Nome de usuário já está em uso. Por favor, escolha outro nome de usuário.");
                return;
            }

            // Verificar se o CPF já está em uso
            FirebaseResponse cpfCheckResponse = await client.GetAsync("usuarios");
            Dictionary<string, register> users = cpfCheckResponse.ResultAs<Dictionary<string, register>>();

            // Se o nome de usuário estiver disponível, proceda com o cadastro
            var register = new register
            {
                NomeCompleto = txtNomeCompleto.Text,
                Cidade = txtCidade.Text,
                Usuario = txtUsuario.Text,
                Senha = txtSenha.Text,
                PontuacaoTotal = 0
            };

            FirebaseResponse response = await client.SetAsync("usuarios/" + txtUsuario.Text, register);
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                MessageBox.Show("Cadastro realizado com sucesso!");

                this.Close();

                t1 = new Thread(abrirLogin);
                t1.SetApartmentState(ApartmentState.STA);
                t1.Start();
            }
            else
            {
                MessageBox.Show("Erro ao cadastrar usuário.");
            }
        }

        private void frmCadastro_Load(object sender, EventArgs e)
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
    }
}
