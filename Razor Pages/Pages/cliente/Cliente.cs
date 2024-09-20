using Razor_Pages.Pages.venda;

namespace Razor_Pages.Pages.cliente
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Cpf { get; set; }

        // List of sales associated with this client
        public virtual List<Venda> Vendas { get; set; }
    }
}
