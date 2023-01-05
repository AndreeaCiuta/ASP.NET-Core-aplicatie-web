using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Vandute
{
    public class DeleteModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DeleteModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vandut Vandut { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vandut == null)
            {
                return NotFound();
            }

            var vandut = await _context.Vandut.FirstOrDefaultAsync(m => m.ID == id);

            if (vandut == null)
            {
                return NotFound();
            }
            else 
            {
                Vandut = vandut;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vandut == null)
            {
                return NotFound();
            }
            var vandut = await _context.Vandut.FindAsync(id);

            if (vandut != null)
            {
                Vandut = vandut;
                _context.Vandut.Remove(Vandut);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
