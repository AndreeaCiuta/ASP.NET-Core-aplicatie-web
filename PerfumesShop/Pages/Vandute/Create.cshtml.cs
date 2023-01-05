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
    public class CreateModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public CreateModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var parfumList = _context.Parfum
                  .Include(b => b.Tip)
                  .Select(x => new { x.ID, Denumire = x.Denumire + " - " + x.Tip.Type + " " +x.Categorie.Categ});


        ViewData["ParfumID"] = new SelectList(parfumList, "ID", "Denumire");
        ViewData["UtilizatorID"] = new SelectList(_context.Utilizator, "ID", "NCompl");
            return Page();
        }

        [BindProperty]
        public Vandut Vandut { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vandut.Add(Vandut);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
