using Dermafine.Classes;
using Dermafine.Formularios.ADMIN;
using Dermafine.Formularios.ADMIN.DashBoard;
using Dermafine.Formularios.Consulta;
using Dermafine.Formularios.Pedido;
using Dermafine.Formularios.Produtos;
using Firebase.Storage;
using FireSharp.Config;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using static System.Net.WebRequestMethods;

namespace Dermafine.Formularios.Principal
{
    public partial class frmPrincipal : Form
    {
        private Form activeForm;
        private Button currentButton;
        private int currentIndex = 0;
        private Timer timer;

        // URLs das imagens armazenadas no Firebase Storage
        private readonly List<string> imageUrls = new List<string>
        {
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5946-removebg-preview.png?alt=media&token=538c85e7-19f6-4997-9148-d5296eea659f",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5805-removebg-preview.png?alt=media&token=dcbfdee6-8d6a-4437-80c3-5ffe461ad7a8",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5808-removebg-preview.png?alt=media&token=fffdd842-584f-4ba1-bf7f-09494ea86019",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5814-removebg-preview.png?alt=media&token=e91e3724-39b9-454a-9224-48d94a901b5e",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5815-removebg-preview.png?alt=media&token=b1fbd65a-c6bc-4a0e-950b-8d0dd61cc2b3",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5820-removebg-preview.png?alt=media&token=9e17e2dd-9cd8-4835-9985-bd63aa6aaf1c",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5822-removebg-preview.png?alt=media&token=aed826fd-b33d-4340-b667-5228893ff043",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5824-removebg-preview.png?alt=media&token=72d02247-3f54-4889-905f-b7fe49a373fa",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5828-removebg-preview.png?alt=media&token=7a5f82b3-0172-4e59-ba70-2d42ad556f48",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5830-removebg-preview.png?alt=media&token=4d81d9a3-284b-4b46-8ec3-a1bd783c1511",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5832-removebg-preview.png?alt=media&token=0fd3e55e-c225-470f-a56c-eb130f52a348",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5836-removebg-preview.png?alt=media&token=e2048288-b54f-420a-a982-955cd0263090",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5841-removebg-preview.png?alt=media&token=57f238a1-1320-425f-8b3b-bb2860416988",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5845-removebg-preview.png?alt=media&token=8b2dbbd8-4789-4d01-95c0-472eead03da9",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5848-removebg-preview.png?alt=media&token=377591d3-5d33-4d1f-93f9-f3edf845e30a",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5849-removebg-preview.png?alt=media&token=333a14c3-dc05-42e4-a0bd-3ccd9ae507f5",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5854-removebg-preview.png?alt=media&token=81e323cd-4d44-4415-b492-df955dd7cb51",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5856-removebg-preview.png?alt=media&token=4f21f363-9dda-4072-b5ae-1564fbf495d1",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5859-removebg-preview.png?alt=media&token=97bad74f-25c1-4d3c-a320-cbf0cfd7e6f3",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5861-removebg-preview.png?alt=media&token=14d28973-ce30-4455-9995-64ad1ecf366a",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5864-removebg-preview.png?alt=media&token=5e821351-b031-4d86-8306-cf28c4a60db0",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5866-removebg-preview.png?alt=media&token=ebfc4a14-3381-45c9-8839-5254b2eb310c",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5870-removebg-preview.png?alt=media&token=5ee98a2b-b06d-4c28-aed2-984621e43c9e",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5871-removebg-preview.png?alt=media&token=93b8a6ea-e268-470a-a0fb-1d2ffedb5248",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5875-removebg-preview.png?alt=media&token=1d4afa7e-fab9-4ca6-b0f7-e029dc8a02bb",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5883-removebg-preview.png?alt=media&token=2220480b-e5b2-48c9-a561-646d0bbfcadc",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5896-removebg-preview.png?alt=media&token=10de028c-c3ca-493f-91c7-26a032173343",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5898-removebg-preview.png?alt=media&token=ac433f83-48f7-4d6d-b8ec-8adf8c806fcc",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5900-removebg-preview.png?alt=media&token=fde3a006-7804-4988-8086-a0a794a2ae95",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5908-removebg-preview.png?alt=media&token=4d85f16e-6047-45e1-bea0-0d7f8fc4713d",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5910-removebg-preview.png?alt=media&token=2c636a19-a096-4361-a5a8-ff27e4a14d4c",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5917-removebg-preview.png?alt=media&token=1686b568-d9a8-4f9b-a814-90f5ade004a3",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5922-removebg-preview.png?alt=media&token=bd86bb41-37ef-4a91-8b2c-0dde6ed804e5",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5926-removebg-preview.png?alt=media&token=ef58ad2f-4898-4523-89fa-42c9b4264716",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5930-removebg-preview.png?alt=media&token=974b4b0e-2815-4193-854c-6b388f99fb06",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5934-removebg-preview.png?alt=media&token=09119a5d-cc1a-4584-9a3f-129202065341",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5936-removebg-preview.png?alt=media&token=edf448f4-7950-4426-9351-8b3573f35f7c",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5940-removebg-preview.png?alt=media&token=166c4be3-2a0b-4c24-b78a-4f8ed736a2e5",
            "https://firebasestorage.googleapis.com/v0/b/produtosdermafine.appspot.com/o/SemFundo%2F7A3A5942-removebg-preview.png?alt=media&token=a3aefd9c-ea69-4218-a142-60713884af07"
        };

        public frmPrincipal()
        {
            InitializeComponent();
            LoadImages();
        }

        private void LoadImages()
        {
            if (imageUrls.Count > 0)
            {
                // Exibir a primeira imagem
                DisplayImage(currentIndex);

                // Configurar e iniciar o Timer para exibição rotativa
                timer = new Timer();
                timer.Interval = 4000; // 5000 ms = 5 segundos
                timer.Tick += (sender, args) => NextImage();
                timer.Start();
            }
        }

        private void DisplayImage(int index)
        {
            if (imageUrls != null && imageUrls.Count > 0 && index < imageUrls.Count)
            {
                pictureBox2.Load(imageUrls[index]);
            }
        }

        private void NextImage()
        {
            currentIndex++;
            if (currentIndex >= imageUrls.Count)
            {
                currentIndex = 0; // Voltar ao início da lista
            }
            DisplayImage(currentIndex);
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
