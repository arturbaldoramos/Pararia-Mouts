using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages.Data;

namespace Razor_Pages.Pages.venda
{
    public class DetailsModel : PageModel
    {
        private readonly Razor_Pages.Data.Razor_PagesContext _context;

        public DetailsModel(Razor_Pages.Data.Razor_PagesContext context)
        {
            _context = context;
        }

        public Venda Venda { get; set; } = default!;
        public decimal TotalAmount { get; set; } // Propriedade para armazenar o valor total

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Venda = await _context.Venda
                .Include(v => v.Cliente) // Incluir o cliente
                .Include(v => v.ItensVendidos) // Incluir os itens vendidos
                    .ThenInclude(iv => iv.Produto) // Incluir os detalhes dos produtos
                .FirstOrDefaultAsync(m => m.Id == id);

            if (Venda == null)
            {
                return NotFound();
            }

            // Calcular o valor total da venda
            TotalAmount = Venda.ItensVendidos.Sum(iv => iv.Produto.Preco * iv.Quantidade);

            return Page();
        }
    }
}
