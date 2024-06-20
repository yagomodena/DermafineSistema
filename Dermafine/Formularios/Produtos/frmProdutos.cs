using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.Produtos
{
    public partial class frmProdutos : Form
    {
        public frmProdutos()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnAntiAcne_Click(object sender, EventArgs e)
        {
            frmAntiAcne antiAcne = new frmAntiAcne();
            antiAcne.Show();
        }

        private void btnCabelosUnhas_Click(object sender, EventArgs e)
        {
            frmCabelosUnhas cabelos = new frmCabelosUnhas();
            cabelos.Show();
        }

        private void btnCuidadosFaciais_Click(object sender, EventArgs e)
        {
            frmCuidadosFaciais faciais = new frmCuidadosFaciais();
            faciais.Show();
        }

        private void btnHidratacaoCorporal_Click(object sender, EventArgs e)
        {
            frmHidratacaoCorporal hidratacaoCorporal = new frmHidratacaoCorporal();
            hidratacaoCorporal.Show();
        }

        private void btnProtecaoSolar_Click(object sender, EventArgs e)
        {
            frmProtecaoSolar protecaoSolar = new frmProtecaoSolar();
            protecaoSolar.Show();
        }

        private void btnCilios_Click(object sender, EventArgs e)
        {
            frmCilios cilios = new frmCilios();
            cilios.Show();
        }
    }
}
