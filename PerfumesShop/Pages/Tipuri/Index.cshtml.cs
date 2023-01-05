using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Tipuri
{
    public class IndexModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public IndexModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IList<Tip> Tip { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tip != null)
            {
                Tip = await _context.Tip.ToListAsync();
            }
        }
    }
}
