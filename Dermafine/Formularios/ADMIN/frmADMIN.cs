using Dermafine.Formularios.ADMIN.Produtos.Consulta;
using Dermafine.Formularios.ADMIN.Usuarios;
using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dermafine.Formularios.ADMIN
{
    public partial class frmADMIN : Form
    {

        private IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "L4SqYZL5dM3XHtp7cDE2Y2WHaB3ISqZN3oVDuiMB",
            BasePath = "https://produtosdermafine-default-rtdb.firebaseio.com/"
        };
        private IFirebaseClient client;
        private const long LimiteGratisEmBytes = 1073741824; // 1GB em bytes

        public frmADMIN()
        {
            InitializeComponent();
            client = new FireSharp.FirebaseClient(config);
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

        private async void button2_Click(object sender, EventArgs e)
        {
            try
            {
                long usedBytes = await CalcularUsoDeArmazenamento();
                if (usedBytes != -1)
                {
                    long freeBytes = LimiteGratisEmBytes - usedBytes; // 1GB - usado em bytes

                    // Converter para MB ou GB conforme necessário
                    double usedMB = usedBytes / (1024.0 * 1024.0);
                    double freeMB = freeBytes / (1024.0 * 1024.0);

                    MessageBox.Show($"Armazenamento utilizado: {usedMB:F2} MB\nEspaço livre restante: {freeMB:F2} MB\n\nRealizando os pagamentos das pontuações, " +
                        $"espaço adicional será liberado à medida que as informações forem excluídas do banco de dados.");

                    // Verificar se o uso excede o limite gratuito
                    if (usedBytes > LimiteGratisEmBytes)
                    {
                        MessageBox.Show("O uso de armazenamento excedeu o limite gratuito de 1GB. Cobranças adicionais podem ser aplicadas.");
                    }
                }
                else
                {
                    MessageBox.Show("Falha ao obter informações de uso de armazenamento.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao verificar armazenamento: " + ex.Message);
            }
        }

        private async Task<long> CalcularUsoDeArmazenamento()
        {
            try
            {
                // Exemplo: Vamos calcular o uso de armazenamento com base na quantidade de dados em "usuarios"
                FirebaseResponse response = await client.GetAsync("usuarios");
                if (response.Body != "null")
                {
                    var usuariosDict = response.ResultAs<Dictionary<string, object>>();
                    long totalBytes = 0;

                    // Calcular o tamanho total dos dados em bytes
                    foreach (var usuario in usuariosDict.Values)
                    {
                        // Aqui você deve ajustar conforme a estrutura dos seus dados
                        // Por exemplo, se cada usuário tem uma estrutura fixa de dados, calcule o tamanho desses dados
                        // Se houver várias coleções, repita este processo para cada coleção relevante
                        totalBytes += CalcularTamanhoDoObjeto(usuario);
                    }

                    return totalBytes;
                }
                else
                {
                    MessageBox.Show("Nenhum dado encontrado.");
                    return -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao calcular uso de armazenamento: " + ex.Message);
                return -1;
            }
        }

        private long CalcularTamanhoDoObjeto(object obj)
        {
            // Aqui você implementa a lógica para calcular o tamanho em bytes do objeto
            // Exemplo: converter para JSON e calcular o comprimento do JSON em bytes
            // Este método é apenas um exemplo, adapte conforme a estrutura dos seus dados
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(obj);
            return System.Text.Encoding.UTF8.GetByteCount(json);
        }
    }
}
