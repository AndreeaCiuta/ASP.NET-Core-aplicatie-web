using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Parfumuri
{
    public class DetailsModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DetailsModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

      public Parfum Parfum { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Parfum == null)
            {
                return NotFound();
            }

            var parfum = await _context.Parfum.FirstOrDefaultAsync(m => m.ID == id);
            if (parfum == null)
            {
                return NotFound();
            }
            else 
            {
                Parfum = parfum;
            }
            return Page();
        }
    }
}
