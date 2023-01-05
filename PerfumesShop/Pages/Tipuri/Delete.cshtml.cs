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
    public class DeleteModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DeleteModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tip Tip { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }

            var tip = await _context.Tip.FirstOrDefaultAsync(m => m.ID == id);

            if (tip == null)
            {
                return NotFound();
            }
            else 
            {
                Tip = tip;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tip == null)
            {
                return NotFound();
            }
            var tip = await _context.Tip.FindAsync(id);

            if (tip != null)
            {
                Tip = tip;
                _context.Tip.Remove(Tip);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
