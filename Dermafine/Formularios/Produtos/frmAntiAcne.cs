using System;
using System.Windows.Forms;

namespace Dermafine.Formularios.Produtos
{
    public partial class frmAntiAcne : Form
    {
        public frmAntiAcne()
        {
            InitializeComponent();
        }

        private void pictureLinhaAcneSec_Click(object sender, EventArgs e)
        {
            MessageBox.Show("AcneSec - Loção Adstringente é um eficiente no combate à oleosidade e na remoção das impurezas nos poros," +
                " como acúmulo de sujeira e células mortas. AcneSec possui ação adstringente oferecendo benefícios para peles acneicas." +
                " Sua fórmula foi especialmente desenvolvida para permitir uma pele limpa com agradável sensação de frescor. " +
                "O uso de AcneSec representa a primeira etapa na utilização de produtos dermatológicos faciais.\r\n\r\n" +
                "A máscara AcneSec promove controle eficaz e seguro da oleosidade facial. É um coadjuvante no tratamento da pele " +
                "acneica. Sua fórmula contém Óleo de Melaleuca com ação antimicrobiana de amplo espectro, Óxido de Zinco com ação" +
                " antinflamatória e ação adstringente, Argila Cinza (Bentonita) promove efeito antiedema, clareador, secativo e " +
                "absorvente, e Estearato de Octila com ação emoliente não comedogênica, oferecendo toque aveludado. " +
                "Fragrância suave.\r\n\r\nAcneSec Sabonete Esfoliante Cremoso foi especialmente desenvolvido para a esfoliação da pele." +
                " Remove as impurezas na superfície da pele e acne e promovendo uma agradável sensação de limpeza e maciez." +
                " Cuidado diário. Limpa, desobstrui os poros e remove o excesso de oleosidade. Retira as impurezas e células mortas," +
                " enquanto hidrata na medida certa sem deixar a pele com aspecto oleoso e pesado. Combate e previne o " +
                "aparecimento de espinhas, refrescando e deixando a pele com um toque suave sem ressecar.", "Descrição Linha AcneSec");
        }

        private void pictureAcneSecAdstringente_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Indicações:\r\n• Limpeza facial profunda\r\n\r\nBenefícios:\r\n• Controle da oleosidade\r\n• Remoção de impurezas dos poros\r\n• Remoção de células mortas\r\n• Promove desobstrução de folículos pilossebáceos\r\n• Limpeza da pele\r\n• Renovação celular\r\n• Demaquilante\r\n\r\nModo de usar:\r\nÁpos a limpeza, umedeça um disco de algodão com o produto e passe sobre a pele delicadamente. Não enxugar e evitar aplicar o produto na área dos olhos.\r\n\r\nApresentação:\r\nFrasco contendo 200ml\r\n\r\nDetalhes:\r\nAcneSec - Loção Adstringente é um produto eficiente no combate à oleosidade e na remoção das impurezas nos poros, como acúmulo de sujeira e células mortas. AcneSec possui ação adstringente oferecendo benefícios para peles acneicas. Sua fórmula foi especialmente desenvolvida para permitir uma pele limpa com agradável sensação de frescor. O uso de AcneSec representa a primeira etapa na utilização de produtos dermatológicos faciais.", "Descrição AcneSec Loção Adstringente");
        }

        private void pictureAcneSecMascara_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Indicações:\r\n• Controle da oleosidade facial\r\n\r\nBenefícios:\r\n• Controle da oleosidade das peles acneicas e não acneicas\r\n• Tratamento da foliculite\r\n\r\nModo de usar:\r\nUso continuo, aplicar a noite uma camada generosa na face, deixar agir por pelo menos 40 minutos, lavando o rosto com água em seguida ou dormir e lavar no dia seguinte\r\n\r\nApresentação:\r\nBisnaga contendo 100g\r\n\r\nA máscara AcneSec promove controle eficaz e seguro da oleosidade facial. É um coadjuvante no tratamento da pele acneica. Sua fórmula contém Óleo de Melaleuca com ação antimicrobiana de amplo espectro, Óxido de Zinco com ação anti-inflamatória e ação adstringente, Argila Cinza (Bentonita) promove efeito antiedema, clareador, secativo e absorvente, e Estearato de Octila com ação emoliente não comedogênica, oferecendo toque aveludado. Fragrância suave.", "Descrição AcneSec Máscara Secativa");
        }

        private void pictureAcneSecSabonete_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Indicações:\r\n• Esfoliação facial\r\n\r\nBenefícios:\r\n• Limpa e Renova a pele\r\n• Desobstrui os poros evitando o aparecimento de acne\r\n• Remove o excesso de Oleosidade\r\n\r\nModo de Usar:\r\nmassagear o produto suavemente na pele molhada evitando a área dos olhos. Enxugar abundantemente em seguida. Utilizar de 2 a 3 vezes por semana ou conforme orientação de seu Dermatologista.\r\n\r\nApresentação:\r\nBisnaga contendo 100g\r\n\r\nDetalhes:\r\nAcneSec Sabonete Esfoliante Cremoso foi especialmente desenvolvido para a esfoliação da pele. Remove as impurezas na superfície da pele e acne e promovendo uma agradável sensação de limpeza e maciez. Cuidado diário. Limpa, desobstrui os poros e remove o excesso de oleosidade. Retira as impurezas e células mortas, enquanto hidrata na medida certa sem deixar a pele com aspecto oleoso e pesado. Combate e previne o aparecimento de espinhas, refrescando e deixando a pele com um toque suave sem ressecar.", "Descrição AcneSec Sabonete Esfoliante Cremoso");
        }
    }
}
