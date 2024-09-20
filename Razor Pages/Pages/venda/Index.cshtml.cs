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
    public class IndexModel : PageModel
    {
        private readonly Razor_Pages.Data.Razor_PagesContext _context;

        public IndexModel(Razor_Pages.Data.Razor_PagesContext context)
        {
            _context = context;
        }

        public IList<Venda> Venda { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Venda = await _context.Venda
                .Include(v => v.Cliente) // Incluir o cliente
                .ToListAsync();
        }
    }
}
