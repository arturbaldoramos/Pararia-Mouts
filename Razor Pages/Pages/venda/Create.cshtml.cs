using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Razor_Pages.Data;
using Razor_Pages.Pages.produto;

namespace Razor_Pages.Pages.venda
{
    public class CreateModel : PageModel
    {
        private readonly Razor_Pages.Data.Razor_PagesContext _context;

        public CreateModel(Razor_Pages.Data.Razor_PagesContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Venda Venda { get; set; } = default!;

        public SelectList ClienteSelectList { get; set; }
        public SelectList ProdutoSelectList { get; set; }
        public SelectList FormaDePagamentoSelectList { get; set; }

        [BindProperty]
        public List<int> SelectedProdutoIds { get; set; }

        [BindProperty]
        public List<int> ProdutoQuantidades { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            ClienteSelectList = new SelectList(await _context.Cliente.ToListAsync(), "Id", "Nome");
            ProdutoSelectList = new SelectList(await _context.Produto.ToListAsync(), "Id", "Nome");
            FormaDePagamentoSelectList = new SelectList(Enum.GetValues(typeof(FormaDePagamento)));

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            /*if (!ModelState.IsValid)
            {
                ClienteSelectList = new SelectList(await _context.Cliente.ToListAsync(), "Id", "Nome");
                ProdutoSelectList = new SelectList(await _context.Produto.ToListAsync(), "Id", "Nome");
                FormaDePagamentoSelectList = new SelectList(Enum.GetValues(typeof(FormaDePagamento)));
                return Page();
            }*/

            Venda.Data = DateTime.Now;
            Venda.ItensVendidos = new List<ProdutoVenda>();

            for (int i = 0; i < SelectedProdutoIds.Count; i++)
            {
                var produtoId = SelectedProdutoIds[i];
                var quantidade = ProdutoQuantidades[i];

                if (quantidade > 0)
                {
                    var produtoVenda = new ProdutoVenda
                    {
                        ProdutoId = produtoId,
                        Quantidade = quantidade
                    };
                    Venda.ItensVendidos.Add(produtoVenda);
                }
            }

            // Se o ClienteId não for selecionado, definir como null
            if (Venda.ClienteId == 0)
            {
                Venda.ClienteId = null;
            }

            _context.Venda.Add(Venda);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}