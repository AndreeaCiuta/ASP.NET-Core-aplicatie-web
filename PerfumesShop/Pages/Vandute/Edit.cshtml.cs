using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Vandute
{
    public class EditModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public EditModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vandut Vandut { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vandut == null)
            {
                return NotFound();
            }

            var vandut =  await _context.Vandut.FirstOrDefaultAsync(m => m.ID == id);
            if (vandut == null)
            {
                return NotFound();
            }
            Vandut = vandut;
           ViewData["ParfumID"] = new SelectList(_context.Parfum, "ID", "ID");
           ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "ID");
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

            _context.Attach(Vandut).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VandutExists(Vandut.ID))
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

        private bool VandutExists(int id)
        {
          return _context.Vandut.Any(e => e.ID == id);
        }
    }
}
