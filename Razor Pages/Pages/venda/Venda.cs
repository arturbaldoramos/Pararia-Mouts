using Razor_Pages.Pages.cliente;
using Razor_Pages.Pages.produto;

namespace Razor_Pages.Pages.venda
{
    public class Venda
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }

        // fk cliente
        public int? ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }

        public virtual List<ProdutoVenda> ItensVendidos { get; set; }

        public FormaDePagamento FormaDePagamento { get; set; }
    }
}
