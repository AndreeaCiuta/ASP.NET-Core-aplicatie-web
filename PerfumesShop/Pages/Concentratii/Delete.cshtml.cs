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
    public class DeleteModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DeleteModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Concentratie Concentratie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Concentratie == null)
            {
                return NotFound();
            }

            var concentratie = await _context.Concentratie.FirstOrDefaultAsync(m => m.ID == id);

            if (concentratie == null)
            {
                return NotFound();
            }
            else 
            {
                Concentratie = concentratie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Concentratie == null)
            {
                return NotFound();
            }
            var concentratie = await _context.Concentratie.FindAsync(id);

            if (concentratie != null)
            {
                Concentratie = concentratie;
                _context.Concentratie.Remove(Concentratie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
