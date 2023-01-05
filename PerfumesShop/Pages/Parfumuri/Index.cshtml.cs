using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PerfumesShop.Data;
using PerfumesShop.Pages.Models;

namespace PerfumesShop.Pages.Parfumuri
{
    public class IndexModel : PageModel
    {
        private readonly PerfumesShop.Data.PerfumesShopContext _context;

        public IndexModel(PerfumesShop.Data.PerfumesShopContext context)
        {
            _context = context;
        }

        public IList<Parfum> Parfum { get; set; } = default!;

        public ParfumData ParfumD { get; set; }
        public int ParfumID { get; set; }
        public int TipID { get; set; }

        public string DenumireSort { get; set; }
        public string TipSort { get; set; }
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? tipID, string sortOrder, string searchString)
        {
            ParfumD = new ParfumData();

            DenumireSort = String.IsNullOrEmpty(sortOrder) ? "denumire_desc" : "";
            TipSort = String.IsNullOrEmpty(sortOrder) ? "tip_desc" : "";

            CurrentFilter = searchString;

            ParfumD.Parfumuri = await _context.Parfum
                    .Include(b => b.Categorie)
                    .Include(b => b.Tip)
                    .Include(b => b.Concentratie)
                    .AsNoTracking()
                    .OrderBy(b => b.Denumire)
                    .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                ParfumD.Parfumuri = ParfumD.Parfumuri.Where(s => s.Tip.Type.Contains(searchString)

               || s.Tip.Type.Contains(searchString)
               || s.Denumire.Contains(searchString));
            }



            if (id != null)
            {
                ParfumID = id.Value;
                Parfum parfum = ParfumD.Parfumuri
                .Where(i => i.ID == id.Value).Single();
                /* ParfumD.Tipuri = parfum.TipuriParfum.Select(s =>
                s.Category);*/
            }
            switch (sortOrder)
            {
                case "denumire_desc":
                    ParfumD.Parfumuri = ParfumD.Parfumuri.OrderByDescending(s =>
                   s.Denumire);
                    break;
                case "tip_desc":
                    ParfumD.Parfumuri = ParfumD.Parfumuri.OrderByDescending(s =>
                   s.Tip.Type);
                    break;
            }
        }
    }
}