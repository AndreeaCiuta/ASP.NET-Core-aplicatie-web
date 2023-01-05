using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Parfumuri
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DeleteModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Parfum == null)
            {
                return NotFound();
            }
            var parfum = await _context.Parfum.FindAsync(id);

            if (parfum != null)
            {
                Parfum = parfum;
                _context.Parfum.Remove(Parfum);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
