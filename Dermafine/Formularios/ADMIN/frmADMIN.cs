using Dermafine.Formularios.ADMIN.Produtos.Consulta;
using Dermafine.Formularios.ADMIN.Usuarios;
using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN
{
    public partial class frmADMIN : Form
    {
        public frmADMIN()
        {
            InitializeComponent();
        }

        private void btnProdutos_Click(object sender, EventArgs e)
        {
            frmConsultaProdutos inicio = new frmConsultaProdutos();
            inicio.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmConsultaUsuarios inicio = new frmConsultaUsuarios();
            inicio.Show();
        }
    }
}
