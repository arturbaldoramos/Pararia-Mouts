using Razor_Pages.Pages.produto;

namespace Razor_Pages.Pages.venda
{
    public class ProdutoVenda
    {
        public int Id { get; set; }

        // fk produto
        public int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }

        // fk venda
        public int VendaId { get; set; }
        public virtual Venda Venda { get; set; }

        public int Quantidade { get; set; }
    }
}
