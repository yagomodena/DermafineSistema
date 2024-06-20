using Dermafine.Classes;
using Dermafine.Formularios.ADMIN;
using Dermafine.Formularios.ADMIN.DashBoard;
using Dermafine.Formularios.Consulta;
using Dermafine.Formularios.Pedido;
using Dermafine.Formularios.Produtos;
using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.Principal
{
    public partial class frmPrincipal : Form
    {
        private Form activeForm;
        private Button currentButton;

        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void btnPedido_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmPedido(), sender);
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmProdutos(), sender);
        }

        private void ActivateButton(object btnSender)
        {
            if (btnSender != null)
            {
                if (currentButton != (Button)btnSender)
                {
                    currentButton = (Button)btnSender;
                }
            }
        }

        private void OpenChildForm(Form childForm, object btnSender)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            ActivateButton(btnSender);
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            this.panelExibir.Controls.Add(childForm);
            this.panelExibir.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
            lblTitle.Text = childForm.Text;
        }

        private void btnConsulta_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmConsulta(), sender);
        }

        public void frmPrincipal_Load(object sender, EventArgs e)
        {
            // Exibir o nome do usuário logado
            lblUsuarioLogado.Text = "Usuário: " + UserSession.Usuario;
            lblNomeUsuario.Text = "Nome: " + UserSession.NomeCompleto;
            lblPontuacaoTotal.Text = "Pontuação total: " + UserSession.pontuacaoTotal;

            if (UserSession.Usuario == "dermafine" && UserSession.NomeCompleto == "Dermafine ADMIN")
            {
                btnADMIN.Visible = true;
                btnDashboard.Visible = true;
            }
        }
        public void AtualizarPontuacaoTotal(int novaPontuacao)
        {
            lblPontuacaoTotal.Text = "Pontuação total: " + novaPontuacao;
        }

        private void btnADMIN_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmADMIN(), sender);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (activeForm != null)
            {
                activeForm.Close();
                activeForm = null;
                lblTitle.Text = "ÍNICIO";
            }
        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frmDashboard(), sender);
        }
    }
}
