using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Tipuri
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
            return Page();
        }

        [BindProperty]
        public Tip Tip { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Tip.Add(Tip);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
