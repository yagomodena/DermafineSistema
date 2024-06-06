using System.Collections.Generic;

namespace Dermafine.Classes
{
    public class Produto
    {
        public string NomeProduto { get; set; }
        public string Categoria { get; set; }
    }

    public class CategoriaProdutos
    {
        public Dictionary<string, Produto> Produtos { get; set; }
    }
}
