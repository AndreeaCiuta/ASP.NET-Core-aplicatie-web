using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Security.Policy;
using System.Xml.Linq;

namespace PerfumesShop.Pages.Models
{
    public class Parfum
    {
        public int ID { get; set; }
        [Display(Name = "Denumirea parfumului")]
        public string Denumire { get; set; }
        public string Gen { get; set; }
        [Display(Name = "Pret (lei)")]
        [Column(TypeName = "decimal(6, 2)")]
        [Range(0.01, 500)]
        public decimal Pret { get; set; }
        [Display(Name = "Cantitate (ml)")]
        public decimal Cantitate { get; set; }
        [Display(Name = "Ton Varf")]
        public string TVarf { get; set; }
        [Display(Name = "Ton Mijloc")]
        public string TMijloc { get; set; }
        [Display(Name = "Ton Baza")]
        public string TBaza { get; set; }

        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; } //navigation property

        public int? TipID { get; set; }
        public Tip? Tip { get; set; }

        public int? ConcentratieID { get; set; }
        public Concentratie? Concentratie { get; set; }



    }
}