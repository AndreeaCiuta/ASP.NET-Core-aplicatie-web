using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Data
{
    public class PerfumesShopContext : DbContext
    {
        public PerfumesShopContext (DbContextOptions<PerfumesShopContext> options)
            : base(options)
        {
        }

        public DbSet<PerfumesShop.Pages.Models.Parfum> Parfum { get; set; } = default!;

        public DbSet<PerfumesShop.Pages.Models.Categorie> Categorie { get; set; }

        public DbSet<PerfumesShop.Pages.Models.Concentratie> Concentratie { get; set; }

        public DbSet<PerfumesShop.Pages.Models.Tip> Tip { get; set; }

        public DbSet<PerfumesShop.Pages.Models.Utilizator> Utilizator { get; set; }

        public DbSet<PerfumesShop.Pages.Models.Vandut> Vandut { get; set; }
    }
}
