using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Parfumuri
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public CreateModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "Categ");
            ViewData["TipID"] = new SelectList(_context.Set<Tip>(), "ID", "Type");
            ViewData["ConcentratieID"] = new SelectList(_context.Set<Concentratie>(), "ID", "Conctr");

            return Page();
        }

        [BindProperty]
        public Parfum Parfum { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {

            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Parfum.Add(Parfum);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}