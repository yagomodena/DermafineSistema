using System.Collections.Generic;

namespace Dermafine.Classes
{
    public class Atendimento
    {
        public string NomeUsuario { get; set; }
        public string NomeCompleto { get; set; }
        public List<ItemAtendimento> Itens { get; set; }
        public string Data { get; set; }
        public int Pontos { get; set; }
    }

    public class ItemAtendimento
    {
        public string Categoria { get; set; }
        public string NomeProduto { get; set; }
        public int Quantidade { get; set; }
        public int Pontos { get; set; }
    }
}
