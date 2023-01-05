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
    public class DetailsModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public DetailsModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

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
    }
}
