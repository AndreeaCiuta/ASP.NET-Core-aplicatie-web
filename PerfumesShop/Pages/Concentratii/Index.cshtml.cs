using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Concentratii
{
    public class IndexModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public IndexModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IList<Concentratie> Concentratie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Concentratie != null)
            {
                Concentratie = await _context.Concentratie.ToListAsync();
            }
        }
    }
}
