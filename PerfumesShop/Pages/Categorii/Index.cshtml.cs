using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;
using PerfumesShop.Pages.Models.ViewModels;

namespace PerfumesShop.Pages.Categorii
{
    public class IndexModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public IndexModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IList<Categorie> Categorie { get; set; } = default!;


        public CategorieIndexData CategorieData { get; set; }
        public int CategorieID { get; set; }
        public int ParfumID { get; set; }
        public async Task OnGetAsync(int? id, int? parfumID)
        {
            CategorieData = new CategorieIndexData();
            CategorieData.Categorii = await _context.Categorie
            .Include(i => i.Parfumuri)
            .ThenInclude(c => c.Tip)
            .OrderBy(i => i.Categ)
            .ToListAsync();
            if (id != null)
            {
                CategorieID = id.Value;
                Categorie categorie = CategorieData.Categorii
                .Where(i => i.ID == id.Value).Single();
                CategorieData.Parfumuri = categorie.Parfumuri;
            }



        }
    }
}
