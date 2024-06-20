using Dermafine.Classes;
using Dermafine.Formularios.Cadastro;
using Dermafine.Formularios.Principal;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace Dermafine
{
    public partial class frmLogin : Form
    {
        Thread t1;
        IFirebaseClient client;

        public frmLogin()
        {
            InitializeComponent();
        }

        IFirebaseConfig config = new FirebaseConfig()
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };

        private void txtCadastro_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirCadastro);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }

        private void abrirCadastro(object obj)
        {
            Application.Run(new frmCadastro());
        }

        private void abrirRecuperacao(object obj)
        {
            Application.Run(new frmRecuperarSenha());
        }

        private async void btnAcessar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtUsuario.Text) || string.IsNullOrEmpty(txtSenha.Text))
            {
                MessageBox.Show("Informe todos os campos!");
                return;
            }

            try
            {
                FirebaseResponse response = await client.GetAsync("usuarios/");
                Dictionary<string, register> result = response.ResultAs<Dictionary<string, register>>();

                foreach (var get in result)
                {
                    string usuario = get.Value.Usuario;
                    string senha = get.Value.Senha;

                    if (txtUsuario.Text == usuario && txtSenha.Text == senha)
                    {
                        MessageBox.Show("Bem-vindo(a) " + txtUsuario.Text);

                        UserSession.Usuario = usuario;
                        UserSession.NomeCompleto = get.Value.NomeCompleto;
                        UserSession.Cidade = get.Value.Cidade;
                        UserSession.pontuacaoTotal = get.Value.pontuacaoTotal;

                        this.Hide();
                        frmPrincipal inicio = new frmPrincipal();
                        inicio.FormClosed += (s, args) => Application.Exit();
                        inicio.Show();
                        return;
                    }
                }

                MessageBox.Show("Usuário ou senha incorretos!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao acessar o Firebase: " + ex.Message);
            }
        }        

        private void frmLogin_Load(object sender, EventArgs e)
        {
            try
            {
                client = new FireSharp.FirebaseClient(config);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao conectar ao Firebase: " + ex.Message);
            }
        }

        private void txtRecuperarSenha_Click(object sender, EventArgs e)
        {
            this.Close();
            t1 = new Thread(abrirRecuperacao);
            t1.SetApartmentState(ApartmentState.STA);
            t1.Start();
        }        
    }
}
