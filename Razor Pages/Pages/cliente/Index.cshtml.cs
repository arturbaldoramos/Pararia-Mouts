using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Razor_Pages.Data;

namespace Razor_Pages.Pages.cliente
{
    public class IndexModel : PageModel
    {
        private readonly Razor_Pages.Data.Razor_PagesContext _context;

        public IndexModel(Razor_Pages.Data.Razor_PagesContext context)
        {
            _context = context;
        }

        public IList<Cliente> Cliente { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Cliente = await _context.Cliente.ToListAsync();
        }
    }
}
