using Dermafine.Classes;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using System.Windows.Forms;
using System.Drawing;

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

        public frmConsultaUsuarios()
        {
            InitializeComponent(); 
            client = new FireSharp.FirebaseClient(config);
        }

        private async void frmConsultaUsuarios_Load(object sender, System.EventArgs e)
        {
            ConfigurarDataGridView();
            await CarregarUsuarios();
        }

        private async Task CarregarUsuarios()
        {
            try
            {
                FirebaseResponse response = await client.GetAsync("usuarios");
                if (response.Body != "null")
                {
                    var usuariosDict = response.ResultAs<Dictionary<string, register>>();

                    foreach (var usuario in usuariosDict.Values)
                    {
                        dgvUsuarios.Rows.Add(usuario.NomeCompleto, usuario.Cidade);
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
        }
    }
}
