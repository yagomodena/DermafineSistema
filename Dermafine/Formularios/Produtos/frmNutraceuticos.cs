using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.Produtos
{
    public partial class frmNutraceuticos : Form
    {
        public frmNutraceuticos()
        {
            InitializeComponent();
        }

        private void pictureUnissy_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Suplemento Alimentar em Cápsula\r\n\r\nIndicações:\r\n• Tratamento de cabelos e unhas frágeis e quebradiças\r\n\r\nBenefícios:\r\n• Melhora as características físicas dos fios\r\n• Proporciona mais elasticidade, força e brilho\r\n• Ajuda no crescimento de cabelos e unhas\r\n• Fortalece unhas frágeis e quebradiças\r\n\r\nRecomendação de uso:\r\nIngerir 1 cápsula ao dia, preferencialmente pela manhã.\r\n\r\nApresentação:\r\n60 Cápsulas\r\n\r\nDescrição:\r\n\r\nUnissy+ Cabelos e Unhas - Foi desenvolvido para suprir a falta de nutrientes essenciais para fortalecimento de cabelos e unhas. É um nutricosmético que possui em sua fórmula vitaminas e minerais indispensáveis à saúde, atuando de dentro para fora na revitalização e fortalecimento de cabelos e unhas.", "Unissy+ Cabelos e Unhas");
        }
    }
}
