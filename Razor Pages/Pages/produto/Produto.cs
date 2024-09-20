using Razor_Pages.Pages.venda;

namespace Razor_Pages.Pages.produto
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
