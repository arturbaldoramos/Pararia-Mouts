using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Razor_Pages.Pages.cliente;
using Razor_Pages.Pages.produto;
using Razor_Pages.Pages.venda;

namespace Razor_Pages.Data
{
    public class Razor_PagesContext : DbContext
    {
        public Razor_PagesContext (DbContextOptions<Razor_PagesContext> options)
            : base(options)
        {
        }

        public DbSet<Razor_Pages.Pages.cliente.Cliente> Cliente { get; set; } = default!;
        public DbSet<Razor_Pages.Pages.produto.Produto> Produto { get; set; } = default!;
        public DbSet<Razor_Pages.Pages.venda.Venda> Venda { get; set; } = default!;
    }
}
