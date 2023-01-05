using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Parfumuri
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public EditModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Parfum Parfum { get; set; } = default!;

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
            Parfum = parfum;
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Categ");
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "Type");
            ViewData["ConcentratieID"] = new SelectList(_context.Set<Concentratie>(), "ID", "Conctr");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Parfum).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ParfumExists(Parfum.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ParfumExists(int id)
        {
            return _context.Parfum.Any(e => e.ID == id);
        }
    }
}